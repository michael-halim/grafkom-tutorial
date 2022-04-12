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
        Circle circle = new Circle();
        Circle circle2 = new Circle();
        Circle circle3 = new Circle();
        Circle circle4 = new Circle();
        Circle circle5 = new Circle();
        Circle circle6 = new Circle();
        Limb limbs = new Limb();
        Circle body1 = new Circle();
        Circle body2 = new Circle();
        Circle body3 = new Circle();
        float degree = 0;
        int time = 0;
        bool isAnimateHead = true;
        int countAnimateHead = 0;

        bool isAnimateBody = false;
        int countAnimateBody = 0;
        public Window(GameWindowSettings gameWindowSettings, NativeWindowSettings nativeWindowSettings) : base(gameWindowSettings, nativeWindowSettings)
        {
        }

        protected override void OnLoad()
        {


            base.OnLoad();
            //// ganti background
            GL.ClearColor(0.8f, 0.8f, 0.7f, 1.0f);
            _object3d[0] = new Asset3d();
            //_object3d[0].createBoxVertices(0.0f, 0.0f, 0.0f, 0.5f);
            //_object3d[0].addChild(0.7f, 0.7f, 0.3f, 0.1f);



            //_object3d[0].createEllipsoid2(0.5f, 0.3f, -0.5f,0.0f,0.0f,0.0f,10,10);




            //_object3d[0].createOneSideHyperboloid(0.2f, 0.2f, 0.2f, 0f, 0f, 0f);
            //_object3d[0].createTwoSideHyperboloid(0.2f, 0.2f, 0.2f, 0f, 0f, 0f);
            //_object3d[0].createHyperboloidParaboloid(0.2f, 0.2f, 0.2f, 0f, 0f, 0f);
            //_object3d[0].createEllipticCone(0.2f, 0.2f, 0.2f, 0f, 0f, 0f);
            //_object3d[0].createTorus(0.0f, 0f, 0f, 0.5f, 0.1f, 3f, 1000f); // sphere
            //_object3d[0].createSphere(0.0f, 0.0f, 1f, 0.4f);

            // Body
            //circle.createSphere(0.0f, 0.0f, 1f, 0.1f);
            //circle.addChild(0.0f, 0.2f, 1f, 0.1f);
            //circle.addChild(0.0f, 0.4f, 1f, 0.1f);
            //circle.addBoxChild(0.2f, 0.5f, 1f, 0.1f, 0.13f);
            //circle.Child[2].rotate(circle.Child[2]._centerPosition, circle.Child[2]._euler[2], 300);

            //circle.addHalfSphereChild(-0.2f, 0.6f, 1f, 0.04f);
            //circle.Child[3].rotate(circle.Child[3]._centerPosition, circle.Child[3]._euler[0], 0);
            //circle.addHalfSphereChild(-0.2f, 0.1f, 0f, 0.068f);

            

            body1.createSphere(0, 0, 0, 0.1f);
            body2.createSphere(0, 0.2f, 0, 0.1f);
            body3.createSphere(0, 0.4f, 0, 0.1f);


            body3.addChild(circle);
            circle.halimBoxVertices(0.1f, 0.55f, 0f, 0.1f, 0.13f);

            Circle halfSphereTop = new Circle();
            Circle halfSphereBottom = new Circle();
            halfSphereTop.h_createHalfSphere(0.1f, 0.65f, 0f, 0.04f);
            halfSphereBottom.h_createHalfSphere(0.1f, 0.45f, 0f, 0.068f,"FLIP");
            circle.addChild(halfSphereTop);
            circle.addChild(halfSphereBottom);


            circle.rotate(circle._centerPosition, circle._euler[2], -60);


            body3.addChild(circle2);

            circle2.halimBoxVertices(-0.1f, 0.55f, 0f, 0.1f, 0.13f);

            halfSphereTop = new Circle();
            halfSphereBottom = new Circle();
            halfSphereTop.h_createHalfSphere(-0.1f, 0.65f, 0f, 0.04f);
            halfSphereBottom.h_createHalfSphere(-0.1f, 0.45f, 0f, 0.068f, "FLIP");

            circle2.addChild(halfSphereTop);
            circle2.addChild(halfSphereBottom);


            circle2.rotate(circle2._centerPosition, circle2._euler[2], 60);
            

            //===
            body2.addChild(circle3);
            circle3.halimBoxVertices(0.1f, 0.35f, 0f, 0.1f, 0.13f);

            halfSphereTop = new Circle();
            halfSphereBottom = new Circle();
            halfSphereTop.h_createHalfSphere(0.1f, 0.45f, 0f, 0.04f);
            halfSphereBottom.h_createHalfSphere(0.1f, 0.25f, 0f, 0.068f, "FLIP");
            circle3.addChild(halfSphereTop);
            circle3.addChild(halfSphereBottom);


            circle3.rotate(circle3._centerPosition, circle3._euler[2], -90);


            body2.addChild(circle4);

            circle4.halimBoxVertices(-0.1f, 0.35f, 0f, 0.1f, 0.13f);

            halfSphereTop = new Circle();
            halfSphereBottom = new Circle();
            halfSphereTop.h_createHalfSphere(-0.1f, 0.45f, 0f, 0.04f);
            halfSphereBottom.h_createHalfSphere(-0.1f, 0.25f, 0f, 0.068f, "FLIP");

            circle4.addChild(halfSphereTop);
            circle4.addChild(halfSphereBottom);


            circle4.rotate(circle4._centerPosition, circle4._euler[2], 90);
            

            // ==

            body1.addChild(circle5);
            circle5.halimBoxVertices(0.1f, 0.15f, 0f, 0.1f, 0.13f);

            halfSphereTop = new Circle();
            halfSphereBottom = new Circle();
            halfSphereTop.h_createHalfSphere(0.1f, 0.25f, 0f, 0.04f);
            halfSphereBottom.h_createHalfSphere(0.1f, 0.05f, 0f, 0.068f, "FLIP");
            circle5.addChild(halfSphereTop);
            circle5.addChild(halfSphereBottom);


            circle5.rotate(circle5._centerPosition, circle5._euler[2], -135);
            

            body1.addChild(circle6);

            circle6.halimBoxVertices(-0.1f, 0.15f, 0f, 0.1f, 0.13f);

            halfSphereTop = new Circle();
            halfSphereBottom = new Circle();
            halfSphereTop.h_createHalfSphere(-0.1f, 0.25f, 0f, 0.04f);
            halfSphereBottom.h_createHalfSphere(-0.1f, 0.05f, 0f, 0.068f, "FLIP");

            circle6.addChild(halfSphereTop);
            circle6.addChild(halfSphereBottom);


            circle6.rotate(circle6._centerPosition, circle6._euler[2], 135);
            


            body1.load(Constants.SHADER_PATH + "bodyBody.vert", Constants.SHADER_PATH + "bodyBody.frag", Size.X, Size.Y);
            body2.load(Constants.SHADER_PATH + "bodyBody.vert", Constants.SHADER_PATH + "bodyBody.frag", Size.X, Size.Y);
            body3.load(Constants.SHADER_PATH + "bodyHead.vert", Constants.SHADER_PATH + "bodyHead.frag", Size.X, Size.Y);

            body3.Child[0].load(Constants.SHADER_PATH + "limb.vert", Constants.SHADER_PATH + "limb.frag", Size.X, Size.Y);
            body3.Child[1].load(Constants.SHADER_PATH + "limb.vert", Constants.SHADER_PATH + "limb.frag", Size.X, Size.Y);


            body2.Child[0].load(Constants.SHADER_PATH + "limb.vert", Constants.SHADER_PATH + "limb.frag", Size.X, Size.Y);
            body2.Child[1].load(Constants.SHADER_PATH + "limb.vert", Constants.SHADER_PATH + "limb.frag", Size.X, Size.Y);
            
            body1.Child[0].load(Constants.SHADER_PATH + "limb.vert", Constants.SHADER_PATH + "limb.frag", Size.X, Size.Y);
            body1.Child[1].load(Constants.SHADER_PATH + "limb.vert", Constants.SHADER_PATH + "limb.frag", Size.X, Size.Y);
 
        }

        protected override void OnRenderFrame(FrameEventArgs args)
        {
            base.OnRenderFrame(args);
            GL.Clear(ClearBufferMask.ColorBufferBit);

            
            Matrix4 temp = Matrix4.Identity;
            //temp = temp * Matrix4.CreateRotationX(degree % 360);
            //temp = temp * Matrix4.CreateTranslation();

            //temp = temp * Matrix4.CreateRotationY(degree % 360);
            //temp = temp * Matrix4.CreateRotationZ(degree % 360);

            //limbs.render(3, temp);

            //render and rotate
            body1.render(3, temp);
            body2.render(3, temp);
            circle.render(3, temp);
            body3.render(3, temp);

            if (isAnimateHead)
            {
                body3.render(3, temp);
                if (countAnimateHead <= 10 && countAnimateHead != 0)
                {
                    body3.rotate(body3._centerPosition, body3._euler[1], degree % 10);
                    
                }
                else
                {
                    body3.rotate(body3._centerPosition, body3._euler[1], -(degree % 10));

                }
                countAnimateHead++;
                if(countAnimateHead >= 280)
                {
                    isAnimateHead = false;
                    isAnimateBody = true;
                }
            }
            

            if (isAnimateBody)
            {
                body2.render(3, temp);
                if (countAnimateBody <= 145)
                {
                    body2.Child[0].rotate(body2.Child[0]._centerPosition, body2.Child[0]._euler[2], degree % 10);
                }
                else
                {
                    body2.Child[1].rotate(body2.Child[1]._centerPosition, body2.Child[1]._euler[2], -(degree % 10));

                }
                countAnimateBody++;

                if(countAnimateBody >= 290)
                {
                    isAnimateBody=false;
                }
            }



            //body2.rotate(body2._centerPosition, body2._euler[0], degree % 2);



            degree += 0.5f;
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
