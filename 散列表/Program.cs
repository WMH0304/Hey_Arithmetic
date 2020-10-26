using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace 散列表
{
    class Program
    {
        class Test
        { 
            public string name { get; set; }

            public double org { get; set; }
        }
        static void Main(string[] args)
        {
            var SwA = new Stopwatch();
            /*
             * 字典 和哈希表一样都是以键值对的方式存储数据并且它的键是集合内唯一的。
             * 字典的本质还是哈希表，字典是哈希表的扩展
             * 
             * 可以根据字典和哈希表的特点定制一颗数据树，建立索引树
             * 不过 在 list dictionary hastable 的查询，插入，删除中 dictionary 的综合能力最好
             * 所以如果没有特定的条件的话，用dictionary 最好
             * 
             */
           // Dictionary<int, Test> keyValues = new Dictionary<int, Test>();
            Dictionary<int, string> keyValues = new Dictionary<int, string>();

            Hashtable hashtable = new Hashtable();
            for (int i = 0; i < 100; i++)
            {
                //Test test = new Test();
                //test.name = i+"lilimm".Trim();
                //test.org = i+i;
                keyValues.Add(i,i+"___values".Trim());
                hashtable.Add(i,i+"___哈希表");
            }
            SwA.Start();
            
            //bool ck = keyValues.ContainsKey(99);
            //if (ck)
            //{
            //     Console.WriteLine("{0}存在,年龄{1}", keyValues[99].name,keyValues[99].org);
            //}
           
           
            
            if (keyValues.ContainsValue("99___values"))
            {
                Console.WriteLine("是否存在对象__{0}", keyValues.ContainsValue("99___values"));
            }

           
            if (hashtable.ContainsKey(99))
            {
                Console.WriteLine("{0}键存在",hashtable[99]);
            }
                
            var v = keyValues.Values; 
            
            Console.WriteLine(SwA.Elapsed);
            Console.ReadKey();
        }
    }
}
