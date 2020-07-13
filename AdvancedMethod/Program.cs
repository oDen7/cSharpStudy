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
            /*
                在方法调用时,形参和实参指向堆中相同的对象。
                对成员值的修改会同时影响形参和实参。
                当方法创建新的对象时,形参和实参的引用都指向该新对象。
            */
            e4.val = 50;
            Console.WriteLine($"After member assignment: {e4.val}");
            e4 = new Example();
            Console.WriteLine($"After new object creation: {e4.val}");
        }

        static void outParamMethod(out Example e5, out int outParam) // 输出参数
        {
            e5 = new Example();
            outParam = e5.val + 15;
        }
        static void outParamMethod(out int outParam)  // 输出参数 不想再重写一个方法,偷懒了....
        {
            Example e = new Example();
            outParam = e.val + 20;
        }

        static void paramArrayMethod(params int[] paramLists)
        {
            if ((paramLists != null) && (paramLists.Length != 0))
            {
                for (int i = 0; i < paramLists.Length; i++)
                {
                    paramLists[i] *= 10;
                    Console.WriteLine($"{paramLists[i]}");
                }
            }
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
            /*
                如果在方法内创建一个新对象并赋值给形参,将切断形参与实参之间的关联,并且在方法内调用结束后,新对象也将不复存在。
            */
            Example e3 = new Example();
            Console.WriteLine($"Before method call: {e3.val}");
            refAsValueParamMethod(e3);
            Console.WriteLine($"After method call: {e3.val}");
            Console.WriteLine("=========引用类型作为引用参数传递=========");
            /*
                如果在方法内创建一个新对象并赋值给形参,在方法结束后该对象依然存在,并且是实参所引用的值。
            */
            Example e4 = new Example();
            Console.WriteLine($"Before method call: {e4.val}");
            refAsRefParamMethod(ref e4);  // 方法调用
            Console.WriteLine($"After method call: {e4.val}");
            Console.WriteLine("=========输出参数=========");
            Example e5 = null;
            int outParam;
            outParamMethod(out e5, out outParam);  // 方法调用
            Console.WriteLine($"C# 7.0 之前 输出参数: {outParam}");
            Example e6 = null;
            outParamMethod(out e6, out int outValue);  // 方法调用 c# 7.0 之后 不需要预先声明 变量作为 out参数
            Console.WriteLine($"C# 7.0 之后 输出参数: {outValue}");
            outParamMethod(out int outVal);  // 方法重载  方法调用 c# 7.0 之后 不需要预先声明 变量作为 out参数
            Console.WriteLine($"只返回 输出参数:{outVal}");
            Console.WriteLine("=========参数数组延伸式=========");
            paramArrayMethod(2, 3, 4);  // 方法调用
            Console.WriteLine("=========参数数组作为实参=========");
            int[] lists = new int[] { 5, 6, 7 }; // 创建并初始化数组
            paramArrayMethod(lists);  // 方法调用
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

    必须在声明和调用中都使用修饰符。输出参数是 out
    和引用参数相似,实参必须是变量,而不能是其他类型表达式。(因为方法需要内存位置来保存返回值)
*/

// 参数数组
/*
    在一个参数列表中只有一个参数数组,它必须是列表中最后一个
    参数列表的所有参数必须是同一个类型。

    参数数组是一组有序的同一类型的数据项。
    数组使用一个数字索引进行访问。
    数组是一个引用类型,因此它的所有数据项都保存在堆中。
*/

// 方法参数优先级:必填参数>可选参数>params参数(参数数组)

// 方法重载
/*
    使用相同名称的每个方法必须有一个和其他方法不同的签名(signature)

    方法签名:
    方法的名称
    参数的数目
    参数的数据类型和顺序
    参数修饰符

    返回类型不是签名的一部分
    形参的名称不是签名的一部分
*/