using Moq;
using SpaceSystemWebRepositories;
using SpaceSystemWebServices;
using System.Net.WebSockets;

namespace SpaceSystemWebUnitTests
{
    public class TestPlanetsService
    {
        private IPlanetsService _planetsService;
        private Mock<IPlanetsRepository> _repository;
        private int NUMBER_OF_PLANETS = 8;

        public TestPlanetsService()
        {
            CreateMocks();
            _planetsService = new PlanetsService(_repository.Object);
        }

        private void CreateMocks()
        {
            _repository = new Mock<IPlanetsRepository>();
            //var planets = GetPlanetsTestData();
            //var singlePlanet = GetSinglePlanet();
        }

        [Fact]
        public void Test1()
        {

        }
    }
}