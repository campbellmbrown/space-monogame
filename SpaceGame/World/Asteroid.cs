using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.World
{
    public class Asteroid
    {
        protected Vector2 position;
        protected Vector2 linearVelocity;
        protected float rotation;
        protected float angularVelocity;
        protected List<AsteroidChunk> meteorChunks;
        protected int minCount;
        protected int maxCount;
        protected int meteorChunkDistance;

        public Asteroid(Vector2 position, int minCount, int maxCount, int meteorChunkDistance = 6)
        {
            this.position = position;
            linearVelocity = new Vector2(LimitsEdgeGame.r.Next(-50, 51), LimitsEdgeGame.r.Next(-50, 51));
            angularVelocity = LimitsEdgeGame.r.Next(-400, 401) / 100f;
            meteorChunks = new List<AsteroidChunk>();
            this.minCount = minCount;
            this.maxCount = maxCount;
            this.meteorChunkDistance = meteorChunkDistance;
            FormMeteorChunks();
        }

        public virtual void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            position += linearVelocity * t;
            rotation += angularVelocity * t;
            foreach (var meteorChunk in meteorChunks)
            {
                meteorChunk.UpdatePosition(position, rotation);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            foreach (var meteorChunk in meteorChunks)
            {
                meteorChunk.Draw(spriteBatch);
            }
        }

        protected virtual void FormMeteorChunks()
        {
            if (minCount > 0)
            {
                meteorChunks.Add(new AsteroidChunk(position));
                for (int i = 0; i < LimitsEdgeGame.r.Next(minCount, maxCount + 1); ++i)
                {
                    var branchPosition = meteorChunks[LimitsEdgeGame.r.Next(0, meteorChunks.Count)].relativePosition;
                    float angle = LimitsEdgeGame.r.Next(0, 629) / 100f;
                    var direction = new Vector2((float)Math.Cos(angle), -(float)Math.Sin(angle));
                    var newPosition = branchPosition + direction * meteorChunkDistance;
                    meteorChunks.Add(new AsteroidChunk(newPosition));
                }
            }
        }
    }
}
