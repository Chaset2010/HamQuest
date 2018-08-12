using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HamQuest.Core;
using HamQuest.Systems;
using RLNET;

namespace HamQuest {
    public class Game {

        public static DungeonMap DungeonMap { get; private set; }
        public static Player Player { get; private set; }

        private static readonly int _screenWidth = 100;
        private static readonly int _screenHeight = 70;
        private static RLRootConsole _rootConsole;

        private static readonly int _mapWidth = 80;
        private static readonly int _mapHeight = 48;
        private static RLConsole _mapConsole;

        private static readonly int _messageWidth = 80;
        private static readonly int _messageHeight = 11;
        private static RLConsole _messageConsole;

        private static readonly int _statWidth = 20;
        private static readonly int _statHeight = 70;
        private static RLConsole _statConsole;

        private static readonly int _inventoryWidth = 80;
        private static readonly int _inventoryHeight = 11;
        private static RLConsole _inventoryConsole;

        public static void Main() {
            string fontFileName = "terminal8x8.png";
            string consoleTitle = "RogueSharp V3 Tutorial - Level 1";

            _rootConsole = new RLRootConsole(fontFileName, _screenWidth, _screenHeight, 8, 8, 1f, consoleTitle);

            _mapConsole = new RLConsole(_mapWidth, _mapHeight);
            _messageConsole = new RLConsole(_messageWidth, _messageHeight);
            _statConsole = new RLConsole(_statWidth, _statHeight);
            _inventoryConsole = new RLConsole(_inventoryWidth, _inventoryHeight);

            _rootConsole.Update += OnRootConsoleUpdate;

            _rootConsole.Render += OnRootConsoleRender;

            Player = new Player();

            MapGenerator mapGenerator = new MapGenerator(_mapWidth, _mapHeight);
            DungeonMap = mapGenerator.CreateMap();

            DungeonMap.UpdatePlayerFieldOfView();

            _rootConsole.Run();
        }

        private static void OnRootConsoleUpdate(object sender, UpdateEventArgs e) {
            _mapConsole.SetBackColor(0, 0, _mapWidth, _mapHeight, Color.FloorBackground);
            _mapConsole.Print(1, 1, "", Color.TextHeading);

            _messageConsole.SetBackColor(0, 0, _messageWidth, _messageHeight, Pallette.DbDeepWater);
            _messageConsole.Print(1, 1, "Messages", Color.TextHeading);

            _statConsole.SetBackColor(0, 0, _statWidth, _statHeight, Pallette.DbOldStone);
            _statConsole.Print(1, 1, "Stats", Color.TextHeading);

            _inventoryConsole.SetBackColor(0, 0, _inventoryWidth, _inventoryHeight, Pallette.DbWood);
            _inventoryConsole.Print(1, 1, "Inventory", Color.TextHeading);
        }

        private static void OnRootConsoleRender(object sender, UpdateEventArgs e) {
            RLConsole.Blit(_mapConsole, 0, 0, _mapWidth, _mapHeight, _rootConsole,
                0, _inventoryHeight);
            RLConsole.Blit(_statConsole, 0, 0, _statWidth, _statHeight, _rootConsole,
                _mapWidth, 0);
            RLConsole.Blit(_messageConsole, 0, 0, _messageWidth, _messageHeight, _rootConsole,
                0, _screenHeight - _messageHeight);
            RLConsole.Blit(_inventoryConsole, 0, 0, _inventoryWidth, _inventoryHeight, _rootConsole,
                0, 0);

            _rootConsole.Draw();

            DungeonMap.Draw(_mapConsole);
            Player.Draw(_mapConsole, DungeonMap);
        }
    }
}


