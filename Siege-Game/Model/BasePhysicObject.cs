using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Siege_Game.Model;

public abstract class BasePhysicObject(Vector2 position, Texture2D texture) : BaseObject(position, texture)
{
    protected float g = 0.5f;
    protected Vector2 force;
    protected float Xmax = 800;
    protected float Xmin = 0;
    protected float Ymax = 565;
    protected float Ymin = 0;

    public void AddForce(Vector2 force)
    {
        this.force += force;
    }
    
    public override void Update(GameTime gameTime)
    {
        position += force;
        position.X = MathHelper.Clamp(position.X, Xmin, Xmax);
        position.Y = MathHelper.Clamp(position.Y, Ymin, Ymax);
        force.X -= CalculateSopr(force.X);
        position.Y += g;
        force.Y += g/5;
        if (position.Y > 560)
        {
            force.X = 0;
        }
    }

    private float CalculateSopr(float value)
    {
        if(value > 1)
            return 0.0025f;
        if(value > 0.5)
            return 0.002f;
        if(value > 0.25)
            return 0.0012f;
        if(value > 0.1)
            return 0.01f;
        if(value > 0.05f)
            return value;
        return value;
    }
    
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, Color.White);
    }
}