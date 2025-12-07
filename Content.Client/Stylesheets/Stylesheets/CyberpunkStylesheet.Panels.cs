using Content.Client.Stylesheets.SheetletConfigs;
using Robust.Shared.Utility;

namespace Content.Client.Stylesheets.Stylesheets;

public sealed partial class CyberpunkStylesheet : IWindowConfig, IPanelConfig
{
    ResPath IWindowConfig.WindowHeaderTexturePath => new("panel_header_cyber.svg");
    ResPath IWindowConfig.WindowHeaderAlertTexturePath => new("panel_header_cyber.svg");
    ResPath IWindowConfig.WindowBackgroundPath => new("panel_background_cyber.svg");
    ResPath IWindowConfig.WindowBackgroundBorderedPath => new("panel_background_bordered_cyber.svg");
    ResPath IWindowConfig.TransparentWindowBackgroundBorderedPath => new("panel_background_glass_cyber.svg");

    ResPath IPanelConfig.GeometricPanelBorderPath => new("panel_border_neon_cyber.svg");
    ResPath IPanelConfig.BlackPanelDarkThinBorderPath => new("panel_background_cyber.svg");
}
