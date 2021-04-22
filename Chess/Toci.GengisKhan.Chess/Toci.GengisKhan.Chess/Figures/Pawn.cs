using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.GengisKhan.Chess.Board;

namespace Toci.GengisKhan.Chess.Figures {
    class Pawn : Figure {

        private const string figureName = "Pawn.png";

        private bool firstMove = true;

        public Pawn(int team_) : base(team_) {
            IconPath = IconBasePath + color + figureName;
        }

        public override void showAvailableMoves(ChessBoardField[,] chessBoard, ChessBoardField nowBoard) {

            var direction = (nowBoard.getTeam() == 1) ? "UP" : "DOWN";

            int[] coords = nowBoard.getCoords();

            if (direction == "UP") {
                if (coords[1] == 0) return;

                coords[1] -= 1;
                if (coords[1] < 0) coords[1] = 0;

            } else if (direction == "DOWN") {
                if (coords[1] == 7) return;

                coords[1] += 1;
                if (coords[1] > 7) coords[1] = 8;
            }


            if (chessBoard[coords[0], coords[1]].getTeam() == 0) {
                chessBoard[coords[0], coords[1]].setAvailableToGo();

                tempCoords.Add(new int[] { coords[0], coords[1] });
            }



            int tempRight = coords[0] + 1;
            if (tempRight <= 7 && chessBoard[tempRight, coords[1]].hasFigure() &&
                chessBoard[tempRight, coords[1]].getTeam() != nowBoard.getTeam()) {

                chessBoard[tempRight, coords[1]].setAvailableToGo();
                tempCoords.Add(new int[] { tempRight, coords[1] });
            }



            int tempLeft = coords[0] - 1;
            if (tempLeft >= 0 && chessBoard[tempLeft, (coords[1])].hasFigure() &&
                chessBoard[tempLeft, coords[1]].getTeam() != nowBoard.getTeam()) {

                chessBoard[tempLeft, coords[1]].setAvailableToGo();
                tempCoords.Add(new int[] { tempLeft, coords[1] });
            }


            if (firstMove) {
                coords[1] += (direction == "UP") ? -1 : 1;
                if (coords[1] < 0) coords[1] = 0;

                if (chessBoard[coords[0], coords[1]].getTeam() == 0) {
                    chessBoard[coords[0], coords[1]].setAvailableToGo();

                    tempCoords.Add(new int[] { coords[0], coords[1] });
                }

                firstMove = false;
            }

        }

    }
}
