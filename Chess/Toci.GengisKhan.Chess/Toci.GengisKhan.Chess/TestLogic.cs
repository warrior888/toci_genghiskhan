using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toci.GengisKhan.Chess.Board;
using Toci.GengisKhan.Chess.SelectBoard;

namespace Toci.GengisKhan.Chess {
    class TestLogic {

        static int nowSelectedTeam = 1;

        ChessBoardField nowSelected = null;

        static bool gameStart = false;

        protected ChessBoardField clickedBoard;

        protected Figure ChosenFigure;


        public static void selectNewFigure(ChessBoardSelectField figure) {

        }


        public static void selectBoardField(ChessBoardField figure) {

        }


        public static void startGame(Button btn) {
            if (!gameStart) {
                gameStart = true;
                btn.Text = "Koniec gry";
            } else if (gameStart) {
                gameStart = false;
                //clearChessBoard();
                btn.Text = "start gry";
            }
        }

        /*public static void clearChessBoard() {

            for (int i = 0; i < 8; i++) {
                for (int j = 0; j < 8; j++) {
                    chessBoard[i, j].setDefaultColors();
                }
            }
        }*/

    }
}
