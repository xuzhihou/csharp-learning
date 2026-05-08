public class PriorityDocumentManager
{
	private LinkedList<Document> _documentList;
	private readonly List<LinkedListNode<Document>> _priorityNodes;
	public PriorityDocumentManager()
	{
		_documentList = new LinkedList<Document>();
		_priorityNodes = new List<LinkedListNode<Document>>(10);
        for (int i = 0;  i < 10; i++)
        {
			_priorityNodes.Add(new LinkedListNode<Document>(null));
        }
    }
	public void AddDocument(Document doc)
	{
		if(doc==null)
		{
			throw new ArgumentNullException(nameof(doc));
		}
		lock (this)
		{
			if (_documentList.Count == 0)
			{
				_documentList.AddFirst(doc);
			}
			else
			{
				var current = _documentList.First;
				while (current != null && current.Value.Priority <= doc.Priority)
				{
					current = current.Next;
				}
				if (current == null)
				{
					_documentList.AddLast(doc);
				}
				else
				{
					_documentList.AddBefore(current, doc);
				}
			}
		}
		Console.WriteLine($"文档 '{doc.Title}' 已添加到优先级队列中。");
	}

	private void AddDocumentToPriorityNode(Document doc,int priority)
	{
		if(priority>9||priority< 0)
		{
			throw new ArgumentOutOfRangeException(nameof(priority), "优先级必须在0到9之间。");
		}
		var node = _priorityNodes[priority];
		if (node.Value == null)
		{
			--priority;
			if (priority <= 0)
			{
				AddDocumentToPriorityNode(doc, priority);
			}
			else
			{
				_documentList.AddLast(doc);
				_priorityNodes[doc.Priority] = _documentList.Last;
			}
			return;

		}
		else
		{
			LinkedListNode<Document> prioNode = _priorityNodes[priority];
			if (priority == doc.Priority)
			{
				_documentList.AddAfter(prioNode, doc);
				_priorityNodes[doc.Priority] = prioNode.Next;

			}
			else
			{
				LinkedListNode<Document> firstPrioNode = prioNode;
				while (firstPrioNode != null && firstPrioNode.Previous.Value.Priority == prioNode.Value.Priority)
				{
					firstPrioNode = prioNode.Previous;
					prioNode = firstPrioNode;
				}

				_documentList.AddBefore(firstPrioNode, doc);
				_priorityNodes[doc.Priority] = firstPrioNode.Previous;
			}

		}
	}
	public void DisplayDocuments()
	{
		lock (this)
		{
			Console.WriteLine("当前优先级队列中的文档：");
			foreach (var doc in _documentList)
			{
				Console.WriteLine($"文档标题: {doc.Title}, 优先级: {doc.Priority}");
			}
		}
	}
	public Document GetDocument()
	{
		lock (this)
		{
			if (_documentList.Count > 0)
			{
				var doc = _documentList.First.Value;
				_documentList.RemoveFirst();
				return doc;
			}
			else
			{
				Console.WriteLine("优先级队列中没有文档。");
				return null;
			}
		}
	}
	public void ProcessDocuments()
	{
		while (_documentList.Count > 0)
		{
			Document doc = GetDocument();
			Console.WriteLine($"读取文档： {doc}");
			// Simulate processing time
			System.Threading.Thread.Sleep(300);
		}
		Console.WriteLine("所有文档已处理完毕。");
	}
	public bool IsDocumentAvailable => _documentList.Count > 0;
}