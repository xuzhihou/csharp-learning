namespace ConsoleApp07
{
    internal class Program
    {
        static void Main(string[] args)
        {

            #region【1】简单的数组
            Console.WriteLine("【1】简单的数组");
            int[] arr = new int[5] { 1, 2, 3, 4, 5 };
            for (int i = 0; i < arr.Length; i++)
            {
                Console.WriteLine(arr[i]);
            }
            Console.WriteLine();
            #endregion

            #region【2】使用引用类型的数组
            Console.WriteLine("【2】使用引用类型的数组");
            Person[] people = new Person[3];
            people[0] = new Person { Name = "Alice", Age = 25 };
            people[1] = new Person { Name = "Bob", Age = 30 };
            people[2] = new Person { Name = "Charlie", Age = 35 };
            foreach (var person in people)
            {
                Console.WriteLine(person.ToString());
            }
            Console.WriteLine();
            #endregion

            #region【3】多维数组
            Console.WriteLine("【3】多维数组");
            int[,] twodim = new int[3, 3];
            twodim[0, 0] = 1;
            twodim[0, 1] = 2;
            twodim[0, 2] = 3;
            twodim[1, 0] = 4;
            twodim[1, 1] = 5;
            twodim[1, 2] = 6;
            twodim[2, 0] = 7;
            twodim[2, 1] = 8;
            twodim[2, 2] = 9;

            // 输出twodim里面的值
            for (int i = 0; i < twodim.GetLength(0); i++)
            {
                for (int j = 0; j < twodim.GetLength(1); j++)
                {
                    Console.Write(twodim[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            int[,] secondDim = new int[4, 4]
            {
                {1,2,3,4 },
                {11,12,13,14 },
                {21,22,23,24 },
                {31,32,33,34 }
            };
            for (int i = 0; i < secondDim.GetLength(0); i++)
            {
                for (int j = 0; j < secondDim.GetLength(1); j++)
                {
                    Console.Write(secondDim[i, j] + " ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            #endregion

            #region 【4】锯齿数组
            Console.WriteLine("【4】锯齿数组");
            int[][] jaggedArray = new int[3][];
            jaggedArray[0] = new int[] { 1, 2, 3 };
            jaggedArray[1] = new int[] { 4, 5 };
            jaggedArray[2] = new int[] { 6, 7, 8, 9 };
            for (int row = 0; row < jaggedArray.Length; row++)
            {
                {
                    for (int col = 0; col < jaggedArray[row].Length; col++)
                    {
                        Console.Write(jaggedArray[row][col] + " ");
                    }
                    Console.WriteLine();
                }
            }
            Console.WriteLine();
            #endregion

            #region【5】Array 类（用方括号声明的数组是C#中使用Array的表示法,实际上是Array的子类）
            Console.WriteLine("【5】Array 类");
            Array intArray1 = Array.CreateInstance(typeof(int), 5);
            for (int i = 0; i < intArray1.Length; i++)
            {
                intArray1.SetValue(i + 1, i);
            }
            for (int i = 0; i < intArray1.Length; i++)
            {
                Console.WriteLine(intArray1.GetValue(i));
            }
            //也可以将已经创建的array数组强制转换为声明为int[]的数组
            int[] array2 = (int[])intArray1;
            Console.WriteLine();
            #endregion

            #region 【5.1】Array 类（创建多维数组和不基于0的数组）
            int[] lengths = { 2, 3 };//2*3的二维数组
            int[] lowerBounds = { 1, 10 };//第一维基于1，第二维基于10
            Array races = Array.CreateInstance(typeof(Person), lengths, lowerBounds);
            races.SetValue(new Person { Name = "Alice", Age = 25 }, 1, 10);
            races.SetValue(new Person { Name = "Alice1", Age = 125 }, 1, 11);
            races.SetValue(new Person { Name = "Alice2", Age = 225 }, 1, 12);
            races.SetValue(new Person { Name = "Alice3", Age = 325 }, 2, 10);
            races.SetValue(new Person { Name = "Alice4", Age = 425 }, 2, 11);
            races.SetValue(new Person { Name = "Alice5", Age = 525 }, 2, 12);
            //•	用GetLowerBound和GetUpperBound获取每一维的起止下标。
            int lowerI = races.GetLowerBound(0);
            int upperI = races.GetUpperBound(0);
            int lowerJ = races.GetLowerBound(1);
            int upperJ = races.GetUpperBound(1);

            for (int i = lowerI; i <= upperI; ++i)
            {
                for (int j = lowerJ; j <= upperJ; ++j)
                {
                    var person = races.GetValue(i, j) as Person;
                    if (person != null)
                        Console.Write(person.ToString() + " ；");
                    else
                        Console.Write("null ");
                }
                Console.WriteLine();
            }
            //foreach(var person in races)
            //{
            //    Console.WriteLine(person.ToString());
            //}
            Console.WriteLine();
            #endregion

            #region【6】复制数组(值类型)
            int[] sourceArray = { 1, 2, 3, 4, 5 };
            int[] destinationArray = (int[])sourceArray.Clone();
            Console.WriteLine("源数组");
            foreach (var v in sourceArray)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("修改前");

            foreach (var v in destinationArray)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("修改后");

            destinationArray.SetValue(11, 2);
            foreach (var v in destinationArray)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();
            #endregion

            #region 【6.1】复制数组（引用类型）
            Person[] sourcePeople = new Person[3];
            sourcePeople[0] = new Person { Name = "Alice", Age = 25 };
            sourcePeople[1] = new Person { Name = "Bob", Age = 30 };
            sourcePeople[2] = new Person { Name = "Charlie", Age = 35 };

            Person[] destinationPeople = (Person[])sourcePeople.Clone();
            Console.WriteLine("源数组");
            foreach (var v in sourcePeople)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("修改前");

            foreach (var v in destinationPeople)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("对克隆后的数组修改后");

            destinationPeople.SetValue(new Person { Name = "David", Age = 40 }, 2);
            foreach (var v in destinationPeople)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("对克隆后的数组修改后，原数组");

            foreach (var v in sourcePeople)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();

            #endregion

            #region 【6.2】复制数组（Copy方法）
            Person[] sourcePeople1 = new Person[3];
            sourcePeople1[0] = new Person { Name = "Alice", Age = 25 };
            sourcePeople1[1] = new Person { Name = "Bob", Age = 30 };
            sourcePeople1[2] = new Person { Name = "Charlie", Age = 35 };

            // 使用Array.Copy方法复制到destinationPeople数组
            Person[] destinationPeople1 = new Person[sourcePeople1.Length];
            Array.Copy(sourcePeople1, destinationPeople1, sourcePeople1.Length);
            Console.WriteLine("源数组");
            foreach (var v in sourcePeople1)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("修改前");

            foreach (var v in destinationPeople1)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("对克隆后的数组修改后");

            destinationPeople1.SetValue(new Person { Name = "David", Age = 40 }, 2);
            foreach (var v in destinationPeople1)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();
            Console.WriteLine("对克隆后的数组修改后，原数组");

            foreach (var v in sourcePeople1)
            {
                Console.Write(v.ToString() + " ");
            }
            Console.WriteLine();

            #endregion

            #region 【7】数组的排序
            string[] names = { "Charlie", "Alice", "Bob", "Benjamin", "Jack", "Bruse" };
            Console.WriteLine("排序前的数组：");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Array.Sort(names);
            Console.WriteLine("排序后的数组：");
            foreach (var name in names)
            {
                Console.WriteLine(name);
            }
            Console.WriteLine();
            Person[] person01 =
            {
                new Person { Name = "Alice", Age = 25 },
                new Person { Name = "Bob", Age = 30 },
                new Person { Name = "Charlie", Age = 35 },
                new Person { Name = "Benjamin", Age = 15 },
                new Person { Name = "Jack", Age = 35 },
                new Person { Name = "Joke", Age = 25 },
            };
            Console.WriteLine("排序前的数组：");
            foreach (var v in person01)
            {
                Console.WriteLine(v);
            }
            Array.Sort(person01);
            Console.WriteLine("排序后的数组：");
            foreach (var v in person01)
            {
                Console.WriteLine(v);
            }
            #endregion

            #region 【7.1】数组的排序,传递排序参数

            Person[] person02 =
            {
                new Person { Name = "Alice", Age = 25 },
                new Person { Name = "Bob", Age = 30 },
                new Person { Name = "Charlie", Age = 35 },
                new Person { Name = "Benjamin", Age = 15 },
                new Person { Name = "Jack", Age = 35 },
                new Person { Name = "Joke", Age = 25 },
            };
            Console.WriteLine("排序前的数组：");
            foreach (var v in person02)
            {
                Console.WriteLine(v);
            }
            Array.Sort(person02, new PersonComparer(PersonCompareType.ByAge));
            Console.WriteLine("排序后的数组：");
            foreach (var v in person02)
            {
                Console.WriteLine(v);
            }
            #endregion

            Console.ReadLine();
        }

        class Person : IComparable<Person>
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public override string ToString()
            {
                return $"Name: {Name}, Age: {Age}";
            }
            public int CompareTo(Person? other)
            {
                if (other == null) return 1;
                int result = this.Age.CompareTo(other.Age);
                if (result == 0)
                {
                    result = string.Compare(this.Name, other.Name);
                }
                return result;
            }
        }
        enum PersonCompareType
        {
            ByAge,
            ByName
        }
        class PersonComparer : IComparer<Person>
        {
            private PersonCompareType _compareType;

            public PersonComparer(PersonCompareType compareType)
            {
                _compareType = compareType;
            }

            public int Compare(Person? x, Person? y)
            {
                if (x == null && y == null) return 0;
                if (x == null) return 1;
                if (y == null) return -1;
                switch (_compareType)
                {
                    case PersonCompareType.ByAge:
                        return x.Age.CompareTo(y.Age);
                    case PersonCompareType.ByName:
                        return string.Compare(x.Name, y.Name);
                    default:
                        throw new ArgumentException("Invalid comparison type");
                }
            }
        }
    }
}