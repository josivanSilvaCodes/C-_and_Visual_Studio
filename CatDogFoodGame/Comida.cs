using System.Drawing;

class Comida
{
    public int x;
    public int y;
    public int tamanhox;
    public int tamanhoy;
    public int dx;

    public Comida()
    {
        x = 250;
        y = 250;
        tamanhox = 10;
        tamanhoy = 10;
        dx = 0;
    }

    public void Mover()
    {
        x += dx;
    }

    public void Desenhar(Graphics g) { g.FillRectangle(Brushes.Blue, x, y, tamanhox, tamanhoy); }
}
