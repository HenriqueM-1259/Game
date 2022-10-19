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
        public float velocity { get; set; } = 2.5f;

        public void SetPosition(float? x, float? y)
        {
            Vector2f p = Position;
            p.X += x.Value * velocity;
            p.Y += y.Value * velocity;
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
            keyBoard();
        }



        public void keyBoard()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                if (Position.X <= win.Size.X - 25)
                    SetPosition(3.1f, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                if (Position.X >= 0)
                    SetPosition(-3.1f, 0);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                if (Position.Y >= 0)
                    SetPosition(0, -3.1f);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                if (Position.Y <= win.Size.Y - 35)
                    SetPosition(0, 3.1f);
            }

        }

    }
}
