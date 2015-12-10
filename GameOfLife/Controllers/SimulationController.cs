using GameOfLife.Actions;

namespace GameOfLife.Controllers
{
   public class SimulationController : ISimulationController
   {
      private readonly ISimulationActions _simulationActions;

      public SimulationController(ISimulationActions simulationActions)
      {
         _simulationActions = simulationActions;
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
