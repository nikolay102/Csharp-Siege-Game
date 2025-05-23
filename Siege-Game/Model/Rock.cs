using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Siege_Game.Model;

public class Rock(Vector2 position, Texture2D texture) : BasePhysicObject(position, texture)
{
    public event Action<Rock> deleted;
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);
    }

    public void CheckTowers(List<Tower> towers)
    {
        var sourceRectangle = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
        foreach (var tower in towers)
        {
            if (sourceRectangle.Intersects(tower.SourceRectangle))
            {
                tower.CheckHit();
                deleted?.Invoke(this);
            }
        }
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        base.Draw(gameTime, spriteBatch);
    }
}