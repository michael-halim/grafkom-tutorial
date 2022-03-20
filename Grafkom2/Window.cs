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

        Asset3d[] _object3d = new Asset3d[4];
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {


            base.OnLoad();
            //// ganti background
            GL.ClearColor(0.0f, 0.0f, 0.2f, 1.0f);
            //_object3d[0] = new Asset3d();
            //_object3d[0].createBoxVertices(0.0f,0.0f,0.0f,0.5f);
            //_object3d[0].load(Constants.SHADER_PATH + "shader.vert", Constants.SHADER_PATH + "shader.frag");

            //_object3d[0] = new Asset3d();
            //_object3d[0].createEllipsoid2(1.0f, 0.5f, 0.2f, 0.0f, 0.0f, 0.0f,3,2);
            //_object3d[0].load(Constants.SHADER_PATH + "shader.vert", Constants.SHADER_PATH + "shader.frag");



        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _object3d[0].render(3);
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
