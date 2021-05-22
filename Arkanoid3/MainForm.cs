using System;
using System.Windows.Forms;
using System.Diagnostics;


namespace Arkanoid3
{
	public partial class MainForm : Form
	{
		Game game = null;
		Stopwatch crono=null;
		int numVidas = 3;

		public MainForm()
		{
			InitializeComponent();
			this.TimerLoopGame.Interval = 20;
			this.crono = new Stopwatch();
			game = new Game(this.pictureBox1.Width, pictureBox1.Height, numVidas);
			this.pictureBox1.Image = game.RenderFrame();
		}

		/// <summary>
		/// Evento chamado quando se clica no botão 1 PLAYER
		/// Começar um novo jogo
		/// </summary>
		void StartbtClick(object sender, EventArgs e)
		{
			game = new Game(this.pictureBox1.Width, pictureBox1.Height, numVidas);
			this.menu.Visible = false;   // esconder o Menu
 			this.TimerLoopGame.Interval=40;			
			this.game.Start(); // começar jogo
			
			int loopTime=this.TimerLoopGame.Interval;
	 		
			// loop principal de jogo
 			while (this.game.Status!=Game.GameStatus.ENDED)
  	  		{
 	   			crono.Restart();
       			game.Update();
       			this.AtualizaEcran();
	  			
       			while (crono.ElapsedMilliseconds<loopTime)
         		{
 	   	  		Application.DoEvents();
         		}		           
       		this.Text = crono.ElapsedMilliseconds.ToString("00");
      		} // fim do while	 
    		this.startbt.Visible=true;	
			   		
		}
		
		//Butao de saida
		void ExitbtClick(object sender, EventArgs e)
		{
			DialogResult dialog = new DialogResult();
			dialog = MessageBox.Show("Tem a certeza ?", "", MessageBoxButtons.YesNo);
			if (dialog == DialogResult.Yes)
				Application.Exit();
		}
		

		// Game loop 
		void TimerLoopTick(object sender, EventArgs e)
		{
			this.TimerLoopGame.Start(); // recomeçar de imediato um novo loop, tentar ser CPU independent!!
			game.HandleKeys();
			game.Update();
			
			// verificar situação de jogo e agir em conformidade
			if (this.game.Status == Game.GameStatus.PAUSE)
				this.TimerLoopGame.Stop();              // fazer pause (parar o loop e esperar pelo recomeço...	   	
			if (this.game.Status == Game.GameStatus.ENDED)
			{
				this.TimerLoopGame.Stop();      // parar o loop;
				this.menu.Visible = true;        // mostrar menu;
			}
			if (this.pictureBox1.Image != null)         // libertar a memória ocupada pela imagem anterior
				this.pictureBox1.Image.Dispose();
			this.pictureBox1.Image = game.RenderFrame();
		}
		
		// para atualizar o picFrame de acordo com o frame de jogo
		public void AtualizaEcran()
		{
	 		if (this.game.Status!=Game.GameStatus.ONGOING)
			    return;		
	 		if (this.pictureBox1.Image!=null && this.game.Status==Game.GameStatus.ONGOING)
		 	 	this.pictureBox1.Image.Dispose();
	 		this.pictureBox1.Image=this.game.RenderFrame();
	 	}


		// verificar teclas e fazer algum controlo de 
		// Define quando começa e para o timerLoop PAUSE...
		void MainFormKeyPress(object sender, KeyPressEventArgs e)
		{
			if (this.game == null)
				return;
			if (e.KeyChar == 'P' || e.KeyChar == 'p' && this.game.Status != Game.GameStatus.ENDED)
			{
				this.game.PauseStart();
				this.TimerLoopGame.Start();     // Mostra Pause no ecran
			}
			if (this.pictureBox1.Image != null)
				this.pictureBox1.Image.Dispose();
			this.pictureBox1.Image = game.RenderFrame();
		}

		//Termina o jogo
		void MainFormFormClosing(object sender, FormClosingEventArgs e)
		{
			if (this.game != null)
				this.game.Stop();
		}


	}// fim classe MainForm
}