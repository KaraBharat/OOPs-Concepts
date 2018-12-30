using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance
{
    public class Presentation
    {
        public Presentation(double height, double width)
        {
            this.Height = height;
            this.Width = width;
        }

        public double Height { get; set; }
        public double Width { get; set; }

        public void Copy()
        {
            Console.WriteLine("Object copied");
        }

        public void Move()
        {
            Console.WriteLine("Object Moved");
        }
    }

    public class Text : Presentation
    {
        public Text(double height, double width)
            : base(height, width)
        {

        }

        public string Value { get; set; }
        public double FontSize { get; set; }
        public string FontName { get; set; }

        public void AddHyperLink(string link)
        {
            Console.WriteLine("Link added to the object, " + link);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var text = new Text(20, 40);
            text.Value = "Google";
            text.FontName = "Arial";
            text.FontSize = 15.5;

            text.AddHyperLink("www.google.com");

            text.Copy();

            Console.WriteLine(text.Value + " Located on, X = " + text.Height + " and Y = " + text.Width);
        }
    }
}
