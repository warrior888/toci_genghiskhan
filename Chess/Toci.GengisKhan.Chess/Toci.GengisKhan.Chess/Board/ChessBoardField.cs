using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Toci.GengisKhan.Chess.Board {
    public class ChessBoardField : Button {
        private int DimX;
        private int DimY;

        private string IconPath;

        private int team = 0;
        private string name { get; set; }

        Figure figure;

        public ChessBoardField(int x, int y, Color color) {
            DimX = x;
            DimY = y;

            this.BackColor = color;
        }

        public Figure getFigure() { return figure; }
        public bool hasFigure() { return (figure != null) ? true : false; }
        public void setTeam(int team_) { team = team_; }
        public int getTeam() { return team; }
        public string getName() { return name; }
        public void setName(string name_) { name = name_; }
        public void setAvailableToGo() { this.BackColor = Color.Yellow; }
        public int[] getCoords() { return new[] { DimX, DimY }; }

        public void setFigure(Figure figure_) {
            if (figure_ == null) {
                removeFigure();
                return;
            }

            figure = figure_;
            team = figure.getTeam();

            IconPath = figure.getIconPath();
            Bitmap picture = new Bitmap(IconPath);

            this.Image = picture;
        }

        public void removeFigure() {
            figure = null;
            team = 0;
            name = null;
            this.Image = null;
        }

        public void resetField() {
            team = 0;
            name = "";
            IconPath = null;
            this.Image = null;

            setDefaultColors();
        }

        public void setDefaultColors() {

            if ((DimX + DimY) % 2 == 0) {
                this.BackColor = Color.AntiqueWhite;
            } else {
                this.BackColor = Color.Brown;
            }
        }

        public void BoardClick(object sender, EventArgs e) {
            TestLogic.selectBoardField((ChessBoardField)sender);
        }
    }
}
