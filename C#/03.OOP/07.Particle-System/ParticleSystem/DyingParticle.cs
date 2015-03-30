using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class DyingParticle : Particle
    {
        int lifeTime = 0;

        public DyingParticle(MatrixCoords position, MatrixCoords speed,int lifeTime)
            : base(position, speed)
        {
            if (lifeTime < 0)
            {
                throw new ArgumentOutOfRangeException("Life time must be greater than or equal to zero");
            }
            else
            {
                this.lifeTime = lifeTime;
            }
        }

        public override bool Exists
        {
            get
            {
                return this.lifeTime > 0;
            }
        }

        public override IEnumerable<Particle> Update()
        {
            lifeTime--;


            return base.Update();
        }
    }
}
