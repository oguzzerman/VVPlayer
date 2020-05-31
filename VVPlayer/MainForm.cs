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

            //_PlayVVideo.Start();
            btnStartStopAnimation.Text = "Start Animation";
            _IsAnimationRunning = false;
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
        private double _VerticalRotation;
        private double _HorizontalRotation;
        private double _LookAtDist;
        private float _AverageX;
        private float _AverageY;
        private float _AverageZ;

        // OBJ Related Fields
        private List<Obj> _ObjFiles;
        private List<BitmapData> _TextureData;
        private List<float[]> _TextureDataFloat;
        private List<Mtl> _MtlData;
        private Obj _SelectedObjFile;
        private BitmapData _SelectedTextureData;
        private float[] _SelectedTextureDataFloat;
        private Mtl _SelectedMtlData;

        private int _TextID;
        #endregion

        #region Public Methods

        #endregion

        #region Private Methods

        #region GL Related

        private void LoadObjFile()
        {
            _ObjFiles = new List<Obj>();
            _TextureData = new List<BitmapData>();
            _MtlData = new List<Mtl>();
            _TextureDataFloat = new List<float[]>();

            Obj obj1 = new Obj();
            string[] lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00001_textured.obj");
            obj1.LoadObj(lines);

            _ObjFiles.Add(obj1);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00001_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00001_textured.jpg"));


            Obj obj2 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00002_textured.obj");
            obj2.LoadObj(lines);
            _ObjFiles.Add(obj2);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00002_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00002_textured.jpg"));

            Obj obj3 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00003_textured.obj");
            obj3.LoadObj(lines);
            _ObjFiles.Add(obj3);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00003_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00003_textured.jpg"));

            Obj obj4 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00004_textured.obj");
            obj4.LoadObj(lines);
            _ObjFiles.Add(obj4);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00004_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00004_textured.jpg"));

            Obj obj5 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00005_textured.obj");
            obj5.LoadObj(lines);
            _ObjFiles.Add(obj5);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00005_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00005_textured.jpg"));

            Obj obj6 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00006_textured.obj");
            obj6.LoadObj(lines);
            _ObjFiles.Add(obj6);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00006_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00006_textured.jpg"));

            Obj obj7 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00007_textured.obj");
            obj7.LoadObj(lines);
            _ObjFiles.Add(obj7);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00007_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00007_textured.jpg"));

            Obj obj8 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00008_textured.obj");
            obj8.LoadObj(lines);
            _ObjFiles.Add(obj8);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00008_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00008_textured.jpg"));

            Obj obj9 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00009_textured.obj");
            obj9.LoadObj(lines);
            _ObjFiles.Add(obj9);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00009_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00009_textured.jpg"));

            Obj obj10 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00010_textured.obj");
            obj10.LoadObj(lines);
            _ObjFiles.Add(obj10);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00010_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00010_textured.jpg"));

            Obj obj11 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00011_textured.obj");
            obj11.LoadObj(lines);
            _ObjFiles.Add(obj11);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00011_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00011_textured.jpg"));

            Obj obj12 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00012_textured.obj");
            obj12.LoadObj(lines);
            _ObjFiles.Add(obj12);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00012_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00012_textured.jpg"));

            Obj obj13 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00013_textured.obj");
            obj13.LoadObj(lines);
            _ObjFiles.Add(obj13);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00013_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00013_textured.jpg"));

            Obj obj14 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00014_textured.obj");
            obj14.LoadObj(lines);
            _ObjFiles.Add(obj14);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00014_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00014_textured.jpg"));

            Obj obj15 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00015_textured.obj");
            obj15.LoadObj(lines);
            _ObjFiles.Add(obj15);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00015_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00015_textured.jpg"));

            Obj obj16 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00016_textured.obj");
            obj16.LoadObj(lines);
            _ObjFiles.Add(obj16);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00016_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00016_textured.jpg"));

            Obj obj17 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00017_textured.obj");
            obj17.LoadObj(lines);
            _ObjFiles.Add(obj17);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00017_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00017_textured.jpg"));

            Obj obj18 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00018_textured.obj");
            obj18.LoadObj(lines);
            _ObjFiles.Add(obj18);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00018_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00018_textured.jpg"));

            Obj obj19 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00019_textured.obj");
            obj19.LoadObj(lines);
            _ObjFiles.Add(obj19);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00019_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00019_textured.jpg"));

            Obj obj20 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00020_textured.obj");
            obj20.LoadObj(lines);
            _ObjFiles.Add(obj20);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00020_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00020_textured.jpg"));

            Obj obj21 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00021_textured.obj");
            obj21.LoadObj(lines);
            _ObjFiles.Add(obj21);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00021_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00021_textured.jpg"));

            Obj obj22 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00022_textured.obj");
            obj22.LoadObj(lines);
            _ObjFiles.Add(obj22);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00022_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00022_textured.jpg"));

            Obj obj23 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00023_textured.obj");
            obj23.LoadObj(lines);
            _ObjFiles.Add(obj23);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00023_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00023_textured.jpg"));

            Obj obj24 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00024_textured.obj");
            obj24.LoadObj(lines);
            _ObjFiles.Add(obj24);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00024_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00024_textured.jpg"));

            Obj obj25 = new Obj();
            lines = File.ReadAllLines("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00025_textured.obj");
            obj25.LoadObj(lines);
            _ObjFiles.Add(obj25);
            _TextureData.Add(LoadImage("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00025_textured.jpg"));
            _TextureDataFloat.Add(LoadTexture("D:\\Develop\\Source\\GL\\matis_hd_obj\\Frame_00025_textured.jpg"));

            SetSelectedObj(0);


            //Bitmap bmp = new Bitmap("C:\\Users\\oguzz\\Desktop\\GL\\texture.png");
            //Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
            // _SelectedTextureData = bmp.LockBits(rect,System.Drawing.Imaging.ImageLockMode.ReadOnly,System.Drawing.Imaging.PixelFormat.Format24bppRgb);
            //bmp.UnlockBits(_SelectedTextureData);

            _AverageX = (float)_SelectedObjFile.VertexList.Average((x) => x.X);
            _AverageY = (float)_SelectedObjFile.VertexList.Average((x) => x.Y);
            _AverageZ = (float)_SelectedObjFile.VertexList.Average((x) => x.Z);
        }

        private void SetSelectedObj(int index)
        {
            _SelectedTextureDataFloat = _TextureDataFloat[index];
            _SelectedObjFile = _ObjFiles[index];
            _SelectedTextureData = _TextureData[index];
            //_SelectedMtlData = _MtlData[index];
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
            GL.Rotate(_VerticalRotation, 0, 0, 1);
            GL.Rotate(_HorizontalRotation, 0, 1, 0);

            GL.Translate(-_AverageX, -_AverageY, -_AverageZ);

            // Texture Info
            GL.Enable(EnableCap.Texture2D);

            if (_SelectedTextureDataFloat != null)
            {

                GL.DeleteTexture(_TextID);

                _TextID = InitTextures(_SelectedTextureDataFloat);
                //BindTexture(_TextID);

                GL.Begin(BeginMode.Triangles);

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
                GL.Begin(BeginMode.Triangles);

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

        private void UpdateGL()
        {

        }

        public virtual void BindTexture(int VertexArray)
        {
            GL.BindVertexArray(VertexArray);
            GL.BindTexture(TextureTarget.Texture2D, _TextID);
        }

        private int InitTexturesAlt1(float[] data)
        {
            int texture;
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.Texture2D);

            GL.Hint(HintTarget.PerspectiveCorrectionHint, HintMode.Nicest);

            GL.GenTextures(1, out texture);
            GL.BindTexture(TextureTarget.Texture2D, texture);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMinFilter, (int)TextureMinFilter.Linear);
            GL.TexParameter(TextureTarget.Texture2D, TextureParameterName.TextureMagFilter, (int)TextureMagFilter.Linear);


            GL.TexImage2D(TextureTarget.Texture2D, 0, PixelInternalFormat.Rgba, _SelectedTextureData.Width, _SelectedTextureData.Height, 0,
                OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, _SelectedTextureData.Scan0);

            return texture;
            // data not needed from here on, OpenGL has the data
        }

        private int InitTextures(float[] data)
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
                data);
            return texture;
            // data not needed from here on, OpenGL has the data
        }
        private float[] LoadTexture(string fileName)
        {
            float[] r;
            using (var bmp = ConvertToBitmap(fileName))
            {
                int width = bmp.Width;
                int height = bmp.Height;
                r = new float[width * height * 4];
                int index = 0;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        var pixel = bmp.GetPixel(x, y);
                        r[index++] = pixel.R / 255f;
                        r[index++] = pixel.G / 255f;
                        r[index++] = pixel.B / 255f;
                        r[index++] = pixel.A / 255f;
                    }
                }
            }
            return r;
        }

        BitmapData LoadImage(string path)
        {
            Bitmap bmp = new Bitmap(ConvertToBitmap(path));
            Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);

            BitmapData ret = bmp.LockBits(rect, ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            bmp.UnlockBits(ret);

            return ret;
        }

        public Bitmap ConvertToBitmap(string fileName)
        {
            Bitmap bitmap;
            using (Stream bmpStream = System.IO.File.Open(fileName, System.IO.FileMode.Open))
            {
                Image image = Image.FromStream(bmpStream);

                bitmap = new Bitmap(image);

            }
            return bitmap;
        }

        private void SetDefaultViewParameters()
        {
            if (_SelectedObjFile != null)
            {
                List<double> maxDistList = new List<double>() { _SelectedObjFile.Size.XSize, _SelectedObjFile.Size.YSize, _SelectedObjFile.Size.ZSize };
                _LookAtDist = maxDistList.Max() * 1.1;
                //_LookAtDist = 100;
                _VerticalRotation = 0;
                _HorizontalRotation = 0;

                _AverageX = (float)_SelectedObjFile.VertexList.Average((x) => x.X);
                _AverageY = (float)_SelectedObjFile.VertexList.Average((x) => x.Y);
                _AverageZ = (float)_SelectedObjFile.VertexList.Average((x) => x.Z);
            }
        }

        #endregion
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
                        Thread.Sleep(65);
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

                        _HorizontalRotation += AutoRotateSpeed;

                        if (_HorizontalRotation >= 360)
                        {
                            _HorizontalRotation = _HorizontalRotation - 360;
                        }

                        this.nUDHorizontal.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            nUDHorizontal.Value = Convert.ToDecimal(_HorizontalRotation);
                        });


                        this.nUDVertical.Invoke((MethodInvoker)delegate {
                            // Running on the UI thread
                            nUDVertical.Value = Convert.ToDecimal(_VerticalRotation);
                        });


                        glControlMain.Invalidate();
                    }
                }
            });
        }

        private void Rec2Form()
        {
            nUDHorizontal.Value = (decimal)_HorizontalRotation;
            nUDVertical.Value = (decimal)_VerticalRotation;

        }

        private void Form2Rec()
        {

        }

        private void PrepareUI()
        {
            // Set Defaults
            chkAutoRotate.Checked = false;
            nUDHorizontal.Enabled = true;
            nUDVertical.Enabled = true;

            chkInvertMouseWheel.Checked = false;
            rbMediumSensitivityWheel.Checked = true;
            rbMediumSensitivity.Checked = true;
            rbARMediumSpeed.Checked = true;

            // Set Max and Min Values of the NumericalUpDown
            nUDHorizontal.Minimum = -decimal.MaxValue;
            nUDVertical.Minimum = -decimal.MaxValue;

            nUDHorizontal.Maximum = decimal.MaxValue;
            nUDVertical.Maximum = decimal.MaxValue;

            trackBarAnimation.Minimum = 0;
            trackBarAnimation.Maximum = _ObjFiles.Count() - 1;
            trackBarAnimation.Value = 0;
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
            btnStartStopAnimation.Click += BtnStartStopAnimation_Click;
            trackBarAnimation.ValueChanged += TrackBarAnimation_ValueChanged;
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
            btnStartStopAnimation.Click -= BtnStartStopAnimation_Click;
            trackBarAnimation.ValueChanged -= TrackBarAnimation_ValueChanged;
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
            _VerticalRotation = Convert.ToDouble(nUDVertical.Value);
            _HorizontalRotation = Convert.ToDouble(nUDHorizontal.Value);
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
