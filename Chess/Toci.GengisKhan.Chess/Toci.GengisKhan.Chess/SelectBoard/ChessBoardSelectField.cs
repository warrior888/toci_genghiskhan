using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Toci.GengisKhan.Chess.Figures;

namespace Toci.GengisKhan.Chess.SelectBoard {
    public class ChessBoardSelectField : Button {

        protected int DimX;
        protected int DimY;
        protected string IconPath;

        private int team;
        public string name { get; set; }

        Figure figure;

        public ChessBoardSelectField(int x, int y, Color color, int team_, string name_) {
            DimX = x;
            DimY = y;

            team = team_;
            name = name_;

            this.BackColor = color;

            figure = FigureFactory.createCharacter(name, team);

            Bitmap picture = new Bitmap(figure.getIconPath());

            this.Image = picture;
        }



        public void createChessBoardSelectField() {

        }

        public Figure generateFigure() {
            return FigureFactory.createCharacter(name, team);
        }
    }
}
