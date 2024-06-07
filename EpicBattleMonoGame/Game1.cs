using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace EpicBattleMonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Fighter _myHero;
        private List<Minion> _minionList;

        private int _numMinions;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _numMinions = 5;
            _minionList = new List<Minion>();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //for(int i = 0; i <  _numMinions; i++)
            //{
            SpriteFont minionFont = Content.Load<SpriteFont>("MinionFont");
                _minionList.Add(new Goblin(20, 5, 3,Content.Load<Texture2D>("goblinSprite"), minionFont, 100, 100));
                _minionList.Add(new Skellie(19, Content.Load<Texture2D>("skellieSprite"), minionFont, 300, 100));
                _minionList.Add(new Slime(35, false, Content.Load<Texture2D>("slimeSprite"), minionFont, 500, 100));
            //}
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Minion m in _minionList)
            {
                m.Update(gameTime);
            }

            for(int i = 0; i <  _minionList.Count; i++)
            {
                if (_minionList[i].GetHealth() < 0)
                    _minionList.RemoveAt(i);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (Minion m in _minionList)
            {
                m.Draw(_spriteBatch);
            }

            base.Draw(gameTime);
        }
    }
}
