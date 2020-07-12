using System;

namespace BasicMethod
{
    class Program
    {
        public int global = 1; // 全局变量
        // 类型推断 var关键字
        // 你提供的是编译器能从初始化语句的右边推断出来的信息
        // var ss = "sasdf";
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.WriteLine("全局变量:{0}", program.global);
            program.helloWorld();  // 方法调用
            Console.WriteLine("返回值实现:{0}", program.outputValue());
            program.localMethod(); // 方法调用
        }

        public void helloWorld()
        {
            // 局部常量 
            // 一旦初始化，值就不能改变了
            const int local1 = 2;
            // 局部变量
            // 局部变量的存在和生存期仅限于创建它的块及其内嵌的块
            int local2 = 3;
            Console.WriteLine("局部常量:{0}", local1);
            Console.WriteLine("局部变量:{0}", local2);
        }

        public string outputValue()
        {
            // return; 可以在任何情况下退出方法，不带参数 这种方式只能用void声明方法
            return "返回一个字符串";
        }

        public void localMethod()
        {
            string returnString(string s) // 声明局部函数
            {
                return s;
            }
            Console.WriteLine("{0}", returnString("这是一个局部函数~"));  // 调用局部函数
        }
    }
}
// 形式参数 形参
/*
    局部变量,声明在参数列表中,而不是方法体中。
    可以读入和读取。
    参数在方法体的外面定义并在方法开始之前初始化。
*/

// 实际参数 实参
/*
    当调用一个方法时,形参的值必须在方法的代码开始执行之前初始化。
    用于初始化形参的表达式或变量称作为  实参(actual parameter,有时也称为argument)
    实参位于方法调用的参数列表中
    每一个实参必须与对应形参的类型相匹配,或是编译器必须能够把实参隐式转换为那个类型。
*/

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
