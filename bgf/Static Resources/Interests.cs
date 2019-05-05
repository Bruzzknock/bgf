using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace bgf.Static_Resources
{
    public static class Interests
    {
        public static int[] ID { get; set; }
        public static string[] Interest_Desc { get; set; }

        public static int GetIdByDesc(string interestDesc)
        {
            for(int i = 0;i < Interest_Desc.Length;i++)
            {
                if (interestDesc == Interest_Desc[i])
                {
                    return i;
                }
            }

            return -1;
        }
    }
}