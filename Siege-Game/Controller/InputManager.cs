using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Siege_Game.Model;

namespace Siege_Game.Controller;

public class InputManager
{
    private Catapult catapult;
    private float angleDelta = 1f;
    private float powerDelta = 0.05f;
    public InputManager(Catapult catapult)
    {
        this.catapult = catapult;
    }

    public void Update()
    {
        var keyboardState = Keyboard.GetState();
        
        if (keyboardState.IsKeyDown(Keys.R))
            catapult.ChangePower(powerDelta);
        if (keyboardState.IsKeyDown(Keys.F))
            catapult.ChangePower(-powerDelta);
        if (keyboardState.IsKeyDown(Keys.T))
            catapult.ChangeAngle(angleDelta);
        if (keyboardState.IsKeyDown(Keys.G))
            catapult.ChangeAngle(-angleDelta);
    }
}