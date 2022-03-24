using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Windowing.Common;
using OpenTK.Windowing.Desktop;
using System;
using System.Collections.Generic;
using System.Text;
using OpenTK.Windowing.GraphicsLibraryFramework;
using OpenTK.Mathematics;

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

        float degree = 0;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {


            base.OnLoad();
            //// ganti background
            GL.ClearColor(0.0f, 0.0f, 0.2f, 1.0f);
            _object3d[0] = new Asset3d();
            _object3d[0].createBoxVertices(0.0f, 0.0f, 0.0f, 0.5f);
            _object3d[0].addChild(0.7f, 0.7f, 0.3f, 0.1f);

            _object3d[0].load(Constants.SHADER_PATH + "shader.vert", Constants.SHADER_PATH + "shader.frag", Size.X, Size.Y);

            //_object3d[0] = new Asset3d();
            //_object3d[0].createEllipsoid2(1.0f, 0.5f, 0.2f, 0.0f, 0.0f, 0.0f,3,2);
            //_object3d[0].load(Constants.SHADER_PATH + "shader.vert", Constants.SHADER_PATH + "shader.frag", Size.x, Size.y);



        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            //
            Matrix4 temp = Matrix4.Identity;
            //temp = temp * Matrix4.CreateRotationX(degree % 360);
            //temp = temp * Matrix4.CreateTranslation();

            //temp = temp * Matrix4.CreateRotationY(degree % 360);
            //temp = temp * Matrix4.CreateRotationZ(degree % 360);

            _object3d[0].render(3,temp);

            _object3d[0].rotate(_object3d[0]._centerPosition,_object3d[0]._euler[0],degree % 2);
            _object3d[0].rotate(_object3d[0]._centerPosition,_object3d[0]._euler[1],degree % 2);
            _object3d[0].rotate(_object3d[0]._centerPosition,_object3d[0]._euler[2],degree % 2);
            degree += 0.5f;
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
