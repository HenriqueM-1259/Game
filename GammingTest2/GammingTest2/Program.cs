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
        public Lado ladotiro { get; set; }
        public void drawn()
        {
            if (balaList.Count > 0)
            {
                foreach (var item in balaList)
                {
                    renderWindow.Draw(item.Gerar());
                    switch (item.ladotiro)
                    {
                        case Lado.Cima:
                            Vector2f pos = item.position;
                            pos.Y -= 1;
                            item.SetPosition(pos);
                            break;
                        case Lado.Direita:
                            Vector2f pos2 = item.position;
                            pos2.X += 1;
                            item.SetPosition(pos2);
                            break;
                        case Lado.Esquerda:
                            Vector2f pos3 = item.position;
                            pos3.X -= 1;
                            item.SetPosition(pos3);
                            break;
                        case Lado.Baixo:
                            Vector2f pos4 = item.position;
                            pos4.Y += 1;
                            item.SetPosition(pos4);
                            break;
                        default:
                            break;
                    }

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
                    switch (item.ladotiro)
                    {
                        case Lado.Cima:
                            Vector2f pos = item.position;
                            pos.Y -= 1;
                            item.SetPosition(pos);
                            break;
                        case Lado.Direita:
                            Vector2f pos2 = item.position;
                            pos2.X += 1;
                            item.SetPosition(pos2);
                            break;
                        case Lado.Esquerda:
                            Vector2f pos3 = item.position;
                            pos3.X -= 1;
                            item.SetPosition(pos3);
                            break;
                        case Lado.Baixo:
                            Vector2f pos4 = item.position;
                            pos4.Y += 1;
                            item.SetPosition(pos4);
                            break;
                        default:
                            break;
                    }

                   
                }

                for (int i = 0; i < balaList.Count; i++)
                {
                    switch (balaList[i].ladotiro)
                    {
                       case Enums.Lado.Cima:


                            float y = 0;
                            y = y - permapos.Y;
                            float y2 = 0;
                            y2 = y2 -= balaList[i].position.Y;

                            if (y2 - 30 < y)
                            {


                                this.balaList[i].tiraBala = false;
                            }
                            else
                            {
                                this.balaList[i].tiraBala = true;

                            }
                            break;
                        case Enums.Lado.Direita:
                            if (permapos.X + 30 > Math.Abs(balaList[i].position.X))
                            {
                                

                                this.balaList[i].tiraBala = false;
                            }
                            else
                            {
                                this.balaList[i].tiraBala = true;

                            }
                            break;
                            case Enums.Lado.Esquerda:

                            float x = 0;
                              x = x - permapos.X;
                            float x2 = 0;
                              x2 = x2 -= balaList[i].position.X;

                            if (x2 - 30 < x)
                            {
                                

                                this.balaList[i].tiraBala = false;
                            }
                            else
                            {
                                this.balaList[i].tiraBala = true;

                            }
                            break;
                        case Enums.Lado.Baixo:
                            if (permapos.Y + 30 > balaList[i].position.Y)
                            {


                                this.balaList[i].tiraBala = false;
                            }
                            else
                            {
                                this.balaList[i].tiraBala = true;

                            }
                            break;
                        default:
                            break;
                    }
                   

                }

            }
           

        }
        public void SetPosition(Vector2f POS)
        {
            position = POS;
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

                    switch (player.lado)
                    {
                        case Lado.Cima:
                            bala.ladotiro = Lado.Cima;
                            break;
                        case Lado.Direita:
                            bala.ladotiro = Lado.Direita;
                            break;
                        case Lado.Esquerda:
                            bala.ladotiro = Lado.Esquerda;
                            break;
                        case Lado.Baixo:
                            bala.ladotiro = Lado.Baixo;
                            break;
                        default:
                            break;
                    }

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
                        switch (player.lado)
                        {
                            case Lado.Cima:
                                bala.ladotiro = Lado.Cima;
                                break;
                            case Lado.Direita:
                                bala.ladotiro = Lado.Direita;
                                break;
                            case Lado.Esquerda:
                                bala.ladotiro = Lado.Esquerda;
                                break;
                            case Lado.Baixo:
                                bala.ladotiro = Lado.Baixo;
                                break;
                            default:
                                break;
                        }

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
