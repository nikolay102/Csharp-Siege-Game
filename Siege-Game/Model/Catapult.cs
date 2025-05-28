using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Siege_Game.View;

namespace Siege_Game.Model;

public class Catapult : BaseObject
{
    private CatapultDrawer catapultDrawer;
    
    private float angle = 10f;
    private float power = 5f;
    
    private float angleMax = 80f;
    private float angleMin = 10f;
    
    private float powerMax = 10f;
    private float powerMin = 1f;

    private int rocksAmount = 10;
    
    private bool isReload;

    public bool IsReload => isReload;

    public event Action angleChanged;
    public event Action powerChanged;
    public event Action fired; 

    public float Angle
    {
        get => angle;
        set
        {
            angle = value;
            angleChanged?.Invoke();
        }
    }
    
    public float AnglePercent => angle / angleMax;

    public float Power
    {
        get => power;
        set
        {
            power = value;
            powerChanged?.Invoke();
        }
    }

    public int RocksAmount => rocksAmount;
    public float PowerPercent => power / powerMax;

    public Catapult(Vector2 position, Texture2D idleTexture, Texture2D fireTexture, Texture2D reloadTexture, Texture2D reloadedTexture) : base(position, idleTexture)
    {
        catapultDrawer = new CatapultDrawer(reloadTexture, fireTexture, reloadedTexture, 64,this);
    }

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        catapultDrawer.Update(gameTime,spriteBatch);
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
    
    public void Reload()
    {
        if(isReload) return;
        isReload = true;
        catapultDrawer.DrawReload();
    }
    
    public void ThrowRock()
    {
        if (!isReload) return;
        if (rocksAmount > 0)
        {
            isReload = false;
            catapultDrawer.DrawFire();
            rocksAmount--;
            fired?.Invoke();
        }
    }

    public Vector2 GetFinalRockVector()
    {
        var angleInRads = -angle * MathHelper.Pi / 180f;
        var angleVector = new Vector2((float)Math.Cos(angleInRads), (float)Math.Sin(angleInRads));
        var result = angleVector * power;
        return result;
    }
}