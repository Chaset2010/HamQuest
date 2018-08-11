using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RLNET;
namespace HamQuest.Core {
    class Color {
        public static RLColor FloorBackground = RLColor.Black;
        public static RLColor Floor = Pallette.AlternateDarkest;
        public static RLColor FloorBackgroundFov = Pallette.DbDark;
        public static RLColor FloorFov = Pallette.Alternate;

        public static RLColor WallBackground = Pallette.SecondaryDarkest;
        public static RLColor Wall = Pallette.Secondary;
        public static RLColor WallBackgroundFov = Pallette.SecondaryDarker;
        public static RLColor WallFov = Pallette.SecondaryLighter;

        public static RLColor TextHeading = Pallette.DbLight;
    }
}
