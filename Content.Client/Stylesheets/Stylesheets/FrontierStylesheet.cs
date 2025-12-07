using System.Linq;
using Content.Client.Stylesheets.Fonts;
using Robust.Client.ResourceManagement;
using Robust.Client.UserInterface;
using Robust.Client.UserInterface.Controls;
using Robust.Shared.Utility;
using static Robust.Client.UserInterface.StylesheetHelpers;

namespace Content.Client.Stylesheets.Stylesheets;

[Virtual]
public partial class FrontierStylesheet : CommonStylesheet
{
    public override string StylesheetName => "Frontier";

    public override NotoFontFamilyStack BaseFont { get; }

    public static readonly ResPath TextureRoot = new("/Textures/Interface/Nano");

    public override Dictionary<Type, ResPath[]> Roots => new()
    {
        { typeof(TextureResource), [TextureRoot] },
    };

    private const int PrimaryFontSize = 13;
    private const int FontSizeStep = 2;

    private readonly List<(string?, int)> _commonFontSizes = new()
    {
        (null, PrimaryFontSize),
        (StyleClass.FontSmall, PrimaryFontSize - FontSizeStep),
        (StyleClass.FontLarge, PrimaryFontSize + FontSizeStep),
    };

    public FrontierStylesheet(object config, StylesheetManager man) : base(config)
    {
        BaseFont = new NotoFontFamilyStack(ResCache);
        var rules = new[]
        {
            GetRulesForFont(null, BaseFont, _commonFontSizes),
            [
                Element().Prop(Label.StylePropertyFont, BaseFont.GetFont(PrimaryFontSize)),
            ],
            GetAllSheetletRules<PalettedStylesheet, CommonSheetletAttribute>(man),
            GetAllSheetletRules<FrontierStylesheet, CommonSheetletAttribute>(man),
        };

        Stylesheet = new Stylesheet(rules.SelectMany(x => x).ToArray());
    }
}
