namespace GameOfLife.Actions
{
   public interface IWorldActions
   {
      void SetCellsAlive(params WorldPoint[] points);

      void SetCellsDead(params WorldPoint[] points);

      void SetAllCellsDead();

      World GetNextGenerationFromCurrentWorld();

      void AddPastGeneration(World pastGenerationOfWorld);
   }
}
