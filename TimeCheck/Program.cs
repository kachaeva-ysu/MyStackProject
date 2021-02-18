using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using MyStack;
using System.Text.RegularExpressions;

namespace TimeCheck
{
    class Program
    {
        static List<string> ReturnWords(string fileName)
        {
            List<string> output = new List<string>();
            string text;
            using (StreamReader sr = new StreamReader(fileName))
            {
                text = sr.ReadToEnd();
            }
            var words = Regex.Split(text, @"\W+");
            output = words.ToList<string>();
            return output;
        }
        static void Main(string[] args)
        {
            StringBuilder result = new StringBuilder();
            var myStack = new MyStack<int>();
            var stack = new Stack<int>();

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
                myStack.Push(i);
            stopwatch.Stop();
            result.Append("Push " + stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
                stack.Push(i);
            stopwatch.Stop();
            result.AppendLine(" vs " + stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
                myStack.Peek();
            stopwatch.Stop();
            result.Append("Peek " + stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
                stack.Peek();
            stopwatch.Stop();
            result.AppendLine(" vs " + stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
                myStack.Pop();
            result.Append("Pop " + stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 0; i < 1000000; i++)
                stack.Pop();
            stopwatch.Stop();
            result.AppendLine(" vs " + stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 5000; i < 15000; i++)
                myStack.Contains(i);
            stopwatch.Stop();
            result.Append("Contains " + stopwatch.Elapsed);

            stopwatch = new Stopwatch();
            stopwatch.Start();
            for (int i = 5000; i < 15000; i++)
                stack.Contains(i);
            stopwatch.Stop();
            result.AppendLine(" vs " + stopwatch.Elapsed);

            var words = ReturnWords("anna.txt");
            var stack2 = new Stack<string>();
            var myStack2 = new MyStack<string>();
            var result2 = new StringBuilder();

            var watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 20000; i++)
                stack2.Push(words[i]);
            for (int i = 0; i < 20000; i++)
                stack2.Pop();
            watch.Stop();
            result2.Append(watch.Elapsed+" ");

            watch = new Stopwatch();
            watch.Start();
            for (int i = 0; i < 20000; i++)
                myStack2.Push(words[i]);
            for (int i = 0; i < 20000; i++)
                myStack2.Pop();
            watch.Stop();
            result2.Append(watch.Elapsed);

            Console.WriteLine(result.ToString());
            Console.WriteLine(result2);
            Console.ReadLine();
        }
    }
}
