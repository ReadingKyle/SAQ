using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SharpDX.MediaFoundation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperAdventureQuest
{
    /// <summary>
    /// A class representing sprite elements on the starting screen
    /// </summary>
    public class SceneElement
    {
        /// <summary>
        /// The texture of the element
        /// </summary>
        public Texture2D Texture;

        public GraphicsDevice Graphics;

        /// <summary>
        /// The position of the element on the menu screen
        /// </summary>
        public Vector2 Position { get; set; }


        public Vector2 OriginalPosition { get; set; }

        /// <summary>
        /// The speed of the parallax on the object
        /// </summary>
        public float ParallaxSpeed { get; set; }

        public Vector2 PreviousMouseState { get; set; }

        /// <summary>
        /// Load the element's texture
        /// </summary>
        /// <param name="content">content of the game</param>
        /// <param name="texture">texture of the element</param>
        public void LoadContent(ContentManager content, GraphicsDevice graphics, string texture, float parallaxSpeed)
        {
            Texture = content.Load<Texture2D>(texture);
            Graphics = graphics;
            ParallaxSpeed = parallaxSpeed;
            OriginalPosition = Position;
        }

        /// <summary>
        /// Update the game elements in the scene based on mouse movement to make a parallax effect
        /// </summary>
        /// <param name="gameTime">Game's time clock</param>
        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            Vector2 offset = new Vector2(mouseState.X, mouseState.Y);
            Position = new Vector2(OriginalPosition.X - (ParallaxSpeed * offset.X), OriginalPosition.Y - (ParallaxSpeed * offset.Y));
        }

        /// <summary>
        /// Draw the element in the scene
        /// </summary>
        /// <param name="spriteBatch">Queue for drawing the sprites</param>
        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, Position, null, Color.White, 0, new Vector2(64, 64), 4.0f, SpriteEffects.None, 0);
        }

    }
}
