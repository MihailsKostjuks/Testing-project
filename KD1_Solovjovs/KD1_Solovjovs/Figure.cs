using SharpGL;
using SharpGL.SceneGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KD1_Solovjovs
{
    public abstract class Figure
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        public float Size { get; set; }

        protected double[] color;
        public bool[] displaySides;
        public abstract void drawFigure(OpenGL gl);
        protected Figure(
            float x, 
            float y, 
            float z, 
            float size, 
            double[] color,
            bool[] displaySides
            )
        {
            X = x;
            Y = y;
            Z = z;
            Size = size;
            this.color = color;
            this.displaySides = displaySides;
        }
    }
}
