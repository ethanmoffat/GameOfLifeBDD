using GameOfLife.Services;

namespace GameOfLife.Controllers
{
   public class SimulationController : ISimulationController
   {
      private readonly ISimulationStateRepository _simulationStateRepository;

      public SimulationController(ISimulationStateRepository simulationStateRepository)
      {
         _simulationStateRepository = simulationStateRepository;
      }

      public void RunSimulation()
      {
         throw new System.NotImplementedException();
      }

      public void PauseSimulation()
      {
         throw new System.NotImplementedException();
      }

      public void ResumeSimulation()
      {
         throw new System.NotImplementedException();
      }

      public void ResetSimulation()
      {
         throw new System.NotImplementedException();
      }
   }
}
