namespace Term.MusicPlayer.Ui.Services.Factory;

internal class SearchOverlayLayer : IViewLayer
{
    public string LayerName  => "Telescope Finder";

    public void OverlayRender(int startRow, int startCol, int width, int height)
    {
        // Set up a floating window color scheme (ANSI Dark Grey background)
        Console.Write("\x1b[48;5;235m");
            
        // Draw the inner overlay box
        for (int i = 0; i < height; i++)
        {
            Console.SetCursorPosition(startCol, startRow + i);
            if (i == 0)
                Console.Write("┌── 🔍 Find Track (Type to filter) ──┐".PadRight(width - 1) + "│");
            else if (i == 2)
                Console.Write("├──  lofi_coding_mix.mp3            ─┤".PadRight(width - 1) + "│");
            else if (i == 3)
                Console.Write("│    synthwave_1984.wav              │".PadRight(width - 1) + "│");
            else
                Console.Write("│".PadRight(width - 1) + "│");
        }
        Console.Write("\x1b[0m"); // Reset colors    
    }
}
