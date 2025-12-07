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

        var textureRoot = StyleBoxHelpers.GetTextureRoot(sheet);

        var chromeTex = sheet.GetTextureOr(windowCfg.WindowBackgroundBorderedPath, textureRoot);
        var chromeGlassTex = sheet.GetTextureOr(windowCfg.TransparentWindowBackgroundBorderedPath, textureRoot);
        var neonBorderTex = sheet.GetTextureOr(panelCfg.GeometricPanelBorderPath, textureRoot);
        var flatTex = sheet.GetTextureOr(windowCfg.WindowBackgroundPath, textureRoot);

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

        var boxLight = PanelFrom(chromeTex, sheet.SecondaryPalette.BackgroundLight, 12, 14);
        var boxDark = PanelFrom(chromeTex, sheet.SecondaryPalette.BackgroundDark, 12, 14);
        var boxPositive = PanelFrom(chromeTex, sheet.PositivePalette.Background, 12, 14);
        var boxNegative = PanelFrom(chromeTex, sheet.NegativePalette.Background, 12, 14);
        var boxHighlight = PanelFrom(chromeTex, sheet.HighlightPalette.Background, 12, 14);

        var section = PanelFrom(flatTex, sheet.SecondaryPalette.BackgroundLight, 12, 12);
        section.SetContentMarginOverride(StyleBox.Margin.All, 10);
        var sectionDim = PanelFrom(flatTex, sheet.SecondaryPalette.BackgroundDark, 12, 10);
        var sectionEmphasis = PanelFrom(flatTex, sheet.PositivePalette.Background.WithAlpha(0.92f), 12, 12);

        var glassPanel = PanelFrom(chromeGlassTex, sheet.SecondaryPalette.BackgroundLight.WithAlpha(0.95f), 12, 14);
        glassPanel.SetPatchMargin(StyleBox.Margin.All, 14);

        var neonFrame = PanelFrom(neonBorderTex, sheet.HighlightPalette.Text.WithAlpha(0.95f), 18, 14);
        neonFrame.SetPadding(StyleBox.Margin.All, 4);

        var glowHeader = PanelFrom(chromeGlassTex, sheet.PrimaryPalette.BackgroundLight, 14, 14);
        glowHeader.SetPatchMargin(StyleBox.Margin.All, 14);

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
