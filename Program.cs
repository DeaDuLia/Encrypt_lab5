namespace lab_5
{
    class Program
    {
        static void Main(string[] args)
        {
            Frequency f;
            f = new Frequency("task1eng.txt", "engFreq1.txt");
            Console.WriteLine(f.Decrypt());
            Console.ReadLine();
        }
    }
}