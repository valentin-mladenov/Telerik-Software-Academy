//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;

//namespace ParticleSystem
//{
//    public class ChickenParticleUpdater : ParticleUpdater
//    {

//        private readonly MatrixCoords stopToCreateNew = new MatrixCoords(0, 0);
//        //private readonly int stopToCreateDuration = 4;
//        private List<Particle> currentTickParticles = new List<Particle>();
//        private List<ChickenParticle> chickenParticles = new List<ChickenParticle>();

//        public override IEnumerable<Particle> OperateOn(Particle p)
//        {
//            var potentialChicken = p as ChickenParticle;
//            if (potentialChicken!=null)
//            {
//                chickenParticles.Add(potentialChicken);
//            }
//            else
//            {
//                this.currentTickParticles.Add(p);
//            }

//            return base.OperateOn(p);
//        }

//        public override void TickEnded()
//        {
//            base.TickEnded();
//        }
//    }
//}
