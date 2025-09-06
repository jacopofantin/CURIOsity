using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Xbim.Ifc;
using Xbim.Ifc4.Interfaces;
using static System.Windows.Forms.LinkLabel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TaskbarClock;

namespace CURIOsity
{
    // auxiliary class to read INI files
    public class IniFile
    {
        public string Path;
        [DllImport("kernel32")]
        private static extern long WritePrivateProfileString(string section, string key, string val, string filePath);
        [DllImport("kernel32")]
        private static extern int GetPrivateProfileString(string section, string key, string def, StringBuilder retVal, int size, string filePath);

        public IniFile(string path)
        {
            Path = path;
        }

        public string Read(string section, string key)
        {
            StringBuilder stringBuilder = new StringBuilder(255);
            GetPrivateProfileString(section, key, "", stringBuilder, 255, Path);
            return stringBuilder.ToString();
        }
    }

    public partial class CuriosityForm : Form
    {
        // class-level dictionaries to store moving element data coming from CURIO in
        Dictionary<string, int> curioStagecraftEquipmentPositions = new Dictionary<string, int>();
        Dictionary<string, int> curioLeftPanelApertures = new Dictionary<string, int>();
        Dictionary<string, int> curioRightPanelApertures = new Dictionary<string, int>();

        // class-level dictionaries to store moving element data coming from the BIM model in
        Dictionary<string, int> bimStagecraftEquipmentPositions = new Dictionary<string, int>();
        Dictionary<string, int> bimLeftPanelApertures = new Dictionary<string, int>();
        Dictionary<string, int> bimRightPanelApertures = new Dictionary<string, int>();

        // INI file and timers for automatic file check and usage
        private string iniPath = "D:\\CURIOsity\\Configuration\\conf.ini";

        private System.Windows.Forms.Timer textFileCheckTimer;
        private string textFileCheckDirectory = "D:\\CURIOsity\\IO_files"; // default directory, can be changed in INI file
        private string textFileCheckName = "Fotografia_sala_CURIO.txt"; // default file name, can be changed in INI file
        private int textFileCheckInterval = 5000; // default to 5 seconds, can be changed in INI file
        private bool textFileCheckActive = true; // default to true, can be changed in INI file

        private System.Windows.Forms.Timer bimFileCheckTimer;
        private string bimFileCheckDirectory = "D:\\CURIOsity\\IO_files"; // default directory, can be changed in INI file
        private string bimFileCheckName = "Model.ifc"; // default file name, can be changed in INI file
        private int bimFileCheckInterval = 5000; // default to 5 seconds, can be changed in INI file
        private bool bimFileCheckActive = true; // default to true, can be changed in INI file


        public CuriosityForm()
        {
            InitializeComponent();
            this.Icon = new Icon("icon.ico");
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // read INI file
            if (File.Exists(iniPath))
            {
                var iniFile = new IniFile(iniPath);

                // text file check parameters
                textFileCheckDirectory = iniFile.Read("TextFileCheck", "Directory");
                textFileCheckName = iniFile.Read("TextFileCheck", "FileName");
                int.TryParse(iniFile.Read("TextFileCheck", "Interval"), out textFileCheckInterval);
                bool.TryParse(iniFile.Read("TextFileCheck", "Active"), out textFileCheckActive);

                // BIM file check parameters
                bimFileCheckDirectory = iniFile.Read("BimFileCheck", "Directory");
                bimFileCheckName = iniFile.Read("BimFileCheck", "FileName");
                int.TryParse(iniFile.Read("BimFileCheck", "Interval"), out bimFileCheckInterval);
                bool.TryParse(iniFile.Read("BimFileCheck", "Active"), out bimFileCheckActive);
            }

            // initialize timers
            InitTimers();
        }

        // timer methods
        protected void InitTimers()
        {
            // initialize CURIO file timer if active
            if (textFileCheckActive)
            {
                textFileCheckTimer = new System.Windows.Forms.Timer();
                textFileCheckTimer.Interval = textFileCheckInterval;
                textFileCheckTimer.Tick += TextFileCheckTimer_Tick;
                textFileCheckTimer.Start();
            }

            // initialize BIM file timer if active
            if (bimFileCheckActive)
            {
                bimFileCheckTimer = new System.Windows.Forms.Timer();
                bimFileCheckTimer.Interval = bimFileCheckInterval;
                bimFileCheckTimer.Tick += BimFileCheckTimer_Tick;
                bimFileCheckTimer.Start();
            }
        }

