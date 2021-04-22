using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toci.GengisKhan.Chess.Board {
    public class ChessBoard {

        Button testBtn;

        const int Dimension = 8;
        const int Size = 100;

        protected ChessBoardField[,] Board = new ChessBoardField[Dimension, Dimension];

        protected Action<ChessBoardField> AddToInterface;
        protected Action<Button> AddBtnToInterface;

        public ChessBoard(Action<ChessBoardField> addToInterface, Action<Button> startBtn) {
            AddToInterface += addToInterface;
            AddBtnToInterface += startBtn;
        }

        public virtual void CreateChessBoard() {
            for (int i = 0; i < Dimension; i++) {
                for (int j = 0; j < Dimension; j++) {
                    Board[i, j] = new ChessBoardField(i, j, (i + j) % 2 == 1 ? Color.Brown : Color.AntiqueWhite);
                    Board[i, j].Size = new Size(Size, Size);
                    Board[j, i].Click += BoardClick;
                    Board[i, j].Location = new Point(Size * i, Size * j);
                    AddToInterface(Board[i, j]);
                }
            }


            testBtn = new Button();
            testBtn.Text = "ZACZNIJ GRE";
            testBtn.Size = new Size(100, 80);
            testBtn.Location = new Point(900, 600);
            testBtn.Click += startGame;
        }

        public void BoardClick(object sender, EventArgs e) {
            TestLogic.selectBoardField((ChessBoardField)sender);
        }

        private void startGame(object sender, EventArgs e) {
            TestLogic.startGame((Button)sender);
        }

    }
}
