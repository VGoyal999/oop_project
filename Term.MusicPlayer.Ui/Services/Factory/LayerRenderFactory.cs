namespace Term.MusicPlayer.Ui.Services.Factory;

public abstract class LayerRenderFactory
{
    public abstract IViewLayer CreateLayer();

    public void DrawLayerToScreen(int row, int col, int width, int height)
    {
	var layer = CreateLayer();
	layer.OverlayRender(row, col, width, height);
    }
}
