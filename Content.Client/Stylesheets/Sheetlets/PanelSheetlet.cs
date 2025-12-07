using Content.Client.Stylesheets.SheetletConfigs;
using Content.Client.Stylesheets.Stylesheets;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Content.Client.Stylesheets.StylesheetHelpers;

namespace Content.Client.Stylesheets.Sheetlets;

[CommonSheetlet]
public sealed class PanelSheetlet<T> : Sheetlet<T>
    where T : PalettedStylesheet, IButtonConfig, IWindowConfig, IPanelConfig
{
    public override StyleRule[] GetRules(T sheet, object config)
    {
        IWindowConfig windowCfg = sheet;
        IPanelConfig panelCfg = sheet;

        var chromeTex = sheet.GetTextureOr(windowCfg.WindowBackgroundBorderedPath, NanotrasenStylesheet.TextureRoot);
        var chromeGlassTex = sheet.GetTextureOr(windowCfg.TransparentWindowBackgroundBorderedPath, NanotrasenStylesheet.TextureRoot);
        var neonBorderTex = sheet.GetTextureOr(panelCfg.GeometricPanelBorderPath, NanotrasenStylesheet.TextureRoot);
        var flatTex = sheet.GetTextureOr(windowCfg.WindowBackgroundPath, NanotrasenStylesheet.TextureRoot);

        StyleBoxTexture PanelFrom(Texture texture, Color modulate, float margin, float? contentMargin = null)
        {
            var box = new StyleBoxTexture
            {
                Texture = texture,
                Modulate = modulate,
            };
            box.SetPatchMargin(StyleBox.Margin.All, margin);
            if (contentMargin is { } content)
                box.SetContentMarginOverride(StyleBox.Margin.All, content);
            return box;
        }

        var boxLight = PanelFrom(chromeTex, sheet.SecondaryPalette.BackgroundLight.WithAlpha(0.9f), 2, 10);
        var boxDark = PanelFrom(chromeTex, sheet.SecondaryPalette.BackgroundDark.WithAlpha(0.95f), 2, 10);
        var boxPositive = PanelFrom(chromeTex, sheet.PositivePalette.Background, 2, 10);
        var boxNegative = PanelFrom(chromeTex, sheet.NegativePalette.Background, 2, 10);
        var boxHighlight = PanelFrom(chromeTex, sheet.HighlightPalette.Background, 2, 10);

        var section = PanelFrom(flatTex, sheet.SecondaryPalette.Background, 1, 8);
        section.SetContentMarginOverride(StyleBox.Margin.All, 8);
        var sectionDim = PanelFrom(flatTex, sheet.SecondaryPalette.BackgroundDark, 1, 6);
        var sectionEmphasis = PanelFrom(flatTex, sheet.PositivePalette.Background, 1, 8);

        var glassPanel = PanelFrom(chromeGlassTex, sheet.SecondaryPalette.Background.WithAlpha(0.8f), 2, 10);
        glassPanel.Modulate = sheet.SecondaryPalette.BackgroundLight.WithAlpha(0.82f);
        glassPanel.SetPatchMargin(StyleBox.Margin.All, 3);

        var neonFrame = PanelFrom(neonBorderTex, sheet.HighlightPalette.Text.WithAlpha(0.9f), 4, 12);
        neonFrame.SetPadding(StyleBox.Margin.All, 2);

        var glowHeader = PanelFrom(chromeGlassTex, sheet.PrimaryPalette.BackgroundLight.WithAlpha(0.78f), 2, 10);
        glowHeader.SetPatchMargin(StyleBox.Margin.All, 3);

        return
        [
            E<PanelContainer>().Class(StyleClass.PanelLight).Panel(boxLight),
            E<PanelContainer>().Class(StyleClass.PanelDark).Panel(boxDark),

            E<PanelContainer>().Class(StyleClass.Positive).Panel(boxPositive),
            E<PanelContainer>().Class(StyleClass.Negative).Panel(boxNegative),
            E<PanelContainer>().Class(StyleClass.Highlight).Panel(boxHighlight),

            E<PanelContainer>().Class(StyleClass.Section).Panel(section),
            E<PanelContainer>().Class(StyleClass.SectionDim).Panel(sectionDim),
            E<PanelContainer>().Class(StyleClass.SectionEmphasis).Panel(sectionEmphasis),
            E<PanelContainer>().Class(StyleClass.ChatPanel).Panel(section),
            E<PanelContainer>().Class(StyleClass.ChatSubPanel).Panel(sectionDim),
            E<PanelContainer>().Class(StyleClass.GlassPanel).Panel(glassPanel),
            E<PanelContainer>().Class(StyleClass.NeonFrame).Panel(neonFrame),
            E<PanelContainer>().Class(StyleClass.GlowHeader).Panel(glowHeader),

            // TODO: this should probably be cleaned up but too many UIs rely on this hardcoded color so I'm scared to touch it
            E<PanelContainer>()
                .Class("BackgroundDark")
                .Prop(PanelContainer.StylePropertyPanel, new StyleBoxFlat(Color.FromHex("#25252A"))),

            // panels that have the same corner bezels as buttons
            E()
                .Class(StyleClass.BackgroundPanel)
                .Prop(PanelContainer.StylePropertyPanel, StyleBoxHelpers.BaseStyleBox(sheet))
                .Modulate(sheet.SecondaryPalette.Background),
            E()
                .Class(StyleClass.BackgroundPanelOpenLeft)
                .Prop(PanelContainer.StylePropertyPanel, StyleBoxHelpers.OpenLeftStyleBox(sheet))
                .Modulate(sheet.SecondaryPalette.Background),
            E()
                .Class(StyleClass.BackgroundPanelOpenRight)
                .Prop(PanelContainer.StylePropertyPanel, StyleBoxHelpers.OpenRightStyleBox(sheet))
                .Modulate(sheet.SecondaryPalette.Background),
        ];
    }
}
