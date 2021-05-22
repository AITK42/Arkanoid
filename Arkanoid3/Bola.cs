using System;
using System.Drawing;

namespace Arkanoid3
{
    public class Bola : GameObject
    {

        public Bola(float px, float py, int comp, int alt, float dir, float veloc, Color cor) : base(px, py,comp,alt, dir, veloc, cor)
        {
        }
        public override void Move()
        {
            this.pX = this.pX + this.velocidade * (float)Math.Cos(this.direcao * Math.PI / 180.0);
            this.pY = this.pY + this.velocidade * (float)Math.Sin(this.direcao * Math.PI / 180.0);
        }

        public override void Render(Graphics g)     //desenha uma circunferencia que representa a bola
        {
            g.FillEllipse(new SolidBrush(this.cor), this.pX - this.comprimento / 2, this.pY - this.altura, this.comprimento, this.altura);
        }

    }
}
