using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Tiles
{
    public class CollidableWall : Tile
    {
        public CollidableWall(Texture2D texture, Vector2 position, SpecificTileType specificTileType) : base(texture, position, specificTileType)
        {
        }
    }
}
