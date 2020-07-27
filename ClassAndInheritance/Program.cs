using System;

namespace ClassAndInheritance
{
    class BaseClass // 基类
    {
        public string field1 = "base class field";
        private int _int = 5;
        virtual public int property
        {
            get { return _int; }
        }
        public void method1(string value)
        {
            Console.WriteLine($"Base Class Method --- {value}");
        }

        virtual public void print()
        {
            Console.WriteLine("使用虚方法");
        }
    }

    class DeriveClass : BaseClass // 派生类
    {
        public string field2 = "derive class field";
        public void method2(string value)
        {
            Console.WriteLine($"Derive Class Method --- {value}");
        }
    }

    class ShieldBaseMemeberClass : BaseClass  // 屏蔽基类成员
    {
        /*
            成员“成员”不会隐藏继承的成员。不需要新关键字
            即使该声明未覆盖基类中的现有声明，该类声明仍包含new关键字。您可以删除新关键字。
            https://docs.microsoft.com/en-us/dotnet/csharp/misc/cs0109
        */
        new public string field1 = "屏蔽基类成员重新赋值"; // 屏蔽基类成员
        new public void method1(string value) // 屏蔽基类方法
        {
            Console.WriteLine($"屏蔽基类方法重新声明:{value}");
        }

        public void printBaseFileld()
        {
            Console.WriteLine($"基类访问:{base.field1}"); // 访问基类字段 field1
        }
    }

    class OverrideClass : BaseClass // 使用override声明print
    {
        override public void print()
        {
            Console.WriteLine("使用覆写方法");
        }
    }

    class BestOverrideClass : OverrideClass // 最高派生(most-derived)
    {
        // 如果把 OverrideClass 的 print 方法声明为 override,那么它会覆写方法的两个低派生级别的版本
        override public void print()
        {
            Console.WriteLine("最高派生类使用覆写方法");
        }
    }

    class BestNewClass : OverrideClass // 使用new 声明print
    {
        new public void print()
        {
            Console.WriteLine("最高派生类使用覆写方法");
        }
    }

    class OverrideOtherMemberClass : BaseClass // 覆写其他成员类型
    {
        private int _int = 10;
        override public int property
        {
            get { return _int; }
        }
    }

    class ControllerInitClass // 构造函数初始化语句
    {
        public int mem1;
        public string mem2;
        public int mem3;

        private ControllerInitClass() // 私有构造函数执行其他构造
        {
            mem1 = 10; // 函数共有的初始化
        }

        public ControllerInitClass(string value) : this()
        { // 使用构造函数初始化语句
            mem2 = value;
        }
        public ControllerInitClass(int value) : this()
        { // 使用构造函数初始化语句
            mem3 = value;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("===========访问继承的成员===========");
            DeriveClass deriveClass = new DeriveClass();
            Console.WriteLine($"field1:{deriveClass.field1}"); // 访问基类 field1
            Console.WriteLine("===========method1===========");
            deriveClass.method1(deriveClass.field1); // 调用基类方法 method1
            Console.WriteLine($"field2:{deriveClass.field2}"); // 访问派生类 field2
            Console.WriteLine("===========method2===========");
            deriveClass.method2(deriveClass.field2); // 调用派生类方法 method2
            Console.WriteLine("===========屏蔽基类的成员===========");
            ShieldBaseMemeberClass shieldBaseMemeberClass = new ShieldBaseMemeberClass();
            Console.WriteLine($"field1:{shieldBaseMemeberClass.field1}");
            shieldBaseMemeberClass.method1("shieldBaseMemeberClass");
            Console.WriteLine("===========基类访问===========");
            shieldBaseMemeberClass.printBaseFileld();
            Console.WriteLine("===========使用基类的引用===========");
            DeriveClass baseHref = new DeriveClass();
            BaseClass baseClass = (BaseClass)baseHref; // 使用 对象强制转换 访问 基类
            baseHref.method2(baseHref.field2);
            baseClass.method1(baseClass.field1);
            Console.WriteLine("===========虚方法和覆写方法===========");
            BaseClass baseClass1 = new BaseClass();
            baseClass1.print();  // 调用 基类 虚方法
            OverrideClass overrideClass = new OverrideClass();
            BaseClass baseClass2 = (BaseClass)overrideClass;
            overrideClass.print(); // 使用 覆写方法(派生类同签名方法会覆盖掉基类同签名方法)
            baseClass2.print();
            Console.WriteLine("===========覆写标记为override的方法===========");
            Console.WriteLine("===========使用override声明print===========");
            BestOverrideClass bestOverrideClass = new BestOverrideClass();
            BaseClass baseClass3 = (BaseClass)bestOverrideClass;
            bestOverrideClass.print();
            baseClass3.print(); // 无论 print 是通过派生类调用还是基类调用的,都会调用最高派生类中的方法.
            Console.WriteLine("===========使用new声明print===========");
            BestNewClass bestNewClass = new BestNewClass();
            BaseClass baseClass4 = (BaseClass)bestNewClass;
            bestNewClass.print();
            baseClass4.print(); // 当通过 baseClass4 的引用调用print方法时,方法调用只向上传递了一级,到达了 BestNewClass,在那里它被执行.
            Console.WriteLine("===========覆写其他成员类型===========");
            OverrideOtherMemberClass overrideOtherMemberClass = new OverrideOtherMemberClass();
            BaseClass baseClass5 = (BaseClass)overrideOtherMemberClass;
            Console.WriteLine($"覆写基类property:{overrideOtherMemberClass.property}");
            Console.WriteLine($"BaseClass property:{baseClass5.property}");
            Console.WriteLine("===========构造函数初始化语句===========");
            ControllerInitClass controllerInitClass1 = new ControllerInitClass("mem2");
            Console.WriteLine($"mem1:{controllerInitClass1.mem1},mem2:{controllerInitClass1.mem2},mem1:{controllerInitClass1.mem3}");
            ControllerInitClass controllerInitClass2 = new ControllerInitClass(100);
            Console.WriteLine($"mem1:{controllerInitClass2.mem1},mem2:{controllerInitClass2.mem2},mem1:{controllerInitClass2.mem3}");
        }
    }
}

