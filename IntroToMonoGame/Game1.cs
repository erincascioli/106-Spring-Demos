using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

// Erin Cascioli
// 1/29/2024
// Demo: Introduction to MonoGame with Content Loading and Drawing
//        Mouse & Keyboard Input
//        SpriteFonts & Text

namespace IntroToMonoGame
{
    public class Game1 : Game
    {
        // DO NOT MODIFY!
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // ------------------------------------------------------------------------------------
        // ***** Declaring your own fields in the Game1 class *****
        // - FYI: COMMENT AND "CHUNK" YOUR FIELDS TO ORGANIZE THEM!
        // ------------------------------------------------------------------------------------

        // Cat and Cupcake images and positioning
        private Texture2D catImage;
        private Texture2D cupcakeImage;
        private Vector2 catPosition;
        private Rectangle resizedCupcakeRect;
        private Rectangle cupcakeRect;

        // Rotation for the smaller image
        private float rotationAngle;

        // Color for background
        private Color purplish;

        // SpriteFont for text
        private SpriteFont arial20;

        // Booleans that dictate what is rendered
        private bool displayText;


        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
        // ***** Game1 Constructor *****
        // - Not necessary to make many changes in this class.
        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        public Game1()
        {
            // DO NOT MODIFY!
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            // CAN MODIFY!
            IsMouseVisible = true;
        }


        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
        // ***** Initialize method *****
        // - Initialize fields that are not dependent on loaded content.
        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~

        protected override void Initialize()
        {
            // ------------------------------------------------------------------------------------
            // ***** Resize the window if needed *****
            // ------------------------------------------------------------------------------------
            // 800 wide x 600 high window
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            // ------------------------------------------------------------------------------------
            // ***** Initialize fields that are not dependent on content *****
            // ------------------------------------------------------------------------------------
            catPosition = new Vector2(0, 0);
            purplish = new Color(126, 94, 219);
            rotationAngle = 0f;

            // KEEP THIS AS THE LAST STATEMENT IN INITIALIZE!
            base.Initialize();
        }


        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
        // ***** LoadContent method *****
        // - Load in assets needed in this game.
        // - Initialize objects that require knowledge of any loaded assets here.
        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // ------------------------------------------------------------------------------------
            // ***** Load Content *****
            // Load Texture2Ds and SpriteFonts here.
            // The generic Content.Load<> method requires the asset type and asset name.
            // ------------------------------------------------------------------------------------
            catImage = Content.Load<Texture2D>("cat");
            cupcakeImage = Content.Load<Texture2D>("cupcake");
            arial20 = Content.Load<SpriteFont>("arial-20");

