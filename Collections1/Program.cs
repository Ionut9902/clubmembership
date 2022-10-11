using System.Security.Cryptography.X509Certificates;

namespace collections
{
    class program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            list.Add("cuvant");
            foreach (string word in list)
            {
                Console.WriteLine(word);
            }
            list.Insert(1, "word");
            foreach (var word in list)
            {
                Console.WriteLine(word);
            }
            list.Add("masina");
            list.Remove("cuvant");
            Console.WriteLine(list.Count());
            foreach (string word in list)
            {
                var i = list.IndexOf(word) + 1;
                Console.WriteLine("{0}-->{1}", i, word);
            }

            Queue<int> queue = new Queue<int>();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            queue.Enqueue(4);
            queue.Enqueue(5);
            queue.Enqueue(6);

            Console.WriteLine(queue.Contains(5));
            queue.Dequeue();
            Console.WriteLine(queue.Count());
            int[] array = queue.ToArray();
            foreach (int i in array)
            {
                Console.WriteLine(i);
            }
            while (queue.Count > 0)
            {
                int number = queue.Dequeue();
                Console.WriteLine(number);
            }

            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            dictionary.Add(5, "house");
            dictionary.Add(3, "map");
            dictionary.Add(13, "ladder");
            Console.WriteLine("The number of values in dictionary is " + dictionary.Count);
            dictionary.Remove(5);
            Console.WriteLine(dictionary.Count);


        }
    }
}