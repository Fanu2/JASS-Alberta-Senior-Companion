using System.IO;
using System.Text.Json;
using JASS.AlbertaSeniorCompanion.Models;

namespace JASS.AlbertaSeniorCompanion.Services;

public static class AppData
{
    private static readonly string Folder = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
        "JASS", "AlbertaSeniorCompanion");
    private static readonly string FilePath = Path.Combine(Folder, "checklist.json");

    public static List<ChecklistItem> LoadChecklist()
    {
        try {
            if (File.Exists(FilePath))
                return JsonSerializer.Deserialize<List<ChecklistItem>>(File.ReadAllText(FilePath)) ?? Defaults();
        } catch { }
        return Defaults();
    }

    public static void SaveChecklist(IEnumerable<ChecklistItem> items)
    {
        Directory.CreateDirectory(Folder);
        File.WriteAllText(FilePath, JsonSerializer.Serialize(items,
            new JsonSerializerOptions { WriteIndented = true }));
    }

    private static List<ChecklistItem> Defaults() => new()
    {
        new() { Title = "Review Alberta Seniors Benefit eligibility" },
        new() { Title = "Review Coverage for Seniors health coverage" },
        new() { Title = "Review dental and optical assistance" },
        new() { Title = "File annual income tax return" },
        new() { Title = "Review CRA account and benefit information" },
        new() { Title = "Review CPP / OAS / GIS information" },
        new() { Title = "Keep emergency contacts current" },
        new() { Title = "Review bank and direct-deposit information" },
        new() { Title = "Review beneficiary and estate documents" },
        new() { Title = "Review medications and pharmacy information" },
        new() { Title = "Review home safety and emergency plan" }
    };
}
