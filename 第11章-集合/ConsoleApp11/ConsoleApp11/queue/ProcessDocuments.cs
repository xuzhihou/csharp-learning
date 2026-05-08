public class ProcessDocuments
{
	public static void Start(DocumentManager dm)
	{
		Task.Run(new ProcessDocuments(dm).Run);
	}

	private DocumentManager _documentManager;
	protected ProcessDocuments(DocumentManager dm)
	{
		if (dm == null)
		{
			throw new ArgumentNullException(nameof(dm));
		}
		_documentManager = dm;
	}

	protected async Task Run()
	{
		while (true)
		{
			if (_documentManager.IsDocumentAvailable)
			{
				var document = _documentManager.GetDocument();
				Console.WriteLine($"读取文档 {document.Title}");
				await Task.Delay(200); // Simulate time-consuming processing
			}
			else
			{
				await Task.Delay(500); // Wait before checking for new documents
			}
		}
	}
}