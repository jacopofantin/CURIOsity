using System.Windows.Forms;

namespace CURIOsity
{
    partial class CuriosityForm
    {
        // variable declaration

        // CURIO data group title
        private System.Windows.Forms.Label curioDataGroupLabel;

        // CURIO DataGridView titles
        private System.Windows.Forms.Label curioStagecraftDataGridViewLabel;
        private System.Windows.Forms.Label curioLeftPanelsDataGridViewLabel;
        private System.Windows.Forms.Label curioRightPanelsDataGridViewLabel;

        // CURIO DataGridView for viewing stagecraft equipment positions and left/right panel array apertures coming from CURIO
        private System.Windows.Forms.DataGridView curioStagecraftDataGridView;
        private System.Windows.Forms.DataGridView curioLeftPanelsDataGridView;
        private System.Windows.Forms.DataGridView curioRightPanelsDataGridView;

        // Horizontal separator between CURIO and BIM model data groups
        private System.Windows.Forms.Label groupSeparator;

        // BIM model data group title
        private System.Windows.Forms.Label bimDataGroupLabel;

        // BIM model DataGridView titles
        private System.Windows.Forms.Label bimStagecraftDataGridViewLabel;
        private System.Windows.Forms.Label bimLeftPanelsDataGridViewLabel;
        private System.Windows.Forms.Label bimRightPanelsDataGridViewLabel;

        // BIM model DataGridView for viewing stagecraft equipment positions and left/right panel array apertures coming from BIM model
        private System.Windows.Forms.DataGridView bimStagecraftDataGridView;
        private System.Windows.Forms.DataGridView bimLeftPanelsDataGridView;
        private System.Windows.Forms.DataGridView bimRightPanelsDataGridView;

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

            // CURIO DataGridView titles creation
            this.curioStagecraftDataGridViewLabel = new System.Windows.Forms.Label();
            this.curioLeftPanelsDataGridViewLabel = new System.Windows.Forms.Label();
            this.curioRightPanelsDataGridViewLabel = new System.Windows.Forms.Label();

            // CURIO DataGridView creation
            this.curioStagecraftDataGridView = new System.Windows.Forms.DataGridView();
            this.curioLeftPanelsDataGridView = new System.Windows.Forms.DataGridView();
            this.curioRightPanelsDataGridView = new System.Windows.Forms.DataGridView();

            // Horizontal separator creation
            this.groupSeparator = new System.Windows.Forms.Label();

            // BIM model data group title creation
            this.bimDataGroupLabel = new System.Windows.Forms.Label();

            // BIM model DataGridView titles creation
            this.bimStagecraftDataGridViewLabel = new System.Windows.Forms.Label();
            this.bimLeftPanelsDataGridViewLabel = new System.Windows.Forms.Label();
            this.bimRightPanelsDataGridViewLabel = new System.Windows.Forms.Label();

            // BIM model DataGridView creation
            this.bimStagecraftDataGridView = new System.Windows.Forms.DataGridView();
            this.bimLeftPanelsDataGridView = new System.Windows.Forms.DataGridView();
            this.bimRightPanelsDataGridView = new System.Windows.Forms.DataGridView();

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

            // title for CURIO stagecraft equipment DataGridView initialization
            this.curioStagecraftDataGridViewLabel.Location = new System.Drawing.Point(12, 56);
            this.curioStagecraftDataGridViewLabel.Size = new System.Drawing.Size(240, 20);
            this.curioStagecraftDataGridViewLabel.Text = "Stagecraft equipment positions";
            this.curioStagecraftDataGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for CURIO left panel array DataGridView initialization
            this.curioLeftPanelsDataGridViewLabel.Location = new System.Drawing.Point(270, 56);
            this.curioLeftPanelsDataGridViewLabel.Size = new System.Drawing.Size(240, 20);
            this.curioLeftPanelsDataGridViewLabel.Text = "Left panel array apertures";
            this.curioLeftPanelsDataGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for CURIO right panel array DataGridView initialization
            this.curioRightPanelsDataGridViewLabel.Location = new System.Drawing.Point(528, 56);
            this.curioRightPanelsDataGridViewLabel.Size = new System.Drawing.Size(240, 20);
            this.curioRightPanelsDataGridViewLabel.Text = "Right panel array apertures";
            this.curioRightPanelsDataGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // CURIO DataGridView for stagecraft equipment initialization
            this.curioStagecraftDataGridView.Location = new System.Drawing.Point(12, 76);
            this.curioStagecraftDataGridView.Size = new System.Drawing.Size(240, 120);
            this.curioStagecraftDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.curioStagecraftDataGridView.AllowUserToAddRows = false;
            this.curioStagecraftDataGridView.ColumnCount = 2;
            this.curioStagecraftDataGridView.Columns[0].Name = "Name";
            this.curioStagecraftDataGridView.Columns[0].Width = this.curioStagecraftDataGridView.Width / 2;
            this.curioStagecraftDataGridView.Columns[1].Name = "Value";
            this.curioStagecraftDataGridView.Columns[1].Width = this.curioStagecraftDataGridView.Width / 2;
            this.curioStagecraftDataGridView.Name = "curioStagecraftDataGridView";
            this.curioStagecraftDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView_ColumnHeaderMouseDown);
            this.curioStagecraftDataGridView.Sorted += new System.EventHandler(this.DataGridView_Sorted);

