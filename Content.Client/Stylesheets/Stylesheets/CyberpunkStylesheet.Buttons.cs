using Content.Client.Stylesheets.SheetletConfigs;
using Robust.Shared.Utility;

namespace Content.Client.Stylesheets.Stylesheets;

public sealed partial class CyberpunkStylesheet : IButtonConfig
{
    ResPath IButtonConfig.BaseButtonPath => new("Radial/button_normal.png");
    ResPath IButtonConfig.OpenLeftButtonPath => new("Radial/button_normal.png");
    ResPath IButtonConfig.OpenRightButtonPath => new("Radial/button_normal.png");
    ResPath IButtonConfig.OpenBothButtonPath => new("Radial/button_normal.png");
    ResPath IButtonConfig.SmallButtonPath => new("Radial/button_normal.png");
    ResPath IButtonConfig.RoundedButtonPath => new("Radial/button_normal.png");
    ResPath IButtonConfig.RoundedButtonBorderedPath => new("Radial/button_normal.png");

    ResPath IButtonConfig.MonotoneBaseButtonPath => new("Radial/button_normal.png");
    ResPath IButtonConfig.MonotoneOpenLeftButtonPath => new("Radial/button_normal.png");
    ResPath IButtonConfig.MonotoneOpenRightButtonPath => new("Radial/button_normal.png");
    ResPath IButtonConfig.MonotoneOpenBothButtonPath => new("Radial/button_normal.png");
}
