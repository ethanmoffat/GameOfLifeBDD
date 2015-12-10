﻿namespace GameOfLife.Services
{
   public class SimulationStateRepository : ISimulationStateRepository, 
                                            ISimulationStateProvider,
                                            ISimulationStateUpdater
   {
      public SimulationState CurrentState { get; set; }
   }
}
