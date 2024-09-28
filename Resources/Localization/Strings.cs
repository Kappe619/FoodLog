using System.Globalization;
using System.Resources;

namespace FoodLog.Resources.Localization
{
    public static class Strings

    {

        public static string FoodItemName => "Food Item Name";
        public static string Calories => "Calories";
        public static string Protein => "Protein";


        public static string? testString = "test the resource";
        private static readonly ResourceManager resourceManager = new ResourceManager("FoodLog/Resources.Localization.Strings", typeof(Strings).Assembly);
        #region Resource Manager

        public static string TableLabelText => "this is the table label";

        //FIX: Implement correct resx handling
        // private static readonly ResourceManager resourceManager = new ResourceManager("Resources.Localization.Strings", typeof(Strings).Assembly);
        // private static readonly ResourceManager resourceManager = new ResourceManager("FoodLog.Resources.Localization.Strings", typeof(Strings).Assembly);
        public static string TestText => "test text";
        // public static string? MyText => resourceManager.GetString("MyText", CultureInfo.CurrentUICulture);
        // public static string MyButtonText2 => resourceManager.GetString("MyButtonText", new CultureInfo("de-DE"));
        #endregion
    }

}
