using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGame.Extended;
using SpaceGame.Models;
using SpaceGame.Tiles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Sprites.ShipStateSprites
{
    public class Person : SSSprite
    {
        protected List<Vector2> pathToTake;
        protected List<PathNode> nodes;
        protected Vector2 currentObjective;
        protected List<ShipFloor> walkableTiles;
        protected float currentIdleDelay = 0;
        protected float idleDelay = 0;

        public Person(Vector2 position, Texture2D texture, List<ShipFloor> walkableTiles) : base(position, texture)
        {
            this.walkableTiles = walkableTiles;
            pathToTake = new List<Vector2>();
            nodes = new List<PathNode>();
            CreateNodes(walkableTiles);
            CreatePath();
        }

        public Person(Vector2 position, Animation animation, List<ShipFloor> walkableTiles) : base(position, animation)
        {
            this.walkableTiles = walkableTiles;
            pathToTake = new List<Vector2>();
            nodes = new List<PathNode>();
            CreateNodes(walkableTiles);
            CreatePath();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }

        public override void Update(GameTime gameTime)
        {
            float t = (float)gameTime.ElapsedGameTime.TotalSeconds;
            base.Update(gameTime);
            if (currentIdleDelay >= idleDelay)
            {
                Vector2 difference = currentObjective - position;
                if (difference.Length() < 0.2f)
                {
                    pathToTake.Remove(currentObjective);
                    if (pathToTake.Count == 0)
                    {
                        animationManager.Play(LimitsEdgeGame.animations["basic_person_idle"]);
                        idleDelay = LimitsEdgeGame.r.Next(0, 31);
                        currentIdleDelay = 0;
                        CreateNodes(walkableTiles);
                        CreatePath();
                    }
                    else currentObjective = pathToTake.ElementAt(0);
                }
                else
                {
                    animationManager.Play(LimitsEdgeGame.animations["basic_person_walk_down"]);
                    Vector2 direction = Vector2.Normalize(difference);
                    position += direction * 15f * t;
              }
            } else currentIdleDelay += t;
        }

        public void CreatePath()
        {
            List<PathNode> unvisitedNodes = nodes.ToList();
            List<PathNode> visitedNodes = new List<PathNode>();
            PathNode currentNode;
            PathNode endNode;

            int xToSearch = (int)Math.Round(position.X - Tile.tileSize / 2f, 0);
            int yToSearch = (int)Math.Round(position.Y - Tile.tileSize / 2f, 0);
            int startingNodeIndex = unvisitedNodes.FindIndex(node => node.X == xToSearch && node.Y == yToSearch);

            if (startingNodeIndex == -1) // Failsafe - if a node at the person's location is not found, generate a random place to go.
                startingNodeIndex = LimitsEdgeGame.r.Next(0, unvisitedNodes.Count);

            unvisitedNodes[startingNodeIndex].cost = 0;
            currentNode = unvisitedNodes.ElementAt(startingNodeIndex);
            endNode = unvisitedNodes.ElementAt(LimitsEdgeGame.r.Next(0, unvisitedNodes.Count));
            currentNode.cost = 0;

            var selected = unvisitedNodes.Where(node => node.nodeID == currentNode.nodeID).ToList();
            unvisitedNodes = unvisitedNodes.Except(selected).ToList();
            visitedNodes.AddRange(selected);
            
            bool finishedRoute = false;
            while (!finishedRoute)
            {
                foreach (var neighborNodeID in currentNode.connectedNodes)
                {
                    int neighborCost = currentNode.cost + 1;
                    int neighborNodeIndex = unvisitedNodes.FindIndex(node => node.nodeID == neighborNodeID);
                    if (neighborNodeIndex >= 0)
                    {
                        if (neighborCost < unvisitedNodes[neighborNodeIndex].cost)
                        {
                            unvisitedNodes[neighborNodeIndex].cost = neighborCost;
                            unvisitedNodes[neighborNodeIndex].stepsTo = new List<Vector2>(currentNode.stepsTo);
                            unvisitedNodes[neighborNodeIndex].stepsTo.Add(
                                new Vector2(unvisitedNodes[neighborNodeIndex].X + Tile.tileSize / 2f, unvisitedNodes[neighborNodeIndex].Y + Tile.tileSize / 2f));
                        }
                    }
                }
                int lowestCost = unvisitedNodes[0].cost;
                int nextNodeID = unvisitedNodes[0].nodeID;
                foreach (var unvisitedNode in unvisitedNodes)
                    if (unvisitedNode.cost < lowestCost)
                    {
                        nextNodeID = unvisitedNode.nodeID;
                        lowestCost = unvisitedNode.cost;
                    }

                currentNode = unvisitedNodes[unvisitedNodes.FindIndex(node => node.nodeID == nextNodeID)];
                var nextNode = unvisitedNodes.Where(node => node.nodeID == currentNode.nodeID).ToList();
                unvisitedNodes = unvisitedNodes.Except(nextNode).ToList();
                visitedNodes.AddRange(nextNode);
                if (visitedNodes.Exists(node => node.nodeID == endNode.nodeID)) 
                { 
                    finishedRoute = true; 
                    pathToTake = endNode.stepsTo.ToList();
                    // index out of range here for some reason
                    if (pathToTake.Count != 0) currentObjective = pathToTake.ElementAt(0);
                }
            }
        }

        protected void CreateNodes(List<ShipFloor> walkableTiles)
        {
            nodes.Clear();
            foreach (var walkableTile in walkableTiles)
            {
                PathNode pathNode = new PathNode(walkableTile.X, walkableTile.Y, walkableTile.floorID);
                List<Point> coordsToCheck = new List<Point>();
                coordsToCheck.Add(new Point(walkableTile.X - Tile.tileSize, walkableTile.Y));
                coordsToCheck.Add(new Point(walkableTile.X, walkableTile.Y + Tile.tileSize));
                coordsToCheck.Add(new Point(walkableTile.X + Tile.tileSize, walkableTile.Y));
                coordsToCheck.Add(new Point(walkableTile.X, walkableTile.Y - Tile.tileSize));
                foreach (var p in coordsToCheck)
                {
                    Predicate<ShipFloor> offsetPosition = (ShipFloor pos) => { return pos.X == p.X && pos.Y == p.Y; };
                    ShipFloor foundNeighbor = walkableTiles.Find((ShipFloor pos) => { return pos.X == p.X && pos.Y == p.Y; });
                    if (foundNeighbor != null) pathNode.connectedNodes.Add(foundNeighbor.floorID);
                }
                nodes.Add(pathNode);
            }
        }
    }
}
