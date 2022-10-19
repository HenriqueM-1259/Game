using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Text;

namespace GammingTest2
{
    class Frutas
    {
        public Frutas(RenderWindow renderWindow)
        {
            this.renderWindow = renderWindow;
        }
        public Vector2f posicao { get; set; }
        public Vector2f tamanho { get; set; } = new Vector2f(20,20);
        public RenderWindow renderWindow { get; set; }

        public Vector2f getPosition()
        {
            return posicao;
        }
        public void RandLocation()
        {
            int x = RandomNumber(50, 500);
            int y = RandomNumber(50, 500);
            posicao = new Vector2f(x, y);
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        public void removeFruta()
        {
            this.posicao = new Vector2f(0, 0);
        }

        public void Drawn()
        {
            this.renderWindow.Draw(criaFruta());
        }
        public void Update()
        {
            if (posicao == new Vector2f(0,0))
            {
                RandLocation();
            }
        }

        public RectangleShape criaFruta()
        {
            RectangleShape frutas = new RectangleShape(tamanho);
            frutas.Position = posicao;
            frutas.FillColor = Color.Yellow;
            return frutas;
        }
    }
}
