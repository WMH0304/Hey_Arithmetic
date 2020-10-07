using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace 排序
{
    class Program
    {

        static List<int> list = new List<int>(10);
        // static int[] vs = new int[10] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

        static void Main(string[] args)
        {

           
            #region 快速排序
            //检测时间
            System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
            const int z = 1000000;
            //生成随机数
            int[] a = new int[z];
            Random random = new Random();
            // Parallel.For(0, z, (i) => { a[i] = random.Next(0, z); });
            for (int i = 0; i < z; i++)
            {
                a[i] = random.Next(0, z);
            }
            watch.Start();//计时器开始。
            QuickSort(a, 0, z - 1);
            watch.Stop();//计时器结束。
           
            string time = watch.ElapsedMilliseconds.ToString();
            Console.Write("排序所用时间 :" + " " + time + " ms");
         
            Console.ReadKey();
            #endregion

         
        }


        #region 快速排序
        /*
         * 快速排序思想类似于二分查找，都是确定一个中位数（排序里面叫做基准数）
         * 排序步骤如下：
         * 1.确定基准数
         * 2.遍历数组将以基准数为界分为两个数组（也可以是多个）
         * 3.然后分别对两个数组进行排序
         * 4.最后合并数组
         */
        /// <summary>
        /// 分组
        /// </summary>
        /// <param name="a"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        private static void QuickSort(int[] a, int low, int high)
        {
            if (low >= high)
            {
                return;
            }
           
            //Task task = Task.Run(() => {  pivot = QuickSortOnce(a, low, high); });
            //task.Wait();
            

            int pivot = QuickSortOnce(a, low, high);//输出每一次排序。

            //对枢轴左端进行排序。
            Task.Run(() =>
            {
                QuickSort(a, low, pivot - 1);
            });

            //对枢轴右端进行排序。
            Task.Factory.StartNew(() =>
            {
                QuickSort(a, pivot + 1, high);
            });
            //QuickSort(a, low, pivot - 1);
            //QuickSort(a, pivot + 1, high);
        }
        /// <summary>
        /// 排序
        /// </summary>
        /// <param name="a"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        private static int QuickSortOnce(int[] a, int low, int high)
        {
            //将首个元素作为枢轴。
            int pivot = a[low];
            int i = low, j = high;
            while (i < j)
            {
                //从右往左，寻找首个小于povit的元素。
                while (a[j] >= pivot && i < j)
                {
                    j--;
                }
                //执行到此，j一定指向从右端起首个小于或等于povit的元素。执行替换。
                a[i] = a[j];
                //从左往右，寻找首个大于povit的元素。
                while (a[i] <= pivot && i < j)
                {
                    i++;
                }
                //执行到此，j一定指向从右端起首个大于或等于povit的元素。执行替换。
                a[j] = a[i];
            }
            //退出while循环，执行至此，必定是i==j的情况。i（或j）指向的既是枢轴的位置，定位该趟排序的枢轴并将该位置返回。
            a[i] = pivot;
            return i;






        }
        #endregion





    }
}
