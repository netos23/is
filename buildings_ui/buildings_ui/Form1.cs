using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace buildings_ui
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var dialog = new OpenFileDialog())
                {
                    dialog.Title = "Pick .dll file";
                    dialog.Filter = "DLL Files (*.dll)|*.dll|All Files (*.*)|*.*";

                    DialogResult result = dialog.ShowDialog();

                    if (result != DialogResult.OK || string.IsNullOrWhiteSpace(dialog.FileName)) return;
                    var selectedFilePath = dialog.FileName;
                    label1.Text = selectedFilePath;
                    var assembly = Assembly.LoadFrom(selectedFilePath);
                    var interfaceType = assembly.GetType("buildings.IBuilding");

                    var types = assembly.GetTypes();


                    foreach (var type in types)
                    {
                        if (!interfaceType.IsAssignableFrom(type) || !type.IsClass || type.IsAbstract)
                        {
                            continue;
                        }

                        comboBox2.Items.Add(type.FullName);
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
            }
        }


        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var className = comboBox.SelectedItem.ToString();
            var assembly = Assembly.LoadFile(label2.Text);
            var classType = assembly.GetType(className);
            var methods = classType.GetMethods();

            comboBox1.Items.Clear();
            foreach (var method in methods)
            {
                comboBox1.Items.Add(method.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var arg = textBox1.Text;

            var className = comboBox2.SelectedItem.ToString();
            var assembly = Assembly.LoadFile(label2.Text);
            var classType = assembly.GetType(className);
            var constructor = classType.GetConstructors().First(c => c.GetParameters().Length == 0);
            var arguments = Array.Empty<object>();
            var instance = constructor.Invoke(arguments);
            var methodName = comboBox1.SelectedItem.ToString();
            var method = classType.GetMethod(methodName);

            var args = method.GetParameters();

            string res;
            if (args.Length == 0)
            {
                res = method.Invoke(instance, Array.Empty<object>()).ToString();
            }
            else
            {
                switch (args[0].ParameterType.Name)
                {
                    case "int":
                        res = method.Invoke(instance, new object[]{int.Parse(arg)}).ToString();
                        break;
                    case "double":
                        res = method.Invoke(instance, new object[]{double.Parse(arg)}).ToString();
                        break;
                    default:
                        res = method.Invoke(instance, new object[]{arg}).ToString();
                        break;
                }
            }
            
            MessageBox.Show(res, "Exec", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            
        }
    }
}