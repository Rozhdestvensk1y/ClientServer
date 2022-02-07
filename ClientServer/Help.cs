using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wcf
{
    class Help
    {
        public static int ReadInt64(string inviteMsg)
        {
            int number = 0;
            bool ok=true;

            do
            {
                Console.Write(inviteMsg);
                try
                {
                    ok = int.TryParse(Console.ReadLine(), out number);
                    if (number <= 0)
                        ok = false;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    ok = false;
                }
            } while (!ok);
            return number;
        }
    }
}
