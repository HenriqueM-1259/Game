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
   /*
    public class Bala
    {

    }*/

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
