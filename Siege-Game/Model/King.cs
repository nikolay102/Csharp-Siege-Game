using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Siege_Game.Model;

public class King(Vector2 position, Texture2D texture) : BaseObject(position, texture)
{

    public void SetPos(Vector2 pos)
    {
        position = pos;
    }
    public override void Update(GameTime gameTime)
    {
        
    }
    
    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, Color.White);
    }
}