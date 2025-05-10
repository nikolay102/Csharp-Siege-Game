using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Siege_Game.Model;
using Vector2 = System.Numerics.Vector2;

namespace Siege_Game;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    private Catapult catapult;
    private List<BaseObject> objects;
    
    
    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        catapult = new Catapult(new Vector2(20,400), Content.Load<Texture2D>("Catapult"));
        var rock = new Rock(new Vector2(20,300), Content.Load<Texture2D>("Catapult"));
        rock.AddForce(new Vector2(5f, 0f));
        
        base.Initialize();
        objects = new List<BaseObject>()
        {
            catapult,
            rock
        };
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);
        
        // TODO: use this.Content to load your game content here
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
            Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        
        foreach (var baseObject in objects)
        {
            baseObject.Update(gameTime);
        }
        
        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);
        
        // трисовка спрайта
        spriteBatch.Begin();
        foreach (var baseObject in objects)
        {
            baseObject.Draw(gameTime, spriteBatch);
        }
        spriteBatch.End();

        base.Draw(gameTime);
    }
}