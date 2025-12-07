using Content.Client.Stylesheets.Palette;

namespace Content.Client.Stylesheets.Stylesheets;

public sealed partial class FrontierStylesheet
{
    public override ColorPalette PrimaryPalette => Palettes.Cobalt;
    public override ColorPalette SecondaryPalette => Palettes.Steel;
    public override ColorPalette PositivePalette => Palettes.Green;
    public override ColorPalette NegativePalette => Palettes.Red;
    public override ColorPalette HighlightPalette => Palettes.Amber;
}
