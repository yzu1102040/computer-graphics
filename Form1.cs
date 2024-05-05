using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tao.FreeGlut;
using Tao.OpenGl;

namespace final1102040CD
{
    public partial class Form1 : Form
    {
        const double DEGREE_TO_RAD = 0.01745329;
        double Radius = 7.0, Longitude = 0.0, Latitude = 8.0;
        public Form1()
        {
            InitializeComponent(); 
            this.openGLControl1.InitializeContexts();
            Glut.glutInit();
        }

        private void openGLControl1_Load(object sender, EventArgs e)
        {
            SetViewingVolume();
            MyInit();
        }

        private void MyInit()
        {
            Gl.glClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            Gl.glClearDepth(1.0);

            Gl.glColorMaterial(Gl.GL_FRONT, Gl.GL_AMBIENT_AND_DIFFUSE);

            Gl.glEnable(Gl.GL_NORMALIZE);
            Gl.glEnable(Gl.GL_DEPTH_TEST);
            Gl.glEnable(Gl.GL_LIGHTING);
            Gl.glEnable(Gl.GL_LIGHT0);

            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            float[] light1_ambient = new float[] { 0.2f, 0.2f, 0.2f };
            float[] light1_diffuse = new float[] { 1.0f, 1.0f, 1.0f };
            float[] light1_specular = new float[] { 1.0f, 1.0f, 1.0f };

            float[] light2_ambient = new float[] { 0.8f, 0.4f, 0.0f,0.8f };
            float[] light2_diffuse = new float[] { 0.8f, 0.4f, 0.0f,0.2f };
            float[] light2_specular = new float[] { 0.8f, 0.4f, 0.0f,0.2f };

            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_AMBIENT, light1_ambient);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_DIFFUSE, light1_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT1, Gl.GL_SPECULAR, light1_specular);

            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_AMBIENT, light2_ambient);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_DIFFUSE, light2_diffuse);
            Gl.glLightfv(Gl.GL_LIGHT2, Gl.GL_SPECULAR, light2_specular);

            
        }
        private void SetViewingVolume()
        {

            Gl.glMatrixMode(Gl.GL_PROJECTION);
            Gl.glLoadIdentity();
            double aspectRatio =
                   (double)openGLControl1.Size.Width / (double)openGLControl1.Size.Height;

            Glu.gluPerspective(45, aspectRatio, 0.1, 100.0);
            Gl.glViewport(0, 0, openGLControl1.Size.Width, openGLControl1.Size.Height);
        }

        private void openGLControl1_Resize(object sender, EventArgs e)
        {
            SetViewingVolume();
        }

        private void axes(double length)
        {
            Gl.glDisable(Gl.GL_LIGHTING);

            Gl.glBegin(Gl.GL_LINES);
            Gl.glColor3ub(255, 0, 0);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(length, 0, 0);
            Gl.glColor3ub(0, 255, 0);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, length, 0);
            Gl.glColor3ub(0, 0, 255);
            Gl.glVertex3d(0, 0, 0);
            Gl.glVertex3d(0, 0, length);

            Gl.glEnd();
            Gl.glEnable(Gl.GL_LIGHTING);
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
               
                case Keys.Up:
                    Latitude += 5.0;
                    if (Latitude >=60)
                        Latitude = 60;
                    break;
                case Keys.Down:
                    Latitude -= 5.0;
                    if (Latitude <= 0)
                        Latitude = 0;
                    break;
                case Keys.PageUp:
                    Radius -= 0.1;
                    if (Radius <= 1) Radius = 1;
                    break;
                case Keys.PageDown:
                    Radius += 0.1;
                    if (Radius >= 11) Radius = 11;
                    break;
               
                default: break;

            }

            this.openGLControl1.Refresh();
        }

        private void wall()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            Gl.glColor3d(1, 1, 1);

            Gl.glPushMatrix();
            Gl.glRotated(-210, 0, 1, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(1.0, 1.0, -1.0);
            Gl.glVertex3d(1.0, 1.0, 1.0);
            Gl.glVertex3d(1.0, -1.0, 1.0);
            Gl.glVertex3d(1.0, -1.0, -1.0);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(-300, 0, 1, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(1.0, 1.0, -1.0);
            Gl.glVertex3d(1.0, 1.0, 1.0);
            Gl.glVertex3d(1.0, -1.0, 1.0);
            Gl.glVertex3d(1.0, -1.0, -1.0);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(-30, 0, 1, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(1.0, 1.0, -1.0);
            Gl.glVertex3d(1.0, 1.0, 1.0);
            Gl.glVertex3d(1.0, -1.0, 1.0);
            Gl.glVertex3d(1.0, -1.0, -1.0);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glRotated(60, 0, 1, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-1.0, -1.0, 1.0);
            Gl.glVertex3d(-1.0, -1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, 1.0);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }

        private void top()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColor3d(1, 0, 0);

            Gl.glPushMatrix();
            
            Gl.glRotated(60, 0, 1, 0);
            Gl.glRotated(90, 0, 0, 1);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-1.0, -1.0, 1.0);
            Gl.glVertex3d(-1.0, -1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, 1.0);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }

        private void window()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);

            Gl.glColor3d(0, 0, 0);
            Gl.glPushMatrix();
            Gl.glTranslated(-0.51, 0.0, 0.85);
            Gl.glRotated(60, 0, 1, 0);
            Gl.glScaled(0.1, 0.1, 1.0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-1.0, -1.0, 1.0);
            Gl.glVertex3d(-1.0, -1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, 1.0);
            Gl.glEnd();
            Gl.glPopMatrix();

            
            Gl.glPushMatrix();
            Gl.glTranslated(-0.499, 0.0, 0.751);
            Gl.glScaled(0.1, 1.0, 0.1);
            Gl.glRotated(60, 0, 1, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-1.0, -1.0, 1.0);
            Gl.glVertex3d(-1.0, -1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, 1.0);
            Gl.glEnd();
            Gl.glPopMatrix();


            Gl.glColor3d(0.529, 0.808, 0.922);
            Gl.glPushMatrix();
            Gl.glRotated(60, 0, 1, 0);
            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-1.0, -1.0, 1.0);
            Gl.glVertex3d(-1.0, -1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, 1.0);
            Gl.glEnd();
            Gl.glPopMatrix();

            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }

        private void ground()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColor3d(0.0, 0.5, 0.0);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-10.0, 0.0, 10.0);
            Gl.glVertex3d(-10.0, 0.0, -10.0);
            Gl.glVertex3d(10.0, 0.0, -10.0);
            Gl.glVertex3d(10.0, 0.0, 10.0);
            Gl.glEnd();

            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }

        private void sky()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColor3d(0.529, 0.808, 0.922);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(10.0, -10.0, -10.0);
            Gl.glVertex3d(10.0, 10.0, -10.0);
            Gl.glVertex3d(-10.0, 10.0, -10.0);
            Gl.glVertex3d(-10.0, -10.0, -10.0);
            Gl.glEnd();

            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gl.glEnable(Gl.GL_LIGHT1);
            Gl.glDisable(Gl.GL_LIGHT2);
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_LIGHT0);
            openGLControl1.Invalidate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gl.glDisable(Gl.GL_LIGHT1);
            Gl.glEnable(Gl.GL_LIGHT2);
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_LIGHT0); 
            openGLControl1.Invalidate();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Gl.glDisable(Gl.GL_LIGHT1);
            Gl.glDisable(Gl.GL_LIGHT2);
            Gl.glDisable(Gl.GL_LIGHTING);
            Gl.glDisable(Gl.GL_LIGHT0); 
            openGLControl1.Invalidate();
        }
        
        private void door()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColor3d(0.545, 0.271, 0.075);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(1.0, -1.0, -1.0);
            Gl.glVertex3d(1.0, 1.0, -1.0);
            Gl.glVertex3d(-1.0, 1.0, -1.0);
            Gl.glVertex3d(-1.0, -1.0, -1.0);
            Gl.glEnd();

            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }

        private void mountain()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColor3d(0.0 ,1.0 ,0.0);
            Gl.glBegin(Gl.GL_TRIANGLES);
            Gl.glVertex3f(-1.0f, -1.0f, 0.0f);
            Gl.glVertex3f(1.0f, -1.0f, 0.0f); 
            Gl.glVertex3f(0.0f, 1.0f, 0.0f); 
            Gl.glEnd();
            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }

       

        private void river()
        {
            Gl.glEnable(Gl.GL_COLOR_MATERIAL);
            Gl.glColor3d(.529, 0.808, 0.922);

            Gl.glBegin(Gl.GL_QUADS);
            Gl.glVertex3d(-2.0, 0.0, 2.0);
            Gl.glVertex3d(-2.0, 0.0, -2.0);
            Gl.glVertex3d(2.0, 0.0, -2.0);
            Gl.glVertex3d(2.0, 0.0, 2.0);
            Gl.glEnd();

            Gl.glDisable(Gl.GL_COLOR_MATERIAL);
        }

       
        private void openGLControl1_Paint(object sender, PaintEventArgs e)
        {
            Gl.glClear(Gl.GL_COLOR_BUFFER_BIT | Gl.GL_DEPTH_BUFFER_BIT);

            Gl.glMatrixMode(Gl.GL_MODELVIEW);
            Gl.glLoadIdentity();


            Glu.gluLookAt(Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                                * Math.Sin(Longitude * DEGREE_TO_RAD),
                        Radius * Math.Sin(Latitude * DEGREE_TO_RAD),
                        Radius * Math.Cos(Latitude * DEGREE_TO_RAD)
                               * Math.Cos(Longitude * DEGREE_TO_RAD),
                 0.0, 0.0, 0.0, 0.0, 1.0, 0.0);

            axes(3);

            //------------------------------------------------------------
            Gl.glPushMatrix();
            Gl.glTranslated(0.5, 0.0, -0.5);
            Gl.glScaled(0.7, 0.7, 0.7);
            wall();
            Gl.glPopMatrix() ;

            //------------------------------------------------------------

            Gl.glPushMatrix() ;
            Gl.glTranslated(0.5, 1.4, -0.5);
            Gl.glScaled(0.7, 0.7, 0.7);
            top();
            Gl.glPopMatrix();

            //-------------------------------------------------------------

            Gl.glPushMatrix();
            Gl.glTranslated(0.3, 0.075, -0.14);
            Gl.glScaled(0.3, 0.3, 0.3);
            window();
            Gl.glPopMatrix();

            //-----------------------------------------------------------

            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -0.7, 0.0);
            Gl.glScaled(2.5, 1.0 ,2.5);
            ground();
            Gl.glPopMatrix();

            //-----------------------------------------------------------

            Gl.glPushMatrix();
            Gl.glTranslated(0.0, 0.0, 0.0);
            Gl.glScaled(2.5, 2.0, 2.5);
            sky();
            Gl.glPopMatrix();

            //------------------------------------------------------------

            Gl.glPushMatrix();
            Gl.glTranslated(1.3, -0.3, 0.0);
            Gl.glRotated(60, 0, 1, 0);
            Gl.glScaled(0.2,0.4,0.2);
            door();
            Gl.glPopMatrix();

            //----------------------------------------------------------

            Gl.glPushMatrix();
            Gl.glTranslated(-7.0,0.0,-24.8);
            Gl.glScaled(6.0, 7.0, 8.0);
            mountain();
            Gl.glPopMatrix();

            Gl.glPushMatrix();
            Gl.glTranslated(-3.0, 0.0, -24.8);
            Gl.glScaled(5.0, 8.0, 8.0);
            mountain();
            Gl.glPopMatrix();

            //------------------------------------------------------------

            Gl.glPushMatrix();
            Gl.glTranslated(0.0, -0.68, 4.0);
            Gl.glScaled(8.0, 1.0, 0.2);
            river();
            Gl.glPopMatrix();
        }
    }
}
