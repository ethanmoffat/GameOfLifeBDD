using GameOfLife.Services;

namespace GameOfLife.Actions
{
   public class SimulationActions : ISimulationActions
   {
      private readonly ISimulationStateRepository _simulationStateRepository;

      public SimulationActions(ISimulationStateRepository simulationStateRepository)
      {
         _simulationStateRepository = simulationStateRepository;
      }

      public void SetSimulationState(SimulationState state)
      {
         throw new System.NotImplementedException();
      }
   }
}
