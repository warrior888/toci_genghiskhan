using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toci.GengisKhan.Chess.Board;

namespace Toci.GengisKhan.Chess
{
    public partial class Chess : Form
    {
        public Chess()
        {
            InitializeComponent();

            ChessBoard cb = new ChessBoard(Add);
            cb.CreateChessBoard();

            this.SuspendLayout();
        }

        protected void Add(ChessBoardField field)
        {
            Controls.Add(field);
            
        }

    }
}
