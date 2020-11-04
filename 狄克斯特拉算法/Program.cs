using System;
using System.Collections.Generic;
using System.Linq;

namespace 狄克斯特拉算法
{
  
    class Program
    {
        /*
         * 狄克斯特拉算法：主要运用于解决有权图中的最短路径问题，
         * 他的内核继承了贪心算法（局部最优到全局最优）的思想遍历有权图中的节点（从起始节点开始），从而找出最短路径
         * 
         * 
         * 算法思路：
         * 主体思想：迪克特斯拉算法体现了由近及远，由简到繁的贪婪算法思想
         * 1.0：
         * //从初始节点到下一节点的最短路径 
         * //从初始节点到下一节点的最短路径
         * //从初始节点到下一节点的最短路径
         * //从初始节点到下一节点的最短路径
         * 
         * 
         * 
         * 2.0：在网状图中确定两个顶点A，G，然后遍历整个包含了两个顶点的矩阵（网状图）
         * 将找出 与A点相邻的所有节点，并记录a点到和a相连的所有节点地权值并记录在集合中
         * （集合结构 ： 节点名称，A点到该节点地总权值，该节点的父节点），
         * 通过不断遍历节点找出相邻的两个节点中权值小的路径，并记录在册。
         * 直到遍历到了G点，让后得到的路径就是上一节点到下一节点地路径的最小权值，
         * 从而求出权值最小的路径
         * 
         *（可以将整个执行流想象成电流，网状图就是交错的电路图，电流的
         * 特点就是总是趋向于电阻（相当于网状图权重）小的电路）
         * 
         */

        //节点集合
        public static List<Node> NodeList { get; set; }
        //权值集合
        public static Dictionary<string, int> CostDictionary { get; set; }
        //父节点集合
        public static Dictionary<string, string> ParentDictionary { get; set; }
        //当前节点集合
        public static List<string> CheckedNodeName { get; set; }
        public Program()
        {
            NodeList = new List<Node>
            {
                //开始
                new Node
                {
                    
                    NodeName = "start",
                    RelatedNode = new Dictionary<string, int>()
                    {
                        {"A", 6},
                        {"B", 2}
                    }
                },
                //A点
                new Node
                {
                    NodeName = "A",
                    RelatedNode = new Dictionary<string, int>()
                    {
                        {"end", 1}
                    }
                },
                //B点
                new Node
                {
                    NodeName = "B",
                    RelatedNode = new Dictionary<string, int>()
                    {
                        {"A", 3},
                        {"end", 5}
                    }
                },
                //结束点
                new Node
                {
                    NodeName = "end",
                    RelatedNode = new Dictionary<string, int>()
                }
            };
            //权重
            CostDictionary = new Dictionary<string, int>()
            {
                {"A",6},
                {"B",2},
                {"end",int.MaxValue}
            };
            //父节点
            ParentDictionary = new Dictionary<string, string>()
            {
                {"A","start"},
                {"B","start"},
                {"end",""}
            };

            CheckedNodeName = new List<string>();

        }


        static void Main(string[] args)
        {
            //Dijkstra
            var progra = new Program();
            Console.WriteLine($"{"父节点",10}|{"节点",10}|{"权值",10}");
            foreach (var item in NodeList.SelectMany(node => node.RelatedNode, (node, relatenode) =>
            new { node.NodeName, relatenode }))
            {
                Console.WriteLine($"{item.NodeName,10}|{item.relatenode.Key,10}|{item.relatenode.Value,10}");
            }

            while (CheckedNodeName.Count != CostDictionary.Count)
            {
                //找到Cost最小的节点
                var currentNode = FindMinCostNode(CostDictionary);
                //取出relatednode，
                if (currentNode != null)
                {
                    //循环如果subNode的Cost小于CostDictionary的Cost
                    foreach (var subNode in currentNode.RelatedNode)
                    {
                        if (subNode.Value < CostDictionary[subNode.Key])
                        {
                            //替换
                            CostDictionary[subNode.Key] = subNode.Value + CostDictionary[currentNode.NodeName];
                            ParentDictionary[subNode.Key] = currentNode.NodeName;
                        }
                    }
                    CheckedNodeName.Add(currentNode.NodeName);
                }
            }

            Console.WriteLine("最短路径:" + GetTheMinCostPath());

            Console.WriteLine("最短路径开销:" + CostDictionary["end"]);

            Console.ReadKey();
        }
        //


        /// <summary>
        /// 最短路径
        /// </summary>
        /// <returns></returns>
        public static string GetTheMinCostPath()
        {
            bool isStart = false;
            string startKey = "end";
            string path = "end=>";
            while (!isStart)
            {

                path += ParentDictionary[startKey] + "=>";
                startKey = ParentDictionary[startKey];
                if (!ParentDictionary.ContainsKey(ParentDictionary[startKey]))
                {
                    path += ParentDictionary[startKey];
                    isStart = true;
                }
            }

            return path;
        }

        /// <summary>
        /// 查找最小权值节点
        /// </summary>
        /// <param name="costDictionary"></param>
        /// <returns></returns>
        public static Node FindMinCostNode(Dictionary<string, int> costDictionary)
        {
            var costItems = costDictionary.Where(c => !CheckedNodeName.Contains(c.Key)).ToList();
            if (costItems.Any())
            {
                var minCostItem = costItems.OrderBy(c => c.Value).First().Key;
                return NodeList.FirstOrDefault(n => n.NodeName == minCostItem);
            }
            return null;
        }
    }

    public class Node
    {
        //节点名称
        public string NodeName { get; set; }
        //相邻节点
        public Dictionary<string, int> RelatedNode { get; set; }
    }

    public class CostItem
    {
        //父节点
        public string ParentName { get; set; }
        //节点名称
        public string NodeName { get; set; }
        //权重
        public int Cost { get; set; }
    }
}
