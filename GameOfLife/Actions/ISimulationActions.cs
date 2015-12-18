namespace GameOfLife.Actions
{
   public interface ISimulationActions
   {
      void SetSimulationState(SimulationState state);
      
      void SetDelay(int delay);
   }
}
