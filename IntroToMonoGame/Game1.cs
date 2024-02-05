using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

// Erin Cascioli
// 1/29/2024
// Demo: Introduction to MonoGame with Content Loading and Drawing

namespace IntroToMonoGame
{
    public class Game1 : Game
    {
        // DO NOT MODIFY!
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // ------------------------------------------------------------------------------------
        // FYI: COMMENT YOUR FIELDS TO ORGANIZE THEM!

        // Cat and Cupcake images and positioning
        private Texture2D catImage;
        private Texture2D cupcakeImage;
        private Vector2 catPosition;
        private Rectangle resizedCupcakeRect;
        private Rectangle cupcakeRect;

        // Rotation
        private float rotationAngle;

        // Color for background
        private Color purplish;

        // SpriteFont for text
        private SpriteFont arial20;
        // ------------------------------------------------------------------------------------


        public Game1()
        {
            // DO NOT MODIFY!
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // CAN MODIFY!
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // ------------------------------------------------------------------------------------
            // ***** Initialize fields that are not dependent on content *****
            catPosition = new Vector2(0, 0);
            purplish = new Color(126, 94, 219);
            rotationAngle = 0f;
            // ------------------------------------------------------------------------------------

            // KEEP THIS AS THE LAST STATEMENT IN INITIALIZE
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // ------------------------------------------------------------------------------------
            // ***** Load Content *****
            catImage = Content.Load<Texture2D>("cat");
            cupcakeImage = Content.Load<Texture2D>("cupcake");
            arial20 = Content.Load<SpriteFont>("arial-20");

            // ------------------------------------------------------------------------------------
            // ***** Initialize fields  based on loaded content *****
            // Get a rectangle that is one-third the height of the cupcake
            resizedCupcakeRect = new Rectangle(200, 50, cupcakeImage.Width, cupcakeImage.Height/3);
            cupcakeRect = new Rectangle(500, 200, cupcakeImage.Width, cupcakeImage.Height);
            
            // ------------------------------------------------------------------------------------
        }

        protected override void Update(GameTime gameTime)
        {
            // CAN MODIFY IF NEED TO!
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            // Keyboard and Mouse information
            KeyboardState kbState = Keyboard.GetState();
            if(kbState.IsKeyDown(Keys.A))
            {
                rotationAngle += 0.05f;
            }

            MouseState mState = Mouse.GetState();
            if(mState.LeftButton == ButtonState.Pressed)
            {
                rotationAngle -= 0.05f;
            }

            // ------------------------------------------------------------------------------------
            // ***** Debugging Statements *****
            // Need to get some debugging statements?  Can use Debug.WriteLine() method!
            // Remove once you're done - SLOW!
            //System.Diagnostics.Debug.WriteLine("Hey");

            // Can also write just Debug.WriteLine and it will include the using statement
            //   necessary for writing to the Output window.
            //Debug.WriteLine("This also works!");

            // ------------------------------------------------------------------------------------
            // ***** Movement and Animation *****
            // Move cat to the right!  3 pixels per frame
            catPosition.X += 3;

            // Once the image is completely off-screen, "wrap" it back to the left
            if(catPosition.X > 800)
            {
                catPosition.X = -catImage.Width;
            }
            // ------------------------------------------------------------------------------------

            


            // KEEP THIS AS YOUR LAST STATEMENT IN UPDATE
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // ------------------------------------------------------------------------------------
            // ***** Change the background color *****
            // You can create custom colors from any RGB values:
            // FYI: if the color isn't changing, store it as a Color field.
            GraphicsDevice.Clear(purplish);

            // Feel free to use any other Color values, too:
            // OR GraphicsDevice.Clear(Color.Red);


            // ------------------------------------------------------------------------------------
            // ***** Render necessary content *****

            // ALWAYS NEEDED FOR DRAWING!!!
            _spriteBatch.Begin();

            // PUT YOUR DRAW CALLS HERE!
            _spriteBatch.Draw(
                catImage,                   // Image to use
                catPosition,                // Upper-left corner
                Color.White);               // Color overlay

            _spriteBatch.Draw(
                cupcakeImage,               // Image to use
                resizedCupcakeRect,         // Upper-left corner, W, H (as Rect)
                Color.DeepPink);            // Color overlay

            _spriteBatch.Draw(
               cupcakeImage,               // Image to use
               cupcakeRect,                // Upper-left corner, W, H (as Rect)
               Color.White);               // Color overlay

            _spriteBatch.Draw(
                catImage,
                new Vector2(400, 240),
                null,
                Color.White,
                rotationAngle,
                new Vector2(catImage.Width/2, catImage.Height/2),
                1f,
                SpriteEffects.None,
                1f);

            _spriteBatch.DrawString(
                arial20,                        // Which font?
                "Hi all",                       // What text?
                new Vector2(50, 50),            // Where?
                Color.Firebrick);               // Color?


            // ALWAYS NEEDED FOR DRAWING!!!
            _spriteBatch.End();
            // ------------------------------------------------------------------------------------

            // KEEP THIS AS YOUR LAST STATEMENT IN DRAW
            base.Draw(gameTime);
        }
    }
}