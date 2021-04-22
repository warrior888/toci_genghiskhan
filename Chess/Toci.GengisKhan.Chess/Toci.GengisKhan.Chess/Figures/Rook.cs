using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Toci.GengisKhan.Chess.Board;

namespace Toci.GengisKhan.Chess.Figures {
    class Rook : Queen {

        private const string figureName = "Rook.png";

        public Rook(int team_) : base(team_) {
            IconPath = IconBasePath + color + figureName;
        }

        public override void showAvailableMoves(ChessBoardField[,] chessBoard, ChessBoardField nowBoard) {
            this.showAvailableMovesRook(chessBoard, nowBoard);
        }

    }
}
