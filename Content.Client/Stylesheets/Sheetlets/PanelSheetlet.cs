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
        };
        var boxDark = new StyleBoxFlat()
        {
            BackgroundColor = sheet.SecondaryPalette.BackgroundDark,
        };
        var boxPositive = new StyleBoxFlat { BackgroundColor = sheet.PositivePalette.Background };
        var boxNegative = new StyleBoxFlat { BackgroundColor = sheet.NegativePalette.Background };
        var boxHighlight = new StyleBoxFlat { BackgroundColor = sheet.HighlightPalette.Background };

        var section = new StyleBoxFlat
        {
            BackgroundColor = sheet.SecondaryPalette.Background,
            BorderColor = sheet.PrimaryPalette.BackgroundDark,
            BorderThickness = new Thickness(1f),
        };
        section.SetContentMarginOverride(StyleBox.Margin.All, 8);

        var sectionDim = new StyleBoxFlat
        {
            BackgroundColor = sheet.SecondaryPalette.BackgroundDark,
            BorderColor = sheet.PrimaryPalette.BackgroundDark,
            BorderThickness = new Thickness(1f),
        };
        sectionDim.SetContentMarginOverride(StyleBox.Margin.All, 6);

        var sectionEmphasis = new StyleBoxFlat
        {
            BackgroundColor = sheet.PositivePalette.Background,
            BorderColor = sheet.PositivePalette.PressedElement,
            BorderThickness = new Thickness(1f),
        };
        sectionEmphasis.SetContentMarginOverride(StyleBox.Margin.All, 8);

        var glassPanel = new StyleBoxFlat
        {
            BackgroundColor = sheet.SecondaryPalette.Background.WithAlpha(0.78f),
            BorderColor = sheet.HighlightPalette.HoveredElement,
            BorderThickness = new Thickness(1.5f),
        };
        glassPanel.SetContentMarginOverride(StyleBox.Margin.All, 10);

        var neonFrame = new StyleBoxFlat
        {
            BackgroundColor = sheet.SecondaryPalette.BackgroundDark.WithAlpha(0.72f),
            BorderColor = sheet.HighlightPalette.Text,
            BorderThickness = new Thickness(2f),
        };
        neonFrame.SetContentMarginOverride(StyleBox.Margin.All, 12);

        var glowHeader = new StyleBoxFlat
        {
            BackgroundColor = sheet.PrimaryPalette.BackgroundLight.WithAlpha(0.72f),
            BorderColor = sheet.HighlightPalette.Text,
            BorderThickness = new Thickness(1.5f),
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
