using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Wecres.ECrun.Form1;

namespace Wecres.ECrun
{
    internal static class Template
    {
        internal static Dictionary<string, Dictionary<string, ComboBoxItems>> Templates = new Dictionary<string, Dictionary<string, ComboBoxItems>>
        {
            {
                "BuildEnv", new Dictionary<string, ComboBoxItems>
                {

                }
            },
            {
                "Run", new Dictionary<string, ComboBoxItems>
                {

                }
            },
            {
                "Compile", new Dictionary<string, ComboBoxItems>
                {

                }
            },
            {
                "Decompile", new Dictionary<string, ComboBoxItems>
                {

                }
            }
        };
    }
}
