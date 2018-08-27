using System;              
using System.Drawing;      
using System.Windows.Forms;

public class Game : Form
{
    int score = 0;
    int vidas = 3;
    Timer timer = new Timer();
    bool vivo = true;

    Gato gato = new Gato();
    Comida comida = new Comida();
    Cacchorro[] cachorros = new Cacchorro[6];

    Random rand = new Random();

    public Game()
    {
        timer.Enabled = true;
        timer.Interval = 1000/60;  
        timer.Tick += new EventHandler(Updating);
        this.KeyPress += new KeyPressEventHandler(this.GetKeyDown);

        comida.x = rand.Next(50, 450);
        comida.y = rand.Next(50, 450);

        posCachorros();
    }

    public void posCachorros()
    {
        for (int k = 0; k < 6; k++)
        {
            int lx = rand.Next(100, 400);
            int ly = rand.Next(100, 400);

            cachorros[k] = new Cacchorro(lx, ly);

        }
    }


    public void Updating(object sender, EventArgs e)
    {
        gato.Mover();
        comida.Mover();
        for (int k = 0; k < 6; k++)
        {
            cachorros[k].Mover();

            double dist1 = Math.Sqrt(Math.Pow(gato.x - cachorros[k].x, 2)
                   + Math.Pow(gato.y - cachorros[k].y, 2));

            if (dist1 < 25)
            {
                gato.x = rand.Next(50, 450);
                gato.y = rand.Next(50, 450);

                vidas--;
                posCachorros();
                gato.dx = 0;
                gato.dy = 0;
            }
        }
        this.Invalidate();

        double dist2 = Math.Sqrt( Math.Pow(gato.x-comida.x, 2)
                     + Math.Pow(gato.y-comida.y, 2) );

        if (dist2 < 15)
        {
            comida.x = rand.Next(50, 450);
            comida.y = rand.Next(50, 450);

            score++;
            posCachorros();
        }

        if (vidas <= 0)
        {
            vivo = false;
            gato.dx = 0;
            gato.dy = 0;
        }

    }
    protected override void OnPaint(PaintEventArgs e)
    {
        Graphics g = e.Graphics;
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
        gato.Desenhar(g);
        comida.Desenhar(g);
        for (int k = 0; k < 6; k++)
        {
            cachorros[k].Desenhar(g);
        }
        g.DrawString("Score: " + score, this.Font, Brushes.Black, 10, 10);
        g.DrawString("Lives: " + vidas, this.Font, Brushes.Black, 100, 10);

        if(vivo == false)
        g.DrawString("GAME OVER, presse R to reset " , this.Font, Brushes.Black, 250, 10);

        base.OnPaint(e);
    }

    public void GetKeyDown(Object o, KeyPressEventArgs e)
    {
        if (e.KeyChar == (char)Keys.Escape)
        {
            Console.WriteLine("ESC PRESSIONADA - GAME OVER!");
            Close();
        }
        if (e.KeyChar == (char)Keys.R || e.KeyChar == 'r')
        {
            vidas = 3;
            vivo = true;
            
        }

        if (vivo == true)
        {
            if (e.KeyChar == (char)Keys.A || e.KeyChar == 'a')
            {
                gato.dx = -1;
                gato.dy = 0;
            }
            if (e.KeyChar == (char)Keys.D || e.KeyChar == 'd')
            {
                gato.dx = 1;
                gato.dy = 0;
            }
            if (e.KeyChar == (char)Keys.W || e.KeyChar == 'w')
            {
                gato.dy = -1;
                gato.dx = 0;
            }
            if (e.KeyChar == (char)Keys.S || e.KeyChar == 's')
            {
                gato.dy = 1;
                gato.dx = 0;
            }
        }
    }

    [STAThread]
    static void Main() // Main method to allows start the App
    {
        Game ga = new Game();     // Creating the form window
        ga.Size = new Size(500, 500);
        ga.Text = "Jogo Gato-Cacchorro";
        ga.StartPosition = FormStartPosition.CenterScreen;
        Application.EnableVisualStyles();
        Application.Run(ga);   // Running the form window  
       
    }
}

