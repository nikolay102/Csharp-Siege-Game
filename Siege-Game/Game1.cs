using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Siege_Game.Controller;
using Siege_Game.Model;
using Siege_Game.View;

namespace Siege_Game;

public class Game1 : Game
{
    private GraphicsDeviceManager _graphics;
    private SpriteBatch spriteBatch;
    private Catapult catapult;
    private List<BaseObject> objects;
    private List<Rock> rocks;
    private List<Tower> towers;
    private InputManager inputManager;
    private UiDrawer uiDrawer;
    private King king;
    private Castle castle;

    public Game1()
    {
        _graphics = new GraphicsDeviceManager(this);
        _graphics.PreferredBackBufferHeight = 600;
        _graphics.PreferredBackBufferWidth = 800;
        _graphics.ApplyChanges();
        Content.RootDirectory = "Content";
        IsMouseVisible = true;
    }

    protected override void Initialize()
    {
        // TODO: Add your initialization logic here
        catapult = new Catapult(new Vector2(20, 536), Content.Load<Texture2D>("idle_withoutrock"),
            Content.Load<Texture2D>("fire"), Content.Load<Texture2D>("reload"),
            Content.Load<Texture2D>("idle_withrock"));
        catapult.fired += OnFired;
        inputManager = new InputManager(catapult);
        uiDrawer = new UiDrawer(catapult, Content.Load<SpriteFont>("mytext1"));
        
        king = new King(new Vector2(300, 472), Content.Load<Texture2D>("king"));
        var tower1 = new Tower(new Vector2(300, 472), Content.Load<Texture2D>("tower1"), 64, 128, new Vector2(0,0));
        var tower3 = new Tower(new Vector2(450, 536), Content.Load<Texture2D>("castle"), 64, 64, new Vector2(0,0));
        var tower2 = new Tower(new Vector2(600, 408), Content.Load<Texture2D>("tower2"), 64, 192, new Vector2(0,0));
        castle = new Castle(tower1,tower3,tower2, king);
        
        towers = new List<Tower>
        {
            tower1,
            tower3,
            tower2
        };

        rocks = new List<Rock>();
        
        base.Initialize();
        objects = new List<BaseObject>()
        {
            catapult,
            tower1,
            tower3,
            tower2,
            king
        };
    }

    private void OnFired()
    {
        var rock = new Rock(new Vector2(30, 526), Content.Load<Texture2D>("rock"));
        rock.AddForce(catapult.GetFinalRockVector());
        rock.deleted += RockOnDeleted;
        objects.Add(rock);
        rocks.Add(rock);
    }

    private void RockOnDeleted(Rock rock)
    {
        objects.Remove(rock);
        rocks.Remove(rock);
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

        for (int i = 0; i < rocks.Count; i++)
        {
            var rock = rocks[i];
            rock.CheckTowers(towers);
        }

        inputManager.Update();
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

        uiDrawer.Draw(spriteBatch);
        spriteBatch.End();

        base.Draw(gameTime);
    }
}