namespace BusinessLogic.Notes.Markdown
{
    public interface IMarkdownService
    {
        string ToStyledHTML(string input);
    }
}