using System;
using System.Collections.Generic;

namespace 递归
{
   
    /*
     * 啥是递归？
     * 1.递归指一种通过不断地调用自身从而缩减自身规模地算法（自己调用自己的函数）
     * 2.每个递归都有两个条件 递归条件 和返回条件（跳出条件）
     * 3.递归作用在栈上
     * 4.栈的操作： 压入和弹出
     * 5.所以函数调用的实质都是在调用栈
     * 
     * 我是一个递归
     * 沉睡在栈中
     * 你的温柔唤醒了我
     * 我开始不断地询问自己
     * 该如何走进你的心房
     * 如果条件为true则结束询问并打印家的字符
     * 否则继续询问
     * 直至宇宙消亡
     * 
     * 
     * 他能干啥？
     * 和普通的循环有什么区别？
     * 
     * 循环是在方法内执行地，而递归是循环调用方法直到满足条件是才会停止递归调用
     * 
     * 如果使用循环，程序的性能可能更高；如果使用递归，程序可能更容易理解
     */
    class Program
    {
        static List<int> vs = new List<int>();

        static void Main(string[] args)
        {
            Random random = new Random();
            
            for (int i = 0; i < 5; i++)
            {
                vs.Add(random.Next(0, 10));
            }
            vs.Add(6);
            int gi = Get_int(0);//调用递归方法
            Console.WriteLine("查找"+gi);
            //递归实现阶乘1
            int gif = Get_int_factorial(5, 1);
            Console.WriteLine("阶乘" + gif);
            //递归实现遍历数组累加
            int gia = Get_int_accumulation(0,0);
            Console.WriteLine("累加"+gia);
            //找出最大数
            int gibn = Get_int_big_num(0, 0);
            Console.WriteLine("最大数"+ gibn);


      

        }
      
        /// <summary>
        /// 递归查找
        /// </summary>
        /// <param name="vs"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        static int Get_int(int j)
        {
            /* 
             * 通过不断调用自身从而实现一个循环
             * 
             * 这样就会返回列表中第一次出现 6 的列
             * 
             * 使 j 自增 并将j 传入新地递归方法中
             * 
             */
            if (vs[j] == 6)
            {
                return vs[j];
            }
            j++;
            return Get_int(j++);
        }
       
        /// <summary>
        /// 递归阶乘
        /// </summary>
        /// <param name="i">阶乘数</param>
        /// <param name="j">阶乘结果</param>
        /// <returns></returns>
        static int Get_int_factorial(int i, int j)
        {

            if (i == 1)
            {
                return j;
            }
            else
            {
                j = j * i;
                i--;
                return Get_int_factorial(i, j);
            }
        }
       
        /// <summary>
        /// 累加
        /// </summary>
        /// <returns></returns>
        static int Get_int_accumulation(int num,int i)
        {
           
            num = num + vs[i];
            //跳出条件
            if (i == vs.Count-1)
            {
                return num;
            }
            i++;
            return Get_int_accumulation(num,i);
        }
       
        /// <summary>
        /// 找出最大数
        /// </summary>
        /// <param name="i"></param>
        /// <param name="j"></param>
        /// <returns></returns>
        static int Get_int_big_num(int i,int j)
        {
           
            if (j<vs[i])
            {
                j = vs[i];
            }

            if (i ==vs.Count-1)
            {
                return j;
            }
            i++;
            return Get_int_big_num(i,j);
        }





    }
}
