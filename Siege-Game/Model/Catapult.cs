using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Siege_Game.Model;

public class Catapult(Vector2 position, Texture2D texture) : BaseObject(position, texture)
{
    private float angle = 10f;
    private float power = 1f;

    private float angleMax = 80f;
    private float angleMin = 10f;
    
    private float powerMax = 10f;
    private float powerMin = 1f;
    
    public event Action angleChanged;
    public event Action powerChanged;

    public float Angle
    {
        get => angle;
        set
        {
            angle = value;
            angleChanged?.Invoke();
        }
    }

    public float Power
    {
        get => power;
        set
        {
            power = value;
            powerChanged?.Invoke();
        }
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, Color.White);
    }

    public void ThrowRock()
    {
        
    }

    public void ChangeAngle(float difference)
    {
        angle += difference;
        angle = MathHelper.Clamp(angle, angleMin, angleMax);
    }

    public void ChangePower(float difference)
    {
        power += difference;
        power = MathHelper.Clamp(power, powerMin, powerMax);
    }
}