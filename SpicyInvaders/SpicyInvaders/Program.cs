using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SpicyInvaders
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Console.BufferHeight = 30;
            Console.BufferWidth = 120;
            Console.CursorVisible = false;

            TheHomepage theHomepage = new TheHomepage();
        }
    }
}
