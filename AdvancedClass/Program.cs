using System;
using static AdvancedClass.StaticPropertyClass;
namespace AdvancedClass
{
    class InstanceClass　 // 实例类成员
    {
        public int mem;
    }

    class StaticFieldClass // 静态字段
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

    class StaticMethodClass
    {
        static public int mem1;  // 静态字段
        static public void outPutPrint() // 静态方法
        {
            Console.WriteLine($"打印内部静态字段mem1:{mem1}");
        }
    }

    class ConstValueClass
    {
        public const int inValue1 = 10; // 预定义简单类型
        public const int inValue2 = inValue1 * 10; // 表达式

        public void print()
        {
            Console.WriteLine($"访问类成员常量:inValue1 {inValue1},inValue2 {inValue2}");
        }
    }

    class AttrClass
    {
        // 该类有一个共有字段和一个共有属性.
        // 从用法上无法区分它们
        public int field = 10; // 字段初始化
        public int Property1 = 20; // 属性初始化

        // 下划线及Camel大小写
        private int _property2; // 后备字段:分配内存 

        // 属性:为分配内存 
        public int Property2
        { // 属性声明
            set
            {
                _property2 = value; // 设置后备字段的值
            }
            get
            {
                return _property2; // 读取后备字段的值
            }
        }
    }

    class RunOtherComputeProperty
    {
        private int _property1; // 字段
        private int _property2;
        public int Property3
        { // 属性 执行其他计算
            set
            {
            }
            get
            {
                return 10; // 只读和只写属性
            }
        }
        public int Property1
        { // 属性 执行其他计算
            set
            {
                _property1 = value < 100 ? 100 : value; // 表达式
            }
            get
            {
                return _property1;
            }
        }

        public int Property2
        { // 属性 使用c#7.0中getter/setter表达函数体
            set => _property2 = value < 100 ? 200 : value;
            get => _property2;
        }
    }

    class RightTriangle // 只读属性
    {
        public double A = 3;
        public double B = 4;
        // 只读属性
        public double Hypotenuse
        {
            get
            {
                return Math.Sqrt((A * A) + (B * B));// 计算返回值
            }
        }
    }

    class AutoPropertyClass
    {
        public int inValue
        {
            get; set;
        }
    }

    class StaticPropertyClass
    {
        public static int inValue { get; set; }
        public void printValue()
        {
            Console.WriteLine($"StaticPropertyClass inValue:{inValue}"); // 从内部访问
        }
    }

    class ConstructorClass
    {
        private int _inValue;
        public ConstructorClass() // 带参数的构造函数
        {
            _inValue = 10;
        }

        // 构造函数重载
        public ConstructorClass(int inValue) // 带参数的构造函数
        {
            _inValue = inValue;
        }

