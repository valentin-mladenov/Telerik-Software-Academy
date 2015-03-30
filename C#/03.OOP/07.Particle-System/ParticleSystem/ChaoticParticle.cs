using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//Tasks 01,02:
//Create a ChaoticParticle class, which is a Particle,
//randomly changing its movement (Speed).
//You are not allowed to edit any existing class.
//Test the ChaoticParticle through the ParticleSystemMain class.

namespace ParticleSystem
{
    public class ChaoticParticle : Particle
    {
        protected Random randomSpeedGEnerator;
        private const int MaxSpeed = 1;

        public ChaoticParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator)
            : base(position,speed)        
        {
            this.randomSpeedGEnerator = randomGenerator;
        }

        public override IEnumerable<Particle> Update()
        {
            this.Speed = GetRandomCoorts();

            return base.Update();
        }

        public virtual MatrixCoords GetRandomCoorts()
        {
            int maxSpeedRow = this.randomSpeedGEnerator.Next(-MaxSpeed, MaxSpeed + 1);
            int maxSpeedCol = this.randomSpeedGEnerator.Next(-MaxSpeed, MaxSpeed + 1);

            var createdSpeed = new MatrixCoords(maxSpeedRow, maxSpeedCol);
            return createdSpeed;
        }

        public override char[,] GetImage()
        {
            return new char[,] { { (char)11 } }; 
        }
    }
}
