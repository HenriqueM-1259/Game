using Microsoft.VisualBasic;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

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


    class Frutas
    {
        public Vector2f posicao { get; set; }
        public float width { get; set; } = 20f;
        public float height { get; set; } = 20f;

        
        public void RandLocation()
        {
            int x = RandomNumber(50, 500);
            int y = RandomNumber(50, 500);
            posicao =  new Vector2f(x, y);
        }
        
        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void removeFruta()
        {
            this.posicao = new Vector2f(0,0);
        }

        public RectangleShape FrutaDrawn()
        {


            /* RectangleShape playerDraw = new RectangleShape();
             playerDraw.Size = new Vector2f(width, height);
             playerDraw.Position = new Vector2f(this.x,this.y);
             playerDraw.FillColor = Color.Yellow;*/


            RectangleShape frutaDrawn = new RectangleShape(new Vector2f(width, height))
            {

                FillColor = Color.Black,
                Position = posicao

             };
            if (frutaDrawn.Position == new Vector2f(0,0))
           {
                RandLocation();
           }          
            return frutaDrawn;
        }
    }
    
    class ViewWindow
    {
        public void Run()
        {
            RenderWindow renderWindow;
            renderWindow = new RenderWindow(new VideoMode(860, 500), "First window");
            renderWindow.Closed += (_, __) => renderWindow.Close();
            Console.WriteLine("Iniciado...");


            Player player = new Player(renderWindow);
          
            
            while (renderWindow.IsOpen)
            {
                renderWindow.DispatchEvents();
                renderWindow.Clear(Color.White);

                player.Drawn();
                player.Update();



                renderWindow.Display();
            }


        }
        
    }
}
