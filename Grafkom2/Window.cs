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

    internal class Window : GameWindow
    {
        //float[] _vertices =
        //{
        //    -0.2f,-0.2f,0.0f,
        //    0.2f,-0.2f,0.0f,
        //    0.0f,0.2f,0.0f
        //};
        float[] _vertices =
        {
            0.2f,0.2f,0.0f, // top right
            0.2f,-0.2f,0.0f, // bottom right
            -0.2f,-0.2f,0.0f, // bottom left
            -0.2f,0.2f,0.0f, // top left

            0.5f,-0.2f,0.0f,
            0.7f,-0.2f,0.0f,
            0.6f,0.2f,0.0f

        };

        uint[] _indices = {
            0,1,3, // segitiga pertama
            1,2,3, // segitiga kedua
            4,5,6
            //0,2,3,
            //0,1,2,

        };
        int _elementBufferObject;



        int _vertexBufferObject;
        int _vertexArrayObject;
        Shader _shader;

        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {

        }

        protected override void OnLoad()
        {
            base.OnLoad();

            GL.ClearColor(0.0f, 1.0f, 1.0f, 1.0f);

            _vertexBufferObject = GL.GenBuffer();

            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);

            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);

            _vertexArrayObject = GL.GenVertexArray();

            GL.BindVertexArray(_vertexArrayObject);

            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);

            GL.EnableVertexAttribArray(0);

            _elementBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);

            GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

            _shader = new Shader("D:/Program/Visual Studio/Semester 6 (C# Grafkom)/Grafkom2/Grafkom2/Shaders/shader.vert",
                "D:/Program/Visual Studio/Semester 6 (C# Grafkom)/Grafkom2/Grafkom2/Shaders/shader.frag");

            _shader.Use();

        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);

            GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);

            //GL.DrawArrays(PrimitiveType.Triangles, 0, 3);

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
