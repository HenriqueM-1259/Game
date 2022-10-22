using GammingTest2.Enums;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;

namespace GammingTest2
{
    internal class Program
    {

        static void Main(string[] args)
        {

            ViewWindow viewWindow = new ViewWindow();
            viewWindow.Run();

        }

    }

    public class Inimigo
    {


        public RenderWindow RenderWindow;

        public Inimigo(RenderWindow renderWindow)
        {
            RenderWindow = renderWindow;
        }

        public float Vida { get; set; }
        public Vector2f Position { get; set; } = new Vector2f(300, 400);
        public Vector2f Tamanho { get; set; } = new Vector2f(30, 30);
        public Lado Lado { get; set; }
        public List<Inimigo> inimigos { get; set; }

        public void Drawn()
        {
            RenderWindow.Draw(desenhaInimigo());
        }

        public void Update()
        {

        }
        public void removeInimigo()
        {
            Position = new Vector2f(-1000, -1000);
        }
        public RectangleShape desenhaInimigo()
        {
            RectangleShape inimigo = new RectangleShape()
            {
                Position = Position,
                Size = Tamanho,
                FillColor = Color.Black
            };

            return inimigo;
        }
    }

    class ViewWindow
    {

        public void Run()
        {

            RenderWindow renderWindow;
            renderWindow = new RenderWindow(new VideoMode(860, 500), "First window");
            renderWindow.Closed += (_, __) => renderWindow.Close();
            renderWindow.SetVerticalSyncEnabled(true);
            renderWindow.SetFramerateLimit(60);
            Console.WriteLine("Iniciado...");

            Player player;

            player = new Player(renderWindow);
            Bala bala = new Bala(renderWindow, player);
            Frutas frutas = new Frutas(renderWindow);
            Inimigo inimigo = new Inimigo(renderWindow);


            while (renderWindow.IsOpen)
            {
                renderWindow.DispatchEvents();
                renderWindow.Clear(Color.White);
                player.Drawn();
                player.Update();
                bala.drawn();
                bala.update();
                inimigo.Drawn();
                if (RetornaColisaoPlayerFrutas(player, frutas))
                {
                    frutas.removeFruta();
                }
                if (RetornaColisaoTiroInimigo(bala, inimigo))
                {
                    inimigo.removeInimigo();
                }
                frutas.Drawn();
                frutas.Update();
                renderWindow.Display();
            }


        }
        public bool RetornaColisaoTiroInimigo(Bala b, Inimigo i)
        {
            foreach (var item in b.balaList)
            {
                if (item.position.X < i.Position.X + i.Tamanho.X &&
                    item.position.X + item.Tamanho.X > i.Position.X &&
                    item.position.Y < i.Position.Y + i.Tamanho.Y &&
                    item.position.Y + item.Tamanho.Y > i.Position.Y)
                {
                    Console.WriteLine("Inimigo morto");
                    return true;
                }
            }
            Console.WriteLine("Inimigo vivo");
            return false;
        }
        public bool RetornaColisaoPlayerFrutas(Player p, Frutas f)
        {
            foreach (var item in f.FrutasLista)
            {
                if (p.Position.X < item.posicao.X + item.tamanho.X &&
                   p.Position.X + p.Tamanho.X > item.posicao.X &&
                   p.Position.Y < item.posicao.Y + item.tamanho.Y &&
                   p.Position.Y + p.Tamanho.Y > item.posicao.Y)
                {
                    Console.WriteLine("colidindo");
                   return true;

                }              
            }
            return false;
        }
    }
}
