using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Sprites;
using SpaceGame.Sprites.ShipStateSprites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers.ShipStateManagers
{
    public class PeopleManager
    {
        public List<SSSprite> people;

        public PeopleManager()
        {
            people = new List<SSSprite>();
            people.Add(new SSSprite(Vector2.Zero, LimitsEdgeGame.animations["basic_person_walk_down"]));
        }

        public void Update(GameTime gameTime)
        {
            foreach (var person in people)
            {
                person.Update(gameTime);
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (var person in people)
            {
                person.Draw(spriteBatch);
            }
        }
    }
}
