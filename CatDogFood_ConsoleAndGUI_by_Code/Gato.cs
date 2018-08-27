using System;
using System.Drawing;

class Gato
{
    public int x;
    public int y;
    public int tamanhox;
    public int tamanhoy;
    public int dx;
    public int dy;

    public Gato()
    {
       x = 200;
       y = 200;
       tamanhox = 20;
       tamanhoy = 20;
       dx = 0;
       dy = 0;
    }

    public void Mover()
    {
        x += dx;
        y += dy;
    }

    public void Desenhar(Graphics g) { g.FillRectangle(Brushes.Red, x, y, tamanhox, tamanhoy); }

}

