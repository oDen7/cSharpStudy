using System;

namespace ClassAndInheritance
{
    class BaseClass // 基类
    {
        public string field1 = "base class field";
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

    class DeriveClass1 : BaseClass  // 屏蔽基类成员
    {
        new public string fileld1 = "屏蔽基类成员重新赋值";
        new public void method1(int value)
        {
            Console.WriteLine($"屏蔽基类方法重新声明:{value}");
        }

        public void printBaseFileld()
        {
            Console.WriteLine($"基类访问:{base.field1}"); // 访问基类字段 field1
        }
    }

    class DeriveClass2 : BaseClass
    {
        override public void print()
        {
            Console.WriteLine("使用覆写方法");
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
            DeriveClass1 deriveClass1 = new DeriveClass1();
            Console.WriteLine($"field1:{deriveClass1.field1}");
            deriveClass1.method1(1);
            Console.WriteLine("===========基类访问===========");
            deriveClass1.printBaseFileld();
            Console.WriteLine("===========使用基类的引用===========");
            DeriveClass deriveClass2 = new DeriveClass();
            BaseClass baseClass = (BaseClass)deriveClass2; // 使用 对象强制转换 访问 基类
            deriveClass2.method2(deriveClass2.field2);
            baseClass.method1(baseClass.field1);
            Console.WriteLine("===========虚方法和覆写方法===========");
            BaseClass baseClass1 = new BaseClass();
            baseClass1.print();  // 调用 基类 虚方法
            DeriveClass2 deriveClass3 = new DeriveClass2();
            BaseClass baseClass2 = (BaseClass)deriveClass3;
            deriveClass3.print(); // 使用 覆写方法(派生类同签名方法会覆盖掉基类同签名方法)
            baseClass2.print();
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