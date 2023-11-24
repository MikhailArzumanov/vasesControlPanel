using vaseApi.Models;

namespace vaseApi.Data {
    public class DbInitializer {
        private static Color AddColor(ApplicationContext db, string name, string commentary, string hex) {
            var color = new Color { Name = name, Commentary = commentary, HexRepresentation = hex };
            db.Colors.Add(color);
            db.SaveChanges();
            return color;
        }
        private static Genus AddGenus(ApplicationContext db, string name, string description, string html, string md) {
            var genus = new Genus { Name = name, Description = description, HtmlMarkup = html, MarkdownText = md };
            db.Genuses.Add(genus);
            db.SaveChanges();
            return genus;
        }
        private static Vase AddVase(ApplicationContext db, string name, string commentary, Color mainColor, Color sideColor,
            Genus flowerGenus, Condition vaseCondition, double weight) {
            var vase = new Vase {
                Name          = name          ,
                Commentary    = commentary    ,
                MainColorId   = mainColor.Id  ,
                SideColorId   = sideColor.Id  ,
                FlowerGenusId = flowerGenus.Id,
                VaseCondition = vaseCondition ,
                VaseWeight    = weight        ,
                Autowatering         = false  ,
                WateringIntensity    = 0      ,  
                Autofertilizeing     = false  ,
                FertilizingIntensity = 0      ,
                IsLightingToggled    = false  ,
                LightingIntensity    = 0      ,
                GlassOpacity         = 0      ,
                WateredLevel    = 0,
                FertilizedLevel = 0,
                LightingLevel   = 0,
            };
            db.Vases.Add(vase);
            db.SaveChanges();
            return vase;
        }

        private static Vase SetParameters(ApplicationContext db, Vase vase, bool autowatering, double wateringIntensity, 
            bool autofertilizing, double fertilizingIntensity, bool isLightingToggled, double lightingIntensity, 
            double glassOpacity) {
            vase.Autowatering           = autowatering;
            vase.WateringIntensity      = wateringIntensity;
            vase.Autofertilizeing       = autofertilizing;
            vase.FertilizingIntensity   = fertilizingIntensity;
            vase.IsLightingToggled      = isLightingToggled;
            vase.LightingIntensity      = lightingIntensity;
            vase.GlassOpacity           = glassOpacity;
            db.Vases.Update(vase);
            db.SaveChanges();
            return vase;
        }

        public static void Initialize(ApplicationContext context) {
            var mainColor = AddColor(context, "Красный", "...", "#dd7070");
            var sideColor = AddColor(context, "Зелёный", "...", "#70dd70");
            var poppyGenus = AddGenus(context, "Маки", "...", "<h1>...</h1>", "## ...");
            var vase = AddVase(context, "Пример горшка", "...", mainColor, 
                               sideColor, poppyGenus, Condition.Perfect, 3.4);
            SetParameters(context, vase, true, .34, true, .48, true, .1138, .40);
        }
    }
}
