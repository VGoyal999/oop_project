using Term.MusicPlayer.Ui.Models;

namespace Term.MusicPlayer.Ui.Services;

internal class UiBuilder : IUiBuilder
{
    private  PanelConfig? statusLine;
    private readonly List<PanelConfig> panels = [];
    private readonly int totalWidth = 90;
    private readonly int totalHeight = 22;

    public IUiBuilder AddMainPanel(string title)
    {
        var takenWidth = 0;
	panels.ForEach(p => takenWidth += p.Width);
	int remainingWidth = totalWidth - takenWidth;
	
	panels.Add(new() 
	{
	    Title = title,
	    Width = remainingWidth,
	    Content = "\n\n      [Playing] 💿 Resonance - Home\n      ─────────────────────────────────────\n      01:42 ━━━━━━─────── 03:30\n      Shuffle: Off | Repeat: All"
	});
	return this;
    }

    public IUiBuilder AddSidebar(string title, int widthPercent)
    {
	int calculatedWidth = totalWidth * widthPercent / 100;

	panels.Add(new() 
	{
	    Title = title,
	    Width = calculatedWidth,
	    Content = " 󰓇  Liked Songs\n 󰓇  Coding Lo-Fi\n 󰓇  Synthwave 1984\n 󰓇  Phonk Gym Mix"
	});
        return this;
    }

    public IUiBuilder AddStatusLine(string currentMode, string statusText)
    {
	statusLine = new()
	{
	    Title = currentMode,
	    Content = statusText
	};
        return this;
    }

    public void Build()
    {
        Console.Clear(); 
	Console.CursorVisible = false;

	int currCol = 1;
	int bodyHeight = totalHeight - 2;

	foreach (var panel in panels)
	{
	    DrawBox(currCol, 1, panel.Width, bodyHeight, panel.Title);
	    RenderPanelText(currCol + 2, 3, panel.Content);
	    currCol += panel.Width;
	}

	if (statusLine != null)
	{
	    Console.SetCursorPosition(0, totalHeight);

            // ANSI colors: Purple background for Normal Mode style, dark grey for status text
            string modeBlock = $"\x1b[45m\x1b[30m {statusLine.Title} \x1b[0m";
            string statusBlock = $"\x1b[48;5;236m {statusLine.Content.PadRight(totalWidth - statusLine.Title.Length - 4)} \x1b[0m";
            Console.Write($"{modeBlock}{statusBlock}");
	}
    }

    private static void DrawBox(int startCol, int startRow, int width, int height, string title)
    {
	Console.SetCursorPosition(startCol, startRow);
	Console.Write($"┌── {title} ".PadRight(width - 1, '─') + "┐");

	for (int i = 0; i < height; i++)
	{
	    Console.SetCursorPosition(startCol, startRow + i);
            Console.Write("│");
            Console.SetCursorPosition(startCol + width - 1, startRow + i);
            Console.Write("│");
	}

	Console.SetCursorPosition(startCol, startRow + height - 1);
        Console.Write("└".PadRight(width - 1, '─') + "┘");
    }

    private static void RenderPanelText(int startCol, int startRow, string text)
    {
	var lines = text.Split('\n');

	for (int i = 0; i < lines.Length; i++)
	{
	    Console.SetCursorPosition(startCol, startRow + i);
	    Console.Write(lines[i]);
	}
    }
}
