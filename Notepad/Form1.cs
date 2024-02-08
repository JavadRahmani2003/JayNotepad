using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Notepad
{
    public partial class Notepad : Form
    {
        public Notepad() => InitializeComponent();

        String path = String.Empty;

        private void exitBox()
        {
            DialogResult = MessageBox.Show("Don't you wanna save the text file bro?", "Notepad", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(TextPanel.Text))
            {
                Application.Restart();
            }
            else
            {
                exitBox();
                if (DialogResult == DialogResult.Yes)
                {
                    saveAsToolStripMenuItem_Click(sender, e);
                    path = String.Empty;
                }
                else if (DialogResult == DialogResult.No)
                {
                    exitToolStripMenuItem_Click(sender, e);
                    path = String.Empty;
                    TextPanel.Text = String.Empty;
                }
            }
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Notepad notepad = new Notepad();
            notepad.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Opener.ShowDialog() == DialogResult.OK)
            {
                TextPanel.Text = File.ReadAllText(path = Opener.FileName);
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(path))
            {
                File.WriteAllText(path, TextPanel.Text);
            }
            else
            {
                saveAsToolStripMenuItem_Click(sender,e);
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {   
            if (Saver.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(path = Saver.FileName,TextPanel.Text);
            }
        }
        
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            newToolStripMenuItem_Click(sender,e);
        }

        private void aboutNotepadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string text = "Notepad is a simple text manager in Microsoft Windows, everyone Know that.";
            MessageBox.Show(text);
        }

        private void aboutDeveloperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form AboutDev = new AboutDev();
            AboutDev.ShowDialog();
        }

        private void wordWrapToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (wordWrapToolStripMenuItem.Checked)
            {
                TextPanel.WordWrap = true;
            }
            else
            {
                TextPanel.WordWrap = false;
            }
        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (FontSettings.ShowDialog() == DialogResult.OK)
            {
                TextPanel.Font = TextPanel.Font = new Font(FontSettings.Font, FontSettings.Font.Style);
                TextPanel.ForeColor = FontSettings.Color;
            }
        }

        private void fontDialog1_Apply(object sender, EventArgs e)
        {

        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e) => TextPanel.Cut();

        private void copyToolStripMenuItem_Click(object sender, EventArgs e) => TextPanel.Copy();

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e) => TextPanel.Paste();

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e) => TextPanel.SelectedText = string.Empty;

        private void replaceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Replacor replacor = new Replacor();
            replacor.Show();
        }
    }
}
