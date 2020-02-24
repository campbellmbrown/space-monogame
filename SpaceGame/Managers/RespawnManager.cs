using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Managers
{
    /// <summary>
    /// Class to handle respawns.
    /// </summary>
    public class RespawnManager
    {
        protected int distanceFromScreenEdge;
        protected int spawningBand;
        protected int spawningToDespawningBuffer;
        protected Vector2 topLeftCorner { get { return LimitsEdgeGame.topLeftCorner; } }
        protected Vector2 zoomedScreenSize { get { return LimitsEdgeGame.zoomedScreenSize; } }
        protected float zoom { get { return LimitsEdgeGame.camera.Zoom; } }

        /// <summary>
        /// Creates an instance of the RespawnManager class.
        /// </summary>
        /// <param name="distanceFromScreenEdge">The distance that objects can spawn from the screen edge.</param>
        /// <param name="spawningBand">The band that is spawnable, surrounding the screen.</param>
        /// <param name="spawningToDespawningBuffer">A distance from the edge of the spawning band where things won't despawn.</param>
        public RespawnManager(int distanceFromScreenEdge, int spawningBand, int spawningToDespawningBuffer)
        {
            this.distanceFromScreenEdge = distanceFromScreenEdge;
            this.spawningBand = spawningBand;
            this.spawningToDespawningBuffer = spawningToDespawningBuffer;
        }

        /// <summary>
        /// Returns true if a position is outside of the allowable area.
        /// </summary>
        /// <param name="position">Position to check.</param>
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

        /// <summary>
        /// Generates a new position inside of the spawnable area.
        /// </summary>
        public Vector2 GenerateNewPosition()
        {
            int choose = LimitsEdgeGame.r.Next(0, 4);
            Vector2 newPosition;
            switch (choose)
            {
                case 0:
                    newPosition = topLeftCorner + new Vector2(
                        -distanceFromScreenEdge + LimitsEdgeGame.r.Next(-spawningBand, 1),
                        LimitsEdgeGame.r.Next(-distanceFromScreenEdge - spawningBand, (int)zoomedScreenSize.Y + distanceFromScreenEdge + spawningBand + 1));
                    break;
                case 1:
                    newPosition = topLeftCorner + new Vector2(
                        zoomedScreenSize.X + distanceFromScreenEdge + LimitsEdgeGame.r.Next(0, spawningBand + 1),
                        LimitsEdgeGame.r.Next(-distanceFromScreenEdge - spawningBand, (int)zoomedScreenSize.Y + distanceFromScreenEdge + spawningBand + 1));
                    break;
                case 2:
                    newPosition = topLeftCorner + new Vector2(
                        LimitsEdgeGame.r.Next(-distanceFromScreenEdge, (int)zoomedScreenSize.X + distanceFromScreenEdge + 1),
                        -distanceFromScreenEdge + LimitsEdgeGame.r.Next(-spawningBand, 1));
                    break;
                case 3:
                    newPosition = topLeftCorner + new Vector2(
                        LimitsEdgeGame.r.Next(-distanceFromScreenEdge, (int)zoomedScreenSize.X + distanceFromScreenEdge + 1),
                        zoomedScreenSize.X + distanceFromScreenEdge + LimitsEdgeGame.r.Next(0, spawningBand + 1));
                    break;
                default:
                    newPosition = Vector2.Zero;
                    break;
            }
            return newPosition;
        }
    }
}
