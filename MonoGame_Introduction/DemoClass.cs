using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGame_Introduction
{

    // This class name doesn't matter - we just need to try it for a second :)
    internal class DemoClass
    {
        // Fields
        private Texture2D objImage;
        private Vector2 location;

        public DemoClass(Texture2D objImage, Vector2 location)
        {
            this.objImage = objImage;
            this.location = location;
        }

        public void Update()
        {
            location.Y += 0.1f;
        }

        public void Draw(SpriteBatch _spriteBatch)
        {
            _spriteBatch.Draw(
                objImage,
                location,
                Color.White);
        }
    }
}
