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


        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.0f, 0.239f, 0.7529f, 1.0f);

            //warna kuning
            _object[0] = new Asset2d(
                new float[] {
                    0.0f, 0.5f, 0.0f,
                    -0.25f, 0.0f, 0.0f,
                    0.25f, 0.0f, 0.0f,
                },


                new uint[] { }
            );

            _object[0].load(Constants.SHADER_PATH + "shader.vert", Constants.SHADER_PATH + "shader.frag");

            //warna merah
            _object[1] = new Asset2d(
                new float[] {
                    0.0f, 0.25f, 0.0f,
                    -0.25f, -0.25f, 0.0f,
                    0.25f,-0.25f, 0.0f,
                },
                new uint[] { }
            );
            _object[1].load(Constants.SHADER_PATH + "segitiga2.vert", Constants.SHADER_PATH + "segitiga2.frag");



            _object[2] = new Asset2d(
                new float[] {
                     0.0f, 0.0f, 0.0f,
                    -0.25f, -0.5f, 0.0f,
                    0.25f,-0.5f, 0.0f,
                },
                new uint[] { }
            );
            _object[2].load(Constants.SHADER_PATH + "segitiga3.vert", Constants.SHADER_PATH + "segitiga3.frag");

            _object[3] = new Asset2d(
                new float[] {
                     -0.1f, -0.5f, 0.0f,
                    0.1f, -0.5f, 0.0f,
                    -0.1f,-0.8f, 0.0f,
                    0.1f,-0.8f, 0.0f,
                },
                new uint[] { 
                    0,1,3,
                    0,2,3
                    
                }
            );
            _object[3].load(Constants.SHADER_PATH + "kotak.vert", Constants.SHADER_PATH + "kotak.frag");
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _object[3].render();
            _object[2].render();
            _object[1].render();
            _object[0].render();

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
        }
    }

}
