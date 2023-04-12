namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] arr = new string[40];
            string path = "результаты соревнований.txt";
            arr = File.ReadAllLines(path);
            string[] sep = new string[6];
            string[] time = new string[2];
            Turniki[] A = new Turniki[arr.Length / 2];
            int j = 0;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    A[j].Name = arr[i];
                    A[j].Results = arr[i + 1];
                    i++;
                }
                j++;
            }
            Turniki2[] B = new Turniki2[arr.Length / 2];
            for (int i = 0; i < arr.Length / 2; i++)
            {
                sep = A[i].Results.Split(' ');
                B[i].Name = A[i].Name;
                int am = 0;
                int tm = 0;
                for (int k = 0; k < sep.Length; k++)
                {
                    if (k % 2 == 0)
                    {
                        am += Convert.ToInt32(sep[k]);
                    }
                    else
                    {
                        time = sep[k].Split(':');
                        tm += Convert.ToInt32(time[0]) * 60 + Convert.ToInt32(time[1]);
                    }
                }
                B[i].Amount = am;
                B[i].Time = tm;

            }

            foreach (Turniki2 b in B)
            {
                Console.WriteLine("Name: " + b.Name + " amount: " + b.Amount + " time: " + b.Time);
            }

            int mint = B[0].Time;
            int maxa;
            int o = 0;
            string path2 = "Отсортированный список.txt";
            int[] arrex = new int[20];

            for (int i = 0; i < A.Length; i++)
            {
                maxa = 0;
                for (int p = 0; p < B.Length; p++)
                {

                    if (Array.IndexOf(arrex, p) == -1)
                    {
                        if (B[p].Amount > maxa)
                        {
                            maxa = B[p].Amount;
                            mint = B[p].Time;
                            o = p;
                        }
                        else if (B[p].Amount == maxa)
                        {
                            if (B[p].Time < mint)
                            {
                                maxa = B[p].Amount;
                                mint = B[p].Time;
                                o = p;
                            }
                        }
                    }
                }
                arrex[i] = o;
                File.AppendAllText(path2, "" + B[o].Name);
                File.AppendAllText(path2, " " + Convert.ToString(B[o].Amount));
                File.AppendAllText(path2, " " + Convert.ToString($"{B[o].Time / 60}:{B[o].Time % 60}\n"));
            }
        }
    }

    public struct Turniki
    {
        public string Name;
        public string Results;
        public Turniki(string n, string r)
        {
            Name = n;
            Results = r;
        }
    }
    public struct Turniki2
    {
        public string Name;
        public int Amount;
        public int Time;
    }
}