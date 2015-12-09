namespace GameOfLife.Controllers
{
   public interface ISimulationController
   {
      void RunSimulation();
      
      void PauseSimulation();
      
      void ResumeSimulation();

      void ResetSimulation();
   }
}
