using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.GengisKhan.Chess.Board;

namespace Toci.GengisKhan.Chess.Figures {
    class Queen : Figure {

        private const string figureName = "Queen.png";

        public Queen(int team_) : base(team_) {
            IconPath = IconBasePath + color + figureName;
        }

        public override void showAvailableMoves(ChessBoardField[,] chessBoard, ChessBoardField nowBoard) {
            showAvailableMovesRook(chessBoard, nowBoard);
            showAvailableMovesBishop(chessBoard, nowBoard);
        }

        public void showAvailableMovesRook(ChessBoardField[,] chessBoard, ChessBoardField nowBoard) {

            List<int[]> tempCoords = new List<int[]>();

            tempCoords.Add(new int[] { -1, 0 });
            tempCoords.Add(new int[] { 1, 0 });
            tempCoords.Add(new int[] { 0, 1 });
            tempCoords.Add(new int[] { 0, -1 });

            testLoop(chessBoard, nowBoard, tempCoords); // change name testLoop
        }

        public void showAvailableMovesBishop(ChessBoardField[,] chessBoard, ChessBoardField nowBoard) {

            List<int[]> tempCoords = new List<int[]>();

            tempCoords.Add(new int[] { 1, -1 });
            tempCoords.Add(new int[] { 1, 1 });
            tempCoords.Add(new int[] { -1, 1 });
            tempCoords.Add(new int[] { -1, -1 });

            testLoop(chessBoard, nowBoard, tempCoords);
        }

        public void testLoop(ChessBoardField[,] chessBoard, ChessBoardField nowBoard, List<int[]> array) {

            int tempCoordX, tempCoordY;
            int[] coords = nowBoard.getCoords();
            bool found;

            array.ForEach((coords_) => {

                tempCoordX = coords[0];
                tempCoordX += coords_[0];

                tempCoordY = coords[1];
                tempCoordY += coords_[1];

                found = false;
                while (tempCoordX > -1 && tempCoordX < 8 && tempCoordY > -1 && tempCoordY < 8 && !found) {
                    if (chessBoard[tempCoordX, tempCoordY].getTeam() == 0) {
                        chessBoard[tempCoordX, tempCoordY].setAvailableToGo();
                        addToTempAvialable(tempCoordX, tempCoordY);
                    } else {
                        if (nowBoard.getTeam() != chessBoard[tempCoordX, tempCoordY].getTeam()) {
                            chessBoard[tempCoordX, tempCoordY].setAvailableToGo();
                            addToTempAvialable(tempCoordX, tempCoordY);
                        }

                        found = true;
                    }

                    tempCoordX += coords_[0];
                    tempCoordY += coords_[1];
                }

            });

        }


    }
}
