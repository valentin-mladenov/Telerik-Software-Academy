using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleAtractor : Particle
    {
        public int Attraction { get; private set; }

        public ParticleAtractor(MatrixCoords position, MatrixCoords speed, int attraction)
            :base(position,speed)
        {
            this.Attraction = attraction;
        }
    }
}
