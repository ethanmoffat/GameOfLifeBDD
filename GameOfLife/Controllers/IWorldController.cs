namespace GameOfLife.Controllers
{
   public interface IWorldController
   {
      void ToggleWorldCellsAtPoints(params WorldPoint[] points);
      
      void ResetWorldCells();

      void CalculateNextGeneration();
   }
}
