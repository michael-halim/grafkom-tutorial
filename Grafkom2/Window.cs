using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.GraphicsLibraryFramework;
namespace Grafkom2
{
    static class Constants
    {
        public const string SHADER_PATH = "../../../Shaders/";
    }

    internal class Window : GameWindow
    {
        Asset2d[] _object = new Asset2d[4];
        int time = 0;
        float degree = 0;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {


            base.OnLoad();
            //// ganti background
            GL.ClearColor(0.0f, 0.0f, 0.2f, 1.0f);
            //_object3d[0] = new Asset3d();
            //_object3d[0].createBoxVertices();
            //_object3d[0].load(Constants.SHADER_PATH + "shader.vert",Constants.SHADER_PATH + "shader.frag");

            //lingkaran
            _object[0] = new Asset2d();
            _object[0].createCircle(0.0f,0.0f,0.3f,0.3f);
            _object[0].load(Constants.SHADER_PATH + "shader.vert", Constants.SHADER_PATH + "shader.frag");

            //jam
            _object[1] = new Asset2d(
               new float[] {
                    0.0f, 0.0f, 0.0f,
                    -0.1f, 0.1f, 0.0f,
                    0.0f, 0.0f, 0.0f,
               },


               new uint[] { }
           );

            _object[1].load(Constants.SHADER_PATH + "jam.vert", Constants.SHADER_PATH + "jam.frag");

            //menit
            _object[2] = new Asset2d(
               new float[] {
                    0.0f, 0.0f, 0.0f,
                    0.22f, 0.0f, 0.0f,
                    0.0f, 0.0f, 0.0f,
               },


               new uint[] { }
           );

            _object[2].load(Constants.SHADER_PATH + "menit.vert", Constants.SHADER_PATH + "menit.frag");

            //detik
            _object[3] = new Asset2d(
              new float[] {
                 0.0f   , 0.0f  , 0.0f,
                 0.0f  + (0.27f * (float)Math.Cos(degree)) , 0.0f + (0.27f * (float)Math.Sin(degree)) , 0.0f,
                 0.0f   , 0.0f  , 0.0f,
              },


              new uint[] { });
            _object[3].load(Constants.SHADER_PATH + "detik.vert", Constants.SHADER_PATH + "detik.frag");

        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);
            _object[0].render(3);
            _object[1].render(3);
            _object[2].render(3);
            _object[3].render(3);

            if (time % 60 == 0){
                OnLoad();               
                degree -= 0.167f;
            }

            time++;
            SwapBuffers();
        }

        protected override void OnResize(ResizeEventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(0, 0, Size.X, Size.Y);
        }

        protected override void OnUpdateFrame(FrameEventArgs args)
        {
            base.OnUpdateFrame(args);
            if (KeyboardState.IsKeyDown(Keys.Escape))
            {
                Close();
            }
            if (KeyboardState.IsKeyPressed(Keys.A))
            {
                Console.Write("Hello");
            }
        }

        protected override void OnMouseDown(MouseButtonEventArgs e)
        {
            base.OnMouseDown(e);
            if (e.Button == MouseButton.Left)
            {
                float _x = (MousePosition.X - Size.X / 2) / (Size.X / 2);
                float _y = -(MousePosition.Y - Size.Y / 2) / (Size.Y / 2);

                Console.WriteLine("x = " + _x + " , " + "y = " + _y);
        
            }
        }
    }

}
