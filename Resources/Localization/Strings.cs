using System.Globalization;
using System.Resources;

public static class Strings

{



    public static string? testString = "test the resource";
    private static readonly ResourceManager resourceManager = new ResourceManager("FoodLog/Resources.Localization.Strings", typeof(Strings).Assembly);
    #region Resource Manager
    //FIX: Implement correct resx handling
    // private static readonly ResourceManager resourceManager = new ResourceManager("Resources.Localization.Strings", typeof(Strings).Assembly);
    // private static readonly ResourceManager resourceManager = new ResourceManager("FoodLog.Resources.Localization.Strings", typeof(Strings).Assembly);
public static string TestText => "test text";
    // public static string? MyText => resourceManager.GetString("MyText", CultureInfo.CurrentUICulture);
    // public static string MyButtonText2 => resourceManager.GetString("MyButtonText", new CultureInfo("de-DE"));
    #endregion
}

