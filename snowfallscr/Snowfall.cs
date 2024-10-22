using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace snowfallscr
{
    public class Snowfall : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        private Texture2D snowTexture;
        private Texture2D bgwinterTexture;
        private List<Snowball> snowballs;

        private const int WindowHeight = 700;
        private const int WindowWidth = 900;
        private readonly Random random = new Random();

        /// <summary>
        /// Инициализация графики в конструкторе снегопада.   
        /// </summary>
        public Snowfall()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferWidth = WindowWidth;
            graphics.PreferredBackBufferHeight = WindowHeight;
            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Инициализация игры.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// Загрузка контента.
        /// </summary>
        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            snowTexture = Content.Load<Texture2D>("snow");
            bgwinterTexture = Content.Load<Texture2D>("bgwinter");

            snowballs = new List<Snowball>();

            for (var i = 0; i < 200; i++)
            {
                var size = (float)random.Next(2, 6) / 100;
                var speed = (float)random.NextDouble() * 50f + 20f;
                var startPos = new Vector2(random.Next(0, WindowWidth), random.Next(0, WindowHeight));

                snowballs.Add(new Snowball(snowTexture, startPos, speed, size));
            }
        }

        /// <summary>
        /// Обработка позиции снежинок.
        /// </summary>
        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
            {
                Exit();
            }

            foreach (var snowball in snowballs)
            {
                snowball.Fall(gameTime);

                if (snowball.position.Y > WindowHeight)
                {
                    snowball.position = new Vector2(random.Next(0, WindowWidth), -50);
                }
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Отрисовка снежинок.
        /// </summary>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Blue);

            spriteBatch.Begin();

            spriteBatch.Draw(bgwinterTexture, new Rectangle(0, 0, WindowWidth, WindowHeight), Color.White);

            foreach (var snowball in snowballs)
            {
                snowball.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
