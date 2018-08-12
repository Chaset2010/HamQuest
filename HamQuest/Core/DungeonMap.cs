using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RogueSharp;
using RLNET;

namespace HamQuest.Core {
    public class DungeonMap : Map {
        public void Draw(RLConsole mapConsole) {
            mapConsole.Clear();
            foreach (Cell cell in GetAllCells()) {
                SetConsoleSymbolForCell(mapConsole, cell);
            }
        }

        private void SetConsoleSymbolForCell(RLConsole console, Cell cell) {
            if (!cell.IsExplored) {
                return;
            }

            if (IsInFov (cell.X, cell.Y)) {
                if(cell.IsWalkable) {
                    console.Set(cell.X, cell.Y, Color.FloorFov, Color.FloorBackgroundFov, '.');
                }
                else {
                    console.Set(cell.X, cell.Y, Color.WallFov, Color.WallBackgroundFov, '#');
                }
            }
            else {
                if (cell.IsWalkable) {
                    console.Set(cell.X, cell.Y, Color.Floor, Color.FloorBackground, '.');
                }
                else {
                    console.Set(cell.X, cell.Y, Color.Wall, Color.WallBackground, '#');
                }
            }
        }

        public void UpdatePlayerFieldOfView() {
            Player player = Game.Player;

            ComputeFov(player.X, player.Y, player.Awareness, true);

            foreach(Cell cell in GetAllCells()) {
                if (IsInFov(cell.X, cell.Y)) {
                    SetCellProperties(cell.X, cell.Y, cell.IsTransparent, cell.IsWalkable, true);
                }
            }
        }
    }
}
