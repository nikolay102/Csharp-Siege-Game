using System;

namespace Siege_Game.Model;

public class Castle
{
    private Tower tower1;
    private Tower tower2;
    private Tower tower3;
    private Tower currentTower;
    private King king;
    public Castle(Tower tower1, Tower tower2, Tower tower3, King king)
    {
        this.tower1 = tower1;
        this.tower2 = tower2;
        this.tower3 = tower3;
        this.tower1.win += OnWin;
        this.tower2.win += OnWin;
        this.tower3.win += OnWin;
        var radom = new Random();
        var rnd = radom.Next(0,3);
        if(rnd == 0)
            currentTower = tower1;
        if(rnd == 1)
            currentTower = tower2;
        if(rnd == 2)
            currentTower = tower3;
        this.king = king;
        currentTower = tower1;
        ChooseTower(tower1);
    }


    private void ChooseTower(Tower tower)
    {
        currentTower.IsKingOnTower = false;
        currentTower = tower;
        currentTower.IsKingOnTower = true;
        king.SetPos(currentTower.GetFullKingPos());
    }
    
    
    private void OnWin()
    {
        Console.WriteLine("You win!");
    }
}