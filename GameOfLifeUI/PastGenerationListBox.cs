using System;
using System.IO.MemoryMappedFiles;
using System.Text;
using System.Threading;
using System.Windows.Automation.Provider;
using System.Windows.Forms;
using GameOfLife;

namespace GameOfLifeUI
{
   public class PastGenerationListBox : ListBox
   {
      public const string SELECTEDWORLD_MEMORY_NAME = "SelectedWorld";
      public const string SELECTEDWORLD_MUTEX_NAME = "SelectedWorldMutex";

      private MemoryMappedFile _sharedMemory;
      private Mutex _sharedMemoryMutex;

      public new World SelectedItem
      {
         get { return base.SelectedItem as World; }
         set { base.SelectedItem = value; }
      }

      public PastGenerationListBox()
      {
         _sharedMemory = MemoryMappedFile.CreateNew(SELECTEDWORLD_MEMORY_NAME, 8192);
         _sharedMemoryMutex = new Mutex(false, SELECTEDWORLD_MUTEX_NAME);
      }

      protected override void OnSelectedIndexChanged(EventArgs e)
      {
         WriteSharedMemory(SelectedItem);
         base.OnSelectedIndexChanged(e);
      }

      protected override void Dispose(bool disposing)
      {
         if (disposing)
         {
            _sharedMemoryMutex.WaitOne();

            if (_sharedMemory != null)
               _sharedMemory.Dispose();
            _sharedMemory = null;

            _sharedMemoryMutex.ReleaseMutex();

            if (_sharedMemoryMutex != null)
               _sharedMemoryMutex.Dispose();
            _sharedMemoryMutex = null;
         }
         base.Dispose(disposing);
      }

      private void WriteSharedMemory(World world)
      {
         if (!AutomationInteropProvider.ClientsAreListening) return;

         var data = WorldSerialize.SerializeWorldToString(world);

         _sharedMemoryMutex.WaitOne();
         using (var str = _sharedMemory.CreateViewStream(0, 8192))
         {
            var bytes = Encoding.ASCII.GetBytes(data);
            if (bytes.Length > 8188)
               throw new Exception("Error: the world is too big for the past generation list!");

            str.Write(BitConverter.GetBytes(bytes.Length), 0, 4);
            str.Write(bytes, 0, bytes.Length);
         }
         _sharedMemoryMutex.ReleaseMutex();
      }
   }
}
