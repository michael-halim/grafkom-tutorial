using LearnOpenTK.Common;
using OpenTK.Graphics.OpenGL4;
using OpenTK.Mathematics;
using System;
using System.Collections.Generic;
using System.Text;

namespace Grafkom2
{
    internal class EightSidedBox
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

        Matrix4 _view;
        Matrix4 _projection;
        Matrix4 _model;


        public Vector3 _centerPosition;
        public List<Vector3> _euler;


        public List<EightSidedBox> Child;
        private Vector3 objectCenter;

        public EightSidedBox(List<Vector3> vertices, List<uint> indices)
        {
            _vertices = vertices;
            _indices = indices;
            setDefault();
        }
        public EightSidedBox()
        {
            _vertices = new List<Vector3>();
            setDefault();
        }
        public void load(string shadervert, string shaderfrag, float Size_x, float Size_y)
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

            _view = Matrix4.CreateTranslation(0.0f, 0.0f, -3.0f);
            _projection = Matrix4.CreatePerspectiveFieldOfView(MathHelper.DegreesToRadians(45f), Size_x / (float)Size_y, 0.1f, 100.0f);

            foreach (var item in Child)
            {
                item.load(shadervert, shaderfrag, Size_x, Size_y);
            }

        }

        public void setDefault()
        {


            _model = Matrix4.Identity;
            _euler = new List<Vector3>();

            // sumbu x
            _euler.Add(new Vector3(1, 0, 0));
            // sumbu y
            _euler.Add(new Vector3(0, 1, 0));
            // sumbu z
            _euler.Add(new Vector3(0, 0, 1));

            _centerPosition = new Vector3(0, 0, 0);
            Child = new List<EightSidedBox>();
        }
        public void render(int _lines, Matrix4 temp)
        {
            _shader.Use();
            GL.BindVertexArray(_vertexArrayObject);
            //_model = temp;


            _shader.SetMatrix4("model", _model);
            _shader.SetMatrix4("view", _view);
            _shader.SetMatrix4("projection", _projection);

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
                    GL.DrawArrays(PrimitiveType.TriangleFan, 0, (_vertices.Count));
                }
                else if (_lines == 2)
                {

                }
                else if (_lines == 3)
                {
                    GL.DrawArrays(PrimitiveType.LineStrip, 0, _vertices.Count);
                }
            }
            foreach (var i in Child)
            {
                i.render(_lines, temp);
            }
        }

        public void createBoxVertices(float x, float y, float z, float lengthTop, float lengthBottom)
        {
            _centerPosition.X = x;
            _centerPosition.Y = y;
            _centerPosition.Z = z;

            float offset = lengthTop/2;


            Vector3 temp_vector;

            //Tampilan Depan
            //============================================

            // TITIK 1
            temp_vector.X = x - offset / 2.0f;  // kiri
            temp_vector.Y = y + lengthBottom / 2.0f;  // atas
            temp_vector.Z = z - lengthBottom / 2.0f;  // depan
            _vertices.Add(temp_vector);

            // TITIK 2
            temp_vector.X = x + lengthBottom / 2.0f;
            temp_vector.Y = y - lengthBottom / 2.0f;
            temp_vector.Z = z - lengthBottom / 2.0f;
            _vertices.Add(temp_vector);

            // TITIK 3
            temp_vector.X = x - lengthBottom / 2.0f;
            temp_vector.Y = y - lengthBottom / 2.0f;
            temp_vector.Z = z - lengthBottom / 2.0f;
            _vertices.Add(temp_vector);

            // TITIK 4
            temp_vector.X = x + offset / 2.0f;
            temp_vector.Y = y + lengthBottom / 2.0f;
            temp_vector.Z = z - lengthBottom / 2.0f;
            _vertices.Add(temp_vector);

            //============================================

            //Tampilan samping dari depan
            //============================================
            // TITIK 1
            temp_vector.X = x - offset / 2.0f;  // kiri
            temp_vector.Y = y + lengthBottom / 2.0f;  // atas
            temp_vector.Z = z - lengthBottom / 2.0f;  // depan
            _vertices.Add(temp_vector);

            // TITIK 2
            temp_vector.X = x + lengthBottom / 2.0f;
            temp_vector.Y = y - lengthBottom / 2.0f;
            temp_vector.Z = z - lengthBottom / 2.0f;
            _vertices.Add(temp_vector);

            // TITIK 3
            temp_vector.X = x - lengthBottom / 2.0f;
            temp_vector.Y = y - lengthBottom / 2.0f;
            temp_vector.Z = z - lengthBottom / 2.0f;
            _vertices.Add(temp_vector);

            // TITIK 4
            temp_vector.X = x + offset / 2.0f;
            temp_vector.Y = y + lengthBottom / 2.0f;
            temp_vector.Z = z - lengthBottom / 2.0f;
            _vertices.Add(temp_vector);
            //============================================


            //// Tampilan Belakang
            ////============================================
            //// TITIK 5
            //temp_vector.X = x - offset / 2.0f;  // kiri
            //temp_vector.Y = y + lengthBottom / 2.0f;  // atas
            //temp_vector.Z = z + lengthBottom / 2.0f;  // depan
            //_vertices.Add(temp_vector);

            //// TITIK 2
            //temp_vector.X = x + lengthBottom / 2.0f;
            //temp_vector.Y = y - lengthBottom / 2.0f;
            //temp_vector.Z = z + lengthBottom / 2.0f;
            //_vertices.Add(temp_vector);

            //// TITIK 3
            //temp_vector.X = x - lengthBottom / 2.0f;
            //temp_vector.Y = y - lengthBottom / 2.0f;
            //temp_vector.Z = z + lengthBottom / 2.0f;
            //_vertices.Add(temp_vector);

            //// TITIK 4
            //temp_vector.X = x + offset / 2.0f;
            //temp_vector.Y = y + lengthBottom / 2.0f;
            //temp_vector.Z = z + lengthBottom / 2.0f;
            //_vertices.Add(temp_vector);
            ////============================================

            _indices = new List<uint> {
                 //SEGITIGA DEPAN 1
                0,1,2,
                //SEGITIGA DEPAN 2
                0,1,3,




                ////SEGITIGA BELAKANG 1
                //4,5,6,
                ////SEGITIGA BELAKANG 2
                //4,5,7,

                //SEGITIGA KANAN 1
                //0,3,5,
                ////SEGITIGA KANAN 2
                //3,5,7,
                ////SEGITIGA KIRI 1
                //0,2,4,
                ////SEGITIGA KIRI 2
                //2,4,6,
                ////SEGITIGA BELAKANG 1
                //4,5,6,
                ////SEGITIGA BELAKANG 2
                //5,6,7,
                ////SEGITIGA BAWAH 1
                //2,3,6,
                ////SEGITIGA BAWAH 2
                //3,6,7
            };

        }
        public Vector3 getRotationResult(Vector3 pivot, Vector3 vector, float angle, Vector3 point, bool isEuler = false)
        {
            Vector3 temp, newPosition;

            if (isEuler)
            {
                temp = point;
            }
            else
            {
                temp = point - pivot;
            }

            newPosition.X =
                temp.X * (float)(Math.Cos(angle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(angle))) +
                temp.Y * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) - vector.Z * Math.Sin(angle)) +
                temp.Z * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) + vector.Y * Math.Sin(angle));

            newPosition.Y =
                temp.X * (float)(vector.X * vector.Y * (1.0f - Math.Cos(angle)) + vector.Z * Math.Sin(angle)) +
                temp.Y * (float)(Math.Cos(angle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(angle))) +
                temp.Z * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) - vector.X * Math.Sin(angle));

            newPosition.Z =
                temp.X * (float)(vector.X * vector.Z * (1.0f - Math.Cos(angle)) - vector.Y * Math.Sin(angle)) +
                temp.Y * (float)(vector.Y * vector.Z * (1.0f - Math.Cos(angle)) + vector.X * Math.Sin(angle)) +
                temp.Z * (float)(Math.Cos(angle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(angle)));

            if (isEuler)
            {
                temp = newPosition;
            }
            else
            {
                temp = newPosition + pivot;
            }
            return temp;
        }
        public void rotate(Vector3 pivot, Vector3 vector, float angle)
        {
            var radAngle = MathHelper.DegreesToRadians(angle);

            var arbRotationMatrix = new Matrix4
                (
                new Vector4((float)(Math.Cos(radAngle) + Math.Pow(vector.X, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) + vector.Z * Math.Sin(radAngle)), (float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.Y * Math.Sin(radAngle)), 0),
                new Vector4((float)(vector.X * vector.Y * (1.0f - Math.Cos(radAngle)) - vector.Z * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Y, 2.0f) * (1.0f - Math.Cos(radAngle))), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.X * Math.Sin(radAngle)), 0),
                new Vector4((float)(vector.X * vector.Z * (1.0f - Math.Cos(radAngle)) + vector.Y * Math.Sin(radAngle)), (float)(vector.Y * vector.Z * (1.0f - Math.Cos(radAngle)) - vector.X * Math.Sin(radAngle)), (float)(Math.Cos(radAngle) + Math.Pow(vector.Z, 2.0f) * (1.0f - Math.Cos(radAngle))), 0),
                Vector4.UnitW
                );

            _model *= Matrix4.CreateTranslation(-pivot);
            _model *= arbRotationMatrix;
            _model *= Matrix4.CreateTranslation(pivot);

            for (int i = 0; i < 3; i++)
            {
                _euler[i] = Vector3.Normalize(getRotationResult(pivot, vector, radAngle, _euler[i], true));
            }

            _centerPosition = getRotationResult(pivot, vector, radAngle, _centerPosition);
            //objectCenter = getRotationResult(pivot, vector, radAngle, objectCenter);

            foreach (var i in Child)
            {
                i.rotate(pivot, vector, angle);
            }
        }
        public void addChild(float x, float y, float z, float lengthTop, float lengthBottom)
        {
            EightSidedBox newChild = new EightSidedBox();
            newChild.createBoxVertices(x, y, z, lengthTop, lengthBottom);
            Child.Add(newChild);
        }
    }
}
