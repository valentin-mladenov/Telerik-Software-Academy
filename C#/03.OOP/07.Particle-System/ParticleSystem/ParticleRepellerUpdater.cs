using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ParticleSystem
{
    public class ParticleRepellerUpdater : AdvancedParticleOperator
    {
        private List<Particle> currentTickParticles = new List<Particle>();
        private List<ParticleRepeller> currentTickRepellers = new List<ParticleRepeller>();

        public override IEnumerable<Particle> OperateOn(Particle p)
        {
            var potentialRepeller = p as ParticleRepeller;
            if (potentialRepeller != null)
            {
                this.currentTickRepellers.Add(potentialRepeller);
            }
            else
            {
                this.currentTickParticles.Add(p);
            }

            return base.OperateOn(p);
        }

        public override void TickEnded()
        {
            foreach (var repeller in currentTickRepellers)
            {
                foreach (var particle in currentTickParticles)
                {
                    bool repelling = RepellingParticlesInRange(particle.Position, repeller.Position, repeller.RepellRadius);

                    if (repelling == true)
                    {
                        int reverseRow = (particle.Speed.Row * -2) -1;
                        int reverseCol = (particle.Speed.Col * -2) -1;

                        var currAcceleration = new MatrixCoords( reverseCol, reverseRow);

                        particle.Accelerate(currAcceleration);
                    }
                }
            }
            this.currentTickParticles.Clear();
            this.currentTickRepellers.Clear();

            base.TickEnded();
        }

        private bool RepellingParticlesInRange(MatrixCoords particlePosition, MatrixCoords repellerPosition, int radius)
        {
            int repellCol = Math.Abs(particlePosition.Col) - Math.Abs(repellerPosition.Col);
            int repellRow = Math.Abs(particlePosition.Row) - Math.Abs(repellerPosition.Row);
            int particleDistance = (int)Math.Sqrt((repellCol * repellCol) + (repellRow * repellRow));

            if (particleDistance <= radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
