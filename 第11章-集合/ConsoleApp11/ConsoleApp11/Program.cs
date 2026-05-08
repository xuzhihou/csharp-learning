using System.Runtime.InteropServices;

namespace ConsoleApp11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region List集合

            //集合创建
            List<int> intLs = new List<int>();
            List<int> intLs10 = new List<int>(10);
            intLs10.Capacity = 20;

            //集合初始化
            List<int> tmLs=new List<int>() { 1, 2, 3, 4, 5 };
            var strLs=new List<string>() { "a", "b", "c" };

            //集合添加元素
            tmLs.Add(6);
            strLs.Add("d");
            strLs.AddRange(new string[] { "e", "f" });

            //插入元素
            tmLs.Insert(0,0);
            strLs.Insert(2, "x");
            strLs.Insert(3, "y");
            strLs.Insert(4, "z");


            //访问元素
            for(int i = 0; i < tmLs.Count; i++) {
                Console.WriteLine(tmLs[i]);
            }
            foreach(var item in strLs) {
                Console.WriteLine(item);
            }

            //删除元素
            tmLs.Remove(3);
            if(strLs.Remove("x")) {
                Console.WriteLine("元素x已删除");
            }
            else
            {
                Console.WriteLine("元素x不存在");
            }
            Console.WriteLine("删除范围元素前：");
            for (int i = 0; i < tmLs.Count; i++)
            {
                Console.WriteLine(tmLs[i]);
            }
            int index = 2;
            int count = 3;
            tmLs.RemoveRange(index, count);
            Console.WriteLine("删除范围元素后：");
            for (int i = 0; i < tmLs.Count; i++)
            {
                Console.WriteLine(tmLs[i]);
            }

            //搜索元素
            List<Racer> racers = new List<Racer>()
            {
                new Racer(1,"Michael","Schumacher","Germany",91),
                new Racer(2,"Lewis","Hamilton","UK",103),
                new Racer(3,"Sebastian","Vettel","Germany",53),
                new Racer(4,"Ayrton","Senna","Brazil",41),
                new Racer(5,"Alain","Prost","France",51),
                new Racer(6,"Fernando","Alonso","Spain",32),
                new Racer(7,"Niki","Lauda","Austria",25),
                new Racer(8,"Jim","Clark","UK",25),
                new Racer(9,"Jack","Brabham","Australia",14),
                new Racer(10,"Graham","Hill","UK",14)
            };
            Racer rac=new Racer(11, "Benjamin", "Schumacher", "Germany", 21);
            racers.Add( rac );
            var index1 = racers.FindIndex(r => r.Country == "Germany");
            Console.WriteLine($"第一个德国车手的索引是: {index1}");
            var index2 = racers.FindLastIndex(r => r.Country == "Germany");
            Console.WriteLine($"最后一个德国车手的索引是: {index2}");
            var index3 = racers.IndexOf(rac);
            Console.WriteLine($"rac的索引是: {index3}");
            var index4 = racers.LastIndexOf(rac);
            Console.WriteLine($"rac的最后一个索引是: {index4}");
            var pointRac = racers.Find(t => t.Country == "UK");
            Console.WriteLine($"第一个英国车手是: {pointRac.FirstName} {pointRac.LastName}");
            var lastRac = racers.FindLast(t => t.Country == "UK");
            Console.WriteLine($"最后一个英国车手是: {lastRac.FirstName} {lastRac.LastName}");
            var allRac = racers.FindAll(t => t.Country == "Germany");
            Console.WriteLine($"所有德国车手的数量是: {allRac.Count}");
            foreach(var v in allRac) {
                Console.WriteLine($"德国车手: {v.FirstName} {v.LastName}");
            }
            Console.WriteLine();

            //排序元素
            allRac.Sort();
            Console.WriteLine("按默认排序（姓氏，名字）:");
            foreach (var v in allRac)
            {
                Console.WriteLine($"德国车手: {v.FirstName} {v.LastName}");
            }
            Console.WriteLine();
            allRac.Sort(new RacerComparer(RacerComparer.CompareType.Wins));
            Console.WriteLine("按胜利次数排序:");
            foreach (var v in allRac)
            {
                Console.WriteLine($"德国车手: {v.FirstName} {v.LastName}, 胜利次数: {v.Wins}");
            }
            Console.WriteLine();

            //只读集合
            var readOnlyLs = allRac.AsReadOnly();
            foreach(var v in readOnlyLs)
            {
                Console.WriteLine($"德国车手: {v.FirstName} {v.LastName}, 胜利次数: {v.Wins}");
            }
            Console.WriteLine();

            #endregion

            #region Queue集合（队列）
            var dm= new DocumentManager();
            ProcessDocuments.Start(dm);

            for(int i = 0; i < 20; i++)
            {
                var doc = new Document($"文档 {i}", $"这是文档 {i} 的内容。",1);
                dm.AddDocument(doc);
                Console.WriteLine($"文档 {doc.Title} 已创建并添加到队列中。");
                Thread.Sleep(200); // Simulate time between document creation
            }
            #endregion

            #region Stack集合（栈）
            var alphabet=new Stack<char>();
            alphabet.Push('A');
            alphabet.Push('B');
            alphabet.Push('C');

            foreach(var ch in alphabet)
            {
                Console.WriteLine(ch);
            }

            var top = alphabet.Peek();
            Console.WriteLine($"栈顶元素: {top}");

            if(alphabet.Contains('B'))
            {
                Console.WriteLine("栈中包含元素B");
            }

            while (alphabet.Count > 0)
            {
                char ch = alphabet.Pop();
                Console.WriteLine($"弹出元素: {ch}");
            }
            Console.WriteLine();
            #endregion

            #region LinkedList集合（链表）

            var pdm = new PriorityDocumentManager();
            pdm.AddDocument(new Document("文档1", "内容1", 2));
            pdm.AddDocument(new Document("文档2", "内容2", 0));
            pdm.AddDocument(new Document("文档3", "内容3", 1));
            pdm.AddDocument(new Document("文档4", "内容4", 3));
            pdm.AddDocument(new Document("文档5", "内容5", 5));
            pdm.AddDocument(new Document("文档6", "内容6", 7));
            pdm.AddDocument(new Document("文档7", "内容7", 9));
            pdm.AddDocument(new Document("文档8", "内容8", 3));
            pdm.AddDocument(new Document("文档9", "内容9", 2));

            pdm.DisplayDocuments();
            #endregion

            #region SortedList集合（有序列表）
            var books = new SortedList<string, decimal>();
            books.Add("C# Programming", 29.99m);
            books.Add("Data Structures", 39.99m);
            books.Add("Algorithms", 49.99m);
            books.Add("Design Patterns", 34.99m);
            books["Benjamin's Book"] = 19.99m; // Adding a book with the author's name
            books["Beginning C#"] = 24.99m; 

            //迭代语句会按键的顺序显示
            foreach (var book in books)
            {
                //Console.WriteLine("书名: {0}, 价格: {1:C}", book.Key, book.Value);
                Console.WriteLine($"书名: {book.Key}, 价格: {book.Value:C}");
            }
            Console.WriteLine();

            if (!books.ContainsKey("Benjamin's Book"))
            {
                Console.WriteLine("没有找到Benjamin's Book");
            }
            else
            {
                Console.WriteLine("已经存在Benjamin's Book");
            }
            #endregion
            Console.ReadLine();
        }
    }
}
