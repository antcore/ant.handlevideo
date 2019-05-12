using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ant.handlevideo
{
    public class HandleMessage
    {
        public static void Show(object message)
        {
            if (message != null)
                Console.WriteLine(message.ToString());
        }
    }
}
