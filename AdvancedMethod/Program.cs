using System;

namespace AdvancedMethod
{
    class Example
    {
        public int val = 20;
    }
    class Program
    {
        static void valueParamMethod(Example e1, int a1) // 传递 值参数
        {
            e1.val = e1.val + 5;
            a1 = a1 + 5;
            Console.WriteLine($"e1.val:{e1.val},a1:{a1}");
        }
        static void refParamMethod(ref Example e2, ref int a2) // 传递 引用参数
        {
            e2.val = e2.val + 5;
            a2 = a2 + 5;
            Console.WriteLine($"e2.val:{e2.val},a2:{a2}");
        }
        static void refAsValueParamMethod(Example e3) // 引用类型作为 值参数 传递
        {
            e3.val = 50;
            Console.WriteLine($"After member assignment: {e3.val}");
            e3 = new Example();
            Console.WriteLine($"After new object creation: {e3.val}");
        }
        static void refAsRefParamMethod(ref Example e4) // 引用类型作为 值参数 传递
        {
            e4.val = 50;
            Console.WriteLine($"After member assignment: {e4.val}");
            e4 = new Example();
            Console.WriteLine($"After new object creation: {e4.val}");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("=========值参数=========");
            Example e1 = new Example();
            int a1 = 10;
            valueParamMethod(e1, a1);
            Console.WriteLine($"a1.val:{e1.val},a1:{a1}");
            Console.WriteLine("=========引用参数=========");
            Example e2 = new Example();
            int a2 = 10;
            refParamMethod(ref e2, ref a2);
            Console.WriteLine($"e2.val:{e2.val},a2:{a2}");
            Console.WriteLine("=========引用类型作为值参数传递=========");
            Example e3 = new Example();
            Console.WriteLine($"Before method call: {e3.val}");
            refAsValueParamMethod(e3);
            Console.WriteLine($"After method call: {e3.val}");
            Console.WriteLine("=========引用类型作为引用参数传递=========");
            Example e4 = new Example();
            Console.WriteLine($"Before method call: {e4.val}");
            refAsRefParamMethod(ref e4);
            Console.WriteLine($"After method call: {e4.val}");
        }
    }
}

// 值参数
/*
    当你使用值参数时,通过将实参的值复制到形参的方式把数据传递给方法。

    在栈中为形参分配空间
    将实参的值复制给形参
*/

// 引用参数
/*
    使用引用参数时,必须在方法的声明和调用中都使用ref修饰符
    实参 必须 是变量,在用作 实参 前必须被赋值。

    不会在栈上为形参分配内存
    形参的参数名将作为实参变量的别名,指向相同的内存位置。
*/

// 输出参数
/*
    输出参数 用于从方法体内把数据传出到调用代码,它的行为与引用参数类似
*/