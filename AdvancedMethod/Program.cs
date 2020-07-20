using System;

namespace AdvancedMethod
{
    class Example
    {
        public int val = 20;
    }
    class RefClass
    {
        // 调用了修改的ref局部变量的代码,所以类的字段值改变了。
        private int _score = 5;
        public ref int refToValue()
        {
            return ref _score;
        }
        public void scoreDisplay()
        {
            Console.WriteLine($"value inside class object : {_score}");
        }
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
        static void outParamMethod(out int outParam)  // 输出参数 不想再重写一个方法,偷懒了....(利用重载特性)
        {
            Example e = new Example();
            outParam = e.val + 20;
            Console.WriteLine($"退出 outParamMethod 重载方法");
        }

        static void paramArrayMethod(params int[] paramLists) // 参数数组
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

        static ref int Max(ref int v1, ref int v2) // 返回变量引用
        {
            // 返回较大值的变量引用,而不是实际的值。
            if (v1 > v2)
                return ref v1;
            else
                return ref v2;
        }

        static int namedParamMethod(int a, int b, int c) // 命名参数 
        {
            return a + b + c;
        }

        static int optionalParamMethod(int a, int b = 2, int c = 3) // 可选参数
        {
            return a + b + c;
        }

        static int factorial(int inValue)
        {
            if (inValue <= 1)
            {
                Console.WriteLine("{0}", inValue);
                return inValue;
            }
            else
            {
                Console.WriteLine("{0}", inValue);
                return inValue * factorial(inValue - 1); // 再一次调用 factorial
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
            Console.WriteLine($"=========栈帧=========");
            outParamMethod(out int outVal);  // 方法重载  方法调用 c# 7.0 之后 不需要预先声明 变量作为 out参数
            Console.WriteLine($"只返回 输出参数:{outVal}");
            Console.WriteLine("=========参数数组延伸式=========");
            paramArrayMethod(2, 3, 4);  // 方法调用
            Console.WriteLine("=========参数数组作为实参=========");
            int[] lists = new int[] { 5, 6, 7 }; // 创建并初始化数组
            paramArrayMethod(lists);  // 方法调用
            Console.WriteLine("=========ref局部变量和ref返回=========");
            Console.WriteLine("=========修改ref局部变量的代码=========");
            RefClass refClass = new RefClass();
            refClass.scoreDisplay();
            ref int score = ref refClass.refToValue();
            score = 10;
            refClass.scoreDisplay();
            Console.WriteLine("=========返回变量引用=========");
            int v1 = 10;
            int v2 = 20;
            Console.WriteLine($"初始化:v1 {v1},v2 {v2}");
            ref int max = ref Max(ref v1, ref v2);
            Console.WriteLine($"引用函数调用:{max}");
            max++;
            Console.WriteLine($"修改引用变量的值:max {max}, v1 {v1}, v2 {v2}");
            Console.WriteLine("=========命名参数=========");
            Console.WriteLine("{0}", namedParamMethod(1, 2, 3));
            Console.WriteLine("{0}", namedParamMethod(a: 1, b: 2, c: 3));
            Console.WriteLine("{0}", namedParamMethod(b: 2, a: 1, c: 3));
            Console.WriteLine("=========可选参数=========");
            Console.WriteLine("{0}", optionalParamMethod(1));
            Console.WriteLine("{0}", optionalParamMethod(1, 2, 3));
            Console.WriteLine("{0}", optionalParamMethod(2, 3, 1));
            Console.WriteLine("=========递归=========");
            Console.WriteLine("{0}", factorial(10));
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

// 命名参数
/*
    只要显式指定参数的名字,就可以任意顺序在方法调用中列出实参
*/

// 可选参数
/*
    为了表明某个参数是可选的,你需要在方法声明中为该参数提供默认值

    不是所有参数都可以作为可选参数.
        只要值类型的默认值在编译的时候可以确定,就可以使用值类型作为可选参数
        只要默认值是null的时候,引用类型才可以用作可选参数。

    所有必填参数必须在可选参数声明之前声明.如果有params参数,必须在所有可选参数之后声明。
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

// ref局部变量和ref返回
/*
    ref关键字传递一个对象引用给方法调用,这样在调用上下文中,对对象的任何改动在方法返回后依然可见。
    ref局部变量,它允许一个变量是另一个变量的别名。
    使用这个功能创建一个变量的别名,即使引用的对象是值类型。
    对任意一个变量的赋值都会反映到另一个变量上,因为它们引用的是相同的对象,即使是值类型。

    不能将返回类型是void的方法声明为ref语法
    ref return:
        不能包括 空值(null) 常量 枚举成员 类或者结构体的属性 指向只读位置的指针
        只能指向原先就在调用域内的位置,或者字段. 
        ref局部变量只能被赋值一次.
        即使将一个方法声明为ref返回方法,如果在调用该方法时省略了ref关键字,则返回的将是值,而不是指向值的内存位置的指针。
        如果将ref局部变量作为常规的实际参数传递给其他方法,则该方法仅获取该变量的一个副本.(尽管包含指向存储位置的指针,但使用这种方式时,它会传递值而不是引用)
*/

// 栈帧
/*
    再调用方法时,内存从栈的顶部开始分配,保存和方法关联的一些数据项。
    这块内存叫作方法的栈帧(stack frame)

    栈帧包含的内存保存如下内容:
        返回地址,也就是在方法退出的时候继续执行的位置.
        分配内存的参数,也就是方法的值参数,还可以是参数数组(如果有的话).
        和方法调用相关的方法的其他管理数据项.
    
    在方法调用时,整个栈帧都会压入栈.
    在方法退出时,整个栈帧都会从栈上弹出.(弹出栈帧有的时候也叫作栈展开 unwind)
*/

// 递归
/*
    除了调用其他方法,方法也可以调用自身.这叫作递归

    调用方法自身的机制和调用其他方法其实是完全一样的,都是为每一次方法调用把新的栈帧压入栈顶.
*/