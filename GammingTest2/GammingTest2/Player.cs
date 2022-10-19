using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Text;

namespace GammingTest2
{
    public enum Lado
    {
        Cima,
        Direita,
        Esquerda,
        Baixo
    }

    internal class Player
    {
        
        public Player(RenderWindow win)
        {
            this.win = win;
        }
        public RenderWindow  win { get; set; }
        public Vector2f Position { get; set; } = new Vector2f(100,100);
        public Vector2f Tamanho { get; set; } = new Vector2f(25, 40);
        private RectangleShape rectangleShape { get; set; }
        public float velocity { get; set; } = 2.5f;

        public void SetPosition(float? x, float? y)
        {
            Vector2f p = Position;
            p.X += x.Value * velocity;
            p.Y += y.Value * velocity;
            Position = p;
        }

        //reseta a posicao do objeto caso ele saia da tela
        /*EXEMPLO se o player sair da tela do lado direito ele vai resetar o x do player para 0
         pois ele ultrapassou o limite da tela */

        public void resetPosition(Lado lado)
        {
            Vector2f posAnteriore = Position;
            switch (lado)
            {
                case Lado.Cima:
                    posAnteriore.Y = win.Size.Y - 25;
                    Position = posAnteriore;
                    break;
                case Lado.Direita:               
                    posAnteriore.X = 0;
                    Position = posAnteriore;
                    break;
                case Lado.Esquerda:
                    posAnteriore.X = win.Size.X - 25;
                    Position = posAnteriore;
                    break;
                case Lado.Baixo:
                    posAnteriore.Y = 0;
                    Position = posAnteriore;
                    break;
            }
            
        }
        public RectangleShape CriarPersonagem()
        {
            rectangleShape = new RectangleShape();
            rectangleShape.Size = Tamanho;
            rectangleShape.Position = Position;
            rectangleShape.FillColor = Color.Red;
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

                if (Position.X > win.Size.X - 25)
                    resetPosition(Lado.Direita);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                if (Position.X >= 0)
                    SetPosition(-3.1f, 0);

                if(Position.X < 0)
                    resetPosition(Lado.Esquerda);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.W))
            {
                if (Position.Y >= 0)
                    SetPosition(0, -3.1f);

                if (Position.Y < 0)
                    resetPosition(Lado.Cima);
            }
            if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                if (Position.Y <= win.Size.Y - 35)
                    SetPosition(0, 3.1f);

                if (Position.Y > win.Size.Y - 35)
                    resetPosition(Lado.Baixo);
            }

        }

    }
}
