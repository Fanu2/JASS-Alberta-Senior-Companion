namespace JASS.AlbertaSeniorCompanion.Models;

public record ResourceLink(string Title, string Url, string Category);
public class ChecklistItem { public string Title { get; set; } = ""; public bool Done { get; set; } }
