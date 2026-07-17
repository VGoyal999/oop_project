namespace Term.MusicPlayer.Ui.Services.Builder;

public interface IUiBuilder
{
    IUiBuilder AddSidebar(string title, int widthPercent);
    IUiBuilder AddMainPanel(string title);
    IUiBuilder AddStatusLine(string currentMode, string statusText);
    void Build();
}
