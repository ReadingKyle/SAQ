using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdventureQuest
{
    /// <summary>
    /// A class representing the hero sprite
    /// </summary>
    public class Hero
    {
        /// <summary>
        /// The game the hero is a part of
        /// </summary>
        Game game;

        /// <summary>
        /// The texture of the hero
        /// </summary>
        Texture2D texture;

        /// <summary>
        /// The position of the hero on the menu screen
        /// </summary>
        public Vector2 Position { get; set; }

        /// <summary>
        /// The original position of the hero
        /// </summary>
        public Vector2 OriginalPosition { get; set; }

        /// <summary>
        /// Timer for each animation frame
        /// </summary>
        private double animationTimer;

        /// <summary>
        /// Current frame of hero's animation
        /// </summary>
        private short animationFrame;

        /// <summary>
        /// Load the hero's texture
        /// </summary>
        /// <param name="content">content of the game</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("HeroSheet");
            OriginalPosition = Position;
        }

        /// <summary>
        /// Update the hero sprite's animation and parallax
        /// </summary>
        /// <param name="gameTime">The game's clock time</param>
        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            Vector2 offset = new Vector2(mouseState.X, mouseState.Y);
            Position = new Vector2(OriginalPosition.X - (0.02f * offset.X), OriginalPosition.Y - (0.02f * offset.Y));
        }

        /// <summary>
        /// Draws the hero sprite
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to draw with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            animationTimer += gameTime.ElapsedGameTime.TotalSeconds;

            if (animationTimer > 0.2)
            {
                animationFrame++;
                if (animationFrame > 6) animationFrame = 0;
                animationTimer -= 0.2;
            }
            var source = new Rectangle(animationFrame * 128, 32, 128, 128);
            spriteBatch.Draw(texture, Position, source, Color.White, 0, new Vector2(64, 64), 4.0f, SpriteEffects.None, 0);
        }
    }
}
