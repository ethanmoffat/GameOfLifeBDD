using System;
using GameOfLife.Services;

namespace GameOfLife.Actions
{
   public class SimulationActions : ISimulationActions
   {
      private readonly ISimulationStateRepository _simulationStateRepository;

      public SimulationActions(ISimulationStateRepository simulationStateRepository)
      {
         _simulationStateRepository = simulationStateRepository;
      }

      public void SetSimulationState(SimulationState state)
      {
         if (!ValidateState(state))
            throw new ArgumentException("Invalid state requested", "state");

         _simulationStateRepository.CurrentState = state;
      }

      private bool ValidateState(SimulationState nextState)
      {
         var current = _simulationStateRepository.CurrentState;

         switch (nextState)
         {
            case SimulationState.Initial:
               return current != SimulationState.Initial;
            case SimulationState.Running:
               return current != SimulationState.Running;
            case SimulationState.Paused:
               return current == SimulationState.Running;
         }

         return false;
      }
   }
}
