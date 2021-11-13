using System;
using System.Linq;
using System.Collections.Generic;
using System.IO;

namespace z4_linq
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader sr = new StreamReader("file.txt");
            List<Pepl> people = new List<Pepl>();
            while (!sr.EndOfStream)
            {
                string str = sr.ReadLine();
                string[] st = str.Split(' ');
                people.Add(new Pepl() { f = st[0], i = st[1], o = st[2], group = st[3], mark = st[4] });
            }
            var groupGroups = from gr in people
                              group gr by gr.@group into x
                              select new
                              {
                                  FIOgm = x.Select(p => p),
                                  groups = x.Key,
                                  Count = x.Count(p => Convert.ToDouble(p.mark) > 4)
                              };
            foreach (var group in groupGroups)
            {
                Console.WriteLine($"{group.groups} : {group.Count}");
                foreach (Pepl item in group.FIOgm.Where(p => Convert.ToDouble(p.mark) > 4))
                {
                    Console.WriteLine(item.f + " " + item.i + " " + item.o + " " + item.group + " " + item.mark);
                }
            }
        }
    }
}