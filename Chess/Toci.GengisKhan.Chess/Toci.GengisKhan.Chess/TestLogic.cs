using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toci.GengisKhan.Chess.Board;
using Toci.GengisKhan.Chess.SelectBoard;

namespace Toci.GengisKhan.Chess {
    public class TestLogic {

        static int nowSelectedTeam = 1;

        static ChessBoardField nowSelected = null;

        static bool gameStart = false;

        protected static ChessBoardSelectField choosenFigureToAdd;

        protected static ChessBoardField clickedBoard;

        protected static Figure ChosenFigure;

        static ChessBoard chessBoard;


        public static void setBoardFields(ChessBoard chessBoard_) {
            chessBoard = chessBoard_;
        }

        public static void selectNewFigure(ChessBoardSelectField selectField_) {
            choosenFigureToAdd = selectField_;
        }

        public static bool TryToSelectTheSameFigure() {

            return (nowSelected.getCoords()[0] == clickedBoard.getCoords()[0]
                    && nowSelected.getCoords()[1] == clickedBoard.getCoords()[1])
                ? true : false;
        }

        public static void makeMove() {

            int[] coords = clickedBoard.getCoords();

            var tempAvailableMoves = Figure.getTempCoords();

            var x = tempAvailableMoves.Find(x => { return x[0] == coords[0] && x[1] == coords[1]; });

            if (x == null) return; // hit on not available field

            clearHighlightedFields();


            ChosenFigure = nowSelected.getFigure();

            clickedBoard.setFigure(ChosenFigure);

            nowSelected.setFigure(null);

            nowSelected = null;

            nowSelectedTeam = (nowSelectedTeam == 1) ? 2 : 1;

            Figure.clearTempCoords();

        }

        public static void clearHighlightedFields() {

            Figure.getTempCoords().ForEach((x) => {
                chessBoard.GetBoardField(x[0], x[1]).setDefaultColors();
            });
        }

        private static void showAvailableMoves() {

            Figure tempFigure = nowSelected.getFigure();

            tempFigure.showAvailableMoves(chessBoard.GetChessBoardField(), nowSelected);
        }


        public static void selectBoardField(ChessBoardField nowClickedBoard) {
            clickedBoard = nowClickedBoard;

            if(gameStart) {

                if(nowSelected == null) {

                    if (!nowClickedBoard.hasFigure()) return;

                    if (nowClickedBoard.getTeam() != nowSelectedTeam) return;

                    nowSelected = nowClickedBoard;

                    showAvailableMoves();

                } else if(nowSelected != null) {

                    if(TryToSelectTheSameFigure()) {
                        nowSelected = null;

                        clearHighlightedFields();
                        Figure.clearTempCoords();

                        return;
                    }

                    makeMove();

                }

            } else {

                if(clickedBoard != null) {
                    Figure newFigure = choosenFigureToAdd.generateFigure();
                    nowClickedBoard.setFigure(newFigure);
                }
                
            }
        }

        public static void startGame(Button btn) {
            if (!gameStart) {
                gameStart = true;
                btn.Text = "Koniec gry";
            } else if (gameStart) {
                gameStart = false;
                btn.Text = "start gry";
            }
        }

    }
}
