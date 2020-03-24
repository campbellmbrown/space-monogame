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
        public List<Person> people;

        public PeopleManager(ShipTileManager tileManager)
        {
            people = new List<Person>();
            people.Add(new Person(new Vector2(100, 324), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(108, 324), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(116, 324), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(100, 316), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(100, 308), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(100, 300), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(100, 324), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(108, 324), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(116, 324), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(100, 316), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(100, 308), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
            people.Add(new Person(new Vector2(100, 300), LimitsEdgeGame.animations["basic_person_walk_down"], tileManager.walkableTiles));
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
