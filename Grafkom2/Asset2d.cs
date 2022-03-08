using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafkom2
{
    internal class Asset2d
    {
        float[] _vertices =
        {

        };
        int _elementBufferObject;
        int _vertexBufferObject;
        int _vertexArrayObject;
        Shader _shader;

        uint[] _indices = {

        };

        public Asset2d(float[] vertices, uint[] indices)
        {
            _vertices = vertices;
            _indices = indices;
        }

        public void load(string shaderVert, string shaderFrag)
        {
            //Buffer
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Length * sizeof(float), _vertices, BufferUsageHint.StaticDraw);


            //VAO
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            // Kalo mau bikin object settingannya beda dikasih if
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float, false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            //jika ada data yang disimpan di _indices
            if (_indices.Length != 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Length * sizeof(uint), _indices, BufferUsageHint.StaticDraw);

            }
            //D:/ Program / Visual Studio / Semester 6(C# Grafkom)/Grafkom2/Grafkom2/Shaders/shader.vert",
            //       "D:/Program/Visual Studio/Semester 6 (C# Grafkom)/Grafkom2/Grafkom2/Shaders/shader.frag

            _shader = new Shader(shaderVert, shaderFrag);

            _shader.Use();
        }
        public void render()
        {
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);

            if (_indices.Length != 0)
            {
                GL.DrawElements(PrimitiveType.Triangles, _indices.Length, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
            }
        }
    }
}
