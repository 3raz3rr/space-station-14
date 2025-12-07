using Content.Client.Stylesheets.SheetletConfigs;
using Robust.Shared.Utility;

namespace Content.Client.Stylesheets.Stylesheets;

public sealed partial class CyberpunkStylesheet : IButtonConfig
{
    ResPath IButtonConfig.BaseButtonPath => new("Radial/button_normal_cyber.svg");
    ResPath IButtonConfig.OpenLeftButtonPath => new("Radial/button_normal_cyber.svg");
    ResPath IButtonConfig.OpenRightButtonPath => new("Radial/button_normal_cyber.svg");
    ResPath IButtonConfig.OpenBothButtonPath => new("Radial/button_normal_cyber.svg");
    ResPath IButtonConfig.SmallButtonPath => new("Radial/button_normal_cyber.svg");
    ResPath IButtonConfig.RoundedButtonPath => new("Radial/button_normal_cyber.svg");
    ResPath IButtonConfig.RoundedButtonBorderedPath => new("Radial/button_hover_cyber.svg");

    ResPath IButtonConfig.MonotoneBaseButtonPath => new("Radial/button_normal_cyber.svg");
    ResPath IButtonConfig.MonotoneOpenLeftButtonPath => new("Radial/button_normal_cyber.svg");
    ResPath IButtonConfig.MonotoneOpenRightButtonPath => new("Radial/button_normal_cyber.svg");
    ResPath IButtonConfig.MonotoneOpenBothButtonPath => new("Radial/button_normal_cyber.svg");
}
