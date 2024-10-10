using System.Resources;

namespace FoodLog.Resources.Localization
{
    public static class Strings

    {
        public static string AddData => "Add Data";
        public static string BackButton => "Back";
        public static string Calories => "Calories";
        public static string Chart => "Chart";
        public static string ChartHeader => "Food Consumption Chart";
        public static string ChartName => "Chart Name";
        public static string Data => "Data";
        public static string Day => "Day";
        public static string Food => "Food";
        public static string FoodItemName => "Food Item Name";
        public static string GraphTitle => "Food Graph";
        public static string Import => "Import";
        public static string Year => "Year";
        public static string LoadData => "Load Data";
        public static string Month => "Month";
        public static string Name => "Name";
        public static string Protein => "Protein";
        public static string Save => "Save";
        public static string Table => "Table";


        #region Resource Manager
        private static readonly ResourceManager resourceManager = new ResourceManager("FoodLog/Resources.Localization.Strings", typeof(Strings).Assembly);
        //FIX: Implement correct resx handling
        // private static readonly ResourceManager resourceManager = new ResourceManager("Resources.Localization.Strings", typeof(Strings).Assembly);
        // private static readonly ResourceManager resourceManager = new ResourceManager("FoodLog.Resources.Localization.Strings", typeof(Strings).Assembly);
        #endregion
    }

}
