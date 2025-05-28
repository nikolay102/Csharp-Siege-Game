using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Siege_Game.Model;

namespace Siege_Game.View;

public class UiDrawer
{
    private Catapult catapult;
    private SpriteFont font;
    private Sprite sprite;
    private Texture2D sliderTexture; 
    private Texture2D powerTexture; 
    private Texture2D angleTexture;
    private King king;
    
    private float power;
    private float angle;

    public UiDrawer(Catapult catapult, King king, SpriteFont text, ContentManager Content)
    {
        this.catapult = catapult;
        this.king = king;
        this.catapult.powerChanged += CatapultOnpowerChanged;
        this.catapult.angleChanged += CatapultOnangleChanged;
        font = text;
        sliderTexture = Content.Load<Texture2D>("slider");
        powerTexture = Content.Load<Texture2D>("power");
        angleTexture = Content.Load<Texture2D>("angle");
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
        if (king.Hp > 0 && catapult.RocksAmount > 0)
        {
            spriteBatch.DrawString(font, $"Angle {catapult.Angle.ToString()}", new Vector2(100, 50), color);
            spriteBatch.DrawString(font, $"Force {catapult.Power.ToString()}", new Vector2(100, 70), color);// draw text
            spriteBatch.DrawString(font, $"HpKing {king.Hp.ToString()}", new Vector2(100, 90), color);
            spriteBatch.DrawString(font, $"RocksAmount {catapult.RocksAmount.ToString()}", new Vector2(100, 110), color);
        }
        if (king.Hp <= 0)
        {
            spriteBatch.DrawString(font, $"KING IS DEAD - YOU WIN", new Vector2(100, 50), color);
        }
        else if (catapult.RocksAmount <= 0)
        {
            spriteBatch.DrawString(font, $"You DONT HAVE ENOUGH ROCKS", new Vector2(100, 50), color);
        }
        
        spriteBatch.Draw(powerTexture, new Vector2(25,580), Color.White);
        spriteBatch.Draw(angleTexture, new Vector2(5,515), Color.White);
        
        var powerInPercents = (int)(catapult.PowerPercent * 52);
        spriteBatch.Draw(sliderTexture,new Vector2(25+powerInPercents+4,580+4), Color.White);
        var angleInPercents = (int)(catapult.AnglePercent * 52);
        spriteBatch.Draw(sliderTexture,new Vector2(5+4,562-angleInPercents+4), Color.White);
    }
}  