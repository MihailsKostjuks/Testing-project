using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KD1_Solovjovs
{
    public partial class Form1 : Form
    {
        Random rand = new Random();

        enum Figures{
            CUBE,
            PYRAMID,
            HEXAGON
        }

        public Form1()
        {
            InitializeComponent();
            updateLabel();
        }

        List<Figure> figures = new List<Figure>();
        // string selectedFigure = "Cube"; personal prefference to use enums here
        Figures selectedFigure = Figures.CUBE;
        OpenGL gl;

        float startY = 0.0f;
        float mg = 0.98f;
        float fallingSpeed = 0f;
        bool isFalling = false;

        private void openGLControl1_OpenGLInitialized(object sender, EventArgs e)
        {
            gl = this.openGLControl1.OpenGL;
            // gl.Color(0.1f, 0.1f, 0.3f);
        }

        private void updateLabel()
        {
            if(selectedFigure == Figures.CUBE)
            {
                label.Text = "CUBE";
            } else if(selectedFigure == Figures.PYRAMID)
            {
                label.Text = "PYRAMID";
            } else
            {
                label.Text = "HEXAGON";
            }
        }

        private void openGLControl1_OpenGLDraw(object sender, SharpGL.RenderEventArgs args)
        {
            gl.Clear(OpenGL.GL_COLOR_BUFFER_BIT | OpenGL.GL_DEPTH_BUFFER_BIT);
            gl.LoadIdentity();
            gl.PushMatrix();
            gl.LookAt(0.0f, startY, -55.0f, // Camera's position
              0.0f, startY, 0.0f,   // Camera pointed at
              0.0f, 1.0f, 0.0f);  // Axis vector
            renderAllFigures();
            gl.PopMatrix();
            gl.Flush();
            if(isFalling)
            {
                fallingSpeed += mg;
                startY += fallingSpeed;
            }
        }

        private void renderAllFigures()
        {
            foreach(Figure figure in figures)
            {
                figure.drawFigure(gl);
            }
        }

        private void openGLControl1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Z)
            {
                selectedFigure = Figures.CUBE;
            } 
            else if(e.KeyCode == Keys.X)
            {
                selectedFigure = Figures.PYRAMID;
            } 
            else if(e.KeyCode == Keys.C)
            {
                selectedFigure = Figures.HEXAGON;
            }
            else if (e.KeyCode == Keys.R)
            {
                randomlyCreateFigure();
            }
            else if(
                e.KeyCode == Keys.D1 || e.KeyCode == Keys.D2 || e.KeyCode == Keys.D3 ||
                e.KeyCode == Keys.D4 || e.KeyCode == Keys.D5 || e.KeyCode == Keys.D6
                )
            {
                // d1's value is 49 and so on => if subtract 48 will get [1, 6]
                swapVisibility((int)e.KeyCode - 48);
            }
            else if(e.KeyCode == Keys.G)
            {
                isFalling = true;
            }
            updateLabel();
        }


        private void randomlyCreateFigure()
        {
            const float half_range = 30;
            const float MAX_SIZE = 5;
            float x = (float)(rand.NextDouble() * 2 * half_range - half_range);
            float y = (float)(rand.NextDouble() * 2 * half_range - half_range);
            float z = (float)(rand.NextDouble() * 50);  // will be rendered [0 to further into the depth 50), while camera is moved closer to the screen to ar. -55 to capture the view (had to play with these nums)
            float size = (float)(rand.NextDouble() * (MAX_SIZE));
            double[] color = generateRGB();
            bool[] displaySides = { true, false};
            Figure figure;

            if (selectedFigure == Figures.CUBE)
            {
                figure = new MyCube(x, y, z, size, color, generateDisplaySides());
            }
            else if (selectedFigure == Figures.PYRAMID)
            {
                figure = new Pyramid(x, y, z, size, color, generateDisplaySides());
            }
            else
            {
                figure = new Hexagon(x, y, z, size, color, generateDisplaySides());
            }
            figures.Add(figure);
        }

        private double[] generateRGB()
        {
            // [0, 0.9999..] is good enough
            double R = rand.NextDouble();
            double G = rand.NextDouble();
            double B = rand.NextDouble();
            return new double[3] { R, G, B };
        }

        private bool[] generateDisplaySides()
        {
            int arraySize = selectedFigure == Figures.HEXAGON ? 6 : 4;
            bool[] displaySides = new bool[arraySize];
            for(int i = 0; i < arraySize; i++)
            {
                // displaySides[i] = rand.Next(2) == 0;\

                // On the demo all the sides are initially displayed
                displaySides[i] = true;
            }
            return displaySides;
        }

        private void swapVisibility(int n)
        {
           
            foreach (Figure figure in figures)
            {
                if (n > figure.displaySides.Length) continue;
                figure.displaySides[n - 1] = !figure.displaySides[n - 1];
            }
        }
    }
}
