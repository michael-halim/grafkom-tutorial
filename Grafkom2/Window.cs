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
        Asset2d[] _object = new Asset2d[5];
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {
            base.OnLoad();
            // ganti background
            GL.ClearColor(2.0f, 0.3f, 0.4f, 1.0f);

            _object[0] = new Asset2d(
                new float[]
                {
                    0.0f, 0.0f, 0.0f,
                    0.5f, 0.0f, 0.0f,
                    0.25f, 0.5f, 0.0f
                },
                new uint[] { }
            );
            _object[0].load(Constants.SHADER_PATH + "shader.vert", Constants.SHADER_PATH + "shader.frag");

            _object[1] = new Asset2d(
                new float[]
                {
                    0.25f, -0.2f, 0.0f,
                    0.75f, -0.2f, 0.0f,
                    0.5f, 0.3f, 0.0f
                },
                new uint[] { }
            );
            _object[1].load(Constants.SHADER_PATH + "segitiga2.vert", Constants.SHADER_PATH + "segitiga2.frag");

            _object[2] = new Asset2d(new float[] { }, new uint[] { });
            _object[2].createCircle(0.0f, -0.5f, 0.25f, 0.3f);
            _object[2].load(Constants.SHADER_PATH + "segitiga2.vert", Constants.SHADER_PATH + "segitiga2.frag");

            _object[3] = new Asset2d();
            _object[3].load(Constants.SHADER_PATH + "segitiga2.vert", Constants.SHADER_PATH + "segitiga2.frag");

            _object[4] = new Asset2d();
            _object[4].load(Constants.SHADER_PATH + "segitiga2.vert", Constants.SHADER_PATH + "segitiga2.frag");
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _object[0].render(0);
            _object[1].render(0);
            _object[2].render(1);
            _object[3].render(2);
            if (_object[4].getVerticesLength())
            {
                List<float> _verticesTemp = _object[4].CreateCurveBezier();
                _object[4].setVertices(_verticesTemp.ToArray());
                _object[4].load(Constants.SHADER_PATH + "segitiga2.vert", Constants.SHADER_PATH + "segitiga2.frag");
                _object[4].render(2);
            }

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
                _object[3].updateMousePosition(_x, _y, 0);
            }
        }
    }

}
