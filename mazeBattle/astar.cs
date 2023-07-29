using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace mazeBattle {

    public class astar {
        public class Node {
            public int P { get; set; }
            public int X { get {return P >> 4; } }      
            public int Y { get { return P & 0x0F; } }
            public int G { get; set; } // G: スタートからの移動コスト
            public int H { get; set; } // H: ゴールまでの推定移動コスト
            public int F { get { return G + H; } } // F: G + H
            public Node? Parent { get; set; }
        }

        private int[] map; // マップデータ
        private int  size; // マップサイズ
        private List<Node> openList; // オープンリスト
        //private int startX, startY; // スタート位置
        private int goalX, goalY; // ゴール位置
        private int[] nodeStatList; // ノード状態リスト(0=未オープン/1=オープン/2=クローズ)

        public astar(int[] map, int size) {
            this.map = map;
            this.size = size;
            openList = new List<Node>();
            nodeStatList = new int[map.Length];
        }

        public List<Node>? FindPath(int startX, int startY, int goalX, int goalY) {
            //this.startX = startX;
            //this.startY = startY;
            this.goalX = goalX;
            this.goalY = goalY;

            Node startNode = new Node { P = (startX << 4) + startY, G = 0, H = CalculateHeuristic(startX, startY), Parent = null };
            openList.Add(startNode);
            int cnt = 0;
            while ((openList.Count > 0)&&(cnt < 1000)) {
                cnt++;
                Node currentNode = GetLowestCostNode();
                Debug.WriteLine("[current ](" + currentNode.X + "," + currentNode.Y + ") G=" + currentNode.G + "/H=" + currentNode.H + "/F=" + currentNode.F);

                if (currentNode.X == goalX && currentNode.Y == goalY) {
                    // ゴールに到達
                    //Debug.WriteLine("Path not found." + cnt);
                    return GeneratePath(currentNode);
                }

                openList.Remove(currentNode);
                nodeStatList[currentNode.P] = 2;

                List<Node> neighbors = GetNeighbors(currentNode);
                foreach (Node neighbor in neighbors) {

                    // 未オープンなら開く
                    if (nodeStatList[neighbor.P] == 0) {
                        int tentativeG = currentNode.G + CalculateDistance(currentNode, neighbor);
                        neighbor.Parent = currentNode;
                        neighbor.G = tentativeG;
                        neighbor.H = CalculateHeuristic(neighbor.X, neighbor.Y);
                        openList.Add(neighbor);
                        nodeStatList[neighbor.P] = 1;
                        Debug.WriteLine("[neighbor](" + neighbor.X + "," + neighbor.Y + ") Stat=" + nodeStatList[neighbor.P] + "/G=" + neighbor.G + "/H=" + neighbor.H + "/F=" + neighbor.F);
                    }
                }

            }

            // ゴールに到達できなかった
            return null;
        }

        public Node GetLowestCostNode() {
            Node lowestCostNode = openList[0];
            for (int i = 1; i < openList.Count; i++) {
                if (openList[i].F < lowestCostNode.F)
                    lowestCostNode = openList[i];
                if ((openList[i].F == lowestCostNode.F)&&(openList[i].G < lowestCostNode.G))
                    lowestCostNode = openList[i];
            }
            return lowestCostNode;
        }

        public List<Node> GetNeighbors(Node node) {
            List<Node> neighbors = new List<Node>();
            int np;

            //上
            np = node.P - 16;
            if (IsValidPosition(np) && (map[np] & 1) == 0) {
                neighbors.Add(new Node { P = np });
            }
            //下
            np = node.P + 16;
            if (IsValidPosition(np) && (map[node.P] & 1) == 0) {
                neighbors.Add(new Node { P = np });
            }
            //右
            np = node.P + 1;
            if (IsValidPosition(np) && (map[node.P] & 2) == 0) {
                neighbors.Add(new Node { P = np });
            }
            //左
            np = node.P - 1;
            if (IsValidPosition(np) && (map[np] & 2) == 0) {
                neighbors.Add(new Node { P = np });
            }

            return neighbors;
        }

        private bool IsValidPosition(int p) {
            return ((p >= 0) && ((p >> 4) < this.size) && ((p & 0x0F) < this.size));
        }

        private int CalculateDistance(Node node1, Node node2) {
            int dx = Math.Abs(node1.X - node2.X);
            int dy = Math.Abs(node1.Y - node2.Y);
            return dx + dy;
        }

        private int CalculateHeuristic(int x, int y) {
            int dx = Math.Abs(x - goalX);
            int dy = Math.Abs(y - goalY);
            return dx + dy;
        }

        private List<Node> GeneratePath(Node node) {
            List<Node> path = new List<Node>();
            Node? current = node;
            while (current != null) {
                path.Add(current);
                current = current.Parent;
            }
            path.Reverse();
            return path;
        }
    }
}
