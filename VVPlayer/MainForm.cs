using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GLibrary;
using ObjParser;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace VVPlayer
{
    public partial class MainForm : Form
    {
        #region Ctor

        public MainForm()
        {
            InitializeComponent();

            // Define Open GLParameters
            _IsGLControlLoaded = false;
            _IsAnimationRunning = false;

            _TextureDataType = eTextureDataType.BMP;
            _TextureExtension = eTextureExtension.JPG;

            _CurrentDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            SetDefaultViewParameters();

            PrepareUI();
            PrepareThreads();
            Rec2Form();


            this.FormClosing += MainForm_FormClosing;

            SubscribeToEvents();
        }


        #endregion

        #region Public Fields

        #endregion

        #region Private Fields

        // UI Related Fields
        private bool _IsAnimationRunning;
        private bool _IsGLControlLoaded;
        private bool _IsGLControlClicked;
        private Point _InitialPoint;
        private Thread _AutoRotate;
        private Thread _PlayVVideo;

        // View Related Fields
        private double _DirXRotation;
        private double _DirYRotation;
        private double _DirZRotation;
        private double _LookAtDist;
        private float _AverageX;
        private float _AverageY;
        private float _AverageZ;

        // OBJ Related Fields
        private List<Obj> _ObjFiles;
        private List<TextureData> _TextureData;
        private Obj _SelectedObjFile;
        private TextureData _SelectedTextureData;

        private int _TextID;
        private eTextureDataType _TextureDataType;
        private eTextureExtension _TextureExtension;

        private string _CurrentDirectory;

        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void SetSelectedObj(int index)
        {
            _SelectedObjFile = _ObjFiles[index];

            if (_TextureData!= null && _TextureData.Count > index)
            {
                _SelectedTextureData = _TextureData[index];
            }
        }

        private void DrawSelectedObjFile()
        {
            // Clear Buffers
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.ClearColor(SystemColors.Control);


            // Basic Setup for Viewing
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView((float)1.04, 4 / 3, 1, 10000); // Setup Perspective
            Matrix4 lookAt = Matrix4.LookAt((float)_LookAtDist, 1, 0, 0, 0, 0, 0, 1, 0); //Setup Camera
            GL.MatrixMode(MatrixMode.Projection); // Load Perspective
            GL.LoadIdentity();
            GL.LoadMatrix(ref perspective);
            GL.MatrixMode(MatrixMode.Modelview); // Load Camera
            GL.LoadIdentity();
            GL.LoadMatrix(ref lookAt);
            GL.Viewport(0, 0, glControlMain.Width, glControlMain.Height); // Size of the Control
            GL.Enable(EnableCap.DepthTest); // Enable Correct Z Drawings
            GL.DepthFunc(DepthFunction.Less); // Enable Correct Z Drawings

            // Rotating
            GL.Rotate(_DirXRotation, 0, 0, 1);
            GL.Rotate(_DirYRotation, 0, 1, 0);
            GL.Rotate(_DirZRotation, 1, 0, 0);

            GL.Translate(-_AverageX, -_AverageY, -_AverageZ);


            if (_SelectedTextureData != null && (_SelectedTextureData.Bmp != null || _SelectedTextureData.Data != null))
            {

                // Texture Info
                GL.Enable(EnableCap.Texture2D);

                GL.DeleteTexture(_TextID);

                if (_TextureDataType == eTextureDataType.Float)
                {
                    _TextID = InitTextures();
                }
                else if (_TextureDataType == eTextureDataType.BMP)
                {
                    _TextID = InitTexturesWithBitmapData();
                }

                if (_SelectedObjFile.FaceList.First().VertexIndexList.Count() == 3)
                {
                    GL.Begin(BeginMode.Triangles);

                }
                else if (_SelectedObjFile.FaceList.First().VertexIndexList.Count() == 4)
                {
                    GL.Begin(BeginMode.Quads);

                }
                else
                {
                    GL.Begin(BeginMode.Points);
                }

                GL.Color3(Color.White);

                for (int i = 0; i < _SelectedObjFile.FaceList.Count; i++)
                {
                    var face = _SelectedObjFile.FaceList[i];

                    for (int j = 0; j < face.VertexIndexList.Count(); j++)
                    {
                        double textCoord1 = _SelectedObjFile.TextureList[face.TextureVertexIndexList[j] - 1].X;
                        double textCoord2 = 1 - _SelectedObjFile.TextureList[face.TextureVertexIndexList[j] - 1].Y;
                        GL.TexCoord2(textCoord1, textCoord2);

                        GL.Vertex3(_SelectedObjFile.VertexList[face.VertexIndexList[j] - 1].X,
                                   _SelectedObjFile.VertexList[face.VertexIndexList[j] - 1].Y,
                                   _SelectedObjFile.VertexList[face.VertexIndexList[j] - 1].Z);
                    }
                }
            }
            else if (_SelectedObjFile != null)
            {
                if (_SelectedObjFile.FaceList.First().VertexIndexList.Count() == 3)
                {
                    GL.Begin(BeginMode.Triangles);

                }
                else if (_SelectedObjFile.FaceList.First().VertexIndexList.Count() == 4)
                {
                    GL.Begin(BeginMode.Quads);

                }
                else
                {
                    GL.Begin(BeginMode.Points);
                }

                for (int i = 0; i < _SelectedObjFile.FaceList.Count; i++)
                {
                    var face = _SelectedObjFile.FaceList[i];

                    for (int j = 0; j < face.VertexIndexList.Count(); j++)
                    {
                        GL.Color3(Color.DarkGray);
                        GL.Vertex3(_SelectedObjFile.VertexList[face.VertexIndexList[j] - 1].X,
                                   _SelectedObjFile.VertexList[face.VertexIndexList[j] - 1].Y,
                                   _SelectedObjFile.VertexList[face.VertexIndexList[j] - 1].Z);
                    }
                }

            }

            GL.End();

            //Finally
            glControlMain.SwapBuffers();
        }

        private int InitTextures()
        {
            int texture;
            GL.CreateTextures(TextureTarget.Texture2D, 1, out texture);
            GL.TextureStorage2D(
                texture,
                1,                           // levels of mipmapping
                SizedInternalFormat.Rgba32f, // format of texture
                _SelectedTextureData.Width,
                _SelectedTextureData.Height);

            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.TextureSubImage2D(texture,
                0,                  // this is level 0
                0,                  // x offset
                0,                  // y offset
                _SelectedTextureData.Width,
                _SelectedTextureData.Height,
                OpenTK.Graphics.OpenGL.PixelFormat.Rgba,
                PixelType.Float,
                _SelectedTextureData.Data);
            return texture;
            // data not needed from here on, OpenGL has the data
        }

        private int InitTexturesWithBitmapData()
        {
            int texture;

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);

            BitmapData data = _SelectedTextureData.Bmp.LockBits(new System.Drawing.Rectangle(0, 0, _SelectedTextureData.Bmp.Width, _SelectedTextureData.Bmp.Height),
                ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, data.Width, data.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, data.Scan0);
            _SelectedTextureData.Bmp.UnlockBits(data);


            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapS, (int)TextureWrapMode.Repeat);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureWrapT, (int)TextureWrapMode.Repeat);

            return texture;
        }

        private void SetDefaultViewParameters()
        {
            if (_SelectedObjFile != null)
            {
                List<double> maxDistList = new List<double>() { _SelectedObjFile.Size.XSize, _SelectedObjFile.Size.YSize, _SelectedObjFile.Size.ZSize };
                _LookAtDist = maxDistList.Max() * 1.1;
                //_LookAtDist = 100;
                _DirXRotation = 0;
                _DirYRotation = 0;

                _AverageX = (float)_SelectedObjFile.VertexList.Average((x) => x.X);
                _AverageY = (float)_SelectedObjFile.VertexList.Average((x) => x.Y);
                _AverageZ = (float)_SelectedObjFile.VertexList.Average((x) => x.Z);
            }
        }

        private void PrepareThreads()
        {
            PrepareAutoRotateThread();
            PreparePlayVVThread();

            if (chkAutoRotate.Checked)
            {
                _AutoRotate.Start();
            }
        }

        private void PreparePlayVVThread()
        {
            _PlayVVideo = new Thread(() =>
            {
                while (true)
                {
                    if (_IsGLControlLoaded && !_IsGLControlClicked)
                    {
                        Thread.Sleep(75);
                        int selectedIndex = _ObjFiles.IndexOf(_SelectedObjFile);
                        int nextIndex;
                        if (selectedIndex == _ObjFiles.Count - 1)
                        {
                            nextIndex = 0;
                        }
                        else
                        {
                            nextIndex = selectedIndex + 1;
                        }

                        SetSelectedObj(nextIndex);

                        this.trackBarAnimation.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            trackBarAnimation.Value = nextIndex;
                        });

                        // Update Average X, Y and Z Values
                        _AverageX = (float)_SelectedObjFile.VertexList.Average((x) => x.X);
                        _AverageY = (float)_SelectedObjFile.VertexList.Average((x) => x.Y);
                        _AverageZ = (float)_SelectedObjFile.VertexList.Average((x) => x.Z);

                        glControlMain.Invalidate();
                    }
                }
            });
        }

        private void PrepareAutoRotateThread()
        {
            _AutoRotate = new Thread(() =>
            {
                while (true)
                {
                    if (_IsGLControlLoaded && !_IsGLControlClicked)
                    {
                        Thread.Sleep(10);
                        double AutoRotateSpeed;

                        if (rbARLowSpeed.Checked)
                        {
                            AutoRotateSpeed = 0.5;
                        }
                        else if (rbARMediumSpeed.Checked)
                        {
                            AutoRotateSpeed = 1;
                        }
                        else
                        {
                            AutoRotateSpeed = 2;
                        }

                        _DirYRotation += AutoRotateSpeed;

                        if (_DirYRotation >= 360)
                        {
                            _DirYRotation = _DirYRotation - 360;
                        }


                        this.nUDXRotation.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            nUDXRotation.Value = Convert.ToDecimal(_DirXRotation);
                        });

                        this.nUDYRotation.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            nUDYRotation.Value = Convert.ToDecimal(_DirYRotation);
                        });


                        this.nUDZRotation.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            nUDZRotation.Value = Convert.ToDecimal(_DirZRotation);
                        });

                        glControlMain.Invalidate();
                    }
                }
            });
        }

        private void Rec2Form()
        {
            nUDXRotation.Value = (decimal)_DirXRotation;
            nUDYRotation.Value = (decimal)_DirYRotation;
            nUDZRotation.Value = (decimal)_DirZRotation;

            cmbTextureMethod.SelectedIndex = (int)_TextureDataType;
            cmbTextureExtension.SelectedIndex = (int)_TextureExtension;

        }

        private void Form2Rec()
        {

        }

        private void PrepareUI()
        {
            cmbTextureMethod.Items.Clear();
            cmbTextureMethod.Items.Add("Bmp");
            cmbTextureMethod.Items.Add("Float");

            cmbTextureExtension.Items.Clear();
            cmbTextureExtension.Items.Add("Bmp");
            cmbTextureExtension.Items.Add("Jpg");
            cmbTextureExtension.Items.Add("Png");

            // Set Defaults
            chkAutoRotate.Checked = false;
            nUDXRotation.Enabled = true;
            nUDYRotation.Enabled = true;
            nUDZRotation.Enabled = true;

            chkInvertMouseWheel.Checked = false;
            rbMediumSensitivityWheel.Checked = true;
            rbMediumSensitivity.Checked = true;
            rbARMediumSpeed.Checked = true;

            // Set Max and Min Values of the NumericalUpDown
            nUDXRotation.Minimum = -decimal.MaxValue;
            nUDYRotation.Minimum = -decimal.MaxValue;
            nUDZRotation.Minimum = -decimal.MaxValue;

            nUDXRotation.Maximum = decimal.MaxValue;
            nUDYRotation.Maximum = decimal.MaxValue;
            nUDZRotation.Maximum = decimal.MaxValue;

            trackBarAnimation.Enabled = false;
            if (_ObjFiles != null)
            {
                trackBarAnimation.Minimum = 0;
                trackBarAnimation.Maximum = _ObjFiles.Count() - 1;
                trackBarAnimation.Value = 0;
            }

            btnStartStopAnimation.Text = "Start Animation";
        }

        private void SubscribeToEvents()
        {
            glControlMain.Load += GlControlMain_Load;
            glControlMain.Paint += GlControlMain_Paint;
            nUDXRotation.ValueChanged += NUD_ValueChanged;
            nUDYRotation.ValueChanged += NUD_ValueChanged;
            nUDZRotation.ValueChanged += NUD_ValueChanged;
            glControlMain.MouseDown += GlControlMain_MouseDown;
            glControlMain.MouseUp += GlControlMain_MouseUp;
            glControlMain.MouseMove += GlControlMain_MouseMove;
            glControlMain.MouseWheel += GlControlMain_MouseWheel;
            btnResetView.Click += BtnResetView_Click;
            chkAutoRotate.CheckedChanged += ChkAutoRotate_CheckedChanged;
            btnStartStopAnimation.Click += BtnStartStopAnimation_Click;
            trackBarAnimation.ValueChanged += TrackBarAnimation_ValueChanged;
            btnLoadVV.Click += BtnLoadVV_Click;
            cmbTextureExtension.SelectedIndexChanged += CmbTextureExtension_SelectedIndexChanged;
            cmbTextureMethod.SelectedIndexChanged += CmbTextureMethod_SelectedIndexChanged;
        }

        private void UnsubscribeFromEvents()
        {
            glControlMain.Load -= GlControlMain_Load;
            glControlMain.Paint -= GlControlMain_Paint;
            nUDXRotation.ValueChanged -= NUD_ValueChanged;
            nUDYRotation.ValueChanged -= NUD_ValueChanged;
            nUDZRotation.ValueChanged -= NUD_ValueChanged;
            glControlMain.MouseDown -= GlControlMain_MouseDown;
            glControlMain.MouseUp -= GlControlMain_MouseUp;
            glControlMain.MouseMove -= GlControlMain_MouseMove;
            glControlMain.MouseWheel -= GlControlMain_MouseWheel;
            btnResetView.Click -= BtnResetView_Click;
            chkAutoRotate.CheckedChanged -= ChkAutoRotate_CheckedChanged;
            btnStartStopAnimation.Click -= BtnStartStopAnimation_Click;
            trackBarAnimation.ValueChanged -= TrackBarAnimation_ValueChanged;
            btnLoadVV.Click -= BtnLoadVV_Click;
            cmbTextureExtension.SelectedIndexChanged -= CmbTextureExtension_SelectedIndexChanged;
            cmbTextureMethod.SelectedIndexChanged -= CmbTextureMethod_SelectedIndexChanged;
        }

        #endregion

        #region Events

        private void CmbTextureMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            _TextureDataType = (eTextureDataType)cmbTextureMethod.SelectedIndex;
        }

        private void CmbTextureExtension_SelectedIndexChanged(object sender, EventArgs e)
        {
            _TextureExtension = (eTextureExtension)cmbTextureExtension.SelectedIndex;
        }

        private void BtnLoadVV_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            ofd.Multiselect = true;
            ofd.Filter = "obj files (*.obj)|*.obj|All files (*.*)|*.*";
            ofd.InitialDirectory = _CurrentDirectory;

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                _CurrentDirectory = Path.GetDirectoryName(ofd.FileName);

                _ObjFiles = new List<Obj>();
                _TextureData = new List<TextureData>();
                for (int i = 0; i < ofd.FileNames.Count(); i++)
                {
                    string path = ofd.FileNames[i];

                    Obj obj1 = new Obj();
                    string[] lines = File.ReadAllLines(path);
                    obj1.LoadObj(lines);
                    _ObjFiles.Add(obj1);

                    string texturePath = path.Substring(0, path.Length - 4);

                    if (_TextureExtension == eTextureExtension.BMP)
                    {
                        texturePath = texturePath + ".bmp";
                    }
                    else if (_TextureExtension == eTextureExtension.JPG)
                    {
                        texturePath = texturePath + ".jpg";
                    }
                    else if (_TextureExtension == eTextureExtension.PNG)
                    {
                        texturePath = texturePath + ".png";
                    }



                    if (File.Exists(texturePath))
                    {
                        _TextureData.Add(new TextureData(texturePath, _TextureDataType));
                    }
                }

                trackBarAnimation.Enabled = true;

                trackBarAnimation.Minimum = 0;
                trackBarAnimation.Maximum = _ObjFiles.Count() - 1;
                trackBarAnimation.Value = 0;
                SetSelectedObj(0);

                SetDefaultViewParameters();

                DrawSelectedObjFile();

                glControlMain.Invalidate();
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _AutoRotate.Abort();
            _PlayVVideo.Abort();

        }

        private void ChkAutoRotate_CheckedChanged(object sender, EventArgs e)
        {
            nUDXRotation.Enabled = !chkAutoRotate.Checked;
            nUDYRotation.Enabled = !chkAutoRotate.Checked;
            nUDZRotation.Enabled = !chkAutoRotate.Checked;

            if (chkAutoRotate.Checked)
            {
                PrepareAutoRotateThread();
                _AutoRotate.Start();
            }
            else
            {
                _AutoRotate.Abort();
                Rec2Form();
                glControlMain.Invalidate();
            }
        }

        private void BtnResetView_Click(object sender, EventArgs e)
        {
            UnsubscribeFromEvents();
            _AutoRotate.Abort();
            SetDefaultViewParameters();
            Rec2Form();
            glControlMain.Invalidate();
            SubscribeToEvents();
        }

        private void GlControlMain_Load(object sender, EventArgs e)
        {
            _IsGLControlLoaded = true;

            // Clear Buffers
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);
            GL.ClearColor(SystemColors.Control);
        }

        private void NUD_ValueChanged(object sender, EventArgs e)
        {
            _DirXRotation = Convert.ToDouble(nUDXRotation.Value);
            _DirYRotation = Convert.ToDouble(nUDYRotation.Value);
            _DirZRotation = Convert.ToDouble(nUDZRotation.Value);
            glControlMain.Invalidate();
        }

        private void GlControlMain_MouseMove(object sender, MouseEventArgs e)
        {
            if (_IsGLControlClicked)
            {
                UnsubscribeFromEvents();

                Point newPt = e.Location;

                double dir = -1;

                if (chkInvertMouse.Checked)
                {
                    dir = 1;
                }

                double sensitivity = 1;

                if (rbLowSensitivity.Checked)
                {
                    sensitivity = 100;
                }
                else if (rbMediumSensitivity.Checked)
                {
                    sensitivity = 50;
                }
                else
                {
                    sensitivity = 10;
                }


                _DirXRotation += -dir * Convert.ToDouble(_InitialPoint.Y - newPt.Y) / sensitivity;
                _DirYRotation += dir * Convert.ToDouble(_InitialPoint.X - newPt.X) / sensitivity;

                Rec2Form();
                glControlMain.Invalidate();
                SubscribeToEvents();
            }
        }

        private void GlControlMain_MouseDown(object sender, MouseEventArgs e)
        {
            _InitialPoint = e.Location;
            //if (!chkAutoRotate.Checked)
            //{
            _IsGLControlClicked = true;
            //}
        }

        private void GlControlMain_MouseUp(object sender, MouseEventArgs e)
        {
            _IsGLControlClicked = false;
        }

        private void GlControlMain_MouseWheel(object sender, MouseEventArgs e)
        {
            double dir = -1;

            if (chkInvertMouseWheel.Checked)
            {
                dir = 1;
            }

            double sensitivity;

            if (rbLowSensitivityWheel.Checked)
            {
                sensitivity = 0.05;
            }
            else if (rbMediumSensitivityWheel.Checked)
            {
                sensitivity = 0.2;
            }
            else
            {
                sensitivity = 0.5;
            }

            _LookAtDist += dir * Math.Sign(e.Delta) * _LookAtDist * sensitivity;

            if (_LookAtDist < 0)
            {
                _LookAtDist = 0;
            }

            glControlMain.Invalidate();
        }

        private void GlControlMain_Paint(object sender, PaintEventArgs e)
        {
            if (_IsGLControlLoaded)
            {
                //DrawPyramid();
                DrawSelectedObjFile();
            }
        }

        private void BtnStartStopAnimation_Click(object sender, EventArgs e)
        {
            if (!_IsAnimationRunning)
            {
                _IsAnimationRunning = true;
                PreparePlayVVThread();
                _PlayVVideo.Start();
                btnStartStopAnimation.Text = "Stop Animation";
            }
            else
            {
                _IsAnimationRunning = false;
                _PlayVVideo.Abort();
                btnStartStopAnimation.Text = "Start Animation";
            }

        }

        private void TrackBarAnimation_ValueChanged(object sender, EventArgs e)
        {
            SetSelectedObj(trackBarAnimation.Value);

            // Update Average X, Y and Z Values
            _AverageX = (float)_SelectedObjFile.VertexList.Average((x) => x.X);
            _AverageY = (float)_SelectedObjFile.VertexList.Average((x) => x.Y);
            _AverageZ = (float)_SelectedObjFile.VertexList.Average((x) => x.Z);

            glControlMain.Invalidate();
        }

        #endregion

    }

}
