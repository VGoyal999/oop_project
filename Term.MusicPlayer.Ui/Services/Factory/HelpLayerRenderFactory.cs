namespace Term.MusicPlayer.Ui.Services.Factory;

internal class HelpLayerRenderFactory : LayerRenderFactory
{
    public override IViewLayer CreateLayer()
    {
	return new HelpOverlayLayer();
    }
}
