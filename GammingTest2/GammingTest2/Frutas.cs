using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace GammingTest2
{
    class Frutas
    {
        public Frutas(RenderWindow renderWindow)
        {
            this.renderWindow = renderWindow;
        }
        public Frutas()
        {
           
        }
        public Vector2f posicao { get; set; }
        public Vector2f tamanho { get; set; } = new Vector2f(20, 20);
        public RenderWindow renderWindow { get; set; }
        public List<Frutas> FrutasLista { get; set; } = new List<Frutas>();

        public Vector2f getPosition()
        {
            return posicao;
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
        public void removeFruta()
        {
            Frutas frutas = new Frutas();
          
            foreach (var item in FrutasLista)
            {
                frutas = item;
            }
            FrutasLista.Remove(frutas);
        }

        public void Drawn()
        {
            if (FrutasLista != null)
            {
                foreach (var item in FrutasLista)
                {
                    this.renderWindow.Draw(item.criaFruta());
                }
            }
         
           
        }
        public void Update()
        {

            if (FrutasLista.Count == 0)
            {
                Frutas frutas = new Frutas()
                {
                    renderWindow = this.renderWindow,

                };

                frutas.posicao = frutas.RandLocation();
                FrutasLista.Add(frutas);
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
