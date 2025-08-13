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
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using static System.Windows.Forms.LinkLabel;

namespace CURIOsity
{
    public partial class CuriosityForm : Form
    {
        // class-level dictionaries to store moving element positions
        Dictionary<string, int> stagecraftEquipmentPositions = new Dictionary<string, int>();
        Dictionary<string, int> leftPanelPositions = new Dictionary<string, int>();
        Dictionary<string, int> rightPanelPositions = new Dictionary<string, int>();
        public CuriosityForm()
        {
            InitializeComponent();
        }

        private void LoadTextButton_OnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog loadTextDialog = new OpenFileDialog())
            {
                loadTextDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                if (loadTextDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = loadTextDialog.FileName;
                    try
                    {
                        foreach (var line in File.ReadLines(fileName).Skip(3).Take(13))
                        {
                            stagecraftEquipmentPositions.Add(line.Substring(0, 6), int.Parse(line.Substring(9, 5)));
                        }

                        foreach(var line in File.ReadLines(fileName).Skip(17).Take(26))
                        {
                            leftPanelPositions.Add(line.Substring(0, 6), int.Parse(line.Substring(9, 5)));
                        }

                        foreach (var line in File.ReadLines(fileName).Skip(44).Take(26))
                        {
                            rightPanelPositions.Add(line.Substring(0, 6), int.Parse(line.Substring(9, 5)));
                        }

                        // empty and refill ListBoxes
                        stagecraftListBox.Items.Clear();
                        foreach (var pair in stagecraftEquipmentPositions)
                            stagecraftListBox.Items.Add($"{pair.Key}: {pair.Value} mm");

                        leftPanelsListBox.Items.Clear();
                        foreach (var pair in leftPanelPositions)
                            leftPanelsListBox.Items.Add($"{pair.Key}: {pair.Value} mm");

                        rightPanelsListBox.Items.Clear();
                        foreach (var pair in rightPanelPositions)
                            rightPanelsListBox.Items.Add($"{pair.Key}: {pair.Value} mm");
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error while reading text file: " + error.Message + "Please make sure the text file is formatted as expected (described in the readme file)");
                    }
                }
            }
        }

        private void LoadBimButton_OnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog loadBimDialog = new OpenFileDialog())
            {
                loadBimDialog.Filter = "BIM file (*.bim)|*.bim|All files (*.*)|*.*";
                if (loadBimDialog.ShowDialog() == DialogResult.OK)
                {
                    string fileName = loadBimDialog.FileName;
                    try
                    {
                        using (var model = IfcStore.Open(fileName))
                        {
                            foreach (var pair in stagecraftEquipmentPositions)
                            {
                                //model.Instances.OfType<IIfcProduct>() = pair.Value; // writes the position of each stagecraft equipment piece in the BIM model
                            }
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error while reading BIM file: " + error.Message);
                    }
                }
            }
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // ListBoxes size and distance between them
            int listBoxWidth = stagecraftListBox.Width;
            int listBoxHeight = stagecraftListBox.Height;
            int listBoxSpacing = 18; // distance between the ListBoxes
            int totalWidth = listBoxWidth * 3 + listBoxSpacing * 2;
            int totalHeight = listBoxHeight; // same height for all ListBoxes

            // Starting points for horizontal and vertical centering
            int startX = (this.ClientSize.Width - totalWidth) / 2;
            int startY = (this.ClientSize.Height - totalHeight) / 2;

            // ListBoxes positions
            stagecraftListBox.Left = startX;
            stagecraftListBox.Top = startY;

            leftPanelsListBox.Left = startX + listBoxWidth + listBoxSpacing;
            leftPanelsListBox.Top = startY;

            rightPanelsListBox.Left = startX + (listBoxWidth + listBoxSpacing) * 2;
            rightPanelsListBox.Top = startY;

            // move TextBox titles accordingly, when existing
            if (stagecraftListBoxLabel != null)
            {
                stagecraftListBoxLabel.Left = stagecraftListBox.Left;
                stagecraftListBoxLabel.Top = stagecraftListBox.Top - stagecraftListBoxLabel.Height - 4;
            }
            if (leftPanelsListBoxLabel != null)
            {
                leftPanelsListBoxLabel.Left = leftPanelsListBox.Left;
                leftPanelsListBoxLabel.Top = leftPanelsListBox.Top - leftPanelsListBoxLabel.Height - 4;
            }
            if (rightPanelsListBoxLabel != null)
            {
                rightPanelsListBoxLabel.Left = rightPanelsListBox.Left;
                rightPanelsListBoxLabel.Top = rightPanelsListBox.Top - rightPanelsListBoxLabel.Height - 4;
            }

            // horizontally centering "Load text file" and "Load BIM file" buttons and keeping them one beside the other at the bottom of the form
            int buttonSpacing = 16; // distance between buttons
            int buttonsTotalWidth = loadTextButton.Width + buttonSpacing + loadBimButton.Width;
            int buttonsStartX = (this.ClientSize.Width - buttonsTotalWidth) / 2;
            int buttonsY = this.ClientSize.Height - loadTextButton.Height - 24; // 24 pixels from the bottom of the form

            loadTextButton.Left = buttonsStartX;
            loadTextButton.Top = buttonsY;
            
            loadBimButton.Left = buttonsStartX + loadTextButton.Width + buttonSpacing;
            loadBimButton.Top = buttonsY;
        }
    }
}