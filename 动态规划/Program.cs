using System;

namespace 动态规划
{
    /*
     * 动态规划： 将问题分解成小问题，并先着手解决小问题
     * 
     * 和贪婪算法不同，动态规划得到地是最优解，但效率相对较慢~贪婪虽然快速，但是最终得到地是近似解，
     * 
     *本质： 将原问题地规模变小，借鉴了二分法的思想，将目标分解成规模更小的子问题，从而求出最优解
     * 
     * 动态规划组成部分：
     * 1.确定状态
     * 确定最后一步（最优解地最后一步）
     * 转化子问题（问题规模更小的问题）
     * 2.转移方程
     * 列出所有可能
     * 3.确定边界和初始条件
     * 4.计算顺序从小到大，类似于数学归纳，必须知道前一步才能推后一步
     * 
     */
     /*算法导论：
      * 动态规划方法仔细安排求解顺序，对每个子问题只求解一次，
      * 并将结果保存下来，如果随后再次需要此问题的解，只需要查找保存的结果，
      * 二不必重新计算，因此，动态规划方法是符串额外的内存空间来节省计算时间，是典型的时空权衡栗子
      * 
      */



     /*
      * 我是动态规划
      * 我很神秘，同时也很强大
      * 因为我时常能参透物质世界的运行规律
      * 所以能在混沌中寻找到最优雅的答案
      * 
      */

    class Program
    {
        static void Main(string[] args)
        {


            //买书问题
            //int[] A = {2,5,7};
            //Console.WriteLine(book(A, 27));

            //机器人问题
            //Console.WriteLine(robot(3,7));

            //青蛙问题
            //int[] R = { 3,2,1,0,4}; //{ 2, 3, 1, 1, 4 };
            //Console.WriteLine(frog(R));

            //野餐问题
            //int[] A = { 10, 3, 9, 5, 6 };//价值
            //int[] B = { 3, 1, 2, 2, 1 };//物品自重
            //Console.WriteLine(camping(A, B, 6));

            // 最长公共字符串
            //Console.WriteLine(travel("blue", "clues"));

            // 切钢条问题
            int[] l = { 1,2,3,4,5/*,6,7,8,9,10*/};
            int[] p = { 1,5,8,9,10/*,17,17,20,24,30*/};
            steel_bar(l,p,5);


            Console.ReadKey();
        }

        /// <summary>
        /// 钢条切割问题
        /// </summary>
        /// <returns></returns>
        static int steel_bar(int []A,int []B,int n)
        {

            /*
             *  钢条长度价格表
             *  
             * 长度 i  1   2   3   4   5   6   7   8   9   10
             * 价格 p  1   5   8   9   10  17  17  20  24  30
             * 
             * 求最佳切割方案
             */
            /*
             * 解决思路：
             * 确定每个状态的最优解
             * 满足条件 可取 f[i,j] = b[i]
             * 
             * 小前提，在此之前有最优解
             * 大于满足条件 在当前可取 f[i-a[j],i]+f[a[j],i]
             * 
             * 
             * 
             */
            if (n==0)
            {
                return 0;
            }
             //n 钢条长度
            int A_l = A.Length;//钢条长度数组
            int B_l = B.Length;//钢条价格数组
            //长 a[i]
            //价 b[i]
            int[,] f = new int[A_l+1, B_l+1];
            //长度
            for (int i = 1; i <=n; i++)
            {
                //价格
                for (int j = 0; j <=B_l ; j++)
                {
                    if (i>=A[i-1]&& i>=A[j])
                    {
                        f[i, j] = Math.Max(B[i-1], f[i - A[j], i] + f[A[j], i]);
                    }
                   
                   
                }
            }
            
            



            return f[B_l,n];
        }


        /// <summary>
        /// 最长公共字符串
        /// </summary>
        /// <returns></returns>
        static int travel(string A, string B)
        {
            /*
             *请绘制并填充用来计算blue和clues最长公共子串的网格。
             */
           char[] b = A.ToCharArray();
           char[] c = B.ToCharArray();


            /*
             * 解题思路：
             * 1.将字符串拆分成字符数组
             * 2.分析连续数组在表格中的排列规律
             * 3.开始写bug
             * 
             * 
             * 
             */
            int b_l = b.Length;
            int c_l = c.Length;
            int[,] f = new int[b_l, c_l];
            int l = 0;
            for (int i = 0; i < b_l; i++)
            {
                for (int j = 0; j < c_l; j++)
                {
                    if (b[i] ==c[j])
                    {
                        //假如在某个字符段内存在相同字符，就加一 如果俩个字符串存在公共字符串
                        //那么从某个点开始就会以 i+1,j+1 的规律连续下去

                        l= f[i, j] = f[i - 1, j - 1] + 1;
                    }
                    else
                    {
                        f[i, j] = 0;
                    }
                }
            }


            return l;
        }



