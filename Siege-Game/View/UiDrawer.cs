using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Siege_Game.Model;

namespace Siege_Game.View;

public class UiDrawer
{
    private Catapult catapult;
    private SpriteFont font;
    private SpriteFont fontSmall;
    private Sprite sprite;
    private Texture2D sliderTexture; 
    private Texture2D powerTexture; 
    private Texture2D angleTexture;
    private Texture2D rButtonTexture;
    private Texture2D rlButtonsTexture;
    private Texture2D spaceButtonTexture;
    private Texture2D tdButtonsTexture;
    
    private King king;
    
    private float power;
    private float angle;

    public UiDrawer(Catapult catapult, King king, SpriteFont text,SpriteFont textSmall, ContentManager Content)
    {
        this.catapult = catapult;
        this.king = king;
        this.catapult.powerChanged += CatapultOnpowerChanged;
        this.catapult.angleChanged += CatapultOnangleChanged;
        font = text;
        fontSmall = textSmall;
        sliderTexture = Content.Load<Texture2D>("slider");
        powerTexture = Content.Load<Texture2D>("power");
        angleTexture = Content.Load<Texture2D>("angle");
        rButtonTexture = Content.Load<Texture2D>("Rbutton");
        rlButtonsTexture = Content.Load<Texture2D>("RightLeft");
        spaceButtonTexture = Content.Load<Texture2D>("SpaceButton");
        tdButtonsTexture = Content.Load<Texture2D>("TopDown");
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
        
        var color = new Color(255, 255, 255);
        if (king.Hp > 0 && catapult.RocksAmount > 0)
        {
            
            spriteBatch.DrawString(font, $"Угол :  {catapult.Angle.ToString()}", new Vector2(70, 50-30), color);
            spriteBatch.DrawString(font, $"Сила :  {catapult.Power.ToString()}", new Vector2(70, 85-30), color);
            spriteBatch.DrawString(font, $"Здоровье Короля :  {king.Hp.ToString()}", new Vector2(70, 120-30), color);
            spriteBatch.DrawString(font, $"Снарядов осталось :  {catapult.RocksAmount.ToString()}", new Vector2(70, 155-30), color);
            spriteBatch.DrawString(font, "Перезарядка", new Vector2(70, 190-30), color);
            spriteBatch.DrawString(font, "Огонь", new Vector2(70, 225-30), color);
            spriteBatch.Draw(rButtonTexture, new Vector2(20, 165), color);
            spriteBatch.Draw(rlButtonsTexture, new Vector2(20, 60), color);
            spriteBatch.Draw(tdButtonsTexture, new Vector2(20, 25), color);
            spriteBatch.Draw(spaceButtonTexture, new Vector2(2, 200), color);
        }
        if (king.Hp <= 0)
        {
            spriteBatch.DrawString(font, "Старый король умер!", new Vector2(223, 50), color);
            spriteBatch.DrawString(font, "Вы покрыли себя славой", new Vector2(200, 80), color);
        }
        else if (catapult.RocksAmount <= 0)
        {
            spriteBatch.DrawString(font, "Снаряды закончились, Королю удалось уцелеть!", new Vector2(50, 50), color);
            spriteBatch.DrawString(font, "Вы опозорили своего лорда до скончания века", new Vector2(58, 80), color);
        }
        
        spriteBatch.Draw(powerTexture, new Vector2(25,580), Color.White);
        spriteBatch.Draw(angleTexture, new Vector2(5,515), Color.White);
        
        var powerInPercents = (int)(catapult.PowerPercent * 52);
        spriteBatch.Draw(sliderTexture,new Vector2(25+powerInPercents+4,580+4), Color.White);
        var angleInPercents = (int)(catapult.AnglePercent * 52);
        spriteBatch.Draw(sliderTexture,new Vector2(5+4,562-angleInPercents+4), Color.White);
    }
}  