using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Wecres.ECrun.Form1;

namespace Wecres.ECrun
{
    internal static class Type
    {
        internal static Dictionary<string, ComboBoxItems> Types = new Dictionary<string, ComboBoxItems>
        {
            {
                "BuildEnv", new ComboBoxItems(new string[,]
                {
                    { "Webアプリ", "WebApp" },
                    { "React", "React" },
                })
            },
            {
                "Run", new ComboBoxItems(new string[,]
                {
                    { "", "" },
                })
            },
            {
                "Compile", new ComboBoxItems(new string[,]
                {
                    { "React", "React" }
                })
            },
            {
                "Decompile", new ComboBoxItems(new string[,]
                {
                    { "", "" }
                })
            }
        };
    }
}
