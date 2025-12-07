using Content.Client.Stylesheets.Palette;
using Robust.Shared.Maths;

namespace Content.Client.Stylesheets;

public static class UiTheme
{
    public static Color Button => Palettes.NeonViolet.Element;
    public static Color ButtonHover => Palettes.NeonViolet.HoveredElement;
    public static Color ButtonPressed => Palettes.NeonViolet.PressedElement;
    public static Color ButtonDisabled => Palettes.NeonViolet.DisabledElement;

    public static Color DisabledForeground => Palettes.Nightfall.DisabledElement;
    public static Color NeutralForeground => Palettes.Nightfall.Text;
    public static Color Accent => Palettes.ElectricBlue.Text;
    public static Color NeonGlow => Palettes.ElectricBlue.HoveredElement;
    public static Color Danger => Palettes.Magenta.Text;
    public static Color Warning => Palettes.Amber.Text;
    public static Color Success => Palettes.Green.Text;

    public static Color Panel => Palettes.Nightfall.Background;
    public static Color PanelDark => Palettes.Nightfall.BackgroundDark;
    public static Color PanelLight => Palettes.Nightfall.BackgroundLight;
    public static Color PanelHighlight => Palettes.NeonViolet.BackgroundLight;
}
