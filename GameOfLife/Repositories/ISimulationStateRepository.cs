namespace GameOfLife.Services
{
   public interface ISimulationStateRepository
   {
      SimulationState CurrentState { get; set; }

      int SimulationDelay { get; set; }
   }

   public interface ISimulationStateProvider
   {
      SimulationState CurrentState { get; }

      int SimulationDelay { get; }
   }

   public interface ISimulationStateUpdater
   {
      SimulationState CurrentState { set; }

      int SimulationDelay { set; }
   }
}
