using System;
using System.Windows.Automation;
using System.Windows.Automation.Provider;
using System.Windows.Forms;
using AEI = System.Windows.Automation.AutomationElementIdentifiers;

namespace GameOfLifeUI
{
   //documentation for automation: https://msdn.microsoft.com/en-us/library/ms752044(v=vs.110).aspx
   public partial class WorldGrid : IRawElementProviderSimple
   {
      public const string ITEMSTATUS_LOCKED = "locked";
      public const string ITEMSTATUS_UNLOCKED = "unlocked";
      public const string ITEMSTATUS_MODIFIED = "modified";
      public const string ITEMSTATUS_RESET = "reset";

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
         if (patternId == GridPatternIdentifiers.Pattern.Id ||
             patternId == TablePatternIdentifiers.Pattern.Id ||
             patternId == SelectionPatternIdentifiers.Pattern.Id)
            return new WorldGridProvider(this);
         return null;
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
                  propertyId == AEI.IsContentElementProperty.Id ||
                  propertyId == AEI.IsSelectionPatternAvailableProperty.Id ||
                  propertyId == AEI.IsTablePatternAvailableProperty.Id)
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
         /*WM_GETOBJECT*/
         if (m.Msg == 0x003D && m.LParam.ToInt32() == AutomationInteropProvider.RootObjectId)
         {
            m.Result = AutomationInteropProvider.ReturnRawElementProvider(Handle, m.WParam, m.LParam, this);
            return;
         }
         base.WndProc(ref m);
      }

      private void FireAutomationEvent(GridAutomationEventType @event)
      {
         if (!AutomationInteropProvider.ClientsAreListening) return;

         AutomationPropertyChangedEventArgs args;
         switch (@event)
         {
            case GridAutomationEventType.LockAllCells:
               args = new AutomationPropertyChangedEventArgs(AEI.ItemStatusProperty, ITEMSTATUS_UNLOCKED, ITEMSTATUS_LOCKED);
               break;
            case GridAutomationEventType.UnlockAllCells:
               args = new AutomationPropertyChangedEventArgs(AEI.ItemStatusProperty, ITEMSTATUS_LOCKED, ITEMSTATUS_UNLOCKED);
               break;
            case GridAutomationEventType.ResetAllCells:
               args = new AutomationPropertyChangedEventArgs(AEI.ItemStatusProperty, ITEMSTATUS_MODIFIED, ITEMSTATUS_RESET);
               break;
            default:
               throw new ArgumentOutOfRangeException("event", @event, null);
         }
         AutomationInteropProvider.RaiseAutomationPropertyChangedEvent(this, args);
      }
   }
}
