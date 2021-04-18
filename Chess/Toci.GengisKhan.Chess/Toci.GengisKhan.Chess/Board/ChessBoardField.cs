using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toci.GengisKhan.Chess.Board
{
    public class ChessBoardField : Button
    {
        protected int DimX;
        protected int DimY;

        protected Color Color;

        public ChessBoardField(int x, int y, Color color)
        {
            DimX = x;
            DimY = y;
            Color = color;
            BackColor = color;
        }
    }
}