        /// <summary>
        /// 野营问题
        /// </summary>
        static int camping(int[] A,int[]B,  int n)
        {


            /*
             *  
                假设你要去野营。你有一个容量为6磅的背包，需要决定该携带下面的哪些东西。其中
                每样东西都有相应的价值，价值越大意味着越重要：
                水（重3磅，价值10）；
                书（重1磅，价值3）
                食物（重2磅，价值9）；
                夹克（重2磅，价值5）；
                相机（重1磅，价值6）。
                请问携带哪些东西时价值最高？
                能否重复选取？

             */

            /*
             * 解题思路：
             * 物品状态： 
             * 怎么判断物品是否能取？
             * n -当前状态所占空间 >=0
             * 
             * 取 f[i-1,j-B[i]]+A[i] 上一个状态加现在的价值   
             * 
             * 不取 f[i-1,j] 上一个状态的价值  
             * 
             * 剩余空间利用
             * 取当前空间的[j-1]的价值，如果当前空间还可以利用 那么当前 看空间最大价值就是 f[i,j-1] +f[i,n-t]
             * t 是当前状态所占空间
             * 
             * 如果不可利用，就取当前物品状态的上一个物品状态的最大价值 f[i-1,j]
             * 
             * 然后对二者进行比较 取较大者
             * 隐隐约约有了思路~
             */


            int A_l = A.Length; //价值长 =5
            int B_l = B.Length;//物重长
                              
           
             //n 背包容量 =6
            int[,] f = new  int [A_l+1, n+1];
            
            f[0, 0] = 0;
          
            //物品个数 //A[i] B[i] 
            for (int i =1; i <= A_l; i++)
            {
                //背包容量
                for (int j = 0; j <=n; j++)
                {
                    if (j>=B[i-1])
                    {
                        //比较上一个单元格的值 和当前商品的值加上剩余空间的值
                        f[i, j] = Math.Max(f[i - 1, j], A[i-1] + f[i - 1, j - B[i-1]]);
                    }
                   
                }
            }
            return f[A_l,n];
        }

        /// <summary>
        /// 青蛙跳问题
        /// </summary>
        /// <returns></returns>
        static Boolean frog(int [] A)
        {
            /*
             * 有 n 块石头分别在x轴的0，1，.....n-1位置
             * 一只青蛙在石头0，想跳到石头 n-1
             * 如果青蛙在第 i 块石头上，他最多可以向右跳距离 Ai
             * 问 青蛙能否跳到石头 n-1
             */

            /*
             * 解题思路：
             * n 为步数最优解
             * 最后一步状态： n-1 ,  i<n-1 
             * 已知步长为Ai,  i +Ai <=n-1
             * 
             * 假设 f[j]表示能不能跳到石头j
             * f[j] =if 0<=i<j(f[i] && i +a[i]>=j)
             * 
             * 初始条件 f[0] =true
             * 
             * 
             */



            int n = A.Length;
            Boolean[] f = new Boolean[n];
            f[0] = true;//初始状态

            for (int j = 1; j < n; j++)
            {
                f[j] = false;
                //最后一次跳跃是从i到j
                for (int i = 0; i < j; i++)
                {
                    if (f[i] &&i+A[i] >=j)
                    {
                        f[j] = true;
                        break;
                    }
                }
            }
            

            return f[n-1];
        }

        /// <summary>
        /// 机器人问题
        /// </summary>
        /// <returns></returns>
        static int robot(int m,int n)
        {
            /*
             * 给定 m 行 n列网格， 一个机器从左上角 （0，0）出发
             * 每一步可以向下或者向右走一步
             * 问有多少种不同的方式走到右下角
             */
            /*
             * 解题思路：
             * 1.确定最后挪动的一步，设右下角的坐标为（m-1,n-1）那么前一步一定是（m-2,n-1）或者（m-1,n-2）
             * 
             * 
             */
            int[,] f = new int[m,n];
            int i, j;
            //行
            for (i = 0; i<m; i++)
            {
                //列
                for ( j = 0; j < n; j++)
                {
                    if (i==0||j==0)
                    {
                        f[i, j] = 1;
                    }
                    else
                    {
                        //f[i - 1, j] 到 
                        f[i, j] = f[i - 1, j] + f[i, j - 1];
                    }
                }
            }
            return f[m - 1, n - 1];

         
        }

        /// <summary>
        /// 买书问题
        /// </summary>
        /// <param name="A"></param>
        /// <param name="M"></param>
        /// <returns></returns>
        static int book(int[] A,int M)
        {
            /*
             * 由三种硬币， 2，5，7元，硬币足够多，买一本书需要27元，
             * 如何用最少地硬币付账
             */
             //0...n [n+1]
             //0...n-1  [n]
             //最后一步状态决定
            int[] f = new int[M + 1];
            int n = A.Length; //硬币数
            f[0] = 0;
            int i, j;
            // f[1]....f[27]
            //每种金额下的最优策略
            for ( i = 1; i <= M; i++)
            {
                f[i] = int.MaxValue;

                //硬币种类
                for ( j = 0; j < n; j++)
                {
                    //i>=A[j] 确保不为负数，
                    //f[i-A[j]] !=int.MaxValue 不能越界
                    if (i>=A[j]&& f[i-A[j]] !=int.MaxValue)
                    {
                        f[i] = Math.Min(f[i - A[j]] + 1, f[i]);
                    }
                }
            }
            if (f[M] ==int.MaxValue)
            {
                f[M] = -1;
            }
       
            return f[M];
           // Console.WriteLine(DG_book(27));
         

        }


        static int DG_book(int? x)
        {
            /*
             * 解题思路：
             * 假有 函数 DG_book（27）==x
             * 假设最后一枚硬币是2 则有 DG_book（27-2）+1 == x
             * 假设最后一枚硬币是5 则有 DG_book（27-5）+1 
             * 假设最后一枚硬币是7 则有 DG_book（27-7）+1 
             * 
             */
            if (x==0)
            {
                return 0;
            }
             int  jg = int.MaxValue;
            if (x>=2)
            {
              //  DG_book(y)至少用多少枚硬币组成 y 元
                jg = Math.Min(DG_book(x - 2)+1,jg);
            }
            if (x>=5)
            {
                jg = Math.Min(DG_book(x - 5) + 1, jg);
            }
            if (x>=7)
            {
                jg = Math.Min(DG_book(x - 7) + 1, jg);
            }

            return jg;
        }

     
    }
}
