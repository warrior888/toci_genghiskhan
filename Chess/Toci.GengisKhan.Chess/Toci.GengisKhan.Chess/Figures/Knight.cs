using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.GengisKhan.Chess.Board;

namespace Toci.GengisKhan.Chess.Figures {
    class Knight : Figure {

        private const string figureName = "Knight.png";

        public Knight(int team_) : base(team_) {
            IconPath = IconBasePath + color + figureName;
        }

        public override void showAvailableMoves(ChessBoardField[,] chessBoard, ChessBoardField nowBoard) {

            int[] coords = nowBoard.getCoords();

            List<int[]> tempCoords = new List<int[]>();

            tempCoords.Add(new int[] { (coords[0] + 2), (coords[1] + 1) });
            tempCoords.Add(new int[] { (coords[0] + 2), (coords[1] - 1) });
            tempCoords.Add(new int[] { (coords[0] - 2), (coords[1] + 1) });
            tempCoords.Add(new int[] { (coords[0] - 2), (coords[1] - 1) });

            tempCoords.Add(new int[] { (coords[0] + 1), (coords[1] + 2) });
            tempCoords.Add(new int[] { (coords[0] + 1), (coords[1] - 2) });
            tempCoords.Add(new int[] { (coords[0] - 1), (coords[1] + 2) });
            tempCoords.Add(new int[] { (coords[0] - 1), (coords[1] - 2) });


            tempCoords.ForEach((coords_) => {

                if (coords_[0] <= 7 && coords_[0] >= 0 && coords_[1] <= 7 && coords_[1] >= 0) {

                    if (chessBoard[coords_[0], coords_[1]].getTeam() != nowBoard.getTeam()) {

                        chessBoard[coords_[0], coords_[1]].setAvailableToGo();

                        addToTempAvialable(coords_[0], coords_[1]);
                    }
                }

            });

        }
    }
}
