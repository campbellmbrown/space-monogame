using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SpaceGame.Sprites;
using SpaceGame.Sprites.ShipStateSprites;
using SpaceGame.Tiles;
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
            for (int i = 0; i < 20; ++i) SpawnPerson(tileManager.walkableTiles);
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

        public void SpawnPerson(List<ShipFloorTile> walkableTiles)
        {
            ShipFloorTile spawningTile = walkableTiles.ElementAt(LimitsEdgeGame.r.Next(0, walkableTiles.Count()));
            Vector2 spawningPosition = new Vector2(spawningTile.X + Tile.tileSize / 2f, spawningTile.Y + Tile.tileSize / 2f);
            people.Add(new Person(spawningPosition, LimitsEdgeGame.animations["basic_person_walk_down"], walkableTiles));
        }
    }
}
