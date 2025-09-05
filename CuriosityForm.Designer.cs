using System.Windows.Forms;

namespace CURIOsity
{
    partial class CuriosityForm
    {
        // variable declaration

        // CURIO data group title
        private System.Windows.Forms.Label curioDataGroupLabel;

        // CURIO ListBox titles
        private System.Windows.Forms.Label curioStagecraftListBoxLabel;
        private System.Windows.Forms.Label curioLeftPanelsListBoxLabel;
        private System.Windows.Forms.Label curioRightPanelsListBoxLabel;

        // CURIO ListBox for viewing stagecraft equipment positions and left/right panel array apertures coming from CURIO
        private System.Windows.Forms.ListBox curioStagecraftListBox;
        private System.Windows.Forms.ListBox curioLeftPanelsListBox;
        private System.Windows.Forms.ListBox curioRightPanelsListBox;

        // Horizontal separator between CURIO and BIM model data groups
        private System.Windows.Forms.Label groupSeparator;

        // BIM model data group title
        private System.Windows.Forms.Label bimDataGroupLabel;

        // BIM model ListBox titles
        private System.Windows.Forms.Label bimStagecraftListBoxLabel;
        private System.Windows.Forms.Label bimLeftPanelsListBoxLabel;
        private System.Windows.Forms.Label bimRightPanelsListBoxLabel;

        // BIM model ListBox for viewing stagecraft equipment positions and left/right panel array apertures coming from BIM model
        private System.Windows.Forms.ListBox bimStagecraftListBox;
        private System.Windows.Forms.ListBox bimLeftPanelsListBox;
        private System.Windows.Forms.ListBox bimRightPanelsListBox;

        // "Load text file" button
        private System.Windows.Forms.Button loadTextButton;

        // "Load BIM file" button
        private System.Windows.Forms.Button loadBimButton;

        // "Update BIM file" button
        private System.Windows.Forms.Button updateBimButton;

