using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.GengisKhan.Chess.Board
{
    public class ChessBoard
    {
        const int Dimension = 8;
        const int Size = 100;

        protected ChessBoardField[,] Board = new ChessBoardField[Dimension, Dimension];

        protected Action<ChessBoardField> AddToInterface;

        public ChessBoard(Action<ChessBoardField> addToInterface)
        {
            AddToInterface += addToInterface;
        }

        public virtual void CreateChessBoard()
        {
            for (int i = 0; i < Dimension; i++)
            {
                for (int j = 0; j < Dimension; j++)
                {
                    Board[i, j] = new ChessBoardField(i, j, (i+j) %2 == 1 ? Color.Brown : Color.AntiqueWhite);
                    Board[i, j].Size = new Size(Size, Size);
                    Board[i, j].Location = new Point(Size * i, Size * j);
                    AddToInterface(Board[i, j]);
                }
            }
        }
    }
}
