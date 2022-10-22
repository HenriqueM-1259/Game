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

        public Inimigo(RenderWindow renderWindow, Player player)
        {
            RenderWindow = renderWindow;
            this.Player = player;
        }
        public Inimigo()
        {
          
        }

        public float Vida { get; set; } = 100f;
        public Vector2f Position { get; set; }
        public Vector2f Tamanho { get; set; } = new Vector2f(30, 30);
        public Lado Lado { get; set; }
        public List<Inimigo> inimigosLista { get; set; } = new List<Inimigo>();
        public Player Player { get; set; }

        public void Drawn()
        {
            if (inimigosLista.Count > 0)
            {
                foreach (var item in inimigosLista)
                {
                    RenderWindow.Draw(item.desenhaInimigo());
                }
               
            }
           
        }

        public Vector2f RandLocation()
        {
            int x = RandomNumber(50, 500);
            int y = RandomNumber(50, 500);
            return new Vector2f(x, y);
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void Update()
        {
            if (inimigosLista.Count == 0)
            {
                Inimigo inimigo = new Inimigo()
                {
                    RenderWindow = RenderWindow,
                    Position = RandLocation(),
                    Player = Player,
                };

                inimigosLista.Add(inimigo);
            }

            if (inimigosLista.Count > 0)
            {
                foreach (var item in inimigosLista)
                {

                    float distancia = item.Player.Position.X - item.Position.X;
                    float distancia2 = item.Player.Position.Y - item.Position.Y;

                    if (distancia > 0)
                    {
                        Vector2f posx = item.Position;
                        posx.X += 1;
                        item.Position = posx;
                    }
                    else
                    {
                        Vector2f posx = item.Position;
                        posx.X -= 1;
                        item.Position = posx;
                    }
                    if (distancia2 > 0)
                    {
                        Vector2f posy = item.Position;
                        posy.Y += 1;
                        item.Position = posy;
                    }
                    else
                    {

                        Vector2f posy = item.Position;
                        posy.Y -= 1;
                        item.Position = posy;
                    }
                }
            }
        }
        public void removeInimigo()
        {
            Inimigo inimigo = new Inimigo();
            foreach (var item in inimigosLista)
            {
                inimigo = item;
            };

            inimigosLista.Remove(inimigo);
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
            Inimigo inimigo = new Inimigo(renderWindow, player);


            while (renderWindow.IsOpen)
            {
                renderWindow.DispatchEvents();
                renderWindow.Clear(Color.White);
                player.Drawn();
                player.Update();
                bala.drawn();
                bala.update();
                inimigo.Drawn();
                inimigo.Update();
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
            foreach (var bLista in b.balaList)
            {
                foreach (var iLista in i.inimigosLista)
                {
                    if (bLista.position.X < iLista.Position.X + iLista.Tamanho.X &&
                    bLista.position.X + bLista.Tamanho.X > iLista.Position.X &&
                    bLista.position.Y < iLista.Position.Y + iLista.Tamanho.Y &&
                    bLista.position.Y + bLista.Tamanho.Y > iLista.Position.Y)
                    {
                        Console.WriteLine("Inimigo morto");
                        return true;
                    }
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