        public void printValue()
        {
            Console.WriteLine("ConstructorClass _inValue:{0}", _inValue);
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
            StaticFieldClass.mem2 = 10; // 没有类实例的静态成员仍可以被复制并读取
            Console.WriteLine($"访问静态类成员:{StaticFieldClass.mem2}");
            StaticFieldClass staticFieldClass = new StaticFieldClass();
            Console.WriteLine($"访问静态成员:{staticFieldClass.mem1}");
            Console.WriteLine("调用 updateValue 方法");
            staticFieldClass.updateValue(10, 20);
            Console.WriteLine($"调用 valueDisplay 方法");
            staticFieldClass.valueDisplay();
            Console.WriteLine("===========静态函数成员===========");
            StaticMethodClass.mem1 = 10; // 修改静态成员 使用点号语法
            StaticMethodClass.outPutPrint(); // 调用静态方法 使用点号语法
            Console.WriteLine("===========成员常量===========");
            Console.WriteLine($"访问类成员常量:inValue1 {ConstValueClass.inValue1},inValue2 {ConstValueClass.inValue2}");
            ConstValueClass constValueClass = new ConstValueClass(); // 通过实例化访问
            constValueClass.print(); // 通过方法访问 成员常量 (没有意义....)
            Console.WriteLine("===========属性===========");
            AttrClass attrClass = new AttrClass();
            Console.WriteLine($"读取字段和属性:field {attrClass.field},property {attrClass.Property1}");
            Console.WriteLine("===========属性使用===========");
            // 使用赋值语句设置 属性 的值
            attrClass.Property2 = 5; // 隐式调用set方法 
            // 把 属性 看作一个字段,从中读取它的值.
            Console.WriteLine($"读取属性Property2:{attrClass.Property2}"); // 隐式调用get方法 
            Console.WriteLine("===========执行其他计算属性===========");
            RunOtherComputeProperty runOtherComputeProperty = new RunOtherComputeProperty();
            Console.WriteLine($"执行其他计算只读属性Property3:{runOtherComputeProperty.Property3}");
            runOtherComputeProperty.Property1 = 10;
            Console.WriteLine($"执行其他计算表达式Property1:{runOtherComputeProperty.Property1}");
            runOtherComputeProperty.Property2 = 20;
            Console.WriteLine($"使用c#7.0中getter/setter表达函数体,读取字段Property2:{runOtherComputeProperty.Property2}");
            Console.WriteLine("===========只读属性===========");
            RightTriangle rightTriangle = new RightTriangle();
            Console.WriteLine($"只读属性求第三边长度:{rightTriangle.Hypotenuse}");
            Console.WriteLine("===========自动实现属性===========");
            AutoPropertyClass autoPropertyClass = new AutoPropertyClass();
            autoPropertyClass.inValue = 100;
            Console.WriteLine("自动实现属性:{0}", autoPropertyClass.inValue);
            Console.WriteLine("===========静态属性===========");
            StaticPropertyClass.inValue = 100; // 从外部访问
            Console.WriteLine("从外部访问:{0}", StaticPropertyClass.inValue); // 从外部访问
            inValue = 200;
            Console.WriteLine("使用using static 访问,所以没有使用类型:{0}", inValue); // 从外部访问
            Console.WriteLine("===========实例构造函数===========");
            ConstructorClass constructorClass1 = new ConstructorClass();
            constructorClass1.printValue();
            Console.WriteLine("===========带参数的构造函数===========");
            ConstructorClass constructorClass2 = new ConstructorClass(20);
            constructorClass2.printValue();
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

    静态成员可以使用点运算符从类的外部访问.但因为没有实例,所以最常用的访问静态成员的方法使用类名.
*/

// 静态成员的生存期
/*
    静态成员的生命期与实例成员的不同.
    
    只有实例创建之后才会产生实例成员,在实例销毁之后实例成员也就不存在了.
    但是即使类没有实例,也存在静态成员,并且可以访问.
*/

// 静态函数成员
/*
    如同静态字段,静态函数成员独立于任何类实例,即使没有类的实例,仍然可以调用静态方法.
    静态函数成员 不能访问 实例成员,但能访问其他 静态成员.
*/

// 成员常量
/*
    成员变量类似于局部常量,但是它们声明在类声明中而不是方法内

    与局部变量类似,用于初始化成员常量的值在编译时必须是可计算的,而且通常是一个预定义简单类型或由它们组成表达式.
    不能在成员常量声明以后给它赋值.
*/

// 常量与静态量
/*
    它们对类的每个实例都是"可读的",而且即使没有类的实例也可以使用.
    与真正的静态量不同,常量没有自己的存储位置,而是在编译时被编译器替换.

    虽然常量成员表现得像静态量,但不能将常量声明为 static
*/

// 属性
/*
    属性是代表类实例或类中的数据项的成员.
    使用属性就像写入或读取一个字段,语法相同.

    与字段相同:
        它是命名的类成员.
        它有类型.
        它可以被赋值和读取.
    然而与字段不同,属性是一个 函数成员:
        它不一定为数据存储分配内存
        它执行代码
    属性是一组(两个)匹配的、命名的、称为 访问器 的方法
        set访问器 为 属性赋值
        get访问起 从 属性获取值
*/

// 属性声明和访问器
/*
    set 和 get 访问器有预定义的语法和语义.
    可以把 set 访问器想象成一个方法,带有单一的参数,它"设置"属性的值.
    get 访问器 没有参数并从属性返回一个值.

    set 访问器总是:
        拥有一个单独的、隐式的值参,名称为value,与属性的类型相同
        拥有一个返回类型 void
    get 访问器总是:
        没有参数
        拥有一个与属性类型相同的返回类型

    访问器声明既没有 显式 的参数,也没有返回类型声明.
    不需要它们,因为它们已经 隐含 在属性的类型中.

    set 访问器中的隐式参数value是一个普通的值参.
    和其他值参一样,可以用它发送数据到方法体或访问器块.
    在块的内部,可以像普通变量那样使用value,包括对它赋值.

    访问器的其他要点:
        get 访问器的所有执行路径必须包括一条return语句,他返回一个属性类型的值.
        访问器set 和 get 可以以任何顺序声明,并且,除了这两个访问器外,属性上不允许有其他方法.
*/

// 使用属性
/*
    写入 和 读取 属性的方法与访问字段一样.访问器被隐式调用.
        要写入一个属性,在赋值语句的左边使用属性的名称.
        要读取一个属性,把属性的名称用在表达式中.

    只要使用属性名就可以写入和读取属性,就好像是一个字段名.

    属性会根据是写入还是读取来隐式地调用适当的访问器.
    不能显式地调用访问器,因为这样做会产生编译错误.
*/

// 属性和关联字段
/*
    一种常见的方式是在类中将字段声明为 private 以封装该字段,并声明为以一个 public 属性来控制从类的外部对该字段的访问.
    和属性关联的字段常称为 后备字段 或 后备存储

    字段使用 Camel 大小写,属性使用 Pascal 大小写
*/

// 执行其他计算
/*
    访问器 get 和 set 能执行任何计算,也可以不执行任何计算.
    唯一 必须 的行为是get访问器要返回一个属性类型的值.
*/

// 只读和只写属性
/*
    只有get访问器的属性称为只读属性.
        只读属性能够安全地将一个数据项从类或类的实例中传出,而不必让调用者修改属性值.
    只有set访问器的属性称为只写属性.
        只写属性很少见,因为它们几乎没有实际用途.如果想在赋值时触发一个副作用,应该使用方法而不是属性.
    两个访问器中至少有一个必须定义,否则编译器会产生一条错误信息.
*/

// 属性与公有字段
/*
    属性比公有字段更好.
        属性是函数成员而不是数据成员,允许你处理输入和输出,而公有字段不行.
        属性可以只读或只写,而字段不行.
        编译后的变量和编译后的属性语义不同.
    
    有的时候开发人员可能想用公有字段代替属性,因为如果以后需要为字段的数据增加处理逻辑的话,可以再把字段改为属性.
    但是如果这样修改的话,所有 访问 这个字段的其他程序集都需要重新编译,因为字段和属性在编译后的语义不一样.
    如果实现的是属性,只需要修改属性的实现,而无须重新编译访问它的其他程序集.
*/

// 自动实现属性
/*
    自动实现属性(automatically implemented property 或 auto-implemented property,常简称为"自动属性",auto-property),
    它允许只声明属性而不声明后备字段.
    编译器会为你创建隐藏的后备字段,并且自动挂接到get和set访问器上.

    不声明后备字段-----编译器根据属性的类型分配存储.
    不能提供访问器的方法体-----它们必须被简单地声明为分号.
    get相当于简单的内存读,set相当于简单的写.
    但是无法访问自动属性的方法体,所有在使用自动属性时调用代码通常会更加困难.
*/

// 静态属性
/*
    属性也可以声明为static,和所有静态成员一样,具有一下特点.
        不能访问类的实例成员,但能被实例成员访问.
        不管类是否有实例,它们都是存在的.
        在类的内部,可以仅使用名称来引用静态属性.
        在类的外部,正如本章前面描述的,可以通过类名或者使用 using static结构来引用静态属性.

    即使没有类的实例,也可以访问属性.
*/

// 实例构造函数
/*
    实例构造函数是一个特殊的方法,它在创建类的每个新实例时执行.
        构造函数用于初始化实例的状态.
        如果希望从类的外部创建类的实例,需要将构造函数声明为public.
    
    除了下面这几点,构造函数看起来很像类声明中的其他方法:
        构造函数的名称和类相同.
        构造函数不能有返回值.
*/

// 带参数的构造函数
/*
    构造函数可以带参数.参数的语法和其他方法完全相同.
    构造函数可以被重载.
*/

// 默认构造函数
/*
    类的声明中没有显式地提供实例构造函数,那么编译器会提供一个隐式的默认构造函数.
        没有参数
        方法体为空
    
    如果你为类声明了任何构造函数,那么编译器将不会为该类定义默认构造函数.
*/

// 静态构造函数
/*
    构造函数也可以声明为static.
    实例构造函数初始化类的每个新实例,而static构造函数初始化类级别的项.
    静态构造函数初始化类的静态字段.
        初始化类级别的项.
            在引用任何静态成员之前.
            在创建类的任何实例之前.
        静态构造函数在以后方面与实例构造函数类似.
            静态构造函数的名称必须和类名相同.
            构造函数不能返回值.
        静态构造函数在以下方面和实例构造函数不同.
            静态构造函数声明中使用static关键字.
            类只能有一个静态构造函数,而且不能带参数.
            静态构造函数不能有访问修饰符.
        
        类既可以有静态构造函数也可以有实例构造函数.
        静态构造函数不能访问所在类的实例成员,所以不能使用this访问器
        不能从程序中显式调用静态构造函数,系统会自动调用他们:
            在类的任何实例被创建之前.
            在类的任何静态成员被引用之前.

*/