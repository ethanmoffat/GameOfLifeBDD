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
         _simulationActions.SetSimulationState(SimulationState.Running);
      }

      public void PauseSimulation()
      {
         _simulationActions.SetSimulationState(SimulationState.Paused);
      }

      public void ResumeSimulation()
      {
         _simulationActions.SetSimulationState(SimulationState.Running);
      }

      public void ResetSimulation()
      {
         _simulationActions.SetSimulationState(SimulationState.Initial);
      }

      public void SetSimulationDelay(int delay)
      {
         _simulationActions.SetDelay(delay);
      }
   }
}
