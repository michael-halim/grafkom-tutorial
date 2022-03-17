using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafkom2
{
    internal class Asset3d
    {
        // segitiga

        List<Vector3> _vertices = new List<Vector3>();
        List<uint> _indices = new List<uint>();

        int _vertexBufferObject;
        int _vertexArrayObject;
        int _elementBufferObject;
        Shader _shader;
        int indexs;
        int[] _pascal = { };

        public Asset3d(List<Vector3> vertices, List<uint> indices)
        {
            _vertices = vertices;
            _indices = indices;
        }
        public Asset3d()
        {
            _vertices = new List<Vector3>();
        }
        public void load(string shadervert, string shaderfrag)
        {
            // Buffer
            _vertexBufferObject = GL.GenBuffer();
            GL.BindBuffer(BufferTarget.ArrayBuffer, _vertexBufferObject);
            GL.BufferData(BufferTarget.ArrayBuffer, _vertices.Count
                * Vector3.SizeInBytes, _vertices.ToArray(), BufferUsageHint.StaticDraw);

            // VAO
            _vertexArrayObject = GL.GenVertexArray();
            GL.BindVertexArray(_vertexArrayObject);
            // kalau mau bikin object settingan beda, dikasih if
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Float,
                false, 3 * sizeof(float), 0);
            GL.EnableVertexAttribArray(0);

            // ada data yang disimpan di indices
            if (_indices.Count != 0)
            {
                _elementBufferObject = GL.GenBuffer();
                GL.BindBuffer(BufferTarget.ElementArrayBuffer, _elementBufferObject);
                GL.BufferData(BufferTarget.ElementArrayBuffer, _indices.Count
                    * sizeof(uint), _indices.ToArray(), BufferUsageHint.StaticDraw);
            }

            _shader = new Shader(shadervert, shaderfrag);
            _shader.Use();
        }


        public void render(int _lines)
        {
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            if (_indices.Count != 0)
            {
                GL.DrawElements(PrimitiveType.Triangles, _indices.Count, DrawElementsType.UnsignedInt, 0);
            }
            else
            {
                if (_lines == 0)
                {
                    GL.DrawArrays(PrimitiveType.Triangles, 0, _vertices.Count);
                }
                else if (_lines == 1)
                {
                    GL.DrawArrays(PrimitiveType.TriangleFan, 0, (_vertices.Count + 1) / 3);
                }
                else if (_lines == 2)
                {

                }
                else if (_lines == 3)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, (_vertices.Count + 1) / 3);
                }
            }
        }

        public void createBoxVertices(float x, float y, float z, float length)
        {
            Vector3 temp_vector;

            //TITIK 1
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            _vertices.Add(temp_vector);

            //TITIK 2
            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            _vertices.Add(temp_vector);


            //TITIK 3
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            _vertices.Add(temp_vector);

            //TITIK 4
            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z - length / 2.0f;
            _vertices.Add(temp_vector);

            //TITIK 5
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            _vertices.Add(temp_vector);

            //TITIK 6
            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y + length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            _vertices.Add(temp_vector);

            //TITIK 7
            temp_vector.X = x - length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            _vertices.Add(temp_vector);

            //TITIK 8
            temp_vector.X = x + length / 2.0f;
            temp_vector.Y = y - length / 2.0f;
            temp_vector.Z = z + length / 2.0f;
            _vertices.Add(temp_vector);

            _indices = new List<uint> {
                //SEGITIGA DEPAN 1
                0, 1, 2,

                //SEGITIGA DEPAN 2
                1, 2, 3,

                //SEGITIGA ATAS 1
                0, 4, 5,

                //SEGITIGA ATAS 2
                0, 1, 5,

                //SEGITIGA KANAN 1
                1, 3, 5,

                //SEGITIGA KANAN 2
                3, 5, 7,

                // SEGITIGA KIRI 1
                0, 2, 4,

                // SEGITIGA KIRI 2
                2, 4, 6,

                // SEGITIGA BELAKANG 1
                4, 5, 6,

                // SEGITIGA BELAKANG 2
                5, 6, 7,

                // SEGITIGA BAWAH 1
                2, 3, 6,

                // SEGITIGA BAWAH 2
                3, 6, 7,

            };


            ////FRONT FACE
            ////SEGITIGA FRONT 1
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            ////SEGITIGA FRONT 2
            //_vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));

            ////BACK FACE
            ////SEGITIGA BACK 1
            //_vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            ////SEGITIGA BACK 2
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));

            ////LEFT FACE
            ////SEGITIGA LEFT 1
            //_vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            ////SEGITIGA LEFT 2
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));

            ////RIGHT FACE
            ////SEGITIGA RIGHT 1
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            ////SEGITIGA LEFT 2
            //_vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));

            ////BOTTOM FACE
            ////SEGITIGA BOTTOM 1
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            ////SEGITIGA BOTTOM 2
            //_vertices.Add(new Vector3(0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, -0.5f, -0.5f));

            ////FRONT FACE
            ////SEGITIGA BOTTOM 1
            //_vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, -0.5f));
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            ////SEGITIGA BOTTOM 2
            //_vertices.Add(new Vector3(0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, 0.5f));
            //_vertices.Add(new Vector3(-0.5f, 0.5f, -0.5f));
        }

        public void createEllipsoid(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            for (float u = -pi;  u <= pi/u ; u += pi/300)
            {
                for (float v = -pi/2 ; v <= pi/u ; v+= pi/300)
                {
                    temp_vector.X = _x + (float)Math.Cos(v) + (float)Math.Cos(u) * radiusX;
                    temp_vector.Y = _y + (float)Math.Cos(v) + (float)Math.Sin(u) * radiusY;
                    temp_vector.Z = _z + (float)Math.Sin(v) * radiusZ;
                    _vertices.Add(temp_vector);

                }
            }
        }
        public void createEllipsoid2(float radiusX, float radiusY, float radiusZ, float _x, float _y, float _z, int sectorCount, int stackCount)
        {
            float pi = (float)Math.PI;
            Vector3 temp_vector;
            float sectorStep = 2 * (float)Math.PI / sectorCount;
            float stackStep = (float)Math.PI / stackCount;
            float sectorAngle, StackAngle, x, y, z;

            for (int i = 0; i <= stackCount; ++i)
            {
                StackAngle = pi / 2 - i * stackStep;
                x = radiusX * (float)Math.Cos(StackAngle);
                y = radiusY * (float)Math.Cos(StackAngle);
                z = radiusZ * (float)Math.Sin(StackAngle);

                for (int j = 0; j <= sectorCount; ++j)
                {
                    sectorAngle = j * sectorStep;

                    temp_vector.X = x * (float)Math.Cos(sectorAngle);
                    temp_vector.Y = y * (float)Math.Sin(sectorAngle);
                    temp_vector.Z = z;
                    _vertices.Add(temp_vector);
                }
            }

            uint k1, k2;
            for (int i = 0; i < stackCount; ++i)
            {
                k1 = (uint)(i * (sectorCount + 1));
                k2 = (uint)(k1 + sectorCount + 1);
                for (int j = 0; j < sectorCount; ++j, ++k1, ++k2)
                {
                    if (i != 0)
                    {
                        _indices.Add(k1);
                        _indices.Add(k2);
                        _indices.Add(k1 + 1);
                    }
                    if (i != (stackCount - 1))
                    {
                        _indices.Add(k1 + 1);
                        _indices.Add(k2);
                        _indices.Add(k2 + 1);
                    }
                }
            }
        }
    }
}
