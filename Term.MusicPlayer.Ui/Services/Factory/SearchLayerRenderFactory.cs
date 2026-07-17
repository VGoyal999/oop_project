namespace Term.MusicPlayer.Ui.Services.Factory;

internal class SearchLayerRenderFactory : LayerRenderFactory
{
    public override IViewLayer CreateLayer()
    {
        return new SearchOverlayLayer();
    }
}
