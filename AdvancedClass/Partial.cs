using System;
namespace AdvancedClass
{
    partial class PartialClass
    {
        // 组成类的所有分部类声明必须在一起编译.
        // 使用分部类声明的类必须有相同的含义,就好像所有类成员都声明在一个单独的类声明体内.
        public void printPartialClass(string str)
        {
            Console.WriteLine($"printPartialClass:{str}");
        }
    }
}
