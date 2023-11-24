namespace vaseApi.Utils {
    public class StatProcess {
        private static double[] C = new double[] { 0.403, 0.301, 0.539, 0.676 };
        private const  double M = 5;
        private const  int m = 3;

        private List<double> Q = new List<double>();

        private Func<double> nextQ = () => Sequences.GetNormalDist(0, 1);

        public StatProcess() {
            for (int i = 0; i < m; i++) {
                double qi = nextQ();
                Q.Add(qi);
            }
        }

        public double getNext() {
            double res = 0; int j = 0;
            foreach(var q in Q) {
                res += q*C[j];
                j++;
            }
            double qi = nextQ();
            Q.RemoveAt(0); Q.Add(qi);
            return res + M;
        }
    }
}
