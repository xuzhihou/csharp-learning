public class Document
{
    public string Title { get; set; }
    public string Content { get; set; }
    /// <summary>
    /// 优先级
    /// </summary>
    public byte Priority { get; set; } // 0-255, 0 is highest priority

    public Document(string title, string content, byte priority)
    {
        Title = title;
        Content = content;
        Priority = priority;
    }
    public override string ToString()
    {
        return $"标题: {Title}, 内容: {Content}, 优先级: {Priority}";
    }   
}