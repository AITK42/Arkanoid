using System;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Arkanoid3
{
	public class Game
	{


		public enum GameStatus { NOTREADY = 0, READY, PAUSE, ONGOING, ENDED };  //estados do jogo
		public static int frames = 0;

		private int comprimento;
		private int altura;
		private Bola bola;
		private int numVidas;
		private PlacaJogador Jogador;
		private Peca[,] pecas = new Peca[6,15];
		private GameStatus status = GameStatus.NOTREADY;



		//Construtor
		public Game(int comp, int alt, int numVidas)
		{
			this.comprimento = comp;
			this.altura = alt;
			this.bola = new Bola(comp / 2, alt / 2, 15, 15, 90, 12, Color.Yellow);
			this.numVidas = numVidas;
			
			// Jogador
			PlacaJogador aux;
			aux = new PlacaJogador(comp/2, alt-15,100,20,0,24,Color.Blue);
			aux.SetKeys(Keys.Left, Keys.Right);
			this.Jogador = aux;
	
			//Pecas
			Color[] cores = { Color.Red, Color.Orange, Color.Yellow, Color.Green, Color.Blue, Color.Purple }; //cores disponiveis para as pecas
			int[] dureza = {6,5,4,3,2,1}; //diferentes durezas das pecas
			int c = -1; //indice para percorrer os indices de durezas e cor
			int x = 0;
			int y = this.altura - 350;
			
			for (int i = 0; i < 6; i++)
			{
				c++;
				y -= 23;
				x = 60;
				for (int j = 0; j < 15 ; j++)
				{
					this.pecas[i,j] = new Peca(x, y, 45, 20,0, 0, cores[c], dureza[c],true);
					x += 46;
				}
			}


			Game.frames = 0;
			this.status = GameStatus.READY;


		}


		public GameStatus Status
		{
			get
			{
				return this.status;
			}
		}


		public void Start()
		{
			this.status = GameStatus.ONGOING;
		}

		public void Stop()
		{
			this.status = GameStatus.ENDED;
		}

		public void PauseStart()
		{
			if (this.status == GameStatus.PAUSE)
				this.status = GameStatus.ONGOING;
			else
				this.status = GameStatus.PAUSE;
		}


		// tratamento do input do Jogador
		public void HandleKeys()
		{
			this.Jogador.HandleKeys();
		}




		// Mtodo de atualizacao do estado do jogo
		public GameStatus Update()
		{
			if (this.status != GameStatus.ONGOING)
				return this.Status;

			this.bola.Move();
			this.Jogador.Move();

			// verificar se bola bate na parede esquerda
			if (this.bola.pX < 0 )
			{
				this.bola.direcao = -this.bola.direcao+180; //muda a direcao para a bola voltar para dentro do ecran
				this.bola.Move();           
			}
			
			// verificar se bola bate na parede de cima
			if (this.bola.pY < 0)
			{
				this.bola.direcao = this.bola.direcao+180;
				this.bola.Move();           
			}
			
			// verificar se bola bate na parede direita
			if (this.bola.pX > this.comprimento )
			{
				this.bola.direcao = -this.bola.direcao-180;
				this.bola.Move();
			}


			// verificar se bola bate na placa do jogador
			if (this.bola.IntersectsWith(this.Jogador) == true)
			{
				//Leis da reflexao de angulos
				this.bola.direcao = (360 - bola.direcao) % 360; 
				this.bola.direcao += new Random().Next(20) - 10;
				
				if (this.bola.direcao > 75 && this.bola.direcao <= 90)
					this.bola.direcao = 75;
				if (this.bola.direcao > 270 && this.bola.direcao < 285)
					this.bola.direcao = 285;
			}

			//verificar se a bola bate numa das pecas
			if (this.bola.IntersectMatrix(this.pecas) == true)
            {
				this.bola.direcao = (360 - bola.direcao) % 360;
				this.bola.direcao += new Random().Next(20) - 10; 
				this.bola.pX = this.bola.pX + this.bola.comprimento / 2 + this.bola.comprimento / 2;

				int score = this.Jogador.Score + 10; //atualiza o score do jogador
				this.Jogador.Score = score;
			}

			// se a placa sair dos limites x=0 e x=comprimento
			if (this.Jogador.pX < 0) this.Jogador.pX = 50;
			if (this.Jogador.pX > this.comprimento) this.Jogador.pX = this.comprimento- 50;


			
			//verifica se há perda de vidas
			if (this.bola.pY > altura)  // perda de vida
			{
				//Da "reset" ao jogo
				this.numVidas--;
				this.bola = new Bola(this.comprimento / 2, this.altura / 2, 16, 16, 90, 12, Color.Yellow);
				PlacaJogador aux;
				aux = new PlacaJogador(this.comprimento/2, this.altura-15,100,20,0,24,Color.Blue);
				aux.SetKeys(Keys.Left, Keys.Right);
				this.Jogador = aux;
				
				if (this.numVidas == 0) //se nao houver mais vidas -> Game Over
					this.status = GameStatus.ENDED;
				Thread.Sleep(1000); //espera uns segundos ate dar reset
				return this.Status;
			}


			return this.Status;

		}

		public Image RenderFrame()
		{
			if (this.status == GameStatus.NOTREADY)
				return null;

			// desenhar campo, barras, score, bola e vidas
			Pen pen1 = new Pen(Color.DarkGray, 5);
			pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;
			SolidBrush brush1 = new SolidBrush(Color.Black);

			Image img = new Bitmap(this.comprimento, this.altura);
			Graphics g = Graphics.FromImage(img);
			g.FillRectangle(brush1, 0, 0, this.comprimento, this.altura);   //background


			//Desenha a matriz das pecas
			for (int i = 0; i<6; i++)
            {
				for (int j = 0; j<15; j++)
                {
					if(!this.pecas[i,j].Viva) this.pecas[i,j].Render(g); //apenas desenha as setas vivas
                }
				
			}


			Font font = new System.Drawing.Font("Courrier New", 80, FontStyle.Bold, GraphicsUnit.Point);	
			Font font2 = new System.Drawing.Font("Courrier New", 10, FontStyle.Bold, GraphicsUnit.Point);
			
			g.DrawString(this.Jogador.Score.ToString("00"),font2,Brushes.Gray,this.comprimento/2-280,20); //Score do jogador
			g.DrawString("Score:",font2,Brushes.Gray,this.comprimento/2-330,20); //Score do jogador
			
			g.DrawString(this.numVidas.ToString("00"),font2,Brushes.Gray,this.comprimento/2+330,20); //Vidas do jogador
			g.DrawString("Vidas:",font2,Brushes.Gray,this.comprimento/2+280,20); //Vidas do jogador
			
			//Desenha a bola
			this.bola.Render(g);
			
			//Desenha o Jogador
			this.Jogador.Render(g);

			// de acordo com estado do jogo... desenhar qualquer coisa:
			switch (this.status)
			{
				case GameStatus.READY:
					g.DrawString("READY", font, Brushes.BlueViolet, this.comprimento / 2 - 212, this.altura / 2 - 60);
					break;
				case GameStatus.PAUSE:
					g.DrawString("PAUSE", font, Brushes.Yellow, this.comprimento / 2 - 205, this.altura / 2 - 60);
					break;
				case GameStatus.ENDED:
					g.DrawString("GAME OVER", font, Brushes.Red, this.comprimento / 2 - 350, this.altura / 2 - 60);
					break;
			}

			Game.frames++;
			brush1.Dispose();
			pen1.Dispose();
			g.Dispose();

			return img;
		}



	}
}
