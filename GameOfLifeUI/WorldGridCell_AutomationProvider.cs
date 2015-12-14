using System;
using System.Windows.Automation;
using System.Windows.Automation.Provider;
using System.Windows.Forms;
using AEI = System.Windows.Automation.AutomationElementIdentifiers;

namespace GameOfLifeUI
{
   //todo: follow these instructions https://msdn.microsoft.com/en-us/library/ms742561(v=vs.110).aspx
   partial class WorldGridCell : IRawElementProviderSimple
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
         if (patternId == GridItemPatternIdentifiers.Pattern.Id ||
             patternId == TableItemPatternIdentifiers.Pattern.Id ||
             patternId == SelectionItemPatternIdentifiers.Pattern.Id ||
             patternId == TogglePatternIdentifiers.Pattern.Id)
            return new WorldGridCellProvider(this, _parentGrid);
         return null;
      }

      public object GetPropertyValue(int propertyId)
      {
         object retObj = null;

         if (propertyId == AEI.NameProperty.Id)
            retObj = string.Format("Grid Cell {0}, {1}", Row, Column);
         else if (propertyId == AEI.ControlTypeProperty.Id)
            retObj = ControlType.DataItem.Id;
         else if (propertyId == AEI.IsGridItemPatternAvailableProperty.Id ||
                  propertyId == AEI.IsTableItemPatternAvailableProperty.Id ||
                  propertyId == AEI.IsSelectionItemPatternAvailableProperty.Id ||
                  propertyId == AEI.IsTogglePatternAvailableProperty.Id ||
                  propertyId == AEI.IsControlElementProperty.Id ||
                  propertyId == AEI.IsContentElementProperty.Id)
            retObj = true;
         else if (propertyId == AEI.ClassNameProperty.Id)
            retObj = "WorldGridCell";
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
