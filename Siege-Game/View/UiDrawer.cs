using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Siege_Game.Model;

namespace Siege_Game.View;

public class UiDrawer
{
    private Catapult catapult;
    private SpriteFont font;
    private Sprite sprite;
    private Texture2D slider;
        
    private float power;
    private float angle;

    public UiDrawer(Catapult catapult,SpriteFont text)
    {
        this.catapult = catapult;
        this.catapult.powerChanged += CatapultOnpowerChanged;
        this.catapult.angleChanged += CatapultOnangleChanged;
        font = text;
    }
    
    private void CatapultOnangleChanged()
    {
        angle = catapult.Angle;
    }

    private void CatapultOnpowerChanged()
    {
        power = catapult.Power;
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        var color = new Color(255, 255, 0);// color yellow
        spriteBatch.DrawString(font, $"Angle {catapult.Angle.ToString()}", new Vector2(100, 50), color);
        spriteBatch.DrawString(font, $"Force {catapult.Power.ToString()}", new Vector2(100, 70), color);// draw text
        
    }
}  