using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Toci.GengisKhan.Chess.Figures {
    class FigureFactory {

        public static Figure createCharacter(string name, int team) {

            if (name == "Pawn") {
                return new Pawn(team);
            } else if (name == "Rook") {
                return new Rook(team);
            } else if (name == "Knight") {
                return new Knight(team);
            } else if (name == "King") {
                return new King(team);
            } else if (name == "Bishop") {
                return new Bishop(team);
            } else if (name == "Queen") {
                return new Queen(team);
            }

            return null;
        }

    }
}
