using System;

namespace AdvancedClass
{
    class InstanceClass　 // 实例类成员
    {
        public int mem;
    }

    class StatiClass // 静态字段
    {
        public int mem1 = 1; // 实例字段
        static public int mem2 = 2; // 静态字段

        public void updateValue(int a, int b)
        {
            mem1 = a;
            mem2 = b;
        }

        public void valueDisplay()
        {
            Console.WriteLine("mem1:{0},mem2:{1}", mem1, mem2);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========实例类成员===========");
            InstanceClass instanceClass1 = new InstanceClass();
            InstanceClass instanceClass2 = new InstanceClass();
            instanceClass1.mem = 10;
            instanceClass2.mem = 20;
            Console.WriteLine($"instanceClass1.mem = {instanceClass1.mem},instanceClass2.mem = {instanceClass2.mem}");
            Console.WriteLine("===========静态字段===========");
            Console.WriteLine($"访问静态类成员:{StatiClass.mem2}");
            StatiClass statiClass = new StatiClass();
            Console.WriteLine($"访问静态成员:{statiClass.mem1}");
            Console.WriteLine("调用 updateValue 方法");
            statiClass.updateValue(10, 20);
            Console.WriteLine($"调用 valueDisplay 方法");
            statiClass.valueDisplay();
        }
    }
}

// 类成员
/*
    数据成员(保存数据):
        字段
        变量
    函数方法(执行代码):
        方法
        属性
        构造函数
        析构函数
        运算符
        索引
        事件
*/

// 成员修饰符的顺序
/*
    类成员声明语句由下列部分组成:
    核心声明、一组可选的修饰符和一组可选的特性.
    
    用于描述这个结构的方法如下(方括号为可选):
    [特性] [修饰符] 核心声明
    
    修饰符
        如果有修饰符,必须放在修饰符和核心声明之前
        如果有多个修饰符,可以任意顺序排列
    
    特性
        如果有特性,必须放在修饰符和核心声明之前
        如果有多个特性,可以任意顺序排列
*/

// 实例类成员
/*
    类成员可以关联到类的一个实例,也可以关联到整个类,即类的所有实例.
    默认情况下,成员被关联到一个实例.

    可以认为类的每一个实例拥有自己的各个类成员的脚本,这些成员成为 实例成员.
    改变一个实例字段的值不会影响任何其他实例中成员的值.
*/

// 静态字段
/*
    静态字段被类的所有实例共享,所有实例都访问同一内存位置.
    因此,如果该内存位置的值被一个实例改变了,这种改变对所有的实例都可见.
*/

// 从类的外部访问静态成员
/* 
    使用点运算符可以从类的外部访问 public 实例成员.
    点运算符由 实例名、点和成员名组成.

    静态成员可以使用点运算符从类的外部访问.但因为没有实例,所以最常用的访问静态成员的方法使用类名,
*/