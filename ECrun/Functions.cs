using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;
using System.Text.RegularExpressions;

using static Wecres.ECrun.Form1;

namespace Wecres.ECrun
{
    internal static class Function
    {
        internal static Dictionary<string, Dictionary<string, Dictionary<string, Action<Dictionary<string, string>>>>> Functions =
            new Dictionary<string, Dictionary<string, Dictionary<string, Action<Dictionary<string, string>>>>>
            {
                {
                    "BuildEnv", new Dictionary<string, Dictionary<string, Action<Dictionary<string, string>>>> 
                    {
                        {
                            "WebApp", new Dictionary<string, Action<Dictionary<string, string>>>
                            {
                                {
                                    "TypeScript", data =>
                                    {
                                        if (TestNodeJS())
                                        {
                                            Task.Run(() =>
                                            {
                                                Directory.SetCurrentDirectory(data["path"]);
                                                Directory.CreateDirectory(data["name"]);
                                                Directory.SetCurrentDirectory(data["name"]);

                                                RunPowershell($@"Set-Location ""{data["path"]}\{data["name"]}""
npm init -y
npm install typescript");

                                                File.WriteAllText("tsconfig.json", @"{
    ""compilerOptions"": {
        ""target"": ""es2016"",
        ""strict"": true,
        ""outDir"": ""./dist"",
    },
    ""include"": [
      ""src/**/*"",
    ]
}");
                                                Directory.CreateDirectory("dist");
                                                File.WriteAllText(@"dist\index.html", @"<!DOCTYPE html>
<html lang=""ja"">
<head>
    <meta name=""viewport"" content=""width=device-width, initial-scale=1.0"">
    <meta charset=""UTF-8"">
    <title></title>
    <link rel=""stylesheet"" href=""style.css"">
</head>
<body>
    <script src=""main.js"" type=""module""></script>
</body>
</html>");
                                                File.WriteAllText(@"dist\style.css", @"body {
    margin: 0;
    padding: 0;
}");
                                                Directory.CreateDirectory("src");
                                                File.Create(@"src\main.ts").Close();
                                            });
                                        }
                                    }
                                }
                            }
                        },
                        {
                            "React", new Dictionary<string, Action<Dictionary<string, string>>>
                            {
                                {
                                    "Default", data =>
                                    {
                                        if (TestNodeJS())
                                        {
                                            string name = Regex.Replace(data["name"].ToLower(), @"[^a-z0-9\-_]", "");
                                            Task.Run(() =>
                                            {
                                                RunPowershell($@"Set-Location ""{data["path"]}""
npx create-react-app ""{name}""");

                                                Directory.SetCurrentDirectory(data["path"]);
                                                if (name == data["name"].ToLower())
                                                {
                                                    int randomValue = new Random().Next(0, int.MaxValue);
                                                    Directory.Move(name, name + randomValue);
                                                    Directory.Move(name + randomValue, data["name"]);
                                                }
                                                else Directory.Move(name, data["name"]);

                                                Directory.SetCurrentDirectory(data["name"]);
                                                Directory.Delete("public");
                                                Directory.Delete("src");
                                                Directory.CreateDirectory("public");
                                                File.WriteAllText(@"public\index.html", @"<!DOCTYPE html>
<html lang=""ja"">
<head>
    <meta charset=""UTF-8"">
    <title></title>
</head>
<body>
    <div id=""root""></div>
</body>
</html>");
                                                Directory.CreateDirectory("src");
                                                File.WriteAllText(@"src\index.jsx", @"import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';

ReactDOM.render(
    <React.StrictMode>
    <App />
    </React.StrictMode>,
    document.getElementById('root')
);");
                                                File.WriteAllText(@"src\App.jsx", @"import React from 'react';

function App() {
    return (
    <div></div>
    );
}

export default App;
");
                                            });
                                        }
                                    }
                                },
                                {
                                    "TypeScript", data =>
                                    {
                                        if (TestNodeJS())
                                        {
                                            string name = Regex.Replace(data["name"].ToLower(), @"[^a-z0-9\-_]", "");
                                            Task.Run(() =>
                                            {
                                                RunPowershell($@"
Set-Location ""{data["path"]}""
npx create-react-app ""{name}"" --template typescript
");

                                                Directory.SetCurrentDirectory(data["path"]);
                                                if (name == data["name"].ToLower())
                                                {
                                                    int randomValue = new Random().Next(0, int.MaxValue);
                                                    Directory.Move(name, name + randomValue);
                                                    Directory.Move(name + randomValue, data["name"]);
                                                }
                                                else Directory.Move(name, data["name"]);

                                                                                            Directory.SetCurrentDirectory(data["name"]);
                                                Directory.Delete("public");
                                                Directory.Delete("src");
                                                Directory.CreateDirectory("public");
                                                File.WriteAllText(@"public\index.html", @"<!DOCTYPE html>
<html lang=""ja"">
<head>
    <meta charset=""UTF-8"">
    <title></title>
</head>
<body>
    <div id=""root""></div>
</body>
</html>");
                                                Directory.CreateDirectory("src");
                                                File.WriteAllText(@"src\index.tsx", @"import React from 'react';
import ReactDOM from 'react-dom';
import App from './App';

ReactDOM.render(
    <React.StrictMode>
    <App />
    </React.StrictMode>,
    document.getElementById('root')
);");
                                                File.WriteAllText(@"src\App.tsx", @"import React from 'react';

function App() {
    return (
    <div></div>
    );
}

export default App;
");
                                            });
                                        }
                                    }
                                }
                            }
                        },
                        {
                            "ReactNative", new Dictionary<string, Action<Dictionary<string, string>>>
                            {
                                {
                                    "Default", data =>
                                    {
                                        if (TestNodeJS())
                                        {
                                            Task.Run(() =>
                                            {
                                                RunPowershell($@"Set-Location ""{data["path"]}""
npx react-native ""{data["name"]}""");
                                            });
                                        }
                                    }
                                },
                                {
                                    "TypeScript", data =>
                                    {
                                        if (TestNodeJS())
                                        {
                                            Task.Run(() =>
                                            {
                                                RunPowershell($@"Set-Location ""{data["path"]}""
npx react-native ""{data["name"]}"" --template react-native-template-typescript");
                                            });
                                        }
                                    }
                                }
                            }
                        },
                    }
                },
                {
                    "Run", new Dictionary<string, Dictionary<string, Action<Dictionary<string, string>>>> 
                    {
                        {
                            "WebApp", new Dictionary<string, Action<Dictionary<string, string>>>
                            {
                                {
                                    "TypeScript", data =>
                                    {
                                        Task.Run(() =>
                                        {
                                            RunPowershell($@"Set-Location {data["path"]}\{data["name"]}
npx tsc");
                                        });
                                        string[] indexFileNames = Directory.GetFiles($@"{data["path"]}\{data["name"]}", "index.*", SearchOption.AllDirectories)
                                            .Where(item => Regex.IsMatch(item, @"\.(html|htm|shtml|shtm|php|cgi)$")).ToArray();
                                        if (indexFileNames.Length > 0) Process.Start(indexFileNames[0]);
                                    }
                                }
                            }
                        }
                    }
                },
                {
                    "Compile", new Dictionary<string, Dictionary<string, Action<Dictionary<string, string>>>>
                    {
                        {
                            "WebApp", new Dictionary<string, Action<Dictionary<string, string>>>
                            {
                                {
                                    "TypeScript", data =>
                                    {
                                        Task.Run(() =>
                                        {
                                            RunPowershell($@"Set-Location {data["path"]}\{data["name"]}
npx tsc");
                                        });
                                    }
                                }
                            }
                        },
                        {
                            "React", new Dictionary<string, Action<Dictionary<string, string>>>
                            {
                                {
                                    "Default", data =>
                                    {
                                        if (TestNodeJS())
                                        {
                                            string name = Regex.Replace(data["name"].ToLower(), @"[^a-z0-9\-_]", "");
                                            Task.Run(() =>
                                            {
                                                RunPowershell($@"
    Set-Location ""{data["path"] + "\\" + data["name"]}""
    npm run build
    ");
                                            });
                                        }
                                    }
                                },
                                {
                                    "TypeScript", data =>
                                    {
                                        if (TestNodeJS())
                                        {
                                            string name = Regex.Replace(data["name"].ToLower(), @"[^a-z0-9\-_]", "");
                                            Task.Run(() =>
                                            {
                                                RunPowershell($@"
    Set-Location ""{data["path"] + "\\" + data["name"]}""
    npm run build
    ");
                                            });
                                        }
                                    }
                                }
                            }
                        },
                    }
                },
                {
                    "Decompile", new Dictionary<string, Dictionary<string, Action<Dictionary<string, string>>>>
                    {

                    }
                },
            };
    }
}
