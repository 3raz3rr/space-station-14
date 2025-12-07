using Content.Client.Stylesheets.Palette;
using Robust.Shared.Maths;

namespace Content.Client.Stylesheets;

public static class UiTheme
{
    public static Color Button => Palettes.Cobalt.Element;
    public static Color ButtonHover => Palettes.Cobalt.HoveredElement;
    public static Color ButtonPressed => Palettes.Cobalt.PressedElement;
    public static Color ButtonDisabled => Palettes.Cobalt.DisabledElement;

    public static Color DisabledForeground => Palettes.Steel.DisabledElement;
    public static Color NeutralForeground => Palettes.Steel.Text;
    public static Color Accent => Palettes.Amber.Text;
    public static Color Danger => Palettes.Red.Text;
    public static Color Warning => Palettes.Amber.Text;
    public static Color Success => Palettes.Green.Text;

    public static Color Panel => Palettes.Steel.Background;
    public static Color PanelDark => Palettes.Steel.BackgroundDark;
    public static Color PanelLight => Palettes.Steel.BackgroundLight;
}
