using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Siege_Game.Model;

public class Rock(Vector2 position, Texture2D texture) : BasePhysicObject(position, texture)
{
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
        Console.WriteLine(position);
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);
    }
}