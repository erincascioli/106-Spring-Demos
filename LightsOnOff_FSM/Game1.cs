using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LightsOnOff_FSM
{


    // -----------------------------------------------
    // Enum to describe the 2 states: on and off
    // -----------------------------------------------
    public enum LightState
    {
        On,
        Off
    }


    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;


        // -----------------------------------------------
        // Lights on variables - Finite State Machine
        // -----------------------------------------------
        // ** Enum to hold current state:
        private LightState lights;
        private Color backgroundColor;      // Background color 
        private Texture2D lightOn;          // Light switch image 1
        private Texture2D lightOff;         // Light switch image 2



        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // -----------------------------------------------
            // Initialize variables that are not dependent on loading content
            // -----------------------------------------------
            // Start with a default state:
            lights = LightState.Off;

            // Set background color dependent on default state
            backgroundColor = Color.Black;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // -----------------------------------------------
            // Initialize variables that are dependent on loaded content
            // -----------------------------------------------
            lightOn = Content.Load<Texture2D>("lightOn");
            lightOff = Content.Load<Texture2D>("lightOff");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || 
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // -----------------------------------------------
            // Checking Keyboard state to turn light on or off
            // -----------------------------------------------
            KeyboardState kbState = Keyboard.GetState();


            // -----------------------------------------------
            // Finite State Machine (FSM)
            // Handling transitions should only be done here in Update.
            // However, you can check the state anywhere in your code.
            // For example, checking what the state it to show the proper Texture2D.
            // When a lot of code would be necessary to handle the current state, 
            //   writing static methods to handle it or calling methods from a class
            //   would be advantageous - cleaner, easier to read, more organized. 
            // So why use the FSM?  
            // Cleaner code.
            // Easier to keep track of a single variable changing states than booleans that swap true/false.
            // More organized. All transitions are inside the case they're transitioning from. 
            // -----------------------------------------------
            switch (lights)
            {
                case LightState.On:
                    // Handle game logic for this state:
                    // Set background color to yellow
                    backgroundColor = Color.Yellow;

                    // Handle transition to other states
                    // If user presses F, turn the lights off
                    if (kbState.IsKeyDown(Keys.F))
                    {
                        lights = LightState.Off;
                    }
                    // Don't code a "do nothing" or "change nothing" state!
                    // You would NOT want this:
                    //else if( do nothing )
                    //{
                    //    lights = LightState.On;
                    //}

                    break;

                case LightState.Off:
                    // Handle game logic for this state:
                    // Set background color to dark gray 
                    //backgroundColor = Color.fromArgb();
                    backgroundColor = new Color(60, 60, 60);

                    // Handle transition to other states
                    // If user presses N, turn the lights on
                    if (kbState.IsKeyDown(Keys.N))
                    {
                        lights = LightState.On;
                    }
                    // Don't code a "do nothing" or "change nothing" state!
                    // You would NOT want this:
                    //else if( do nothing )
                    //{
                    //    lights = LightState.Off;
                    //}

                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // -----------------------------------------------
            // Background color has changed from Cornflower blue
            // -----------------------------------------------
            GraphicsDevice.Clear(backgroundColor);

            // -----------------------------------------------
            // Change background color depending on if lights are on or off
            // -----------------------------------------------
            _spriteBatch.Begin();

            // Draw the correct image with necessary tint
            // Must CHECK the value of the enum variable after the FSM runs,
            //   but DO NOT change transitions to other states here!
            switch (lights)
            {
                case LightState.On:
                    _spriteBatch.Draw(lightOn, new Vector2(50, 50), Color.White);
                    break;
                case LightState.Off:
                    _spriteBatch.Draw(lightOff, new Vector2(50, 50), Color.DarkGray);
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}