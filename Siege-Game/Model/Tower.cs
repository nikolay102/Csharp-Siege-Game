using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Siege_Game.Model;

public class Tower(Vector2 position, Texture2D texture, int xSize, int ySize, Vector2 kingPos) : BaseObject(position, texture)
{
    private int xSize = xSize;
    private int ySize = ySize;
    private bool isKingOnTower;
    private Vector2 kingPos = kingPos;
    
    public bool IsKingOnTower
    {
        get => isKingOnTower;
        set => isKingOnTower = value;
    }

    private Rectangle sourceRectangle = new ((int)position.X+10, (int)position.Y-10, xSize-10, ySize-10);

    public Rectangle SourceRectangle => sourceRectangle;

    public event Action kingIsHitted;
    
    
    public void CheckHit()
    {
        if(IsKingOnTower)
            kingIsHitted?.Invoke();
    }

    public Vector2 FullKingPos => kingPos + position;

    public override void Update(GameTime gameTime)
    {
        
    }

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, position, Color.White);
    }
}