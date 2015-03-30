using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ParticleSystem
{
    public class ChickenParticle : ChaoticParticle
    {
        private readonly MatrixCoords StopToCreateNew = new MatrixCoords(0, 0);
        private int currentTick;
        private readonly int stopTicks;
        private MatrixCoords lastKnownSpeed;
        //private bool isStoped;

        public ChickenParticle(MatrixCoords position, MatrixCoords speed, Random randomGenerator,
            int stopTicks = 4)
            : base(position, speed, randomGenerator)
        {
            this.currentTick = 0;
            this.stopTicks = stopTicks;
            //this.isStoped = false;
        }

        public override IEnumerable<Particle> Update()
        {
            //if (!this.isStoped&&)
            //{
                
            //}

            if (this.Speed.Equals(StopToCreateNew))
            {
                this.currentTick++;
                if (this.currentTick==this.stopTicks)
                {
                    this.Accelerate(this.lastKnownSpeed);
                    this.currentTick = 0;
                }

                var baseParticles = base.Update();
                List<Particle> newChickenCreated = new List<Particle>()
                {
                    new ChickenParticle(this.Position, GetRandomCoorts(),
                                        this.randomSpeedGEnerator, this.stopTicks)
                };
                newChickenCreated.AddRange(baseParticles);

                return newChickenCreated;
            }
            else
            {
                this.lastKnownSpeed = this.Speed;
            }
            return base.Update();
        }

        public override char[,] GetImage()
        {
            return new char[,] { { (char)12 } }; 
        }
    }
}
