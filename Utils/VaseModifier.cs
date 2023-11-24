using vaseApi.Data;
using vaseApi.Models;

namespace vaseApi.Utils {
    public class VaseModifier {
        private static StatProcess lightingGenerator = new StatProcess();
        private static void Modify(Vase vase) {
            var newWateredLevel = vase.WateredLevel + Sequences.GetNormalDist(0, 4);
            newWateredLevel = Math.Abs(newWateredLevel);
            vase.WateredLevel = newWateredLevel;

            var newFertilizedLevel = vase.FertilizedLevel + Sequences.GetNormalDist(0, 3);
            newFertilizedLevel = Math.Abs(newFertilizedLevel);
            vase.FertilizedLevel = newFertilizedLevel;

            var newLightingLevel = lightingGenerator.getNext();
            newLightingLevel = Math.Abs(newLightingLevel);
            vase.LightingLevel = newLightingLevel;
        }
        public static void Iterate(ApplicationContext db) {
            foreach(var vase in db.Vases) {
                Modify(vase);
                db.Vases.Update(vase);
            }
            db.SaveChanges();
        }
    }
}