            // CURIO DataGridView for left panel arrays initialization
            this.curioLeftPanelsDataGridView.Location = new System.Drawing.Point(270, 76);
            this.curioLeftPanelsDataGridView.Size = new System.Drawing.Size(240, 120);
            this.curioLeftPanelsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.curioLeftPanelsDataGridView.AllowUserToAddRows = false;
            this.curioLeftPanelsDataGridView.ColumnCount = 2;
            this.curioLeftPanelsDataGridView.Columns[0].Name = "Name";
            this.curioLeftPanelsDataGridView.Columns[0].Width = this.curioLeftPanelsDataGridView.Width / 2;
            this.curioLeftPanelsDataGridView.Columns[1].Name = "Value";
            this.curioLeftPanelsDataGridView.Columns[1].Width = this.curioLeftPanelsDataGridView.Width / 2;
            this.curioLeftPanelsDataGridView.Name = "curioLeftPanelDataGridView";
            this.curioLeftPanelsDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView_ColumnHeaderMouseDown);
            this.curioLeftPanelsDataGridView.Sorted += new System.EventHandler(this.DataGridView_Sorted);

            // CURIO DataGridView for right panel arrays initialization
            this.curioRightPanelsDataGridView.Location = new System.Drawing.Point(528, 76);
            this.curioRightPanelsDataGridView.Size = new System.Drawing.Size(240, 120);
            this.curioRightPanelsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.curioRightPanelsDataGridView.AllowUserToAddRows = false;
            this.curioRightPanelsDataGridView.ColumnCount = 2;
            this.curioRightPanelsDataGridView.Columns[0].Name = "Name";
            this.curioRightPanelsDataGridView.Columns[0].Width = this.curioRightPanelsDataGridView.Width / 2;
            this.curioRightPanelsDataGridView.Columns[1].Name = "Value";
            this.curioRightPanelsDataGridView.Columns[1].Width = this.curioRightPanelsDataGridView.Width / 2;
            this.curioRightPanelsDataGridView.Name = "curioRightPanelsDataGridView";
            this.curioRightPanelsDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView_ColumnHeaderMouseDown);
            this.curioRightPanelsDataGridView.Sorted += new System.EventHandler(this.DataGridView_Sorted);

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

            // title for BIM model stagecraft equipment DataGridView initialization
            this.bimStagecraftDataGridViewLabel.Location = new System.Drawing.Point(12, 256);
            this.bimStagecraftDataGridViewLabel.Size = new System.Drawing.Size(240, 20);
            this.bimStagecraftDataGridViewLabel.Text = "Stagecraft equipment positions";
            this.bimStagecraftDataGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for BIM model left panel array DataGridView initialization
            this.bimLeftPanelsDataGridViewLabel.Location = new System.Drawing.Point(270, 256);
            this.bimLeftPanelsDataGridViewLabel.Size = new System.Drawing.Size(240, 20);
            this.bimLeftPanelsDataGridViewLabel.Text = "Left panel array apertures";
            this.bimLeftPanelsDataGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for BIM model right panel array DataGridView initialization
            this.bimRightPanelsDataGridViewLabel.Location = new System.Drawing.Point(528, 256);
            this.bimRightPanelsDataGridViewLabel.Size = new System.Drawing.Size(240, 20);
            this.bimRightPanelsDataGridViewLabel.Text = "Right panel array apertures";
            this.bimRightPanelsDataGridViewLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // BIM model DataGridView for stagecraft equipment initialization
            this.bimStagecraftDataGridView.Location = new System.Drawing.Point(12, 276);
            this.bimStagecraftDataGridView.Size = new System.Drawing.Size(240, 120);
            this.bimStagecraftDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.bimStagecraftDataGridView.AllowUserToAddRows = false;
            this.bimStagecraftDataGridView.ColumnCount = 2;
            this.bimStagecraftDataGridView.Columns[0].Name = "Name";
            this.bimStagecraftDataGridView.Columns[0].Width = this.bimStagecraftDataGridView.Width / 2;
            this.bimStagecraftDataGridView.Columns[1].Name = "Value";
            this.bimStagecraftDataGridView.Columns[1].Width = this.bimStagecraftDataGridView.Width / 2;
            this.bimStagecraftDataGridView.Name = "bimStagecraftDataGridView";
            this.bimStagecraftDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView_ColumnHeaderMouseDown);
            this.bimStagecraftDataGridView.Sorted += new System.EventHandler(this.DataGridView_Sorted);

            // BIM model DataGridView for left panel arrays initialization
            this.bimLeftPanelsDataGridView.Location = new System.Drawing.Point(270, 276);
            this.bimLeftPanelsDataGridView.Size = new System.Drawing.Size(240, 120);
            this.bimLeftPanelsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.bimLeftPanelsDataGridView.AllowUserToAddRows = false;
            this.bimLeftPanelsDataGridView.ColumnCount = 2;
            this.bimLeftPanelsDataGridView.Columns[0].Name = "Name";
            this.bimLeftPanelsDataGridView.Columns[0].Width = this.bimLeftPanelsDataGridView.Width / 2;
            this.bimLeftPanelsDataGridView.Columns[1].Name = "Value";
            this.bimLeftPanelsDataGridView.Columns[1].Width = this.bimLeftPanelsDataGridView.Width / 2;
            this.bimLeftPanelsDataGridView.Name = "bimLeftPanelDataGridView";
            this.bimLeftPanelsDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView_ColumnHeaderMouseDown);
            this.bimLeftPanelsDataGridView.Sorted += new System.EventHandler(this.DataGridView_Sorted);

            // BIM model DataGridView for right panel arrays initialization
            this.bimRightPanelsDataGridView.Location = new System.Drawing.Point(528, 276);
            this.bimRightPanelsDataGridView.Size = new System.Drawing.Size(240, 120);
            this.bimRightPanelsDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;
            this.bimRightPanelsDataGridView.AllowUserToAddRows = false;
            this.bimRightPanelsDataGridView.ColumnCount = 2;
            this.bimRightPanelsDataGridView.Columns[0].Name = "Name";
            this.bimRightPanelsDataGridView.Columns[0].Width = this.bimRightPanelsDataGridView.Width / 2;
            this.bimRightPanelsDataGridView.Columns[1].Name = "Value";
            this.bimRightPanelsDataGridView.Columns[1].Width = this.bimRightPanelsDataGridView.Width / 2;
            this.bimRightPanelsDataGridView.Name = "bimRightPanelDataGridView";
            this.bimRightPanelsDataGridView.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DataGridView_ColumnHeaderMouseDown);
            this.bimRightPanelsDataGridView.Sorted += new System.EventHandler(this.DataGridView_Sorted);

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
            this.Controls.Add(this.curioStagecraftDataGridViewLabel);
            this.Controls.Add(this.curioLeftPanelsDataGridViewLabel);
            this.Controls.Add(this.curioRightPanelsDataGridViewLabel);
            this.Controls.Add(this.curioStagecraftDataGridView);
            this.Controls.Add(this.curioLeftPanelsDataGridView);
            this.Controls.Add(this.curioRightPanelsDataGridView);
            this.Controls.Add(this.groupSeparator);
            this.Controls.Add(this.bimDataGroupLabel);
            this.Controls.Add(this.bimStagecraftDataGridViewLabel);
            this.Controls.Add(this.bimLeftPanelsDataGridViewLabel);
            this.Controls.Add(this.bimRightPanelsDataGridViewLabel);
            this.Controls.Add(this.bimStagecraftDataGridView);
            this.Controls.Add(this.bimLeftPanelsDataGridView);
            this.Controls.Add(this.bimRightPanelsDataGridView);
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

