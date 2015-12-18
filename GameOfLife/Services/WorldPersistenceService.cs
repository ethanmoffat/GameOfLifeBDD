using System;
using System.IO;

namespace GameOfLife.Services
{
   public class WorldPersistenceService : IWorldPersistenceService
   {
      public FileError LoadWorldFromFile(string fileName, FileVersion version, out World world)
      {
         world = null;

         if (!File.Exists(fileName))
            return FileError.FileDoesNotExist;

         switch (version)
         {
            case FileVersion.PlainText: return LoadPlainText(fileName, out world);
            case FileVersion.BinaryEncoded: return LoadBinary(fileName, out world);
            default: return FileError.InvalidVersion;
         }
      }

      public FileError SaveWorldToFile(string fileName, FileVersion version, World world)
      {
         if (File.Exists(fileName))
         {
            var attr = File.GetAttributes(fileName);
            if ((attr & FileAttributes.ReadOnly) != 0)
               return FileError.FileIsReadOnly;
            if ((attr & FileAttributes.Directory) != 0)
               return FileError.FileIsDirectory;
         }

         switch (version)
         {
            case FileVersion.PlainText: return SavePlainText(fileName, world);
            case FileVersion.BinaryEncoded: return SaveBinary(fileName, world);
            default: return FileError.InvalidVersion;
         }
      }

      private FileError LoadPlainText(string fileName, out World world)
      {
         World localWorld = null; //Can't access ref/out param in anonymous lambda

         var ret = TryLoadOrSave(() =>
         {
            var allText = File.ReadAllText(fileName);
            localWorld = WorldSerialize.DeserializeWorldFromString(allText);
         });

         world = localWorld;
         return ret;
      }

      private FileError SavePlainText(string fileName, World world)
      {
         return TryLoadOrSave(() =>
         {
            var text = WorldSerialize.SerializeWorldToString(world);
            File.WriteAllText(fileName, text);
         });
      }

      private FileError LoadBinary(string fileName, out World world)
      {
         throw new NotImplementedException();
      }

      private FileError SaveBinary(string fileName, World world)
      {
         throw new NotImplementedException();
      }

      private FileError TryLoadOrSave(Action action)
      {
         try
         {
            action();
         }
         catch (ArgumentException)
         {
            return FileError.InvalidFileName;
         }
         catch (PathTooLongException)
         {
            return FileError.InvalidFileName;
         }
         catch (DirectoryNotFoundException)
         {
            return FileError.InvalidDirectory;
         }
         catch (Exception)
         {
            return FileError.UnspecifiedIOError;
         }

         return FileError.None;
      }
   }
}
