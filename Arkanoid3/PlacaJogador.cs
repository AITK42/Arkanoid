using System;
using System.Drawing;
using System.Runtime.InteropServices;   // para usar DLL Import
using System.Windows.Forms;

namespace Arkanoid3
{
	public class PlacaJogador : Placa
	{
		private Keys keyLeft;
		private Keys keyRight;

	
		public PlacaJogador(float px, float py, int comp, int alt, float dir, float veloc, Color cor) : base(px, py, comp, alt, dir, veloc, cor)
		{
		}

		public void SetKeys(Keys KeyLeft, Keys KeyRight)
		{
			this.keyLeft = KeyLeft;
			this.keyRight = KeyRight;
		}

		[DllImport("user32.dll")]
		public extern static Int16 GetKeyState(Int16 nVirtKey);
		private static bool IsKeyDown(Keys key)
		{
			return (GetKeyState(Convert.ToInt16(key)) & 0X80) == 0X80;
		}

		// Input do jogador
		public override void HandleKeys()
		{
			if (IsKeyDown(this.keyLeft))
			{
				this.direcao = 180f;
				this.velocidade = this.myStartVelocity;
				this.pX -= 7;
				return;
			}
			if (IsKeyDown(this.keyRight))
			{
				this.direcao = 0f;
				this.velocidade = this.myStartVelocity;
				this.pX += 7;
				return;
			}
		}
		

		public override void Render(Graphics g)     // passa a desenhar um rectangulo
		{
			g.FillRectangle(new SolidBrush(this.cor), this.pX - this.comprimento / 2, this.pY - this.altura / 2, this.comprimento, this.altura);
		}

	}// fim da classe PlacaJogador
}
