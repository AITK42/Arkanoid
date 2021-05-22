using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Arkanoid3
{
	public abstract class GameObject
	{
		public float pX;
		public float pY;
		public int comprimento;
		public int altura;
		public Color cor;
		public float direcao;
		public float velocidade;

		// Construtor
		protected GameObject(float px, float py, int comp, int alt, float dir, float veloc, Color cor)
		{
			this.pX = px; this.pY = py;
			this.comprimento = comp; 
			this.altura = alt;
			this.cor = cor;
			this.velocidade = veloc;
			this.direcao = dir;
		}
		

		// para ser redefinido nas subclasses
		public virtual void Move()
		{
		}

		// para ser redefinido nas subclasses
		public virtual void Render(Graphics g)
		{
		}

		// verifica se um gameobject interseta com outro
		public virtual bool IntersectsWith(GameObject other)
		{
			if (other.pX - other.comprimento / 2 < this.pX + this.comprimento / 2 &&
				   this.pX - this.comprimento / 2 < other.pX + other.comprimento / 2 &&
					 other.pY - other.altura / 2 < this.pY + this.altura / 2 &&
						 this.pY - this.altura / 2 < other.pY + other.altura / 2)
				return true;
			else
				return false;
		}

		// verifica se um gameobject interseta com a matriz de pecas
        public virtual bool IntersectMatrix(Peca[,] pecas) //vai ser sempre uma matriz de 15 por 6
        {
			bool teste = false;
			for(int i = 0; i<6; i++)
            {
				for(int j = 0; j<15; j++) 
                {
					if (pecas[i,j].pX - pecas[i,j].comprimento / 2 < this.pX + this.comprimento / 2 &&
						 this.pX - this.comprimento / 2 < pecas[i,j].pX + pecas[i,j].comprimento / 2 &&
							 pecas[i,j].pY - pecas[i,j].altura / 2 < this.pY + this.altura / 2 &&
							 this.pY - this.altura / 2 < pecas[i,j].pY + pecas[i,j].altura / 2)
                    {
                        if (!pecas[i,j].Viva) //se a peca tiver dureza 0, vai ignorá-la
                        {
							int d = pecas[i,j].Dureza; 
							d--;
							teste = true;
							pecas[i,j].Dureza = d; //a medida que a bola vai atingindo as pecas, a dureza vai "diminuindo"

							if (pecas[i,j].Dureza == -3) //se chegar a "dureza = 0"
							{
								pecas[i,j].Viva = true;
								teste = false;

							}
						}
						


					}
						
				}
            }
			return teste;
        }




	}// fim da classe GameObject

}
