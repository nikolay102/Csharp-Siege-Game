using System;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Siege_Game.Model;

public class Castle
{
    private Tower tower1;
    private Tower tower2;
    private Tower tower3;
    public Tower currentTower;
    private King king;
    private float timer;
    private const float delay = 5f;
    public Castle(Tower tower1, Tower tower2, Tower tower3, King king)
    {
        this.tower1 = tower1;
        this.tower2 = tower2;
        this.tower3 = tower3;
        
        var radom = new Random();
        var rnd = radom.Next(0,3);
        if(rnd == 0)
            currentTower = tower1;
        if(rnd == 1)
            currentTower = tower2;
        if(rnd == 2)
            currentTower = tower3;
        this.king = king;
        ChooseTower(currentTower);
    }

    public void Update(GameTime gameTime)
    {
        timer+=(float)gameTime.ElapsedGameTime.TotalSeconds;
        if (timer >= delay)
        {
            var radom = new Random();
            var rnd = radom.Next(0,3);
            if(rnd == 0)
                ChooseTower(tower1);
            else if(rnd == 1)
                ChooseTower(tower2);
            else if(rnd == 2)
                ChooseTower(tower3);
            timer = 0f;
        }
    }
    

    public void ChooseTower(Tower tower)
    {
        currentTower.IsKingOnTower = false;
        currentTower = tower;
        currentTower.IsKingOnTower = true;
        king.SetPos(currentTower.GetFullKingPos());
    }
    
}