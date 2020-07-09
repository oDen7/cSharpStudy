using System;

namespace FormatOuput
{
    class Program
    {
        static void Main(string[] args)
        {
            // 单行注释
            /* 
                多行注释
            */ 
            int number = 1000;
            Console.WriteLine("{0},{1}", 500, number); // 多重标记和值
            Console.WriteLine("{0:C}", number); // 格式化为货币
            Console.WriteLine("{0,10:C}", 500); // 对其说明符号
            Console.WriteLine("货币:{0:C}", number); // 输出格式为货币
            Console.WriteLine("十进制:{0:D}", number); // 输出格式为十进制
            Console.WriteLine("定点:{0:F4}", "1000.99999999"); // 输出格式为十进制数字字符串(可包括小数) 
            Console.WriteLine("常规:{0:G4}", 1000.99999999); // 输出格式为定点或科学记数法
            Console.WriteLine("十六进制:{0:X}", number); // 输出格式为十六进制
            Console.WriteLine("数字:{0:N}", number); // 输出格式为数字
            Console.WriteLine("百分比:{0:P}", number); // 输出格式为百分比
            Console.WriteLine("往返过程:{0:R}", "1000"); // 输出格式为往返过程(将字符串使用Parse方法转化为数字)
            Console.WriteLine("科学记数法:{0:E}", number); // 输出格式为科学记数法
        }
    }
}