        private void InitializeComponent()
        {
            // element creation

            // CURIO data group title creation
            this.curioDataGroupLabel = new System.Windows.Forms.Label();

            // CURIO ListBox titles creation
            this.curioStagecraftListBoxLabel = new System.Windows.Forms.Label();
            this.curioLeftPanelsListBoxLabel = new System.Windows.Forms.Label();
            this.curioRightPanelsListBoxLabel = new System.Windows.Forms.Label();

            // CURIO ListBox creation
            this.curioStagecraftListBox = new System.Windows.Forms.ListBox();
            this.curioLeftPanelsListBox = new System.Windows.Forms.ListBox();
            this.curioRightPanelsListBox = new System.Windows.Forms.ListBox();

            // Horizontal separator creation
            this.groupSeparator = new System.Windows.Forms.Label();

            // BIM model data group title creation
            this.bimDataGroupLabel = new System.Windows.Forms.Label();

            // BIM model ListBox titles creation
            this.bimStagecraftListBoxLabel = new System.Windows.Forms.Label();
            this.bimLeftPanelsListBoxLabel = new System.Windows.Forms.Label();
            this.bimRightPanelsListBoxLabel = new System.Windows.Forms.Label();

            // BIM model ListBox creation
            this.bimStagecraftListBox = new System.Windows.Forms.ListBox();
            this.bimLeftPanelsListBox = new System.Windows.Forms.ListBox();
            this.bimRightPanelsListBox = new System.Windows.Forms.ListBox();

            // "Load text file" button creation
            this.loadTextButton = new System.Windows.Forms.Button();

            // "Load BIM file" button creation
            this.loadBimButton = new System.Windows.Forms.Button();

            // "Update BIM file" button creation
            this.updateBimButton = new System.Windows.Forms.Button();

            this.SuspendLayout();


            // element initialization

            // CURIO data group title initialization
            this.curioDataGroupLabel.Size = new System.Drawing.Size(300, 30);
            this.curioDataGroupLabel.Location = new System.Drawing.Point((this.ClientSize.Width - 300) / 2, 16);
            this.curioDataGroupLabel.Text = "CURIO data";
            this.curioDataGroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.curioDataGroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.curioDataGroupLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // title for CURIO stagecraft equipment ListBox initialization
            this.curioStagecraftListBoxLabel.Location = new System.Drawing.Point(12, 56);
            this.curioStagecraftListBoxLabel.Size = new System.Drawing.Size(240, 20);
            this.curioStagecraftListBoxLabel.Text = "Stagecraft equipment positions";
            this.curioStagecraftListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for CURIO left panel array ListBox initialization
            this.curioLeftPanelsListBoxLabel.Location = new System.Drawing.Point(270, 56);
            this.curioLeftPanelsListBoxLabel.Size = new System.Drawing.Size(240, 20);
            this.curioLeftPanelsListBoxLabel.Text = "Left panel array apertures";
            this.curioLeftPanelsListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for CURIO right panel array ListBox initialization
            this.curioRightPanelsListBoxLabel.Location = new System.Drawing.Point(528, 56);
            this.curioRightPanelsListBoxLabel.Size = new System.Drawing.Size(240, 20);
            this.curioRightPanelsListBoxLabel.Text = "Right panel array apertures";
            this.curioRightPanelsListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // CURIO ListBox for stagecraft equipment initialization
            this.curioStagecraftListBox.Location = new System.Drawing.Point(12, 76);
            this.curioStagecraftListBox.Size = new System.Drawing.Size(240, 120);
            this.curioStagecraftListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.curioStagecraftListBox.Name = "curioStagecraftListBox";

            // CURIO ListBox for left panel arrays initialization
            this.curioLeftPanelsListBox.Location = new System.Drawing.Point(270, 76);
            this.curioLeftPanelsListBox.Size = new System.Drawing.Size(240, 120);
            this.curioLeftPanelsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.curioLeftPanelsListBox.Name = "curioLeftPanelListBox";

            // CURIO ListBox for right panel arrays initialization
            this.curioRightPanelsListBox.Location = new System.Drawing.Point(528, 76);
            this.curioRightPanelsListBox.Size = new System.Drawing.Size(240, 120);
            this.curioRightPanelsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.curioRightPanelsListBox.Name = "curioRightPanelListBox";

            // Horizontal separator initialization
            this.groupSeparator.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.groupSeparator.Location = new System.Drawing.Point(12, 206);
            this.groupSeparator.Size = new System.Drawing.Size(776, 2);
            this.groupSeparator.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            // BIM model data group title initialization
            this.bimDataGroupLabel.Size = new System.Drawing.Size(300, 30);
            this.bimDataGroupLabel.Location = new System.Drawing.Point((this.ClientSize.Width - 300) / 2, 216);
            this.bimDataGroupLabel.Text = "BIM model data";
            this.bimDataGroupLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.bimDataGroupLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bimDataGroupLabel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;

            // title for BIM model stagecraft equipment ListBox initialization
            this.bimStagecraftListBoxLabel.Location = new System.Drawing.Point(12, 256);
            this.bimStagecraftListBoxLabel.Size = new System.Drawing.Size(240, 20);
            this.bimStagecraftListBoxLabel.Text = "Stagecraft equipment positions";
            this.bimStagecraftListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for BIM model left panel array ListBox initialization
            this.bimLeftPanelsListBoxLabel.Location = new System.Drawing.Point(270, 256);
            this.bimLeftPanelsListBoxLabel.Size = new System.Drawing.Size(240, 20);
            this.bimLeftPanelsListBoxLabel.Text = "Left panel array apertures";
            this.bimLeftPanelsListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for BIM model right panel array ListBox initialization
            this.bimRightPanelsListBoxLabel.Location = new System.Drawing.Point(528, 256);
            this.bimRightPanelsListBoxLabel.Size = new System.Drawing.Size(240, 20);
            this.bimRightPanelsListBoxLabel.Text = "Right panel array apertures";
            this.bimRightPanelsListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // BIM model ListBox for stagecraft equipment initialization
            this.bimStagecraftListBox.Location = new System.Drawing.Point(12, 276);
            this.bimStagecraftListBox.Size = new System.Drawing.Size(240, 120);
            this.bimStagecraftListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.bimStagecraftListBox.Name = "bimStagecraftListBox";

            // BIM model ListBox for left panel arrays initialization
            this.bimLeftPanelsListBox.Location = new System.Drawing.Point(270, 276);
            this.bimLeftPanelsListBox.Size = new System.Drawing.Size(240, 120);
            this.bimLeftPanelsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.bimLeftPanelsListBox.Name = "bimLeftPanelListBox";

            // BIM model ListBox for right panel arrays initialization
            this.bimRightPanelsListBox.Location = new System.Drawing.Point(528, 276);
            this.bimRightPanelsListBox.Size = new System.Drawing.Size(240, 120);
            this.bimRightPanelsListBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.bimRightPanelsListBox.Name = "bimRightPanelListBox";

            // "Load text file" button initialization
            this.loadTextButton.Location = new System.Drawing.Point(172, 410);
            this.loadTextButton.Anchor = AnchorStyles.Bottom;
            this.loadTextButton.Name = "loadTextButton";
            this.loadTextButton.Size = new System.Drawing.Size(120, 30);
            this.loadTextButton.TabIndex = 1;
            this.loadTextButton.Text = "Load text file";
            this.loadTextButton.UseVisualStyleBackColor = true;
            this.loadTextButton.Click += new System.EventHandler(this.LoadTextButton_OnClick);

            // "Load BIM file" button initialization
            this.loadBimButton.Location = new System.Drawing.Point(340, 410);
            this.loadBimButton.Anchor = AnchorStyles.Bottom;
            this.loadBimButton.Name = "loadBimButton";
            this.loadBimButton.Size = new System.Drawing.Size(120, 30);
            this.loadBimButton.TabIndex = 2;
            this.loadBimButton.Text = "Load BIM file";
            this.loadBimButton.UseVisualStyleBackColor = true;
            this.loadBimButton.Click += new System.EventHandler(this.LoadBimButton_OnClick);

            // "Update BIM file" button initialization
            this.updateBimButton.Location = new System.Drawing.Point(508, 410);
            this.updateBimButton.Anchor = AnchorStyles.Bottom;
            this.updateBimButton.Name = "updateBimButton";
            this.updateBimButton.Size = new System.Drawing.Size(120, 30);
            this.updateBimButton.TabIndex = 3;
            this.updateBimButton.Text = "Update BIM file";
            this.updateBimButton.UseVisualStyleBackColor = true;
            this.updateBimButton.Click += new System.EventHandler(this.UpdateBimButton_OnClick);

            // Form initialization
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.curioDataGroupLabel);
            this.Controls.Add(this.curioStagecraftListBoxLabel);
            this.Controls.Add(this.curioLeftPanelsListBoxLabel);
            this.Controls.Add(this.curioRightPanelsListBoxLabel);
            this.Controls.Add(this.curioStagecraftListBox);
            this.Controls.Add(this.curioLeftPanelsListBox);
            this.Controls.Add(this.curioRightPanelsListBox);
            this.Controls.Add(this.groupSeparator);
            this.Controls.Add(this.bimDataGroupLabel);
            this.Controls.Add(this.bimStagecraftListBoxLabel);
            this.Controls.Add(this.bimLeftPanelsListBoxLabel);
            this.Controls.Add(this.bimRightPanelsListBoxLabel);
            this.Controls.Add(this.bimStagecraftListBox);
            this.Controls.Add(this.bimLeftPanelsListBox);
            this.Controls.Add(this.bimRightPanelsListBox);
            this.Controls.Add(this.loadTextButton);
            this.Controls.Add(this.loadBimButton);
            this.Controls.Add(this.updateBimButton);
            this.Name = "CURIOsity";
            this.Text = "CURIOsity";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

