using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Management.Automation;
using System.Text.RegularExpressions;
using System.Collections.ObjectModel;
using Microsoft.WindowsAPICodePack.Dialogs;

namespace Wecres.ECrun
{
    public partial class Form1 : Form
    {
        static Collection<PSObject> RunPowershell(string script)
        {
            Console.WriteLine(script);
            using (var invoker = new RunspaceInvoke()) return invoker.Invoke(script);
        }

        static bool TestNodeJS()
        {
            foreach (var result in RunPowershell("(Get-Command node -ErrorAction SilentlyContinue) -eq $null"))
            {
                if (result.ToString() == "true")
                {
                    MessageBox.Show("Node.jsをインストールしてください");
                    return false;
                }
            }
            return true;
        }

        Dictionary<string, ComboBoxItems> Types = new Dictionary<string, ComboBoxItems>
        {
            {
                "BuildEnv", new ComboBoxItems(new string[,] {
                    { "React", "React" },
                })
            },
            {
                "Run", new ComboBoxItems(new string[,] {
                    { "React", "React" },
                })
            },
        };

        Dictionary<string, Dictionary<string, ComboBoxItems>> Templates = new Dictionary<string, Dictionary<string, ComboBoxItems>>
        {
            {
                "BuildEnv", new Dictionary<string, ComboBoxItems> {
                    
                }
            },
            {
                "Run", new Dictionary<string, ComboBoxItems> {

                }
            },
        };

        Dictionary<string, Dictionary<string, Dictionary<string, Action<Dictionary<string, string>>>>> Functions =
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
                                        string name = Regex.Replace(data["name"].ToLower(), @"[^a-z]", "");
                                        int randomValue = new Random().Next(0, int.MaxValue);
                                        Task.Run(() => RunPowershell($@"
Set-Location ""{data["path"]}""
npx create-react-app ""{name}""
{(name == data["name"].ToLower() ? $@"
Rename-Item ""{name}"" ""{name + randomValue}""
Rename-Item ""{name + randomValue}"" ""{data["name"]}""
" : $@"
Rename-Item ""{name}"" ""{data["name"]}""
")}
"));
                                    }
                                }
                            }
                        }
                    }
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

                                }
                            }
                        }
                    }
                }
            },
        };

        class ComboBoxItems
        {
            public class ComboBoxItem
            {
                public string Name { get; set; }
                public string Id { get; set; }
            }

            public List<ComboBoxItem> List { get; set; } = new List<ComboBoxItem>();

            public ComboBoxItems(string[,] items)
            {
                for (int i = 0; i < items.Length / 2; i++)
                {
                    var item = new ComboBoxItem();
                    item.Name = items[i, 0];
                    item.Id = items[i, 1];
                    this.List.Add(item);
                }
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = new ComboBoxItems(new string[,] {
                { "環境構築", "BuildEnv" },
                { "実行", "Run" },
            }).List;
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.DataSource = Types[comboBox1.SelectedValue.ToString()].List;
            comboBox2.SelectedIndex = 0;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.DataSource = Templates[comboBox1.SelectedValue.ToString()]
                .TryGetValue(comboBox2.SelectedValue.ToString(), out var result) ? result.List : (new ComboBoxItems(new string[,] { { "デフォルト", "Default" } })).List;
            comboBox3.SelectedIndex = 0;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.Title = "フォルダの選択";
            dialog.RestoreDirectory = true;
            dialog.IsFolderPicker = true;
            if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                Functions[comboBox1.SelectedValue.ToString()][comboBox2.SelectedValue.ToString()][comboBox3.SelectedValue.ToString()](new Dictionary<string, string>
                {
                    { "name", textBox2.Text },
                    { "path", textBox1.Text },
                });
            }
        }
    }
}
