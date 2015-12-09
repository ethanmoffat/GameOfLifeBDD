namespace GameOfLife.Services
{
   public interface ISimulationStateRepository
   {
      SimulationState CurrentState { get; set; }
   }

   public interface ISimulationStateProvider
   {
      SimulationState CurrentState { get; }
   }

   public interface ISimulationStateUpdater
   {
      SimulationState CurrentState { set; }
   }
}
