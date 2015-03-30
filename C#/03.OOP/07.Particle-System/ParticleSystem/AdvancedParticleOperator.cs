using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class AdvancedParticleOperator : ParticleUpdater
    {
        private List<Particle> currentTickParticles = new List<Particle>();
        private List<ParticleAtractor> currentTickAttractors = new List<ParticleAtractor>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var potentialAttractor = p as ParticleAtractor;
            if (potentialAttractor != null)
            {
                this.currentTickAttractors.Add(potentialAttractor);
            }
            else
            {
                this.currentTickParticles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var attract in this.currentTickAttractors)
            {
                foreach (var particle in this.currentTickParticles)
                {
                    var currParticleToAttractorVector = attract.Position - particle.Position;

                    int ptoAttRow = currParticleToAttractorVector.Row;
                    ptoAttRow = DecreaseVectorCoordToPower(attract, ptoAttRow);

                    int ptoAttCol = currParticleToAttractorVector.Col;
                    ptoAttCol = DecreaseVectorCoordToPower(attract, ptoAttCol);

                    var currAcceleration = new MatrixCoords(ptoAttRow, ptoAttCol);

                    particle.Accelerate(currAcceleration);
                }
            }

            this.currentTickAttractors.Clear();
            this.currentTickParticles.Clear();

            base.TickEnded();
        }

        private static int DecreaseVectorCoordToPower(ParticleAtractor attract, int ptoAttCoord)
        {
            if (Math.Abs(ptoAttCoord) > attract.Attraction)
            {
                ptoAttCoord = (ptoAttCoord / Math.Abs(ptoAttCoord)) * attract.Attraction;
            }
            return ptoAttCoord;
        }
    }
}
