namespace GameOfLife.Services
{
   public interface IWorldPersistenceService
   {
      FileError LoadWorldFromFile(string fileName, FileVersion version, out World world);

      FileError SaveWorldToFile(string fileName, FileVersion version, World world);
   }
}
