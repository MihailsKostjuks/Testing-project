using SharpGL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD1_Solovjovs
{
    public class Hexagon : Figure
    {
        public Hexagon(
            float x, float y, float z, float size,
            double[] color, bool[] displaySides)
            : base(x, y, z, size, color, displaySides)
        { }

        public override void drawFigure(OpenGL gl)
        {
            gl.PushMatrix();
            gl.Translate(X, Y, Z);
            gl.Scale(Size, Size, Size);

            gl.Begin(OpenGL.GL_QUADS);

            gl.Color(color[0], color[1], color[2]);

            // TOP
            gl.Vertex(-2f, -1f, 0f);
            gl.Vertex(-1f, -1f, -1f);
            gl.Vertex(1f, -1f, -1f);
            gl.Vertex(2f, -1f, -0f);

            gl.Vertex(-2f, -1f, 0f);
            gl.Vertex(-1f, -1f, 1f);
            gl.Vertex(1f, -1f, 1f);
            gl.Vertex(2f, -1f, 0f);

            // BOTTOM
            gl.Vertex(-2f, 1f, 0f);
            gl.Vertex(-1f, 1f, -1f);
            gl.Vertex(1f, 1f, -1f);
            gl.Vertex(2f, 1f, -0f);

            gl.Vertex(-2f, 1f, 0f);
            gl.Vertex(-1f, 1f, 1f);
            gl.Vertex(1f, 1f, 1f);
            gl.Vertex(2f, 1f, 0f);


            // nepaspeju pabeigt
            if (displaySides[0])
            {

            }

            if (displaySides[1])
            {
 
            }

            if (displaySides[2])
            {
    
            }

            if (displaySides[3])
            {

            }

            if (displaySides[4])
            {

            }

            if (displaySides[5])
            {

            }

            gl.End();
            gl.PopMatrix();
            gl.Flush();
        }
    }
}
