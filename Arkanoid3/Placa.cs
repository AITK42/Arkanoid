using System;
using System.Drawing;

namespace Arkanoid3
{
	public abstract class Placa : GameObject // esta classe simboliza o jogador
	{
		protected int myStartVelocity = 15;

		public int Score { get; set; }  // autoimplemented property

		public Placa(float px, float py, int comp, int alt, float dir, float veloc, Color cor) : base(px, py, comp, alt,veloc, dir, cor)
		{
			this.Score = 0;
		}
		
		
		/// responsavel por fazer mexer o Placa na direção adequada, de acordo com o input do jogador
		public override void Move()
		{
			// so move na horizontal
			HandleKeys();
				
		}
			
		
		
		/// <summary>
		/// responsável por desenhar o Placa (rectangulo) numa imagem  
		/// </summary>
		public override void Render(Graphics g)     // passa a desenhar um rectangulo
		{
		}


		// responsável pelo tratamento de dados de entrada (teclas)
		public virtual void HandleKeys()
		{
		}

	}// fim da classe Placa

}

