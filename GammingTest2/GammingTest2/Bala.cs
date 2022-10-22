using GammingTest2.Enums;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;

namespace GammingTest2
{
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
            DesenhaDirecaoBala();
        }
        public void DesenhaDirecaoBala()
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
                            pos.Y -= 1 * velocity + 2;
                            item.SetPosition(pos);
                            break;
                        case Lado.Direita:
                            Vector2f pos2 = item.position;
                            pos2.X += 1 * velocity + 2;
                            item.SetPosition(pos2);
                            break;
                        case Lado.Esquerda:
                            Vector2f pos3 = item.position;
                            pos3.X -= 1 * velocity + 2;
                            item.SetPosition(pos3);
                            break;
                        case Lado.Baixo:
                            Vector2f pos4 = item.position;

                            pos4.Y += 1 * velocity + 2;
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
            disparaBala();
            verificaSaiuDaTela();
        }
        public void verificaSaiuDaTela()
        {
            List<Bala> balas = new List<Bala>();
            foreach (var item in balaList)
            {
                Console.WriteLine(balaList.Count);
                switch (item.ladotiro)
                {
                    case Lado.Cima:
                        if (item.position.Y  < 0)
                        {
                            balas.Add(item);
                            Console.WriteLine("processo de exclusao: " + balaList.Count);
                        }
                        break;
                    case Lado.Direita:
                        if (item.position.X > 860)
                        {
                            balas.Add(item);
                            Console.WriteLine("processo de exclusao: " + balaList.Count);
                        }
                        break;
                    case Lado.Esquerda:
                        if (item.position.X < 0)
                        {
                            balas.Add(item);
                            Console.WriteLine("processo de exclusao: " + balaList.Count);
                        }
                        break;
                    case Lado.Baixo:
                        if (item.position.Y > 600)
                        {
                            balas.Add(item);
                            Console.WriteLine("processo de exclusao: " + balaList.Count);
                        }
                        break;
                    default:
                        break;
                }
            }
            foreach (var item in balas)
            {
                balaList.Remove(item);
                Console.WriteLine("exclusao Quantidade" + balas.Count.ToString());
            }
        }
        public void disparaBala()
        {
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

                            if (y2 - 100 < y)
                            {


                                this.balaList[i].tiraBala = false;
                            }
                            else
                            {
                                this.balaList[i].tiraBala = true;

                            }
                            break;
                        case Enums.Lado.Direita:
                            if (permapos.X + 100 > Math.Abs(balaList[i].position.X))
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

                            if (x2 - 100 < x)
                            {

                                this.balaList[i].tiraBala = false;
                            }
                            else
                            {
                                this.balaList[i].tiraBala = true;

                            }
                            break;
                        case Enums.Lado.Baixo:
                            if (permapos.Y + 100 > balaList[i].position.Y)
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

                    switch (player.lado)
                    {
                        case Lado.Cima:
                            bala.ladotiro = Lado.Cima;
                            float posx1 = player.Position.X + ( player.Tamanho.X /2);
                            float posy1 = player.Position.Y - 8;
                            Vector2f v1 = new Vector2f(posx1, posy1);
                            bala.position = v1;
                            permapos = v1;
                            balaList.Add(bala);
                            break;
                        case Lado.Direita:
                            bala.ladotiro = Lado.Direita;
                            float posx2 = player.Position.X + player.Tamanho.X;
                            float posy2 = player.Position.Y + 6;
                            Vector2f v2 = new Vector2f(posx2, posy2);
                            bala.position = v2;
                            permapos = v2;
                            balaList.Add(bala);
                            break;
                        case Lado.Esquerda:
                            bala.ladotiro = Lado.Esquerda;
                            float posx3 = player.Position.X - 4;
                            float posy3 = player.Position.Y + 6;
                            Vector2f v3 = new Vector2f(posx3, posy3);
                            bala.position = v3;
                            permapos = v3;
                            balaList.Add(bala);
                            break;
                        case Lado.Baixo:
                            bala.ladotiro = Lado.Baixo;
                            float posx4 = player.Position.X + (player.Tamanho.X / 2);
                            float posy4 = player.Position.Y + 20;
                            Vector2f v4 = new Vector2f(posx4, posy4);
                            bala.position = v4;
                            permapos = v4;
                            balaList.Add(bala);
                            break;
                        default:
                            break;
                    }
                    
                    
                   
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
                        switch (player.lado)
                        {
                            case Lado.Cima:
                                bala.ladotiro = Lado.Cima;
                                float posx1 = player.Position.X + (player.Tamanho.X / 2);
                                float posy1 = player.Position.Y - 8;
                                Vector2f v1 = new Vector2f(posx1, posy1);
                                bala.position = v1;
                                permapos = v1;
                                balaList.Add(bala);
                                break;
                            case Lado.Direita:
                                bala.ladotiro = Lado.Direita;
                                float posx2 = player.Position.X + player.Tamanho.X;
                                float posy2 = player.Position.Y + 6;
                                Vector2f v2 = new Vector2f(posx2, posy2);
                                bala.position = v2;
                                permapos = v2;
                                balaList.Add(bala);
                                break;
                            case Lado.Esquerda:
                                bala.ladotiro = Lado.Esquerda;
                                float posx3 = player.Position.X - 4;
                                float posy3 = player.Position.Y + 6;
                                Vector2f v3 = new Vector2f(posx3, posy3);
                                bala.position = v3;
                                permapos = v3;
                                balaList.Add(bala);
                                break;
                            case Lado.Baixo:
                                bala.ladotiro = Lado.Baixo;
                                float posx4 = player.Position.X + (player.Tamanho.X / 2);
                                float posy4 = player.Position.Y + 20;
                                Vector2f v4 = new Vector2f(posx4, posy4);
                                bala.position = v4;
                                permapos = v4;
                                balaList.Add(bala);
                                break;
                            default:
                                break;
                        }

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
}
