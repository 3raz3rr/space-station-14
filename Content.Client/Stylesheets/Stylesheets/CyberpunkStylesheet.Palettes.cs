using Content.Client.Stylesheets.Palette;

namespace Content.Client.Stylesheets.Stylesheets;

public sealed partial class CyberpunkStylesheet
{
    public override ColorPalette PrimaryPalette => Palettes.NeonViolet;
    public override ColorPalette SecondaryPalette => Palettes.Nightfall;
    public override ColorPalette PositivePalette => Palettes.ElectricBlue;
    public override ColorPalette NegativePalette => Palettes.Magenta with { Element = Palettes.Red.Element };
    public override ColorPalette HighlightPalette => Palettes.ElectricBlue;
}
