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

        public Person(Vector2 position, Texture2D texture) : base(position, texture)
        {
            pathToTake = new List<Vector2>();
            nodes = new List<PathNode>();
        }

        public Person(Vector2 position, Animation animation) : base(position, animation)
        {
            pathToTake = new List<Vector2>();
            nodes = new List<PathNode>();
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            foreach (var pos in pathToTake) spriteBatch.DrawRectangle(new Rectangle((int)pos.X, (int)pos.Y, 8, 8), Color.Red);
            base.Draw(spriteBatch);
        }

        bool createdPath = false;
        public override void Update(GameTime gameTime)
        {
            if (!createdPath) { CreatePath(); createdPath = true; }
            base.Update(gameTime);
        }

        public void CreatePath()
        {
            CreateNodes();

            List<PathNode> unvisitedNodes = nodes.ToList();
            List<PathNode> visitedNodes = new List<PathNode>();
            PathNode currentNode;
            PathNode endNode;

            int startingNodeIndex = LimitsEdgeGame.r.Next(0, unvisitedNodes.Count);
            int endNodeIndex = LimitsEdgeGame.r.Next(0, unvisitedNodes.Count);
            unvisitedNodes[startingNodeIndex].cost = 0;
            currentNode = unvisitedNodes.ElementAt(startingNodeIndex);
            endNode = unvisitedNodes.ElementAt(endNodeIndex);
            currentNode.cost = 0;
            // Add current node to the visited list and remove from the unvisted list
            var selected = unvisitedNodes.Where(node => node.nodeID == currentNode.nodeID).ToList();
            unvisitedNodes = unvisitedNodes.Except(selected).ToList();
            visitedNodes.AddRange(selected);
            bool finishedRoute = false;
            while (!finishedRoute)
            {
                // look at the current node neighbors.
                foreach (var neighborNodeID in currentNode.connectedNodes)
                {
                    // Take the cost of the current node plus the distance to each of the neighbors.
                    int neighborCost = currentNode.cost + 1;
                    // Update the costs at the neighbors if the cost is less than the neighbors current tentative distance
                    int neighborNodeIndex = unvisitedNodes.FindIndex(node => node.nodeID == neighborNodeID);
                    if (neighborNodeIndex >= 0)
                    {
                        if (neighborCost < unvisitedNodes[neighborNodeIndex].cost)
                        {
                            unvisitedNodes[neighborNodeIndex].cost = neighborCost;
                            unvisitedNodes[neighborNodeIndex].stepsTo = new List<Vector2>(currentNode.stepsTo);
                            unvisitedNodes[neighborNodeIndex].stepsTo.Add(new Vector2(unvisitedNodes[neighborNodeIndex].X, unvisitedNodes[neighborNodeIndex].Y));
                        }
                    }
                }
                // Go to the unvisited node with the lowest tentative distance and set this as the current node
                int lowestCost = unvisitedNodes[0].cost;
                int nextNodeID = unvisitedNodes[0].nodeID;
                foreach (var unvisitedNode in unvisitedNodes)
                {
                    if (unvisitedNode.cost < lowestCost)
                    {
                        nextNodeID = unvisitedNode.nodeID;
                        lowestCost = unvisitedNode.cost;
                    }
                }
                // Add the new current node to the list of visited nodes and remove from the list of unvisited nodes
                currentNode = unvisitedNodes[unvisitedNodes.FindIndex(node => node.nodeID == nextNodeID)];
                var nextNode = unvisitedNodes.Where(node => node.nodeID == currentNode.nodeID).ToList();
                unvisitedNodes = unvisitedNodes.Except(nextNode).ToList();
                visitedNodes.AddRange(nextNode);
                // If the final one is in the list of visited nodes, finish
                if (visitedNodes.Exists(node => node.nodeID == endNode.nodeID))
                {
                    finishedRoute = true;
                    pathToTake = endNode.stepsTo.ToList();
                }
            }
        }

        protected void CreateNodes()
        {
            foreach (var walkableTile in LimitsEdgeGame.shipStateManager.tileManager.walkableTiles)
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
                    ShipFloor foundNeighbor = LimitsEdgeGame.shipStateManager.tileManager.walkableTiles.Find((ShipFloor pos) => { return pos.X == p.X && pos.Y == p.Y; });
                    if (foundNeighbor != null) pathNode.connectedNodes.Add(foundNeighbor.floorID);
                }
                nodes.Add(pathNode);
            }
        }
    }
}
