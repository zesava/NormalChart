namespace NormalChart
{
    public class Curve
    {
        public int LogId { get; set; }
        public string Descr { get; set; }

        public override string ToString()
        {
            return "[" + LogId.ToString().PadLeft(3, '0') + "] " + Descr;
        }
    }
}
