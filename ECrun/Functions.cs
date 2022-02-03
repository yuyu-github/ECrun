﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
                "BuildEnv", new Dictionary<string, Dictionary<string, Action<Dictionary<string, string>>>> {
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
                            }
                        }
                    },
                    {
                        "React-TypeScript", new Dictionary<string, Action<Dictionary<string, string>>>
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
                }
            },
            {
                "Run", new Dictionary<string, Dictionary<string, Action<Dictionary<string, string>>>> {
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
npm start
");
                                        });
                                    }
                                }
                            }
                        }
                    },
                    {
                        "React-TypeScript", new Dictionary<string, Action<Dictionary<string, string>>>
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
npm start
");
                                        });
                                    }
                                }
                            }
                        }
                    },
                }
            },
        };
    }
}