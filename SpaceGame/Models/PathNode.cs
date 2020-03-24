using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceGame.Models
{
    public class PathNode
    {
        public int nodeID;
        public int X;
        public int Y;
        public List<int> connectedNodes;
        public List<Vector2> stepsTo;
        public int cost;

        public PathNode(int X, int Y, int nodeID, int cost = 999)
        {
            this.X = X;
            this.Y = Y;
            this.nodeID = nodeID;
            this.cost = cost;
            connectedNodes = new List<int>();
            stepsTo = new List<Vector2>();
        }
    }
}
