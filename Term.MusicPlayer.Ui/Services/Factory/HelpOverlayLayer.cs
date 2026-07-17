namespace Term.MusicPlayer.Ui.Services.Factory;

internal class HelpOverlayLayer : IViewLayer
{
    public string LayerName => "Keymaps Help";

    public void OverlayRender(int startRow, int startCol, int width, int height)
    {
        Console.Write("\x1b[48;5;238m"); // Medium grey highlight
        for (int i = 0; i < height; i++)
        {
           Console.SetCursorPosition(startCol, startRow + i);
            if (i == 0)
                Console.Write("┌── ⌨️ Shortcuts ───────────────────┐".PadRight(width - 1) + "│");
            else if (i == 2)
                Console.Write("│   <Space>sf  -> Search Tracks     │".PadRight(width - 1) + "│");
            else if (i == 3)
                Console.Write("│   <Space>sk  -> Show Keymaps      │".PadRight(width - 1) + "│");
            else
                Console.Write("│".PadRight(width - 1) + "│");
        }
        Console.Write("\x1b[0m");
    }
}
