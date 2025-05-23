using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Siege_Game.Model;
using Vector2 = System.Numerics.Vector2;

namespace Siege_Game.View;

public class CatapultDrawer
{
    private Texture2D reloadingTexture;
    private Texture2D reloadedTexture;
    private Texture2D fireTexture;
    private int currentFrame;
    private int spriteSize;
    private int spritesAmount = 1;
    private CatapultStatus status;
    private Catapult catapult;

    public CatapultDrawer(Texture2D reloadingTexture, Texture2D fireTexture, Texture2D reloadedTexture, int spriteSize, Catapult catapult)
    {
        this.reloadingTexture = reloadingTexture;
        this.reloadedTexture = reloadedTexture;
        this.fireTexture = fireTexture;
        this.spriteSize = spriteSize;
        this.catapult = catapult;
    }

    public void DrawFire()
    {
        status = CatapultStatus.Fired;
        spritesAmount = 11;
    }
    
    public void DrawReload()
    {
        status = CatapultStatus.Reloading;
        spritesAmount = 5;
    }
    
    public void Update(GameTime gameTime, SpriteBatch spriteBatch)
    {
        switch (status)
        {
            case CatapultStatus.Idle:
                spriteBatch.Draw(catapult.IsReload ? reloadedTexture : catapult.Texture, catapult.Position, Color.White);
                break;
            case CatapultStatus.Reloading:
                spriteBatch.Draw(reloadingTexture, catapult.Position,
                    new Rectangle(currentFrame * spriteSize,
                        0,
                        spriteSize, spriteSize),
                    Color.White, 0, Vector2.Zero,
                    1, SpriteEffects.None, 0);
                if (currentFrame == spritesAmount - 1)
                {
                    status = CatapultStatus.Idle;
                    spritesAmount = 1;
                }
                break;
            case CatapultStatus.Fired:
                spriteBatch.Draw(fireTexture, catapult.Position,
                    new Rectangle(currentFrame * spriteSize,
                        0,
                        spriteSize, spriteSize),
                    Color.White, 0, Vector2.Zero,
                    1, SpriteEffects.None, 0);
                if (currentFrame == spritesAmount - 1)
                {
                    status = CatapultStatus.Idle;
                    spritesAmount = 1;
                }
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        currentFrame++;
        currentFrame = MathHelper.Clamp(currentFrame, 0, spritesAmount-1);
    }
}

public enum CatapultStatus
{
    Idle = 0,
    Reloading = 1,
    Fired = 2,
}