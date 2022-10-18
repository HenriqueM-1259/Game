using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace GammingTest2
{
    internal class Player
    {
        public Player(RenderWindow win)
        {
            this.win = win;
        }
        public RenderWindow  win { get; set; }
        private Vector2f Position { get; set; } = new Vector2f(100,100);
        private Vector2f Tamanho { get; set; } = new Vector2f(25, 40);
        private RectangleShape rectangleShape { get; set; }

        public void SetPosition(float? x, float? y)
        {
            Vector2f p = Position;
            p.X += x.Value;
            p.Y += y.Value + 2;
            Position = p;
        }

        public RectangleShape CriarPersonagem()
        {
            rectangleShape = new RectangleShape();
            rectangleShape.Size = Tamanho;
            rectangleShape.Position = Position;
            rectangleShape.FillColor = Color.Green;
            return rectangleShape;
        }

        public void Drawn()
        {
            win.Draw(CriarPersonagem());
        }

        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {   
                if(Position.X <= win.Size.X - 25)
                SetPosition(0.1f,0);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                if (Position.X >= 0)
                    SetPosition(-0.1f, 0);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                if(Position.Y >= 0)
                SetPosition(0, -0.1f);             
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                if (Position.Y <= win.Size.Y - 35)
                    SetPosition(0, 0.1f);
            }
        }


    }
}
