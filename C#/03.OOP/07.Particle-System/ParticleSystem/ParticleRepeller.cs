using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleRepeller : Particle
    {
        public int RepellRadius { get; protected set; }

        public ParticleRepeller(MatrixCoords position, MatrixCoords speed, int repellRadius)
            : base(position, speed) 
        {
            this.RepellRadius = repellRadius;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { (char)15 } };
        }
    }
}
