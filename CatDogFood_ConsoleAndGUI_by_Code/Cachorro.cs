using System;
using System.Drawing;

class Cacchorro
{
    public int x;
    public int y;
    public int tamanhox;
    public int tamanhoy;
    public int dx;
    public int dy;

    public Cacchorro(int px, int py)
    {
        x = px;
        y = py;
        tamanhox = 30;
        tamanhoy = 30;
        dx = 0;
        dy = 0;
    }

    public void Mover()
    {
        x += dx;
        y += dy;


    }

    public void Desenhar(Graphics g) { g.FillRectangle(Brushes.Black, x, y, tamanhox, tamanhoy); }

}


