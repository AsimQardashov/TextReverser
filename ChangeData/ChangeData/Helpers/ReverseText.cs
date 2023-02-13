using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ChangeData.Helpers
{
    public class ReverseText
    {
        public string ReverseString(string text)
        {
            char[] charText= text.ToCharArray();
            Array.Reverse(charText);

            return new string(charText);
        }
    }
}