// 类继承
/*
    已存在的类成为基类(base class)
    新类成为派生类(derived class)

    派生类成员的组成
        本身声明中的成员.
        基类的成员
    
    要声明一个派生类,需要在类名后加入基类规格说明.
    基类规格说明由冒号和用作基类的类名称组成.
    派生类直接继承字列出的基类.
    派生类扩展他的基类,因为它包含了基类的成员,还有它本身声明中的新增功能.
    派生类不能删除它所继承的任何成员.
*/

// 访问继承的成员
/*
    继承的成员可以被访问,就像它们是派生类自己的声明一样.
*/

// 所有类都派生自object类
/*
    除了特殊的类object,所有类都是派生类,即使它们没有基类规格说明.
    类object是唯一的非派生类,因为它是继承层次结构的基础.

    没有基类规格说明的类隐式地直接派生自类object.
    不加基类规格说明只是指定object为基类的简写.
    
    一个类声明的基类规格说明只能有一个单独的类.这称为单继承.
    虽然类只能直接继承一个基类,但派生的层次没有限制.

    基类和派生类是相对术语.所有的类都是派生类,要么派生自object,要么派生自其他的类.
*/

// 屏蔽基类的成员
/*
    虽然派生类不能删除它继承的任何成员,但可以用与基类成员名称相同的成员来屏蔽(mask)基类成员.

    派生类中屏蔽基类成员的一些要点:
        要屏蔽一个继承的数据成员,需要声明一个新的相同类型的成员,并使用相同的名称.
        通过在派生类中声明新的带有相同签名的函数成员,可以屏蔽继承的函数成员.
        要让编译器知道你在故意屏蔽继承的成员,可以用new修饰符.
        也可以屏蔽静态成员.
*/

// 基类访问
/*
    如果派生类必须访问被隐藏的继承成员,可以使用基类访问(base access)表达式.
    基类访问表达式由关键字base后面跟着一个点和成员的名称组成.
*/

// 使用基类的引用
/*
    派生类的实例由基类的实例和派生类新增的成员组成.
    派生类的引用指向整个类对象,包括基类部分.


    如果有一个派生类对象的引用,就可以获取该对象基类部分的引用(使用类型转换运算符把该引用转换为基类类型)
    类型转换运算符放置在对象引用的前面,由圆括号括起的要被转换成的类名组成.
    将派生类对象强制转换为基类对象的作用是产生的变量只能访问基类的成员.
*/

// 虚方法和覆写方法
/*
    虚方法可以使基类的引用访问"升至"派生类内.
    
    可以使用基类引用调用派生类的方法:
        派生类的方法和基类方法有相同的签名和返回类型.
        基类的方法使用virtual标注.
        派生类的方法使用override标注.

    其他关于 virtual 和 override 修饰符的重要信息如下:
        覆写和被覆写的方法必须有相同的可访问性.
        不能覆写 static方法 或 非虚方法
        方法、属性和索引器,以及另一种成员类型-----事件,都可以被声明为 virtual 和 override
*/

// 覆写标记为override的方法
/*
    覆写方法可以在继承的任何层次出现
        当使用对象基类部分的引用调用一个被覆写的方法时,方法的调用被沿派生层次上溯执行,一直到标记为override的方法的高级派生(most-derived)的版本.
        如果在更高的派生级别有该方法的其他声明,但没有被标记为override,那么它们不会被调用.
*/

// 覆写其他成员类型
/*
    virtual/override方法,在属性,事件以及索引器上的用法也是一样的.
*/

// 构造函数的执行
/*
    要创建对象的基类部分,需要隐式调用基类的某个构造函数.
    继承层次链中的每个类在执行它自己的构造函数体之前执行它的基类构造函数.

    周期:
    初始化实例成员
    调用基类构造函数
    执行实例构造函数的方法体

    强烈反对在构造函数中调用虚方法.
    在执行基类的构造函数时,基类的虚方法会调用派生类的覆写方法,但这是在执行派生类的构造函数方法体之前.
    因此,调用会在派生类完全初始化之前传递到派生类.
*/

// 构造函数初始化语句
/*
    默认情况下,在构造对象是,将调用基类的无参数构造函数.
    如果希望派生类使用一个指定的基类构造函数而不是无参数构造函数,必须在构造函数初始化语句中指定它.

    有两种方式的构造函数初始化语句:
        第一种形式使用关键字base并指明使用哪一个基类构造函数.
        第二种形式使用关键字this并指明应该使用当前类的哪一个构造函数.

    base()
    构造函数初始化语句由关键字base和要调用的基类构造函数的参数列表组成.
    当声明一个不带构造函数初始化语句的构造函数时,它实际上是带有base()构造函数初始化语句的简写形式.

    this()
    在构造过程(实际上是编译器)使用当前类中其他的构造函数.
    这种用法的好处:
        一个类有好几个构造函数,并且它们都需要在对象构造过程开始时执行一些公共的代码.
        对于这种情况,可以把公共代码提取出来作为一个构造函数,被其他所有的构造函数作为构造函数初始化语句.
*/