using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD1_Solovjovs
{
    public class MyCube : Figure
    {

        public MyCube(
            float x, float y, float z, float size, 
            double[] color, bool[] displaySides) 
            : base(x, y, z, size, color, displaySides)
        { }

        public override void drawFigure(OpenGL gl)
        {
            // base size 1f [-0.5; 0.5] and will use size property to gl.Scale it

            gl.PushMatrix();
            gl.Translate(X, Y, Z);
            gl.Scale(Size, Size, Size);
            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(color[0], color[1], color[2]);

            // TOP
            gl.Vertex(-0.5f, 0.5f, 0.5f);
            gl.Vertex(0.5f, 0.5f, 0.5f);
            gl.Vertex(0.5f, 0.5f, -0.5f);
            gl.Vertex(-0.5f, 0.5f, -0.5f);

            // BOTTOM
            gl.Vertex(-0.5f, -0.5f, 0.5f);
            gl.Vertex(0.5f, -0.5f, 0.5f);
            gl.Vertex(0.5f, -0.5f, -0.5f);
            gl.Vertex(-0.5f, -0.5f, -0.5f);

            if (displaySides[0])
            {
                gl.Vertex(-0.5f, -0.5f, 0.5f);
                gl.Vertex(0.5f, -0.5f, 0.5f);
                gl.Vertex(0.5f, 0.5f, 0.5f);
                gl.Vertex(-0.5f, 0.5f, 0.5f);
            }


            if (displaySides[1])
            {
                gl.Vertex(0.5f, -0.5f, -0.5f);
                gl.Vertex(0.5f, 0.5f, -0.5f);
                gl.Vertex(0.5f, 0.5f, 0.5f);
                gl.Vertex(0.5f, -0.5f, 0.5f);

            }

            if (displaySides[2])
            {
                gl.Vertex(-0.5f, -0.5f, -0.5f);
                gl.Vertex(-0.5f, 0.5f, -0.5f);
                gl.Vertex(0.5f, 0.5f, -0.5f);
                gl.Vertex(0.5f, -0.5f, -0.5f);
            }
           

            if (displaySides[3])
            {
                gl.Vertex(-0.5f, -0.5f, -0.5f);
                gl.Vertex(-0.5f, -0.5f, 0.5f);
                gl.Vertex(-0.5f, 0.5f, 0.5f);
                gl.Vertex(-0.5f, 0.5f, -0.5f);
            }
           

            gl.End();
            gl.PopMatrix();
        }
    }
}
