using System;
using System.Drawing;


namespace Arkanoid3
{
    public class Peca : GameObject
    {
        private int dureza;
        private bool viva; // simboliza se a peça tem vida ou nao


        public Peca(float px, float py, int comp, int alt, float dir, float veloc, Color cor, int dureza, bool viva) : base(px, py, comp, alt, dir, veloc, cor)
        {
            
            this.dureza = dureza;
            this.viva = viva;

        }

        public int Dureza { get; set; }

        public bool Viva { get; set; }

        public override void Render(Graphics g)     // desenha um rectangulo
        {
            g.FillRectangle(new SolidBrush(this.cor), this.pX-this.comprimento/2, this.pY-this.altura/2, this.comprimento, this.altura);
        }
    }
}
