using System;
using System.Windows.Forms;
using GameOfLife.Actions;
using GameOfLife.Controllers;
using GameOfLife.Services;

namespace GameOfLifeUI
{
   static class Program
   {
      /// <summary>
      /// The main entry point for the application.
      /// </summary>
      [STAThread]
      static void Main()
      {
         //This is kind of like an IOC container, but without the IOC container
         var worldRepository = new WorldRepository();
         var worldPersistenceService = new WorldPersistenceService();
         var worldActions = new WorldActions(worldRepository);
         var worldController = new WorldController(worldActions, worldPersistenceService);
         var simulationRepo = new SimulationStateRepository();
         var simulationActions = new SimulationActions(simulationRepo);
         var simulationController = new SimulationController(simulationActions);

         Application.EnableVisualStyles();
         Application.SetCompatibleTextRenderingDefault(false);
         Application.Run(new MainForm(worldController, 
                                      simulationController,
                                      worldRepository,
                                      simulationRepo));
      }
   }
}
