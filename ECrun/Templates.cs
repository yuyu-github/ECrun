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
                    {
                        "WebApp", new ComboBoxItems(new string[,]
                        {
                            { "TypeScript", "TypeScript" }
                        })
                    },
                    {
                        "React", new ComboBoxItems(new string[,]
                        {
                            { "デフォルト", "Default" },
                            { "TypeScript", "TypeScript" },
                        })
                    },
                }
            },
            {
                "Run", new Dictionary<string, ComboBoxItems>
                {
                    {
                        "WebApp", new ComboBoxItems(new string[,]
                        {
                            { "TypeScript", "TypeScript" }
                        })
                    },
                }
            },
            {
                "Compile", new Dictionary<string, ComboBoxItems>
                {
                    {
                        "WebApp", new ComboBoxItems(new string[,]
                        {
                            { "TypeScript", "TypeScript" }
                        })
                    },
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
