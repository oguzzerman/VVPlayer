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

            LoadObjFile();

            SetDefaultViewParameters();

            PrepareUI();
            PrepareThreads();
            Rec2Form();

            if (chkAutoRotate.Checked)
            {
                _AutoRotate.Start();
            }
            _PlayVVideo.Start();

            SubscribeToEvents();
        }


        #endregion

        #region Public Fields

        #endregion

        #region Private Fields

        private bool _IsGLControlLoaded;
        private bool _IsGLControlClicked;
        private double _VerticalRotation;
        private double _HorizontalRotation;
        private Point _InitialPoint;
        private double _LookAtDist;
        private Thread _AutoRotate;
        private Thread _PlayVVideo;
        private List<Obj> _SelectedObjFiles;
        private Obj _SelectedObjFile;
        private BitmapData _SelectedTextureData;
        private float _AverageX;
        private float _AverageY;
        private float _AverageZ;
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        private void LoadObjFile()
        {
            _SelectedObjFiles = new List<Obj>();

            Obj obj1 = new Obj();
            string[] lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00001_textured.obj");
            obj1.LoadObj(lines);
            _SelectedObjFiles.Add(obj1);

            Obj obj2 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00002_textured.obj");
            obj2.LoadObj(lines);
            _SelectedObjFiles.Add(obj2);

            Obj obj3 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00003_textured.obj");
            obj3.LoadObj(lines);
            _SelectedObjFiles.Add(obj3);

            Obj obj4 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00004_textured.obj");
            obj4.LoadObj(lines);
            _SelectedObjFiles.Add(obj4);

            Obj obj5 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00005_textured.obj");
            obj5.LoadObj(lines);
            _SelectedObjFiles.Add(obj5);

            Obj obj6 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00006_textured.obj");
            obj6.LoadObj(lines);
            _SelectedObjFiles.Add(obj6);

            Obj obj7 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00007_textured.obj");
            obj7.LoadObj(lines);
            _SelectedObjFiles.Add(obj7);

            Obj obj8 = new Obj();
           lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00008_textured.obj");
            obj8.LoadObj(lines);
            _SelectedObjFiles.Add(obj8);

            Obj obj9 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00009_textured.obj");
            obj9.LoadObj(lines);
            _SelectedObjFiles.Add(obj9);

            Obj obj10 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00010_textured.obj");
            obj10.LoadObj(lines);
            _SelectedObjFiles.Add(obj10);

            Obj obj11 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00011_textured.obj");
            obj11.LoadObj(lines);
            _SelectedObjFiles.Add(obj11);

            Obj obj12 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00012_textured.obj");
            obj12.LoadObj(lines);
            _SelectedObjFiles.Add(obj12);

            Obj obj13 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00013_textured.obj");
            obj13.LoadObj(lines);
            _SelectedObjFiles.Add(obj13);

            Obj obj14 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00014_textured.obj");
            obj14.LoadObj(lines);
            _SelectedObjFiles.Add(obj14);

            Obj obj15 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00015_textured.obj");
            obj15.LoadObj(lines);
            _SelectedObjFiles.Add(obj15);

            Obj obj16 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00016_textured.obj");
            obj16.LoadObj(lines);
            _SelectedObjFiles.Add(obj16);

            Obj obj17 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00017_textured.obj");
            obj17.LoadObj(lines);
            _SelectedObjFiles.Add(obj17);

            Obj obj18 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00018_textured.obj");
            obj18.LoadObj(lines);
            _SelectedObjFiles.Add(obj18);

            Obj obj19 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00019_textured.obj");
            obj19.LoadObj(lines);
            _SelectedObjFiles.Add(obj19);
                    
            Obj obj20 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00020_textured.obj");
            obj20.LoadObj(lines);
            _SelectedObjFiles.Add(obj20);

            Obj obj21 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00021_textured.obj");
            obj21.LoadObj(lines);
            _SelectedObjFiles.Add(obj21);

            Obj obj22 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00022_textured.obj");
            obj22.LoadObj(lines);
            _SelectedObjFiles.Add(obj22);

            Obj obj23 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00023_textured.obj");
            obj23.LoadObj(lines);
            _SelectedObjFiles.Add(obj23);

            Obj obj24 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00024_textured.obj");
            obj24.LoadObj(lines);
            _SelectedObjFiles.Add(obj24);

            Obj obj25 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00025_textured.obj");
            obj25.LoadObj(lines);
            _SelectedObjFiles.Add(obj25);

            _SelectedObjFile = _SelectedObjFiles.First();

            //Bitmap bmp = new Bitmap("C:\\Users\\oguzz\\Desktop\\GL\\texture.png");
            //Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            // _SelectedTextureData = bmp.LockBits(rect,System.Drawing.Imaging.ImageLockMode.ReadOnly,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //bmp.UnlockBits(_SelectedTextureData);

            _AverageX = (float)_SelectedObjFile.VertexList.Average((x) => x.X);
            _AverageY = (float)_SelectedObjFile.VertexList.Average((x) => x.Y);
            _AverageZ = (float)_SelectedObjFile.VertexList.Average((x) => x.Z);
        }

        private void PrepareThreads()
        {
            PrepareAutoRotateThread();
            PreparePlayVVThread();

        }

        private void PreparePlayVVThread()
        {
            _PlayVVideo = new Thread(() =>
            {
                while (true)
                {
                    if (_IsGLControlLoaded && !_IsGLControlClicked)
                    {
                        Thread.Sleep(36);
                        int selectedIndex = _SelectedObjFiles.IndexOf(_SelectedObjFile);
                        int nextIndex;
                        if (selectedIndex == _SelectedObjFiles.Count - 1)
                        {
                            nextIndex = 0;
                        }
                        else
                        {
                            nextIndex = selectedIndex + 1;
                        }

                        _SelectedObjFile = _SelectedObjFiles[nextIndex];

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

                        _HorizontalRotation += AutoRotateSpeed;

                        if (_HorizontalRotation >= 360)
                        {
                            _HorizontalRotation = _HorizontalRotation - 360;
                        }

                        glControlMain.Invalidate();
                    }
                }
            });
        }

        private void SetDefaultViewParameters()
        {
            List<double> maxDistList = new List<double>() { _SelectedObjFile.Size.XSize, _SelectedObjFile.Size.YSize, _SelectedObjFile.Size.ZSize };
            _LookAtDist = maxDistList.Max() * 1.1;
            //_LookAtDist = 100;
            _VerticalRotation = 0;
            _HorizontalRotation = 0;

        }

        private void DrawPyramid()
        {

            // Clear Buffers
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

            // Basic Setup for Viewing
            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView((float)1.04, 4 / 3, 1, 10000); // Setup Perspective
            Matrix4 lookAt = Matrix4.LookAt((float)_LookAtDist, 20, 0, 0, 0, 0, 0, 1, 0); //Setup Camera
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
            GL.Rotate(_VerticalRotation, 0, 0, 1);
            GL.Rotate(_HorizontalRotation, 0, 1, 0);

            // Draw Pyramid, Y is up, Z is twards you, X is Left and Right
            // Vertex goes(x,y,z)
            GL.Begin(BeginMode.Triangles);

            // Face 1
            GL.Color3(Color.Red);
            GL.Vertex3(50, 0, 0);
            GL.Color3(Color.White);
            GL.Vertex3(0, 25, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 50);

            // Face 2
            GL.Color3(Color.Green);
            GL.Vertex3(-50, 0, 0);
            GL.Color3(Color.White);
            GL.Vertex3(0, 25, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, 50);

            // Face 3
            GL.Color3(Color.Red);
            GL.Vertex3(50, 0, 0);
            GL.Color3(Color.White);
            GL.Vertex3(0, 25, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, -50);

            // Face 4
            GL.Color3(Color.Green);
            GL.Vertex3(-50, 0, 0);
            GL.Color3(Color.White);
            GL.Vertex3(0, 25, 0);
            GL.Color3(Color.Blue);
            GL.Vertex3(0, 0, -50);

            // Finish the Begin Mode with End
            GL.End();

            //Finally
            glControlMain.SwapBuffers();
        }

        private void DrawSelectedObjFile()
        {
            // Clear Buffers
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Clear(ClearBufferMask.DepthBufferBit);

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

            //GL.Translate(-avgX, -avgY, -avgZ);
            // Rotating
            GL.Rotate(_VerticalRotation, 0, 0, 1);
            GL.Rotate(_HorizontalRotation, 0, 1, 0);

            GL.Translate(-_AverageX, -_AverageY, -_AverageZ);

            // Texture Info
            //GL.Enable(EnableCap.Texture2D);
            //int texture;
            //GL.GenTextures(1, out texture);
            //GL.BindTexture(TextureTarget.Texture2D, texture);
            //GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgb, _SelectedTextureData.Width, _SelectedTextureData.Height,
            //              0, OpenTK.Graphics.OpenGL.PixelFormat.Bgr, PixelType.UnsignedByte, _SelectedTextureData.Scan0);
            //GL.GenerateMipmap(GenerateMipmapTarget.Texture2D);
            GL.Begin(BeginMode.Points);

            
            for (int i = 0; i < _SelectedObjFile.VertexList.Count; i++)
            {
                GL.Color3(Color.White);
                GL.Vertex3(_SelectedObjFile.VertexList[i].X, _SelectedObjFile.VertexList[i].Y, _SelectedObjFile.VertexList[i].Z);

            }

            //for (int i = 0; i < _SelectedObjFile.FaceList.Count; i++)
            //{
            //    for (int j = 0; j < _SelectedObjFile.FaceList[i].VertexIndexList.Count(); j++)
            //    {

            //        ObjParser.Types.Vertex v = _SelectedObjFile.VertexList[_SelectedObjFile.FaceList[i].VertexIndexList[j] - 1];
            //        GL.Vertex3(v.X, v.Y, v.Z);
            //    }
            //}

            //// Face 1
            //GL.Color3(Color.Red);
            //GL.Vertex3(50, 0, 0);
            //GL.Color3(Color.White);
            //GL.Vertex3(0, 25, 0);
            //GL.Color3(Color.Blue);
            //GL.Vertex3(0, 0, 50);

            //// Face 2
            //GL.Color3(Color.Green);
            //GL.Vertex3(-50, 0, 0);
            //GL.Color3(Color.White);
            //GL.Vertex3(0, 25, 0);
            //GL.Color3(Color.Blue);
            //GL.Vertex3(0, 0, 50);

            //// Face 3
            //GL.Color3(Color.Red);
            //GL.Vertex3(50, 0, 0);
            //GL.Color3(Color.White);
            //GL.Vertex3(0, 25, 0);
            //GL.Color3(Color.Blue);
            //GL.Vertex3(0, 0, -50);

            //// Face 4
            //GL.Color3(Color.Green);
            //GL.Vertex3(-50, 0, 0);
            //GL.Color3(Color.White);
            //GL.Vertex3(0, 25, 0);
            //GL.Color3(Color.Blue);
            //GL.Vertex3(0, 0, -50);

            // Finish the Begin Mode with End
            GL.End();

            //Finally
            glControlMain.SwapBuffers();
        }

        private void Rec2Form()
        {
            nUDHorizontal.Value = (decimal)_VerticalRotation;
            nUDVertical.Value = (decimal)_HorizontalRotation;

        }

        private void Form2Rec()
        {

        }

        private void PrepareUI()
        {
            // Set Defaults
            chkAutoRotate.Checked = true;
            nUDHorizontal.Enabled = false;
            nUDVertical.Enabled = false;

            chkInvertMouseWheel.Checked = false;
            rbMediumSensitivityWheel.Checked = true;
            rbMediumSensitivity.Checked = true;
            rbARMediumSpeed.Checked = true;

            // Set Max and Min Values of the NumericalUpDown
            nUDHorizontal.Minimum = -decimal.MaxValue;
            nUDVertical.Minimum = -decimal.MaxValue;

            nUDHorizontal.Maximum = decimal.MaxValue;
            nUDVertical.Maximum = decimal.MaxValue;
        }

        private void SubscribeToEvents()
        {
            glControlMain.Load += GlControlMain_Load;
            glControlMain.Paint += GlControlMain_Paint;
            nUDHorizontal.ValueChanged += NUD_ValueChanged;
            nUDVertical.ValueChanged += NUD_ValueChanged;
            glControlMain.MouseDown += GlControlMain_MouseDown;
            glControlMain.MouseUp += GlControlMain_MouseUp;
            glControlMain.MouseMove += GlControlMain_MouseMove;
            glControlMain.MouseWheel += GlControlMain_MouseWheel;
            btnResetView.Click += BtnResetView_Click;
            chkAutoRotate.CheckedChanged += ChkAutoRotate_CheckedChanged;
            this.FormClosing += MainForm_FormClosing;
        }

        private void UnsubscribeFromEvents()
        {
            glControlMain.Load -= GlControlMain_Load;
            glControlMain.Paint -= GlControlMain_Paint;
            nUDHorizontal.ValueChanged -= NUD_ValueChanged;
            nUDVertical.ValueChanged -= NUD_ValueChanged;
            glControlMain.MouseDown -= GlControlMain_MouseDown;
            glControlMain.MouseUp -= GlControlMain_MouseUp;
            glControlMain.MouseMove -= GlControlMain_MouseMove;
            glControlMain.MouseWheel -= GlControlMain_MouseWheel;
            btnResetView.Click -= BtnResetView_Click;
            chkAutoRotate.CheckedChanged -= ChkAutoRotate_CheckedChanged;
            this.FormClosing -= MainForm_FormClosing;
        }

        #endregion

        #region Events

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            _AutoRotate.Abort();
            _PlayVVideo.Abort();

        }

        private void ChkAutoRotate_CheckedChanged(object sender, EventArgs e)
        {
            nUDHorizontal.Enabled = !chkAutoRotate.Checked;
            nUDVertical.Enabled = !chkAutoRotate.Checked;

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
        }

        private void NUD_ValueChanged(object sender, EventArgs e)
        {
            _VerticalRotation = Convert.ToDouble(nUDHorizontal.Value);
            _HorizontalRotation = Convert.ToDouble(nUDVertical.Value);
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


                _VerticalRotation += -dir * Convert.ToDouble(_InitialPoint.Y - newPt.Y) / sensitivity;
                _HorizontalRotation += dir * Convert.ToDouble(_InitialPoint.X - newPt.X) / sensitivity;
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
                sensitivity = 50;
            }
            else if (rbMediumSensitivityWheel.Checked)
            {
                sensitivity = 10;
            }
            else
            {
                sensitivity = 1;
            }

            _LookAtDist += dir * e.Delta / sensitivity;

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

        #endregion

    }

}
