using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace MonoGame_Introduction
{
    public class Game1 : Game
    {
        // FIELDS OF THE CLASS HERE
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // YOU ARE WELCOME TO ADD YOUR OWN FIELDS, TOO!
        
        // Define 2 Tex2Ds:  cat and cupcake
        private Texture2D catImage;
        private Texture2D cupcakeImage;

        private Vector2 catPosition;
        private Rectangle cupcakeRect;





        public Game1()
        {
            // DON'T CHANGE THESE FIELDS
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // CAN MODIFY! 
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // ----------------------------------------------------------------
            // TODO: Add your initialization logic here

            catPosition = new Vector2(0, 0);
            cupcakeRect = new Rectangle(200, 50, 100, 300);

            // ----------------------------------------------------------------

            // KEEP THIS AS THE LAST STATEMENT IN INITIALIZE
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // DO NOT MODIFY THIS LINE
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // ----------------------------------------------------------------
            // TODO: use this.Content to load your game content here

            // Load the appropriate images into each Tex2D object
            catImage = Content.Load<Texture2D>("cat");
            cupcakeImage = Content.Load<Texture2D>("cupcake");


            // ----------------------------------------------------------------
        }

        protected override void Update(GameTime gameTime)
        {
            // FEEL FREE TO MODIFY OR DELETE IF YOU NEED TO
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // ----------------------------------------------------------------
            // TODO: Add your update logic here


            // Debug statement here:
            // Appears in the Output window

            //System.Diagnostics.Debug.WriteLine("howdy");
            //Debug.WriteLine("This works too.");

            catPosition.X++;

            if(catPosition.X > 800)
            {
                catPosition.X = -catImage.Width;
            }

            // ----------------------------------------------------------------

            // KEEP THIS AS THE LAST STATEMENT IN UPDATE
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // FEEL FREE TO CHANGE COLOR
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // ----------------------------------------------------------------
            // TODO: Add your drawing code here

            // ADD THESE to every new project:
            _spriteBatch.Begin();

            // Draw whatever you need to in between!
            _spriteBatch.Draw(
                catImage,
                catPosition,
                Color.White
                );

            _spriteBatch.Draw(
                cupcakeImage,
                cupcakeRect,
                Color.Chartreuse
                );


            _spriteBatch.End();
            // ----------------------------------------------------------------

            // KEEP THIS AS THE LAST STATEMENT IN DRAW
            base.Draw(gameTime);
        }
    }
}