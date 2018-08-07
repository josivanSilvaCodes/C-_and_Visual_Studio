/* Hello World Code for a interactive window-based App*/
/* That is a basic program to preparing enviroment to develop electronic games in C# /*

using System;               // Namespaces that have classes to our use/reuse
using System.Drawing;       // The word "using" allows us to reuse these classes and libraries of classes
using System.Windows.Forms;

public class Program : Form
{
    Timer t;
    int cx;
    int cy;
    int dx;
    int dy;


    public Program()
    {
        t = new Timer();
        t.Interval = 1;
        t.Tick += updating;
        t.Start();

        cx = 180;
        cy = 250;

        dx = 3;
        dy = 3; 
    }

    private void updating(object sender, EventArgs e)
    {
        move(); // Calling move method

        Graphics g = this.CreateGraphics();
        g.Clear(Color.White); // Clearing screen (Very important)

        Pen selPen = new Pen(Color.Blue); // Drawing interactive content
        g.DrawRectangle(selPen, cx - 10, cy - 10, 20, 20);
                
        g.Dispose();

    }

    private void move()
    {
        cx = cx + dx;
        cy = cy + dy;

        if ((cx - 10) >= 450) dx *= -1;
        if ((cx - 10) <= 0) dx*= -1;
        if ((cy - 10) >= 450) dy*=-1;
        if ((cy - 10) <= 0) dy*= -1;
    }

    [STAThread]
    static void Main() // Main method to allows start the App
    {
        Program p = new Program();     // Creating the form window
        p.Size = new Size(500, 500);
        p.Text = "My Game";
        p.StartPosition = FormStartPosition.CenterScreen;
        Application.EnableVisualStyles();
        Application.Run(p);   // Running the form window     
    }
}
