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
   
    public class Bala
    {

        public Bala(RenderWindow renderWindow, Player player)
        {
            this.renderWindow = renderWindow;
            this.player = player;
        }
        public Bala()
        {

        }
        public int id { get; set; }
        public RenderWindow renderWindow { get; set; }
        public Vector2f position { get; set; }
        public Vector2f Tamanho { get; set; } = new Vector2f(8, 8);
        public List<Bala> balaList { get; set; } = new List<Bala>();
        public bool tiraBala { get; set; } = false;
        public int deleybalasecond { get; set; }
        public Player player { get; set; }
        public float velocity { get; set; } = 3;

        public Vector2f permapos;
        public void drawn()
        {
            if (balaList.Count > 0)
            {
                foreach (var item in balaList)
                {
                    renderWindow.Draw(item.Gerar());
                    item.SetPosition(1, 0);
                }
            }
        }
        public void update()
        {
            atirar();
            if (balaList.Count > 0)
            {
                foreach (var item in balaList)
                {
                    item.SetPosition(1, 0);
                }

                for (int i = 0; i < balaList.Count; i++)
                {
                    if (permapos.X + 30 > balaList[i].position.X)
                    {
                        Bala b1 = balaList[i];

                        this.balaList[i].tiraBala = false;
                    }
                    else
                    {
                      this.balaList[i].tiraBala = true;

                    }

                }

            }
           

        }
        public void SetPosition(float? x, float? y)
        {
            Vector2f p = position;
            float v = x.Value * velocity;
            
            p.X += x.Value + v;
            p.Y += y.Value;
            position = p;
        }
        public void atirar()
        {

            if (Keyboard.IsKeyPressed(Keyboard.Key.F))
            {
                if (balaList.Count == 0)
                {
                    
                    Bala bala = new Bala()
                    {
                        renderWindow = renderWindow
                    };
                    float posx = player.Position.X + player.Tamanho.X;
                    float posy = player.Position.Y + 6;
                    Vector2f v = new Vector2f(posx, posy);
                    bala.position = v;
                    permapos = v;
                    balaList.Add(bala);
                }
                else if (balaList.Count > 0)
                {

                    List<bool> listaPassa = new List<bool>();
                    foreach (var item in balaList)
                    {
                        listaPassa.Add(item.tiraBala);
                    }

                    if (listaPassa[listaPassa.Count - 1] == true)
                    {
                        Bala bala = new Bala()
                        {
                            renderWindow = renderWindow
                        };
                        float posx = player.Position.X + player.Tamanho.X;
                        float posy = player.Position.Y + 6;
                        Vector2f v = new Vector2f(posx, posy);
                        permapos = v;                     
                        bala.position = v;

                        balaList.Add(bala);
                    }
                   
                }
               

            }

        }
        public RectangleShape Gerar()
        {
            return new RectangleShape()
            {
                Position = position,
                Size = Tamanho,
                FillColor = Color.Blue
            };
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


            while (renderWindow.IsOpen)
            {
                renderWindow.DispatchEvents();
                renderWindow.Clear(Color.White);
                //arma.resetBala(player.Position);
                player.Drawn();
                player.Update();
                bala.deleybalasecond = 50;
                bala.drawn();
                bala.update();

                if (RetornaColisaoPlayerFrutas(player, frutas))
                {
                    frutas.removeFruta();
                }

                frutas.Drawn();
                frutas.Update();
                renderWindow.Display();
            }


        }
        public bool RetornaColisaoPlayerFrutas(Player p, Frutas f)
        {
            if (p.Position.X < f.posicao.X + f.tamanho.X &&
                p.Position.X + p.Tamanho.X > f.posicao.X &&
                p.Position.Y < f.posicao.Y + f.tamanho.Y &&
                p.Position.Y + p.Tamanho.Y > f.posicao.Y)
            {

                return true;

            }
            return false;
        }
    }
}
