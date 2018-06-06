using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriansExcuseManager
{
    class Excuse
    {
        public string ExcuseText { get; set; }
        public string Results { get; set; }
        public DateTime LastUsed { get; set; }
        public string ExcusePath { get; set; }

        public Excuse()
        {
            LastUsed = DateTime.Now;
        }

        public bool Valid()
        {
            return
                !String.IsNullOrWhiteSpace(this.ExcuseText) &&
                !String.IsNullOrWhiteSpace(this.Results) &&
                this.LastUsed != DateTime.MinValue;
        }

        public void Open(string path)
        {
            using(StreamReader sr = new StreamReader(path))
            {
                this.ExcuseText = sr.ReadLine();
                this.Results = sr.ReadLine();
                this.LastUsed = DateTime.Parse(sr.ReadLine());
                this.ExcusePath = path;
            }
        }

        public void Save(string path)
        {
            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine(this.ExcuseText);
                sw.WriteLine(this.Results);
                sw.WriteLine(this.LastUsed.ToString());
            }
        }
    }
}
