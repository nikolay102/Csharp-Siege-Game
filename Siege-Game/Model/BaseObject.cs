using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Siege_Game.Model;

public abstract class BaseObject(Vector2 position, Texture2D texture)
{
    protected Vector2 position = position;
    protected Texture2D texture = texture;

    public Vector2 Position => position;

    public Texture2D Texture => texture;

    public abstract void Update(GameTime gameTime);
    public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);
}