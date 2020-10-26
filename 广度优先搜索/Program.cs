using System;
using System.Collections;
using System.Collections.Generic;

namespace 广度优先搜索
{
    class Program
    {
        /*
         * 队列从本质上来说还是一个线性表，
         * 但是他和stack,list 不同的是他是单向存储数据，单向读取数据的
         * 就类似于 管道运输一样 一端存入，另一段读取。
         * queue 是先进先出的数据结构
         * stack 是后进后出的数据结构（砌墙的石头__后来居上）
         */

        /*
         * 广度优先搜索算法：
         * 从某一个节点 A 切入，然后遍历和这个顶点 A 相关的节点,假设是 B和C（一度关系），
         * 如果找到目标节点则立即返回
         * 否则 
         * 从节点 B 切入，遍历和节点B 相关的节点，假设是 B1,B2,(二度关系)以此类推
         * 
         * 本质是通过一次次遍历搜索节点比较找到目标节点，
         * 广度优先算法的执行方式类似于声波的扩散，当声波“碰”到障碍物时会反弹
         * 
         */

        class Node
        {
            public Node()
            {
                
            }

            public Node(int v1, int v2, int v3)
            {
                this.node_x = v1;
                this.node_y = v2;
                this.node_course = v3;
            }

            /// <summary>
            /// 节点x坐标
            /// </summary>
            public int node_x { get; set; }
            /// <summary>
            ///  节点y坐标
            /// </summary>
            public int node_y { get; set; }
            /// <summary>
            /// 层级
            /// </summary>
            public int node_course { get; set; }
        }


        /* ↑ ↓ ← → ↖ ↗ ↙ ↘
         * 
         *       B  →   E   
         *   ↗ ↓  ↘  ↓  ↖
         * A →  C  →   F  →  H
         *   ↘ ↑  ↗  ↓  ↙
         *       D  →   G
         *       
         *        1-2-3-4-5
         *    1   1-1-1-1-1  
         *    2   1-1-1-1-1      
         *    3   1-1-1-1-1
         *    4   1-1-1-0-1 
         *    5   1-1-1-1-1 
         *    
         *    
         */
        class SimpleGraph
        {
            public SimpleGraph()
            {
                // 初始化边表
                edges = new Dictionary<char, char[]>();
            }

            public Dictionary<char, char[]> edges;

            public char[] neighbors(char id)
            {
                return edges[id];
            }
        }
        static void Main(string[] args)
        {
            #region  遍历数组搜索坐标


            /*
             * 第一步 定制二维数组
             */
            /* 
            //原始数组
            int[,] a = new int[6, 6]; //5*5 的矩阵
            //现在标记的位置
            int[,] b =new int[6,6];
            //遍历层级


            for (int i = 1; i <= 5; i++)
            {
                for (int j = 1; j <= 5; j++)
                {
                    //node.node_x = i;
                    //node.node_y = j;
                    //nodes.Enqueue(node);
                        a[i, j] = 0;
                        b[i, j] = 2;
                }
            }
            //定义目标节点
              //----------------------------------------------

            Queue<Node> nodes = new Queue<Node>();

            Node node = new Node( 0, 0, 0 );
            //将元素添加到队列尾部
            nodes.Enqueue(node);
           //----------------------------------------------
            Node node_ = new Node();


            //搜索开始遍历每个节点可连接的节点
            while (nodes.Count !=0)
            {
                int x = nodes.Peek().node_x;
                int y = nodes.Peek().node_y;
                int c = nodes.Peek().node_course;


                if (x==1&&y==3)
                {
                    Console.WriteLine(c);
                    break;
                }
                 //上 从0，0 开始
                 if (y==0)
                 {
                     y = 1;
                 }
                if (a[x,y-1] ==0&&b[x,y-1]==2)
                {
                    node_.node_x = x;//x点坐标
                    node_.node_y = y - 1;
                    node_.node_course = c + 1;//遍历节点次数
                    b[x, y - 1] = 0;
                    nodes.Enqueue(node_);//插入队列中
                    var current = nodes.Dequeue();
                 }
                 else

                //下
                if (y==5)
                 {
                     y = 4;
                 }
                if (a[x, y + 1] == 0 && b[x, y + 1] == 2)
                {
                    node_.node_x = x;//x点坐标
                    node_.node_y = y + 1;
                    node_.node_course = c + 1;//遍历节点次数
                    b[x, y + 1] = 0;
                    nodes.Enqueue(node_);//插入队列中
                    var current = nodes.Dequeue();
                 }
                 else
                //左
                if (x==0)
                 {
                     x=1;
                 }
                if (a[x-1, y] == 0 && b[x - 1, y ] == 2)
                {
                    node_.node_x = x-1;//x点坐标
                    node_.node_y = y;
                    node_.node_course = c + 1;//遍历节点次数
                    b[x-1, y] = 0;
                    nodes.Enqueue(node_);//插入队列中
                    var current = nodes.Dequeue();
                 }
                 else
                //右
                if (x==5)
                 {
                     x = 4;
                 }
                 else
                if (a[x + 1, y] == 0 && b[x + 1, y] == 2)
                {
                    node_.node_x = x + 1;//x点坐标
                    node_.node_y = y;
                    node_.node_course = c + 1;//遍历节点次数
                    b[x + 1, y] = 0;
                    nodes.Enqueue(node_);//插入队列中
                    var current =nodes.Dequeue();
                }

            }

             */


            #endregion

            #region 广度优先搜索_字典
            /*
            // 初始化图
            SimpleGraph example_graph = new SimpleGraph();
            char[] A = { 'B' };
            char[] B = { 'A', 'C', 'D' };
            char[] C = { 'A' };
            char[] D = { 'E', 'A' };
            char[] E = { 'B' };
            example_graph.edges.Add('A', A);
            example_graph.edges.Add('B', B);
            example_graph.edges.Add('C', C);
            example_graph.edges.Add('D', D);
            example_graph.edges.Add('E', E);

            breadthFirstSearch(example_graph, 'A');

            */

            #endregion

            

            Console.ReadKey();

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="start"></param>
        private static void breadthFirstSearch(SimpleGraph graph, char start)
        {
            // 初始化队列
            Queue queue = new Queue();
            queue.Enqueue(start);//插入数据
            Dictionary<char, bool> visited = new Dictionary<char, bool>();
            visited[start] =true ;//给字典对于键值对赋值

            while (queue.Count != 0)
            {
                char current = (char)queue.Dequeue();//移除并返回队首元素
                Console.WriteLine("队首元素: " + current);

                foreach (char next in graph.neighbors(current))
                {
                    //当next 不在visited中时
                    if (!visited.ContainsKey(next))
                    {
                        queue.Enqueue(next);
                        visited[next] = true;
                    }
                }
            }
        }


    }
}
