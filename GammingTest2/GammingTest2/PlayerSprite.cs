using SFML.Graphics;
using SFML.System;
using SFML.Window;

namespace GammingTest2
{
    internal class PlayerSprite
    {
        public RenderWindow RenderWindow {get; set; }
        public Player player { get; set; }
        public Texture texture { get; set; }
        public Sprite sprite { get; set; }

        IntRect reactSourceSprite = new IntRect(0, 0, 48, 48);
        private Clock clock = new Clock();

        public PlayerSprite(Player player)
        {           
            this.player = player;

           
        }

        public Sprite Drawn()
        {

            return sprite;
            
            
        }      
        public void Update()
        {
            if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                this.texture = new Texture(".\\src\\1Characters\\3Cyborg\\Run1.png");
                this.sprite = new Sprite(this.texture, reactSourceSprite);
                this.sprite.Scale = new Vector2f(1, 1);
                this.sprite.Position = player.Position;
            }                          
            else if (Keyboard.IsKeyPressed(Keyboard.Key.A))
            {
                this.texture = new Texture(".\\src\\1Characters\\3Cyborg\\Run1.png");
                this.sprite = new Sprite(this.texture, reactSourceSprite);
                this.sprite.Scale = new Vector2f(-1, 1);
                this.sprite.Position = player.Position;
            }
            else
            {
                if (this.sprite != null)
                {
                    if (this.sprite.Scale.X == -1)
                    {
                        this.texture = new Texture(".\\src\\1Characters\\3Cyborg\\Idle1.png");
                        this.sprite = new Sprite(this.texture, reactSourceSprite);
                        this.sprite.Scale = new Vector2f(-1, 1);
                        this.sprite.Position = player.Position;

                    }
                    else
                    {
                        this.texture = new Texture(".\\src\\1Characters\\3Cyborg\\Idle1.png");
                        this.sprite = new Sprite(this.texture, reactSourceSprite);
                        this.sprite.Position = player.Position;
                    }
                }
                else
                {
                    this.texture = new Texture(".\\src\\1Characters\\3Cyborg\\Idle1.png");
                    this.sprite = new Sprite(this.texture, reactSourceSprite);
                    this.sprite.Position = player.Position;
                }
                
                   

            }
           

            if (clock.ElapsedTime.AsSeconds() > 0.1f)
            {
                if (reactSourceSprite.Left >= 144)
                {
                    reactSourceSprite.Left = 0;
                }
                else
                {
                    reactSourceSprite.Left += 48;
                }
                sprite.TextureRect = reactSourceSprite;               
                sprite.Position = player.Position;
                clock.Restart();
            }
           
        }

    }
}
