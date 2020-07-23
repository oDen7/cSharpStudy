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

    class StatiConstructorClass
    {
        private static Random random; // 私有静态字段

        static StatiConstructorClass() // 静态构造函数
        {
            random = new Random(); // 初始化 random
        }

        public int getRandom()
        {
            return random.Next();
        }
    }

    class InitClass // 对象初始化语句
    {
        public int x = 1;
        public int y = 2;
    }

    class ReadonlyClass // readonly修饰符
    {
        public readonly int mem1 = 1; // 初始化
        public readonly int mem2; // 未初始化

        public ReadonlyClass() // 构造函数
        {
            this.mem1 = 10;
            this.mem2 = 20;
        }
        public ReadonlyClass(int mem2) // 构造函数 重载
        {
            this.mem2 = mem2;
        }

        public ReadonlyClass(int mem1, int mem2) // 构造函数 重载
        {
            this.mem1 = mem1;
            this.mem2 = mem2;
        }
    }

    class ThisClass // this 关键字
    {
        private int mem1 = 10;
        public int returnMax(int mem1)
        {
            return mem1 > this.mem1 ? mem1 : this.mem1;
        }
    }

    class IndexerClass // 索引器
    {
        public string lastName; // 调用字段0
        public string firstName; // 调用字段1
        public string cityOfBirth; // 调用字段2
        public bool sex; // 调用字段3
        public bool student; // 调用字段4
        /*
            它必须声明为public,以便从类的外部访问.
            在set访问器方法体内,代码确定索引指的是那个字段,并把隐式变量value的值赋给它.
            在get访问器方法体内,代码确定索引指的是那个字段,并返回该字段的值.
        */
        public string this[int index] // 索引器声明
        {
            set
            {
                switch (index)
                {
                    case 0:
                        lastName = value;
                        break;
                    case 1:
                        firstName = value;
                        break;
                    case 2:
                        cityOfBirth = value;
                        break;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
            get
            {
                switch (index)
                {
                    case 0: return lastName;
                    case 1: return firstName;
                    case 2: return cityOfBirth;
                    default: throw new ArgumentOutOfRangeException("index");
                }
            }
        }
        public bool this[string index]  // 索引器重载
        {
            /*
                只要索引器的参数列表不同,类就可以有任意多个索引器.
                索引器类型不同是不够的。
                这叫做索引器重载,因为所有索引器都有相同的"名称":this访问引用.
            */
            // 可以使用 if语句 也可以使用 switch语句
            set
            {
                if (index == "student")
                {
                    student = value;
                }
                else
                {
                    switch (index)
                    {
                        case "sex":
                            sex = value;
                            break;
                        default: throw new ArgumentOutOfRangeException("index");
                    }
                }
            }
            get
            {
                // 可以使用 if语句 也可以使用 switch语句
                if (index == "student")
                {
                    return student;
                }
                else
                {
                    switch (index)
                    {
                        case "sex": return sex;
                        default: throw new ArgumentOutOfRangeException("index");
                    }
                }
            }
        }
    }

    class AccessClass // 访问器的访问修饰符
    {
        // 尽管可以从类的外部读取属性,但只能在类的内部设置它.
        // 这是一个非常重要的封装工具.
        public string name { get; private set; }
        public AccessClass(string name)
        {
            this.name = name;
        }
    }

    partial class PartialClass
    {
        partial void partialMethod(string str) // 实现分部方法
        {
            Console.WriteLine($"partialMethod:{str}");
        }
    }

    partial class PartialClass
    {
        partial void partialMethod(string str); // 定义分部方法
        public void printPartialMethod(string str)
        {
            partialMethod(str);
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
            Console.WriteLine("===========静态构造函数===========");
            StatiConstructorClass StatiConstructorClass1 = new StatiConstructorClass();
            StatiConstructorClass StatiConstructorClass2 = new StatiConstructorClass();
            Console.WriteLine($"Next random #:{StatiConstructorClass1.getRandom()}");
            Console.WriteLine($"Next random #:{StatiConstructorClass2.getRandom()}");
            Console.WriteLine("===========对象初始化语句===========");
            InitClass initClass1 = new InitClass();
            InitClass initClass2 = new InitClass { x = 10, y = 20 }; // 对象初始化语句
            Console.WriteLine($"initClass1:x={initClass1.x},x={initClass1.y}");
            Console.WriteLine($"initClass2:x={initClass2.x},x={initClass2.y}");
            Console.WriteLine("===========readonly修饰符===========");
            ReadonlyClass readonlyClass1 = new ReadonlyClass();
            ReadonlyClass readonlyClass2 = new ReadonlyClass(200);
            ReadonlyClass readonlyClass3 = new ReadonlyClass(100, 200);
            Console.WriteLine($"readonlyClass1:x={readonlyClass1.mem1},x={readonlyClass1.mem2}");
            Console.WriteLine($"readonlyClass2:x={readonlyClass2.mem1},x={readonlyClass2.mem2}");
            Console.WriteLine($"readonlyClass3:x={readonlyClass3.mem1},x={readonlyClass3.mem2}");
            Console.WriteLine("===========this关键字===========");
            ThisClass thisClass = new ThisClass();
            Console.WriteLine($"this关键字:{thisClass.returnMax(30)}");
            Console.WriteLine($"this关键字:{thisClass.returnMax(5)}");
            Console.WriteLine("===========索引器===========");
            IndexerClass indexerClass = new IndexerClass();
            indexerClass[0] = "xiao";
            indexerClass[1] = "ming";
            indexerClass[2] = "河北省";
            Console.WriteLine($"indexerClass lastName:{indexerClass[0]},firstName:{indexerClass[1]},cityOfBirth:{indexerClass[2]}");
            indexerClass["student"] = false;
            Console.WriteLine($"indexerClass student:{indexerClass["student"]}");
            indexerClass["sex"] = true;
            Console.WriteLine($"indexerClass 重载 sex:{indexerClass["sex"]}");
            Console.WriteLine("===========访问器的访问修饰符===========");
            AccessClass accessClass = new AccessClass("Jack");
            Console.WriteLine($"访问器的访问修饰符 name:{accessClass.name}");
            Console.WriteLine("===========分部类===========");
            PartialClass partialClass = new PartialClass();
            partialClass.printPartialClass("调用不同文件下的分部类");
            partialClass.printPartialMethod("调用分部方法");
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

// 对象初始化语句
/*
    对象初始化语句拓展了创建语法,在表达式的尾部放置了一组成员初始化语句.
    利用对象初始化语句可以在创建新的对象实例的时,设置字段和属性的值.

    创建对象的代码必须能够访问要初始化的字段和属性.
    初始化发生在构造方法之后,因此在构造方法中设置的值可能会在之后对象初始化中重置为相同或不同的值.
*/

// readonly修饰符
/*
    字段可以使用readonly修饰符声明.
    其作用类似于将字段声明为const,一旦值被设定就不能改变.

    const字段只能在字段的声明语句中初始化,而readonly字段可以在下列任意位置设置它的值.
        字段声明语句,类似于const.
        类的任何构造函数.如果是static字段,初始化必须在静态构造函数中完成.
    const字段的值必须在编译时决定,而readonly字段的值可以在运行时决定.
    const的行为总是静态的,而对于readonly字段以下两点是正确的.
        它可以是实例字段,也可以是静态字段.
        它在内存中有存储位置.
*/

// this关键字
/*
    this关键字在类中的使用,是对当前实例的引用.
    它只能被用在下列类成员的代码块中.
        实例构造函数
        实例方法
        属性和索引器的实例访问器
    
    this的目的:
        用于区分类的成员和局部变量或参数
        作为调用方法的实参
*/

// 索引器
/*
    使用索引访问它们将会很方便,好像该实例是字段的数组一样.
    索引器使用索引运算符,它由一对方括号和中间的索引组成.

    什么是索引器
    索引器是一组get和set访问器,与属性类似.
    和属性一样,索引器不用分配内存来存储.
    索引器和属性都主要被用来访问其他数据成员,它们与这些成员关联,并为它们提供获取和设置访问.
        属性通常表示单个数据成员.
        索引器通常表达多个数据成员.
    和属性一样,索引器可以只有一个访问器,也可以两个都有.
    索引器总是实例成员,因此不能被声明为static.
    和属性一样,实现get和set访问器的代码不一定要关联到某个字段或属性.

    声明索引器
    索引器没有名称.在名称的位置是关键字this.
    参数列表在方括号中间.
    参数列表中必须至少声明一个参数.

    索引器的set访问器
    当索引器被用于赋值时,set访问器被调用,并接受两项数据.
        一个名为value的隐式参数,其中持有要保存的数据.
        一个或更多索引参数,表示数据应该保存到那里.
    
    它的返回类型为void
    它使用的参数列表和索引器声明中的相同
    它有一个名为value的隐式参数,值参类型和索引器类型相同.

    索引器的get访问器
    当使用索引器获取值时,可以通过一个或多个索引参数调用get访问器.
    索引参数指示获取那个值
    
    它的参数列表和索引器声明中的相同.
    它返回索引器类型相同的值.

    和属性一样,不能显式调用get和set访问器.
*/

// 访问器的访问修饰符
/*
    带get和set访问器:属性和索引器。
    默认情况下,成员的两个访问器的访问级别和成员自身相同.

    访问器的访问修饰符的限制
        仅当成员(属性或索引器)既有get访问器也有set访问器是,其访问器才能有访问修饰符.
        虽然两个访问器都必须出现,但它们中只能有一个访问修饰符.
        访问器的访问修饰符的限制必须比成员的访问级别更严格.

    public -> protected internal -> protected = internal -> private
*/

// 分部类和分部类型
/*
    每个分部类的声明都含有一些类成员的声明.
    类的分部类声明可以在同一一个文件中也可以在不同文件中.

    每个分部类声明必须被标注为partial class.

    类型修饰符partial不是关键字,所以在其他上下文中,可以在程序中把它用作标示符.
    但直接用作关键字class、struct或interface之前,它表示分部类型.
*/

// 分部方法
/*
    分部方法是声明在分部类中不同部分的方法.
    分部方法的不同部分可以声明在分部类的不同部分中,也可以声明在同一个部分中.

    分部方法的两个部分
    定义分部方法声明
        给出签名和返回类型
        声明的实现部分只是一个分号
    实现分部方法声明
        给出签名和返回类型
        以普通的语句块形式实现
    
    关于分部方法的重要内容
        定义声明和实现声明的签名和返回类型必须相配.签名和返回类型有如下特征
            返回类型必须为void
            签名不能包括访问修饰符,这使分部方法是隐式私有的
            参数列表不能包括out参数
            在定义声明和实现声明中都必须包括上下文关键字partial,并且直接放在关键字void之前.
        可以有定义部分而没有实现部分。在这种情况下,编译器把方法的声明以及方法内部任何对方法的调用都移除.
        不能只有分部方法的实现部分而没有实现部分.
*/