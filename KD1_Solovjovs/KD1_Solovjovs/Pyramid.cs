﻿using SharpGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD1_Solovjovs
{
    public class Pyramid : Figure
    {

        public Pyramid(
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

            gl.Vertex(-1.0f, 0f, -1.0f);
            gl.Vertex(-1.0f,  0f, 1.0f);
            gl.Vertex(1.0f, 0f, 1.0f);
            gl.Vertex(1.0f, 0f, -1.0f);


            gl.Begin(OpenGL.GL_TRIANGLES);
            if (displaySides[0])
            {
                gl.Vertex(0f, 1.0f, 0f);
                gl.Vertex(-1.0f, 0f, 1.0f);
                gl.Vertex(1.0f, 0f, 1.0f);
            }

            if (displaySides[1])
            {
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Vertex(-1.0f, 0f, -1.0f);
                gl.Vertex(1.0f, 0f, -1.0f);
            }

            if (displaySides[2])
            {
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Vertex(-1.0f, 0f, -1.0f);
                gl.Vertex(-1.0f, 0f, 1.0f);
            }

            if (displaySides[3])
            {
                gl.Vertex(0.0f, 1.0f, 0.0f);
                gl.Vertex(1.0f, 0f, -1.0f);
                gl.Vertex(1.0f, 0f, 1.0f);
            }

            gl.End();
            gl.PopMatrix();
            gl.Flush();
        }
    }
}