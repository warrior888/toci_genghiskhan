using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.GengisKhan.Chess.Board;

namespace Toci.GengisKhan.Chess {
    public class Figure {

        public Figure(int team_) {
            team = team_;
            color = (team == 1) ? "White" : "Black";
        }

        public const string IconBasePath = @"C:\Users\tomek\source\repos\chess\Chess\";

        protected string IconPath;

        protected string testColor;

        protected string color;

        protected int team;

        protected static List<int[]> tempCoords = new List<int[]>();
        public static List<int[]> getTempCoords() { return tempCoords; }
        public static void clearTempCoords() { tempCoords.Clear(); }
        public string getIconPath() { return IconPath; }
        public void setTeam(int team_) { team = team_; }
        public int getTeam() { return team; }
        public virtual void showAvailableMoves(ChessBoardField[,] chessBoard, ChessBoardField nowBoard) { }
        protected static void addToTempAvialable(int coordX, int coordY) {
            int[] temp = { coordX, coordY };
            tempCoords.Add(temp);
        }

    }
}
