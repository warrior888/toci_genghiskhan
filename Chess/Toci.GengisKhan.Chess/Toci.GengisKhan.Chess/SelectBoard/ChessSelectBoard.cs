using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toci.GengisKhan.Chess.SelectBoard {
    public class ChessSelectBoard {

        const int fieldHeight = 100;

        

        static List<string> options = new List<string>() {
            "Rook", "Pawn", "Knight", "King","Bishop" ,"Queen"
        };

        ChessBoardSelectField[,] figures = new ChessBoardSelectField[2, options.Count()];

        protected Action<ChessBoardSelectField> AddToInterface;

        public ChessSelectBoard(Action<ChessBoardSelectField> addToInterface) {
            AddToInterface += addToInterface;
        }

        public void createChessSelectBoard() {

            for (int j = 0; j < 2; j++) {
                for (int i = 0; i < options.Count; i++) {

                    int coordinateX = (j == 0) ? 900 : 1000;
                    string color_ = (j == 0) ? "White" : "Black";

                    figures[j, i] = new ChessBoardSelectField(j, i, Color.Aqua, j + 1, options[i]);
                    figures[j, i].Size = new Size(fieldHeight, fieldHeight);
                    figures[j, i].Click += selectFigure;
                    figures[j, i].Location = new Point(coordinateX, fieldHeight * i);
                    AddToInterface(figures[j, i]);
                }
            }

            Button testBtn = new Button();
            testBtn.Text = "ZACZNIJ GRE";
            testBtn.Size = new Size(100, 80);
            testBtn.Location = new Point(900, 600);
            //testBtn.Click += startGame;

            //AddToInterface(testBtn);
        }

        public void selectFigure(object sender, EventArgs e) {
            TestLogic.selectNewFigure( (ChessBoardSelectField)sender );
        }




    }
}
