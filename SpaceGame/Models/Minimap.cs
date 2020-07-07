using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class Minimap
    {
        protected float scale = 10f;
        protected float zoom { get { return LimitsEdgeGame.worldCamera.Zoom; } }
        protected float objectSize = 2f;

        protected Vector2 distanceFromScreenEdge = new Vector2(10);
        protected Vector2 viewableOutsideRange = new Vector2(500); // How many pixels the player can see outside of the screen
        protected Vector2 scaledZoomedBuffer { get { return viewableOutsideRange / (zoom * scale); } }
        protected Vector2 topLeft { get { return LimitsEdgeGame.topLeft; } }
        protected Vector2 zoomedScreenSize { get { return LimitsEdgeGame.zoomedScreenSize; } }
        protected Vector2 scaledZoomedScreenSize { get { return zoomedScreenSize / scale; } }
        protected Vector2 dimensions { get { return (2 * scaledZoomedBuffer) + scaledZoomedScreenSize; } }
        protected Vector2 mapTopLeft { get { return topLeft + zoomedScreenSize - distanceFromScreenEdge - dimensions; } }
        protected Vector2 center { get { return mapTopLeft + scaledZoomedBuffer + scaledZoomedScreenSize / 2f; } }
        
        protected RectangleF outsideRectangle { get { return new RectangleF(mapTopLeft.X, mapTopLeft.Y, dimensions.X, dimensions.Y); } }
        protected RectangleF insideRectangle { get { return new RectangleF(mapTopLeft.X + scaledZoomedBuffer.X, mapTopLeft.Y + scaledZoomedBuffer.Y, scaledZoomedScreenSize.X, scaledZoomedScreenSize.Y); } }

        protected Color playerColor = new Color(0, 255, 0);
        protected Color outsideRectangleColor = Color.White;
        protected Color insideRectangleColor = new Color(100, 100, 100);
        protected Color crateColor = new Color(100, 255, 255);
        protected Color asteroidColor = new Color(255, 100, 255);

        public Minimap() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.DrawRectangle(outsideRectangle, outsideRectangleColor);
            spriteBatch.DrawRectangle(insideRectangle, insideRectangleColor);
            spriteBatch.DrawPoint(center, playerColor, objectSize);
            foreach (var crate in LimitsEdgeGame.worldStateManager.crateManager.crates)
            {
                Vector2 mapPosition = center + crate.relativeToPlayer / scale;
                if (outsideRectangle.Contains(new Point2(mapPosition.X, mapPosition.Y))) 
                    spriteBatch.DrawPoint(mapPosition, crateColor, objectSize);
            }
            foreach (var asteroid in LimitsEdgeGame.worldStateManager.asteroidManager.asteroids)
            {
                Vector2 mapPosition = center + asteroid.relativeToPlayer / scale;
                if (outsideRectangle.Contains(new Point2(mapPosition.X, mapPosition.Y)))
                    spriteBatch.DrawPoint(mapPosition, asteroidColor, objectSize);
            }
        }
    }
}
