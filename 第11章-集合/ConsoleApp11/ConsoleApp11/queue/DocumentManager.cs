public class DocumentManager
{
    private Queue<Document> documentQueue;
    public DocumentManager()
    {
        documentQueue = new Queue<Document>();
    }
    public void AddDocument(Document doc)
    {
        lock (this)
        {
            documentQueue.Enqueue(doc);
        }

        Console.WriteLine($"文档 '{doc.Title}' 已添加到队列中。");
    }
    public Document GetDocument()
    {
        lock (this)
        {
            if (documentQueue.Count > 0)
            {
                return documentQueue.Dequeue();
            }
            else
            {
                Console.WriteLine("队列中没有文档。");
                return null;
            }
        }
    }
    public void ProcessDocuments()
    {
        while (documentQueue.Count > 0)
        {
            Document doc = documentQueue.Dequeue();
            Console.WriteLine($"读取文档： {doc}");
            // Simulate processing time
            System.Threading.Thread.Sleep(300);
        }
        Console.WriteLine("所有文档已处理完毕。");
    }

    public bool IsDocumentAvailable=> documentQueue.Count > 0;
}