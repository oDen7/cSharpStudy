using System;

namespace DataType
{
    class Program
    {
        static void Main(string[] args)
        {
            // c#提供16种预定义类型
            // 三种非简单类型
            // object 引用类型 string 引用类型 dynamic 引用类型
            // 十三种简单类型
            // 非数值类型 
            // bool 值类型  char 引用类型
            // 数值类型
            // 整数类型 
            // 8位 sbyte byte 值类型
            // 16位 short ushort值类型
            // 32位 int uint 值类型
            // 64位 long  ulong 值类型
            // 浮点类型
            // deciaml float double

            // 用户定义类型
            // 类类型 class  引用类型
            // 结构类型 struct 值类型
            // 数组类型 array 引用类型
            // 枚举类型 enum  值类型
            // 委托类型 delegate 引用类型
            // 接口类型 interface 引用类型

            sbyte number = 127;
            byte number1 = 255;
            short number2 = 32767;
            ushort number3 = 65535;
            int number4 = 2147483647, many = 2147483647;
            uint number5 = 4294967295;
            long number6 = 9223372036854775807;
            ulong number7 = 18446744073709551615;
            float number8 = 3.40282e+038F;
            double number9 = 1.79769e+308;

            int Null = null; // 可空类型
            // char c = U+0000;
            // decimal d = 7.9e+28;

            Console.WriteLine("{0}", number);
            Console.WriteLine("{0}", number1);
            Console.WriteLine("{0}", number2);
            Console.WriteLine("{0}", number3);
            Console.WriteLine("number4:{0},many:{1}", number4, many); // 多变量声明
            Console.WriteLine("{0}", number5);
            Console.WriteLine("{0}", number6);
            Console.WriteLine("{0}", number7);
            Console.WriteLine("{0}", number8);
            Console.WriteLine("{0}", number9);
            Console.WriteLine("{0}", NULL);
            // Console.WriteLine("{0}",c);
            // Console.WriteLine("{0}",d);
        }
    }
}
