using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    public class RespawnManager
    {
        protected int distanceFromScreenEdge;
        protected int spawningBand;
        protected int spawningToDespawningBuffer;
        protected Vector2 topLeftCorner { get { return Game1.topLeftCorner; } }
        protected Vector2 zoomedScreenSize { get { return Game1.zoomedScreenSize; } }
        protected float zoom { get { return Game1.camera.Zoom; } }

        public RespawnManager(int distanceFromScreenEdge, int spawningBand, int spawningToDespawningBuffer)
        {
            this.distanceFromScreenEdge = distanceFromScreenEdge;
            this.spawningBand = spawningBand;
            this.spawningToDespawningBuffer = spawningToDespawningBuffer;
        }

        public bool OutOfBounds(Vector2 position)
        {
            float distanceToDespawn = distanceFromScreenEdge + spawningBand + spawningToDespawningBuffer;
            if (position.X < topLeftCorner.X - distanceToDespawn ||
                position.X > topLeftCorner.X + zoomedScreenSize.X + distanceToDespawn ||
                position.Y < topLeftCorner.Y - distanceToDespawn ||
                position.Y > topLeftCorner.Y + zoomedScreenSize.Y + distanceToDespawn)
                return true;
            return false;
        }

        public Vector2 GenerateNewPosition()
        {
            int choose = Game1.r.Next(0, 4);
            Vector2 newPosition;
            switch (choose)
            {
                case 0:
                    newPosition = topLeftCorner + new Vector2(
                        -distanceFromScreenEdge + Game1.r.Next(-spawningBand, 1),
                        Game1.r.Next(-distanceFromScreenEdge - spawningBand, (int)zoomedScreenSize.Y + distanceFromScreenEdge + spawningBand + 1));
                    break;
                case 1:
                    newPosition = topLeftCorner + new Vector2(
                        zoomedScreenSize.X + distanceFromScreenEdge + Game1.r.Next(0, spawningBand + 1),
                        Game1.r.Next(-distanceFromScreenEdge - spawningBand, (int)zoomedScreenSize.Y + distanceFromScreenEdge + spawningBand + 1));
                    break;
                case 2:
                    newPosition = topLeftCorner + new Vector2(
                        Game1.r.Next(-distanceFromScreenEdge, (int)zoomedScreenSize.X + distanceFromScreenEdge + 1),
                        -distanceFromScreenEdge + Game1.r.Next(-spawningBand, 1));
                    break;
                case 3:
                    newPosition = topLeftCorner + new Vector2(
                        Game1.r.Next(-distanceFromScreenEdge, (int)zoomedScreenSize.X + distanceFromScreenEdge + 1),
                        zoomedScreenSize.X + distanceFromScreenEdge + Game1.r.Next(0, spawningBand + 1));
                    break;
                default:
                    newPosition = Vector2.Zero;
                    break;
            }
            return newPosition;
        }
    }
}
