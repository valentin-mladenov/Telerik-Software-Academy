namespace Cars.Tests.JustMock.Mocks
{
    using Cars.Contracts;
    using Cars.Models;
    using Moq;
    using System.Linq;

    public class MoqCarsRepository : CarRepositoryMock
    {
        protected override void ArrangeCarsRepositoryMock()
        {
            var mockedCarsRepository = new Mock<ICarsRepository>();
            mockedCarsRepository.Setup(r => r.Add(It.IsAny<Car>())).Verifiable();
            mockedCarsRepository.Setup(r => r.All()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.Search(It.IsAny<string>()))
                .Returns(this.FakeCarCollection.Where(c => c.Make == "BMW").ToList());
            mockedCarsRepository.Setup(r => r.GetById(It.IsAny<int>())).Returns(this.FakeCarCollection.First());

            // Homework starts here
            mockedCarsRepository.Setup(r => r.GetById(200)).Verifiable();
            mockedCarsRepository.Setup(r => r.SortedByMake()).Returns(this.FakeCarCollection);
            mockedCarsRepository.Setup(r => r.SortedByYear()).Returns(this.FakeCarCollection);

            this.CarsData = mockedCarsRepository.Object;
        }
    }
}