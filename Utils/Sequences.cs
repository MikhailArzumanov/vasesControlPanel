namespace vaseApi.Utils {
    public class Sequences {
        private static Random mainRng = new Random();
        private static Random sideRng = new Random(DateTime.Now.Millisecond + 1000);

        private static double pi = Math.PI;
        private static Func<double, double> cos = Math.Cos;
        private static Func<double, double> sqrt = Math.Sqrt;
        private static Func<double, double> ln = Math.Log;

        public static double GetNormalDist(double m, double sigm) {
            double x = mainRng.NextDouble();
            double x_ = sideRng.NextDouble();

            double sigmCos = sigm * cos(2 * pi * x);
            double root = sqrt(-2 * ln(x_));

            double y = sigmCos * root + m;

            return y;
        }
        public static double GetExpDist(double l) {
            double x = mainRng.NextDouble();
            double y = (-1 / l) * ln(x);
            return y;
        }
    }
}
