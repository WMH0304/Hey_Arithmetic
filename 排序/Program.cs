using System;
using System.Collections.Generic;
using System.Drawing;

namespace 排序
{
    class Program
    {
        static void Main(string[] args)
        {
            //随机生成 10 个数
            List<int> list = new List<int>(10);
            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                int it = random.Next(0, 10);
                list.Add(it);  
            }
            #region 选择排序



            #endregion
           



            Console.ReadLine();
        }
    }
}
