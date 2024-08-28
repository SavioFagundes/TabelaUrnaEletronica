namespace TabelaUrnaEletronica
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path:");
            string path = Console.ReadLine();
            try
            {
                Dictionary<string, int> dict = new Dictionary<string, int>();

                using (StreamReader sr = File.OpenText(path))
                {
                    while(!sr.EndOfStream)
                    {
                        string[] votingRecord = sr.ReadLine().Split(',');
                        string candidate = votingRecord[0];
                        int votes = int.Parse(votingRecord[1]);

                        if(dict.ContainsKey(candidate))
                        {
                            dict[candidate] += votes;
                        }
                        else
                        {
                            dict[candidate] = votes;
                        }
                    }
                    foreach(var item in dict)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}