            // ------------------------------------------------------------------------------------
            // ***** Initialize fields  based on loaded content *****
            // Have anything dependent on a Texture2D's size? Initialize it here.
            // ------------------------------------------------------------------------------------
            // Get a rectangle that is one-third the height of the cupcake
            resizedCupcakeRect = new Rectangle(200, 50, cupcakeImage.Width, cupcakeImage.Height/3);
            cupcakeRect = new Rectangle(500, 200, cupcakeImage.Width, cupcakeImage.Height);
        }


        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
        // ***** Update method *****
        // Game logic and changes to position, sizing, or rotation can occur here.
        // Finite State Machine logic will be here, too.
        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
        protected override void Update(GameTime gameTime)
        {
            // CAN MODIFY IF NEED TO!
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // ------------------------------------------------------------------------------------
            // ***** Keyboard and Mouse Input *****
            // Gather information from the Keyboard and Mouse here in update.
            // ------------------------------------------------------------------------------------
            // Keyboard and Mouse information is retrieved from the GetState method.
            KeyboardState kbState = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            // Is the A key pressed? Rotate the image by 0.05 radians in a clockwise manner.
            if (kbState.IsKeyDown(Keys.A))
            {
                rotationAngle += 0.05f;
            }

            // Is the left mouse button held? Rotate the image by 0.05 radians in a counter-clockwise manner.
            if (mState.LeftButton == ButtonState.Pressed)
            {
                rotationAngle -= 0.05f;
            }

            // *********
            // ADD ANOTHER WAY OF DOING THIS ERINNNNNNNNNNNN!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
            if(mState.RightButton == ButtonState.Pressed)
            {
                displayText = true;
            }
            else
            {
                displayText = false;
            }

            // ------------------------------------------------------------------------------------
            // ***** Debugging Statements *****
            // - Need to get some debugging statements?  Can use Debug.WriteLine() method!
            // - Remove once you're done - SLOW!
            // ------------------------------------------------------------------------------------
            //System.Diagnostics.Debug.WriteLine("Current rotation angle: " + rotationAngle);

            // Can also write just Debug.WriteLine and it will include the using statement
            //   using System.Diagnostics; necessary for writing to the Output window.
            Debug.WriteLine("Smaller cupcake X: " + resizedCupcakeRect.X);
            Debug.WriteLine("Smaller cupcake Y: " + resizedCupcakeRect.Y);
            Debug.WriteLine("Smaller cupcake width: " + resizedCupcakeRect.Width);
            Debug.WriteLine("Smaller cupcake height: " + resizedCupcakeRect.Height);

            // ------------------------------------------------------------------------------------
            // ***** Movement and Animation *****
            // ------------------------------------------------------------------------------------
            // Move cat to the right!  3 pixels per frame
            catPosition.X += 3;

            // Once the image is completely off-screen, "wrap" it back to the left
            //   starting at a negative position, so that the image appears to float in 
            //   rather than teleport.
            if(catPosition.X > 800)
            {
                catPosition.X = -catImage.Width;
            }
            
            // KEEP THIS AS YOUR LAST STATEMENT IN UPDATE
                base.Update(gameTime);
        }



        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
        // ***** Draw method *****
        // Render images and text to the screen
        // Can check keyboard/mouse input if they necessitate rendering changes
        // ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~ ~
        protected override void Draw(GameTime gameTime)
        {
            // ------------------------------------------------------------------------------------
            // ***** Change the background color *****
            // ------------------------------------------------------------------------------------
            // You can create custom colors from any RGB values:
            // FYI: if the color isn't changing, store it as a Color field.
            GraphicsDevice.Clear(purplish);

            // Feel free to use any other Color values, too:
            // OR GraphicsDevice.Clear(Color.Red);


            // ------------------------------------------------------------------------------------
            // ***** SpriteBatch Drawing *****
            // Always call _spriteBatch.Begin()!!!
            // ------------------------------------------------------------------------------------
            // ALWAYS NEEDED FOR DRAWING!!!
            _spriteBatch.Begin();

            // ------------------------------------------------------------------------------------
            // ***** Render necessary content this frame *****
            // Draw what needs to be displayed in the game window in this frame.
            // ------------------------------------------------------------------------------------
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
                catImage,                                               // Image to use
                new Vector2(400, 240),                                  // Upper-left corner position (world-space)
                null,                                                   // Source rectangle (null if none)
                Color.White,                                            // Color overlay
                rotationAngle,                                          // Angle of rotation (in radians)
                new Vector2(catImage.Width/2, catImage.Height/2),       // Where is the point of rotation (in the image)
                1f,                                                     // Scale
                SpriteEffects.None,                                     // Should the image be flipped?
                1f);                                                    // Layer depth (use 1)

            _spriteBatch.DrawString(
                arial20,                    // Which font?
                "Hi all",                   // What text?
                new Vector2(50, 50),        // Where?
                Color.Firebrick);           // Color?

            // ------------------------------------------------------------------------------------
            // ***** Rendering based on input *****
            // Mouse and/or Keyboard input can be gathered if they facilitate rendered content
            // ------------------------------------------------------------------------------------
            // Draw the text as long as the user does *not* press enter.
            KeyboardState kbState = Keyboard.GetState();
            if (kbState.IsKeyUp(Keys.Enter))
            {
                _spriteBatch.DrawString(
                    arial20,
                    "This is based on the enter key!",
                    new Vector2(
                        _graphics.PreferredBackBufferWidth/2, 
                        _graphics.PreferredBackBufferHeight - 100),
                    Color.Black);
            }

            // Draw this text as long as the user presses the right mouse button
            if(displayText)
            {
                _spriteBatch.DrawString(
                    arial20,
                    "This is based on the enter key!",
                    new Vector2(
                        _graphics.PreferredBackBufferWidth/2, 
                        _graphics.PreferredBackBufferHeight - 100),
                    Color.Black);
            }

            // ------------------------------------------------------------------------------------
            // ***** End the SpriteBatch  *****
            // Always call _spriteBatch.End()!!!
            // ------------------------------------------------------------------------------------
            // ALWAYS NEEDED FOR DRAWING!!!
            _spriteBatch.End();


            // KEEP THIS AS YOUR LAST STATEMENT IN DRAW
            base.Draw(gameTime);
        }
    }
}