using System;
using System.Collections.Generic;
using System.Linq;

namespace 贪婪算法
{
    #region 小车问题
    //家具
    class Volume
    {
        /// <summary>
        /// 物体名称
        /// </summary>
        public string Volume_name { get; set; }
        /// <summary>
        /// 物体体积
        /// </summary>
        public int  Volume_num { get; set; }
    }

    //车子
    class Car
    {
        //车子名
        public string Car_name { set; get; }
        //车子体积
        public int Car_num { get; set; }
        //物品存放
        public List<Volume> Car_ { get; set; }
    }
    #endregion

    class Program
    {

        /*
         * 算法思想：从局部最优解到全局最优解（由近及远的思想）
         * 特点：
         * 1.将复杂的问题简单化
         * 2.减少计算量
         * 3.不一定是最优解，但结果近似最优解 
         * 4.近似思想，类似于数学极限
         * 5.可能存在多个解
         * 6.
         */
        /*
         * 我是贪婪算法，一个活在当下的算法，我的人生理念就是活在当下，做好当前，
         * 我之所以叫贪婪，并不是因为我的劣根性，而是因为我时刻对世界充满着好奇和对未来的热枕之心。
         * 我总想着能最大程度地去探索世界，感受世界，然后在琳琅的选择中选择属于我自己的那条路，对于现在的我来说最契合的那条路。
         * 因为我自身的特性所以我总被人们冠以贪婪，但我并不贪婪，我是我，我是贪婪算法。
         * 
         */
       

        #region 小车问题
        //物品集合
        public static List<Volume> volumes;
        //车集合
        public static List<Car> cars;




        //添加数据
        public Program()
        {
            //添加物品数据
            volumes = new List<Volume>()
            {
                new Volume{Volume_name ="A",Volume_num =1},
                new Volume{Volume_name ="B",Volume_num =2},
                new Volume{Volume_name ="C",Volume_num =3},
                new Volume{Volume_name ="D",Volume_num =4},
                new Volume{Volume_name ="E",Volume_num =5},
                new Volume{Volume_name ="F",Volume_num =6},
                new Volume{Volume_name ="G",Volume_num =7},
                new Volume{Volume_name ="H",Volume_num =8},
                new Volume{Volume_name ="I",Volume_num =9},
                new Volume{Volume_name ="J",Volume_num =10},
                new Volume{Volume_name ="K",Volume_num =11},
                new Volume{Volume_name ="L",Volume_num =12},
                new Volume{Volume_name ="M",Volume_num =1},
                //new Volume{Volume_name ="N",Volume_num =2},
                //new Volume{Volume_name ="O",Volume_num =5},
                //new Volume{Volume_name ="P",Volume_num =4},
                //new Volume{Volume_name ="Q",Volume_num =3},
                //new Volume{Volume_name ="R",Volume_num =5},
                //new Volume{Volume_name ="S",Volume_num =4},
                //new Volume{Volume_name ="T",Volume_num =3},
                new Volume{Volume_name ="U",Volume_num =2}
            };

            //添加车数据
            cars = new List<Car>()
            {
                new Car{Car_name ="手扶拖拉机",Car_num =20,Car_ = new List<Volume>()},
                new Car{Car_name ="朝鲜小马驹",Car_num =30,Car_ = new List<Volume>()}
            };

        }

        #endregion

        static void Main(string[] args)
        {
            //小车问题
            min_car();

            Console.ReadKey();
            
           
        }
       
        /// <summary>
        ///  小车问题
        /// </summary>
        static void min_car()
        {
            /*
           你在一家家具公司工作，需要将家具发往全国各地，为此你需要将箱子装上卡车。每
 个箱子的尺寸各不相同，你需要尽可能利用每辆卡车的空间，为此你将如何选择要装
 上卡车的箱子呢？请设计一种贪婪算法。使用这种算法能得到最优解吗？
              */
            /*
             * 解决思路：1.在范围内找出物品体积最小的物体，放到车容积最小的车
             *           2.在范围内找出物品体积最小的物体，放到车容积最大的车
             *           3.在范围内找出物品体积最大的物体，放到车容积最大的车 （如果还有剩余空间可以反转从最小体积开始查找）你应该就是最优解了
             *           4.在范围内找出物品体积最大的物体，放到车容积最小的车
             *          
             */
            Program program = new Program();

            //体积最小车容积
            int cars_num_count = int.MaxValue;
            //体积最大车容积
            //int cars_num_count = 0;
            string cars_name = string.Empty;
            foreach (var item in cars)
            {
                //体积最小车容积
                if (item.Car_num < cars_num_count)
                {
                    cars_num_count = item.Car_num;
                    cars_name = item.Car_name;
                }
                //体积最大车容积
                //if (item.Car_num > cars_num_count)
                //{
                //    cars_num_count = item.Car_num;
                //    cars_name = item.Car_name;
                //}

            }
            int i = 0;
            int var_count = 0;
            Console.WriteLine("物品体积            物品名称");
            //当物品总体积小于小车体积时就再找出最小体积物品
            while (var_count < cars_num_count)
            {
                //体积最小物品体积
                int vls = int.MaxValue;
                for (int j = 0; j < volumes.Count; j++)
                {
                    //当前最小物品体积
                    if (volumes[j].Volume_num <= vls)
                    {
                        vls = volumes[j].Volume_num;
                    }

                }
                int vn = volumes.Where(d => d.Volume_num == vls).FirstOrDefault().Volume_num;
                string vm = volumes.Where(d => d.Volume_num == vls).FirstOrDefault().Volume_name;
                volumes.Remove(volumes.Where(d => d.Volume_num == vls).FirstOrDefault());


                var_count += vls;
                if (var_count > cars_num_count)
                {

                    break;
                }
                i++;
                Console.WriteLine("   " + vn + "                   " + vm);
            }
            Console.WriteLine("小车   " + cars_name + "    的容积是   " + cars_num_count + "   他最多可以装  " + i + " 个物品");

        }

        /// <summary>
        /// 旅行问题
        /// </summary>
        static void travel_issue()
        {
     /*
      * 你要去欧洲旅行，总行程为7天。对于每个旅游胜地，
      * 你都给它分配一个价值表 集合覆盖问示你有多想去那里看看，
      * 并估算出需要多长时间。你如何将这次旅行的价值最大化？
      */

      /*
       * 解决思路：价值最大化 1.去最多的地方
       *                      2.路途最少
       *                      3.景点权重占比最大
       *                      4.消耗时间最少
       *                      5.
       * 
       */







        }




    }
}
