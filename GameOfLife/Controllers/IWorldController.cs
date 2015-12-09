namespace GameOfLife.Controllers
{
   public interface IWorldController
   {
      void SeedWorld(params WorldPoint[] points);
      
      void ResetWorld();

      void CalculateNextGeneration();
   }
}
