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
using Toci.GengisKhan.Chess.SelectBoard;

namespace Toci.GengisKhan.Chess {
    public partial class Chess : Form {

        protected void Add(ChessBoardField field) { Controls.Add(field); }
        protected void AddSelect(ChessBoardSelectField field) { Controls.Add(field); }

        protected void AddStartBtn(Button startBtn) { Controls.Add(startBtn); }

        public Chess() {
            InitializeComponent();

            ChessBoard cb = new ChessBoard(Add, AddStartBtn);
            cb.CreateChessBoard();

            ChessSelectBoard cbs = new ChessSelectBoard(AddSelect);
            cbs.createChessSelectBoard();

            TestLogic.setBoardFields(cb);

            this.SuspendLayout();
        }


    }
}