        private void TextFileCheckTimer_Tick(object sender, EventArgs e)
        {
            string filePath = Path.Combine(textFileCheckDirectory, textFileCheckName);
            if (File.Exists(filePath))
            {
                // file found, load it
                LoadTextFile(filePath);
            }
        }

        private void BimFileCheckTimer_Tick(object sender, EventArgs e)
        {
            string filePath = Path.Combine(bimFileCheckDirectory, bimFileCheckName);
            if (File.Exists(filePath))
            {
                // file found, load it
                LoadBimFile(filePath);
            }
        }


        // button methods
        private void LoadTextButton_OnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog loadTextDialog = new OpenFileDialog())
            {
                loadTextDialog.Filter = "Text file (*.txt)|*.txt|All files (*.*)|*.*";
                if (loadTextDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadTextFile(loadTextDialog.FileName);
                }
            }
        }

        private void LoadBimButton_OnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog loadBimDialog = new OpenFileDialog())
            {
                loadBimDialog.Filter = "BIM file (*.ifc)|*.ifc|All files (*.*)|*.*";
                if (loadBimDialog.ShowDialog() == DialogResult.OK)
                {
                    LoadBimFile(loadBimDialog.FileName);
                }
            }
        }

        private void UpdateBimButton_OnClick(object sender, EventArgs e)
        {
            using (OpenFileDialog updateBimDialog = new OpenFileDialog())
            {
                updateBimDialog.Filter = "BIM file (*.ifc)|*.ifc|All files (*.*)|*.*";
                if (updateBimDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = updateBimDialog.FileName;
                    try
                    {
                        var editor = new XbimEditorCredentials
                        {
                            ApplicationDevelopersName = "Jacopo Fantin",
                            ApplicationFullName = "CURIOsity",
                            ApplicationIdentifier = "CURIOsity",
                            ApplicationVersion = "1.0",
                            EditorsFamilyName = "Fantin",
                            EditorsGivenName = "Jacopo",
                            EditorsOrganisationName = "Politecnico di Milano"
                        };

                        // open the BIM file
                        using (var model = IfcStore.Open(filePath, editor))
                        {/*
                            // start a transaction to modify the BIM file for left wall pivoting panel apertures
                            using (var leftPanelApertureUpdate = model.BeginTransaction("Left wall pivoting panel aperture update"))
                            {
                                //... extract left panel information into IEnumerable bimLeftPanels like we already did for the loadBimButton...

                                //bimLeftPanels: IEnumerable, leftPanelApertures: list
                                //to be used if the model does not have stagecraft equipment in it: in that case, it makes most sense to use lists for data imported from TXT since panels are identified from number 1 to 26 (we can forget about their IDs)
                                for (int i = 0; i < leftPanelApertures.Count; i++)
                                {
                                    var leftPanel = bimLeftPanels.ElementAt(i);
                                
                                    var aperture = leftPanel.IsDefinedBy
                                        .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                                        .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                                        .OfType<IIfcPropertySingleValue>()
                                        .FirstOrDefault(p => p.Name = "Aperture");

                                    // writes the aperture of each panel on the left wall in the BIM model
                                    aperture.NominalValue = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(leftPanelApertures[i]);
                                }
                                
                                //bimLeftPanels: IEnumerable, leftPanelMapping: dictionary<string, int> where key is the CURIO ID of the left wall panel and value is the index of the corresponding panel in bimLeftPanels
                                //to be used if the model actually has stagecraft equipment in it: in that case, we must use a dictionary for its information and in this case we wanna use dictionaries for all of the data we import from TXT
                                foreach (var corr in leftPanelMapping)
                                {
                                    var leftPanel = bimLeftPanels.ElementAt(corr.Value);

                                    var aperture = leftPanel.IsDefinedBy
                                        .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                                        .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                                        .OfType<IIfcPropertySingleValue>()
                                        .FirstOrDefault(p => p.Name = "Aperture");

                                    // writes the aperture of each panel on the left wall in the BIM model
                                    aperture.NominalValue = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(leftPanelApertures[corr.Key]);
                                }
                                
                                // commit the changes to the BIM file
                                leftPanelApertureUpdate.Commit();
                            }

                            // start a transaction to modify the BIM file for right wall pivoting panel apertures
                            using (var rightPanelApertureUpdate = model.BeginTransaction("Right wall pivoting panel aperture update"))
                            {
                                //... extract right panel information into IEnumerable bimRightPanels like we already did for the loadBimButton...

                                //bimRightPanels: IEnumerable, rightPanelApertures: list
                                //to be used if the model does not have stagecraft equipment in it: in that case, it makes most sense to use lists for data imported from TXT since panels are identified from number 1 to 26 (we can forget about their IDs)
                                for (int i = 0; i < rightPanelApertures.Count; i++)
                                {
                                    var rightPanel = bimRightPanels.ElementAt(i);

                                    var aperture = rightPanel.IsDefinedBy
                                        .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                                        .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                                        .OfType<IIfcPropertySingleValue>()
                                        .FirstOrDefault(p => p.Name = "Aperture");

                                    // writes the aperture of each panel on the right wall in the BIM model
                                    aperture.NominalValue = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(rightPanelApertures[i]);
                                }

                                //bimRightPanels: IEnumerable, rightPanelMapping: dictionary<string, int> where key is the CURIO ID of the right wall panel and value is the index of the corresponding panel in bimRightPanels
                                //to be used if the model actually has stagecraft equipment in it: in that case, we must use a dictionary for its information and in this case we wanna use dictionaries for all of the data we import from TXT
                                foreach (var corr in rightPanelMapping)
                                {
                                    var rightPanel = bimRightPanels.ElementAt(corr.Value);

                                    var aperture = rightPanel.IsDefinedBy
                                        .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                                        .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                                        .OfType<IIfcPropertySingleValue>()
                                        .FirstOrDefault(p => p.Name = "Aperture");

                                    // writes the aperture of each panel on the right wall in the BIM model
                                    aperture.NominalValue = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(rightPanelApertures[corr.Key]);
                                }

                                // commit the changes to the BIM file
                                rightPanelApertureUpdate.Commit();
                            }

                            // start a transaction to modify the BIM file for stagecraft equipment positions
                            using (var stagecraftEquipmentPositionsUpdate = model.BeginTransaction("Stagecraft equipment position update"))
                            {
                                //... extract stagecraft equipment information into IEnumerable bimStagecraftEquipment like we already did for the loadBimButton...

                                //bimStagecraftEquipment: IEnumerable, stagecraftEquipmentMapping: dictionary<string, int> where key is the CURIO ID of the stagecraft equipment piece and value is the index of the corresponding piece in bimStagecraftEquipment
                                foreach (var corr in stagecraftEquipmentMapping)
                                {
                                    var piece = bimStagecraftEquipment.ElementAt(corr.Value);

                                    var position = piece.IsDefinedBy
                                        .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                                        .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                                        .OfType<IIfcPropertySingleValue>()
                                        .FirstOrDefault(p => p.Name = "Position");

                                    // writes the position of each stagecraft equipment piece in the BIM model
                                    position.NominalValue = new Xbim.Ifc4.MeasureResource.IfcLengthMeasure(stagecraftEquipmentPositions[corr.Key]);
                                }

                                // commit the changes to the BIM file
                                stagecraftEquipmentPositionsUpdate.Commit();
                            }*/
                        }
                    }
                    catch (Exception error)
                    {
                        MessageBox.Show("Error while reading BIM file: " + error.Message);
                    }
                }
            }
        }


        // event method to load text file
        private void LoadTextFile(string filePath)
        {
            try
            {
                // save current ListBox vertical scrolling positions to restore them later
                int curioStagecraftListBoxTopIndex = curioStagecraftListBox.TopIndex;
                int curioLeftPanelsListBoxTopIndex = curioLeftPanelsListBox.TopIndex;
                int curioRightPanelsListBoxTopIndex = curioRightPanelsListBox.TopIndex;

                // empty the class-level dictionaries
                curioStagecraftEquipmentPositions.Clear();
                curioLeftPanelApertures.Clear();
                curioRightPanelApertures.Clear();

                // read the text file and fill the class-level dictionaries
                foreach (var line in File.ReadLines(filePath).Skip(3).Take(13))
                {
                    curioStagecraftEquipmentPositions.Add(line.Substring(0, 6), int.Parse(line.Substring(9, 5)));
                }

                foreach (var line in File.ReadLines(filePath).Skip(17).Take(26))
                {
                    curioLeftPanelApertures.Add(line.Substring(0, 6), int.Parse(line.Substring(9, 5)));
                }

                foreach (var line in File.ReadLines(filePath).Skip(44).Take(26))
                {
                    curioRightPanelApertures.Add(line.Substring(0, 6), int.Parse(line.Substring(9, 5)));
                }

                // empty and refill corresponding ListBoxes
                curioStagecraftListBox.Items.Clear();
                foreach (var pair in curioStagecraftEquipmentPositions)
                {
                    curioStagecraftListBox.Items.Add($"{pair.Key}: {pair.Value} mm");
                }

                curioLeftPanelsListBox.Items.Clear();
                foreach (var pair in curioLeftPanelApertures)
                {
                    curioLeftPanelsListBox.Items.Add($"{pair.Key}: {pair.Value} mm");
                }

                curioRightPanelsListBox.Items.Clear();
                foreach (var pair in curioRightPanelApertures)
                {
                    curioRightPanelsListBox.Items.Add($"{pair.Key}: {pair.Value} mm");
                }

                // restore previously saved ListBox vertical scrolling positions
                if (curioStagecraftListBox.Items.Count > curioStagecraftListBoxTopIndex)
                {
                    curioStagecraftListBox.TopIndex = curioStagecraftListBoxTopIndex;
                }

                if (curioLeftPanelsListBox.Items.Count > curioLeftPanelsListBoxTopIndex)
                {
                    curioLeftPanelsListBox.TopIndex = curioLeftPanelsListBoxTopIndex;
                }
                    
                if (curioRightPanelsListBox.Items.Count > curioRightPanelsListBoxTopIndex)
                {
                    curioRightPanelsListBox.TopIndex = curioRightPanelsListBoxTopIndex;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error while reading text file: " + error.Message + "Please make sure the text file is formatted as expected (described in the readme file)");
            }
        }

        // event method to load BIM file
        private void LoadBimFile(string filePath)
        {
            try
            {
                // save current ListBox vertical scrolling positions to restore them later
                int bimStagecraftListBoxTopIndex = bimStagecraftListBox.TopIndex;
                int bimLeftPanelsListBoxTopIndex = bimLeftPanelsListBox.TopIndex;
                int bimRightPanelsListBoxTopIndex = bimRightPanelsListBox.TopIndex;

                // empty the class-level dictionaries
                bimStagecraftEquipmentPositions.Clear();
                bimLeftPanelApertures.Clear();
                bimRightPanelApertures.Clear();

                using (var model = IfcStore.Open(filePath))
                {
                    /*
                    //let's explore the model to find the correct entity for the pivoting panels (and the stagecraft equipment pieces, possibly)
                    var allInstances = model.Instances;
                    var interfaceNames = new HashSet<string>();
                    foreach (var instance in allInstances)
                    {
                        var type = instance.GetType();
                        interfaceNames.Add(type.Name);
                    }
                    foreach (var name in interfaceNames.OrderBy(n => n))
                    {
                        Console.WriteLine(name);
                    }

                    // get pivoting panels from the model (extracted data should be IEnumerable objects whose elements are sorted from 1 to 26)
                    //var pivotingPanels = model.Instances.OfType<IIfcPanel>();
                    //var bimLeftPanels = model.Instances.Where<IIfcPanel>(p => p.IsTypedBy.LeftSide());
                    //var bimRightPanels = model.Instances.Where<IIfcPanel>(p => p.IsTypedBy.RightSide());

                    //let's explore the panels in the IFC file to find the correct property set and property name for the pivoting panel aperture

                    //get information about one of the panels
                    //var firstPanel = model.Instances.FirstOrDefault<IIfcPanel>();
                    //Console.WriteLine($"Panel ID: {firstPanel.GlobalId}, Name: {firstPanel.Name}");

                    //get all single-value properties of the panel
                    //var properties = firstPanel.IsDefinedBy
                    //    .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                    //    .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                    //    .OfType<IIfcPropertySingleValue>();
                    //foreach (var property in properties)
                    //    Console.WriteLine($"Property: {property.Name}, Value: {property.NominalValue}");

                    // store panel names as keys and aperture values as values in the class-level dictionaries

                    foreach (var leftPanel in bimLeftPanels)
                    {
                        var aperture = leftPanel.IsDefinedBy
                            .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                            .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                            .OfType<IIfcPropertySingleValue>()
                            .Where(p => p.Name = "Aperture");

                        bimLeftPanelApertures.Add(leftPanel.Name, int.Parse(aperture.NominalValue));
                    }

                    foreach (var rightPanel in bimRightPanels)
                    {
                        var aperture = rightPanel.IsDefinedBy
                            .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                            .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                            .OfType<IIfcPropertySingleValue>()
                            .Where(p => p.Name = "Aperture");

                        bimRightPanelApertures.Add(rightPanel.Name, int.Parse(aperture.NominalValue));
                    }

                    // store stagecraft equipment names as keys and positions as values in the class-level dictionary
                    foreach (var piece in bimStagecraftEquipment)
                    {
                        var position = piece.IsDefinedBy
                            .Where(r => r.RelatingPropertyDefinition is IIfcPropertySet)
                            .SelectMany(r => ((IIfcPropertySet)r.RelatingPropertyDefinition).HasProperties)
                            .OfType<IIfcPropertySingleValue>()
                            .Where(p => p.Name = "Position");

                        bimStagecraftEquipmentPositions.Add(piece.Name, int.Parse(position.NominalValue));
                    }*/
                }

                // empty and refill corresponding ListBoxes
                bimStagecraftListBox.Items.Clear();
                foreach (var pair in bimStagecraftEquipmentPositions)
                {
                    bimStagecraftListBox.Items.Add($"{pair.Key}: {pair.Value} mm");
                }

                bimLeftPanelsListBox.Items.Clear();
                foreach (var pair in bimLeftPanelApertures)
                {
                    bimLeftPanelsListBox.Items.Add($"{pair.Key}: {pair.Value} mm");
                }

                bimRightPanelsListBox.Items.Clear();
                foreach (var pair in bimRightPanelApertures)
                {
                    bimRightPanelsListBox.Items.Add($"{pair.Key}: {pair.Value} mm");
                }

                // restore previously saved ListBox vertical scrolling positions
                if (bimStagecraftListBox.Items.Count > bimStagecraftListBoxTopIndex)
                {
                    bimStagecraftListBox.TopIndex = bimStagecraftListBoxTopIndex;
                }
                    
                if (bimLeftPanelsListBox.Items.Count > bimLeftPanelsListBoxTopIndex)
                {
                    bimLeftPanelsListBox.TopIndex = bimLeftPanelsListBoxTopIndex;
                }
                    
                if (bimRightPanelsListBox.Items.Count > bimRightPanelsListBoxTopIndex)
                {
                    bimRightPanelsListBox.TopIndex = bimRightPanelsListBoxTopIndex;
                }
            }
            catch (Exception error)
            {
                MessageBox.Show("Error while reading BIM file: " + error.Message);
            }

        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            // Layout constants
            int listBoxSpacing = 12; // distance between ListBoxes
            int groupSpacing = 32;   // distance between data groups
            int titleSpacing = 6;    // distance between group title and ListBoxes
            int labelSpacing = 4;    // distance between ListBox labels and ListBoxes
            int groupTitleHeight = 30; // height reserved for group titles
            int separatorHeight = 2; // height of the separator line

            // compute available width/height for ListBoxes
            int availableWidth = this.ClientSize.Width - 40; // 20px for left and right frame
            int listBoxWidth = (availableWidth - 2 * listBoxSpacing) / 3;

            // compute dynamically ListBox height to fill the available space vertically
            int topMargin = 16;
            int labelHeight = 20;
            int curioGroupHeight = groupTitleHeight + titleSpacing + labelHeight + labelSpacing;
            int bimGroupHeight = groupTitleHeight + titleSpacing + labelHeight + labelSpacing;
            int separatorMargin = groupSpacing / 2 + separatorHeight + 8;
            int buttonHeight = loadTextButton.Height;
            int buttonBottomMargin = 48;
            int totalListBoxHeight = this.ClientSize.Height - topMargin - curioGroupHeight - bimGroupHeight - separatorMargin - buttonHeight - buttonBottomMargin;

            // Each group takes half of the available space
            int listBoxHeight = totalListBoxHeight / 2;

            // Starting positions for data groups
            int startX = 20;
            int curioStartY = topMargin;
            int curioLabelY = curioStartY + groupTitleHeight + titleSpacing;
            int curioListBoxY = curioLabelY + labelHeight + labelSpacing;

            int separatorY = curioListBoxY + listBoxHeight + groupSpacing / 2;
            int bimStartY = separatorY + separatorHeight + 8;
            int bimLabelY = bimStartY + groupTitleHeight + titleSpacing;
            int bimListBoxY = bimLabelY + labelHeight + labelSpacing;

            // CURIO group title
            curioDataGroupLabel.Left = (this.ClientSize.Width - curioDataGroupLabel.Width) / 2;
            curioDataGroupLabel.Top = curioStartY;

            // CURIO ListBox labels
            curioStagecraftListBoxLabel.Left = startX;
            curioStagecraftListBoxLabel.Top = curioLabelY;
            curioLeftPanelsListBoxLabel.Left = startX + listBoxWidth + listBoxSpacing;
            curioLeftPanelsListBoxLabel.Top = curioLabelY;
            curioRightPanelsListBoxLabel.Left = startX + (listBoxWidth + listBoxSpacing) * 2;
            curioRightPanelsListBoxLabel.Top = curioLabelY;

            // CURIO ListBoxes
            curioStagecraftListBox.Left = startX;
            curioStagecraftListBox.Top = curioListBoxY;
            curioStagecraftListBox.Width = listBoxWidth;
            curioStagecraftListBox.Height = listBoxHeight;

            curioLeftPanelsListBox.Left = curioLeftPanelsListBoxLabel.Left;
            curioLeftPanelsListBox.Top = curioListBoxY;
            curioLeftPanelsListBox.Width = listBoxWidth;
            curioLeftPanelsListBox.Height = listBoxHeight;

            curioRightPanelsListBox.Left = curioRightPanelsListBoxLabel.Left;
            curioRightPanelsListBox.Top = curioListBoxY;
            curioRightPanelsListBox.Width = listBoxWidth;
            curioRightPanelsListBox.Height = listBoxHeight;

            // place and scale the horizontal separating line dynamically
            groupSeparator.Left = startX;
            groupSeparator.Top = separatorY;
            groupSeparator.Width = availableWidth;
            groupSeparator.Height = separatorHeight;

            // BIM group title
            bimDataGroupLabel.Left = (this.ClientSize.Width - bimDataGroupLabel.Width) / 2;
            bimDataGroupLabel.Top = bimStartY;

            // BIM ListBox labels
            bimStagecraftListBoxLabel.Left = startX;
            bimStagecraftListBoxLabel.Top = bimLabelY;
            bimLeftPanelsListBoxLabel.Left = startX + listBoxWidth + listBoxSpacing;
            bimLeftPanelsListBoxLabel.Top = bimLabelY;
            bimRightPanelsListBoxLabel.Left = startX + (listBoxWidth + listBoxSpacing) * 2;
            bimRightPanelsListBoxLabel.Top = bimLabelY;

            // BIM ListBoxes
            bimStagecraftListBox.Left = startX;
            bimStagecraftListBox.Top = bimListBoxY;
            bimStagecraftListBox.Width = listBoxWidth;
            bimStagecraftListBox.Height = listBoxHeight;

            bimLeftPanelsListBox.Left = bimLeftPanelsListBoxLabel.Left;
            bimLeftPanelsListBox.Top = bimListBoxY;
            bimLeftPanelsListBox.Width = listBoxWidth;
            bimLeftPanelsListBox.Height = listBoxHeight;

            bimRightPanelsListBox.Left = bimRightPanelsListBoxLabel.Left;
            bimRightPanelsListBox.Top = bimListBoxY;
            bimRightPanelsListBox.Width = listBoxWidth;
            bimRightPanelsListBox.Height = listBoxHeight;


            // horizontally centering buttons "Load text file", "Load BIM file" and "Update BIM file" and keeping them one beside the other at the bottom of the form
            int buttonSpacing = 16; // distance between buttons
            int buttonsTotalWidth = loadTextButton.Width + buttonSpacing + loadBimButton.Width + buttonSpacing + updateBimButton.Width;
            int buttonsStartX = (this.ClientSize.Width - buttonsTotalWidth) / 2;
            int buttonsY = this.ClientSize.Height - loadTextButton.Height - 24; // 24 pixels from the bottom of the form

            loadTextButton.Left = buttonsStartX;
            loadTextButton.Top = buttonsY;
            
            loadBimButton.Left = buttonsStartX + loadTextButton.Width + buttonSpacing;
            loadBimButton.Top = buttonsY;

            updateBimButton.Left = loadBimButton.Left + loadBimButton.Width + buttonSpacing;
            updateBimButton.Top = buttonsY;
        }
    }
}