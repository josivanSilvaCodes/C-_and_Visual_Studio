// READ ME  

// Example to run on WPA (Windows Form application) - Its the second option of project mode on Visual Studio
// Call the project WindowsFormsApp1 (defines that name when create the project)
// The namespace of the project should to be named WindowsFormsApp1
// This class should to be named Form1
// When the project starts click on Form1.cs (Form1.cs[Design]), click again on right button and choose Show Code (or type F7 key)
// So paste this code above the code you will see
// That's all!

// LEIA ME

// Exemplo para executar no WPA (aplicativo Windows Form) - é a segunda opção do modo de projeto no Visual Studio
// Chame o projeto WindowsFormsApp1 (define esse nome quando cria o projeto)
// O namespace do projeto deve ser denominado WindowsFormsApp1
// Esta classe deve ser denominada Form1
// Quando o projeto iniciar, clique em Form1.cs (Form1.cs [Design]), clique novamente no botão direito e escolha Show Code (ou digite a tecla F7)
// Então cole este código acima do código que você verá
// Isso é tudo!


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();

        int x;
        int y;
        public Form1()
        {
            InitializeComponent();
            timer.Enabled = true;
            timer.Interval = 100;  
            timer.Tick += new EventHandler(TimerCallback);
        }
        private void TimerCallback(object sender, EventArgs e)
        {
            x += 10;
            y += 10;
            this.Invalidate();
            return;
        }
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.None;
            g.FillRectangle(Brushes.Red, x, y, 20, 20);
            base.OnPaint(e);
        }
    }
}

