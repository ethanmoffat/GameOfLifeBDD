using System;
using System.Windows.Automation;
using System.Windows.Automation.Provider;
using System.Windows.Forms;
using AEI = System.Windows.Automation.AutomationElementIdentifiers;

namespace GameOfLifeUI
{
   //todo: follow these instructions https://msdn.microsoft.com/en-us/library/ms752044(v=vs.110).aspx
   public partial class WorldGrid : IRawElementProviderSimple
   {
      public ProviderOptions ProviderOptions
      {
         get { return ProviderOptions.ServerSideProvider | ProviderOptions.UseComThreading; }
      }

      public IRawElementProviderSimple HostRawElementProvider
      {
         get { return Handle == IntPtr.Zero ? null : AutomationInteropProvider.HostProviderFromHandle(Handle); }
      }

      public object GetPatternProvider(int patternId)
      {
         return patternId == GridPatternIdentifiers.Pattern.Id ? new WorldGridPattern(this) : null;
      }

      public object GetPropertyValue(int propertyId)
      {
         object retObj = null;

         if (propertyId == AEI.NameProperty.Id)
            retObj = "Game of Life World Grid";
         else if (propertyId == AEI.ControlTypeProperty.Id)
            retObj = ControlType.DataGrid.Id;
         else if (propertyId == AEI.IsGridPatternAvailableProperty.Id || 
                  propertyId == AEI.IsControlElementProperty.Id ||
                  propertyId == AEI.IsSelectionPatternAvailableProperty.Id)
            retObj = true;
         else if (propertyId == AEI.ClassNameProperty.Id)
            retObj = "WorldGrid";
         else if (propertyId == AEI.BoundingRectangleProperty.Id)
            retObj = Bounds;
         else if (propertyId == AEI.IsKeyboardFocusableProperty.Id)
            retObj = false;

         return retObj;
      }

      protected override void WndProc(ref Message m)
      {
         if (m.Msg == 0x003D /*WM_GETOBJECT*/&& m.LParam.ToInt32() == AutomationInteropProvider.RootObjectId)
         {
            m.Result = AutomationInteropProvider.ReturnRawElementProvider(Handle, m.WParam, m.LParam, this);
            return;
         }
         base.WndProc(ref m);
      }
   }
}
