using System.Numerics;
using Content.Client.Stylesheets.SheetletConfigs;
using Robust.Client.Graphics;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using static Content.Client.Stylesheets.StylesheetHelpers;

namespace Content.Client.Stylesheets.Sheetlets;

[CommonSheetlet]
public sealed class PanelSheetlet<T> : Sheetlet<T> where T : PalettedStylesheet, IButtonConfig
{
    public override StyleRule[] GetRules(T sheet, object config)
    {
        IButtonConfig buttonCfg = sheet;

        var boxLight = new StyleBoxFlat()
        {
            BackgroundColor = sheet.SecondaryPalette.BackgroundLight,
            CornerRadius = new Vector4(6f),
            ShadowColor = sheet.HighlightPalette.Element.WithAlpha(0.2f),
            ShadowSoftness = 6f,
        };
        var boxDark = new StyleBoxFlat()
        {
            BackgroundColor = sheet.SecondaryPalette.BackgroundDark,
            CornerRadius = new Vector4(6f),
        };
        var boxPositive = new StyleBoxFlat { BackgroundColor = sheet.PositivePalette.Background, CornerRadius = new Vector4(6f) };
        var boxNegative = new StyleBoxFlat { BackgroundColor = sheet.NegativePalette.Background, CornerRadius = new Vector4(6f) };
        var boxHighlight = new StyleBoxFlat { BackgroundColor = sheet.HighlightPalette.Background, CornerRadius = new Vector4(6f) };

        var section = new StyleBoxFlat
        {
            BackgroundColor = sheet.SecondaryPalette.Background,
            BorderColor = sheet.PrimaryPalette.BackgroundDark,
            BorderThickness = new Thickness(1f),
            ShadowColor = sheet.HighlightPalette.Element.WithAlpha(0.22f),
            ShadowSoftness = 8f,
            CornerRadius = new Vector4(8f),
        };
        section.SetContentMarginOverride(StyleBox.Margin.All, 8);

        var sectionDim = new StyleBoxFlat
        {
            BackgroundColor = sheet.SecondaryPalette.BackgroundDark,
            BorderColor = sheet.PrimaryPalette.BackgroundDark,
            BorderThickness = new Thickness(1f),
            CornerRadius = new Vector4(8f),
        };
        sectionDim.SetContentMarginOverride(StyleBox.Margin.All, 6);

        var sectionEmphasis = new StyleBoxFlat
        {
            BackgroundColor = sheet.PositivePalette.Background,
            BorderColor = sheet.PositivePalette.PressedElement,
            BorderThickness = new Thickness(1f),
            CornerRadius = new Vector4(8f),
        };
        sectionEmphasis.SetContentMarginOverride(StyleBox.Margin.All, 8);

        var glassPanel = new StyleBoxFlat
        {
            BackgroundColor = sheet.SecondaryPalette.Background.WithAlpha(0.78f),
            BorderColor = sheet.HighlightPalette.HoveredElement,
            BorderThickness = new Thickness(1.5f),
            ShadowColor = sheet.HighlightPalette.Element.WithAlpha(0.35f),
            ShadowOffset = new Vector2(0f, 2f),
            ShadowSoftness = 10f,
            CornerRadius = new Vector4(10f),
        };
        glassPanel.SetContentMarginOverride(StyleBox.Margin.All, 10);

        var neonFrame = new StyleBoxFlat
        {
            BackgroundColor = sheet.SecondaryPalette.BackgroundDark.WithAlpha(0.72f),
            BorderColor = sheet.HighlightPalette.Text,
            BorderThickness = new Thickness(2f),
            ShadowColor = sheet.HighlightPalette.HoveredElement.WithAlpha(0.25f),
            ShadowSoftness = 12f,
            CornerRadius = new Vector4(12f, 12f, 6f, 6f),
        };
        neonFrame.SetContentMarginOverride(StyleBox.Margin.All, 12);

        var glowHeader = new StyleBoxFlat
        {
            BackgroundColor = sheet.PrimaryPalette.BackgroundLight.WithAlpha(0.72f),
            BorderColor = sheet.HighlightPalette.Text,
            BorderThickness = new Thickness(1.5f),
            ShadowColor = sheet.HighlightPalette.Element.WithAlpha(0.32f),
            ShadowSoftness = 10f,
            CornerRadius = new Vector4(10f, 10f, 6f, 6f),
        };
        glowHeader.SetContentMarginOverride(StyleBox.Margin.All, 10);

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
