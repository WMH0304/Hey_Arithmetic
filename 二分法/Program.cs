using System;

namespace 二分法
{
    class Program
    {
        /*
         * 思路：寻找数组的中位数，然后向上或者向下查找
         * 以此类推
         * 
         * 
         */
        static void Main(string[] args)
        {
            Random random = new Random();
            int head = 0;
            int atil = 20;
            //获取随机数
            //int ran = random.Next(head, atil);
            int ran = 10;
            //设置范围内的中间数
            int num =(head+atil)/2;

            //一般的方法
            for (int i = 0; i < 20; i++)
            {
                if (i == ran)
                {
                    Console.WriteLine(i);
                }
            }

            //二分法
            while (true)
            {
                //假如中间数大于随机数
                if (num >ran)
                {
                    //确定区间，这个非常重要
                    atil = num;
                    num =(head + num) / 2;

                    /*
                     * 当（）内的和 是奇数时 num 会向上取整 举个栗子  a=7,b=2, (a+b)/2 =5 妈的居然忘了艹
                     * 到最后判断相邻的两个数是否符合条件
                     * 
                     */
                    
                    if (num-1 ==ran)
                    {

                        Console.WriteLine(num-1);
                        break;
                    }
                    //if (num + 1 == ran)
                    //{

                    //    Console.WriteLine(num + 1);
                    //    break;
                    //}
                    if (num == ran)
                    {

                        Console.WriteLine(num);
                        break;
                    }
                }
                //假如中间数小于随机数
                if (num<ran)
                {
                    //确定区间，这个非常重要
                    head = num;
                    num = (num +atil)/ 2;

                    //if (num - 1 == ran)
                    //{

                    //    Console.WriteLine(num - 1);
                    //    break;
                    //}
                    if (num +1 ==ran)
                    {

                        Console.WriteLine(num+1);
                        break;
                    }
                    if (num == ran)
                    {

                        Console.WriteLine(num);
                        break;
                    }
                }
                //恰好等于中间数
                if (num == ran)
                {

                    Console.WriteLine(num);
                    break;
                }

            }
          
            Console.ReadKey();

        }
    }
}
