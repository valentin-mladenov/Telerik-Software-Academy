using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ParticleSystem
{
    class ParticleSystemMain
    {
        const int SimulRows = 23;
        const int SimulCols = 50;

        static readonly Random RandomGenerator = new Random();

        static void Main()
        {
            int tickMiliSecs = 500;
            int chickenStopToCreate = 5;

            var renderer = new ConsoleRenderer(SimulRows, SimulCols);
            var particleOperator = new ParticleRepellerUpdater();

            var particles = new List<Particle>()
            {
                new Particle(new MatrixCoords(5,5), new MatrixCoords(1,1)),
                //new ParticleEmitter(new MatrixCoords(5, 10), new MatrixCoords(0, 0), RandomGenerator),
                //new ParticleEmitter(new MatrixCoords(12, 20), new MatrixCoords(0, 0), RandomGenerator),
                //new VariousLifeTimeParticleEmiter(new MatrixCoords(22, 1), new MatrixCoords(0, 0), RandomGenerator),
                //new ParticleAtractor(new MatrixCoords(5, 8), new MatrixCoords(), 2),
                //new ParticleAtractor(new MatrixCoords(5, 20), new MatrixCoords(), 1)
                ////new ChaoticParticle(new MatrixCoords(15,15), new MatrixCoords(1,1), RandomGenerator),
                new ChickenParticle(new MatrixCoords(15,5), new MatrixCoords(1,1), RandomGenerator, chickenStopToCreate),
                //new ParticleRepeller(new MatrixCoords(15,10),new MatrixCoords(0,0), 7)
            };

            var engine = new Engine(renderer, particleOperator, particles, tickMiliSecs);

            engine.Run();
        }
    }
}
