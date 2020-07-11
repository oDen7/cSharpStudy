using System;

namespace BasiClass
{
    class Program
    {
        public class BasiClass
        {
            // 显式声明
            public string s = "你正在使用BasiClass类";
            // 隐式声明
            // 每种值类型默认值为0,bool类型默认值为false,引用类型默认值为null。
            public int aDefault;
            public string sDefault;
            private int number = 10;  // 私有访问
            public int PrintNumber()  // 共有访问
            {
                return number;  // 从类的内部访问成员
            }
        }
        public static void Main(string[] args)
        {
            BasiClass basiClass = new BasiClass(); // 创建一个BasiClass实例
            // 调用实例字段值
            Console.WriteLine("{0}", basiClass.s);
            Console.WriteLine("值类型:{0},引用类型:{1}", basiClass.aDefault, basiClass.sDefault);
            // 调用实例方法
            Console.WriteLine("调用实例basiClass.PrintNumber方法:{0}", basiClass.PrintNumber()); // 从类的外部访问成员
        }
    }
}
