using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace LightsOnOff_FSM
{
    // ******* WHAT IS THIS? ********
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

        // ******* WHAT IS THIS? ********
        private LightState lights;

        // ** Fields to handle display to user
        private Color backgroundColor;          // Background color 
        private Texture2D lightOnTex2d;         // Light switch image 1
        private Texture2D lightOffTex2d;        // Light switch image 2



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

            // ******* WHAT IS THIS? ********
            lights = LightState.Off;

            // Set background color dependent on initialized state
            backgroundColor = Color.Black;

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // -----------------------------------------------
            // Initialize variables that are dependent on loaded content
            // -----------------------------------------------
            lightOnTex2d = Content.Load<Texture2D>("lightOn");
            lightOffTex2d = Content.Load<Texture2D>("lightOff");
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


            // ******* WHAT DOES THIS DO? ********
            switch (lights)
            {
                case LightState.On:

                    backgroundColor = Color.Yellow;

                    if (kbState.IsKeyDown(Keys.F))
                    {
                        lights = LightState.Off;
                    }

                    break;

                case LightState.Off:

                    backgroundColor = new Color(60, 60, 60);

                    if (kbState.IsKeyDown(Keys.N))
                    {
                        lights = LightState.On;
                    }

                    break;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(backgroundColor);

            _spriteBatch.Begin();


            // ******* WHAT DOES THIS DO? ********
            switch (lights)
            {
                case LightState.On:
                    _spriteBatch.Draw(lightOnTex2d, new Vector2(50, 50), Color.White);
                    break;
                case LightState.Off:
                    _spriteBatch.Draw(lightOffTex2d, new Vector2(50, 50), Color.DarkGray);
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}