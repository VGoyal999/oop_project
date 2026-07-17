namespace Term.MusicPlayer.Ui.Services.Factory;

public interface IViewLayer
{
    string LayerName { get; }
    void OverlayRender(int startRow, int startCol, int width, int height);
}
