namespace CURIOsity
{
    partial class CuriosityForm
    {
        // variable declaration

        // ListBox variables for viewing stagecraft equipment, left panel array and right panel array positions
        private System.Windows.Forms.ListBox stagecraftListBox;
        private System.Windows.Forms.ListBox leftPanelsListBox;
        private System.Windows.Forms.ListBox rightPanelsListBox;

        // ListBox titles
        private System.Windows.Forms.Label stagecraftListBoxLabel;
        private System.Windows.Forms.Label leftPanelsListBoxLabel;
        private System.Windows.Forms.Label rightPanelsListBoxLabel;

        // "Load text file" button variable
        private System.Windows.Forms.Button loadTextButton;

        // "Load BIM file" button variable
        private System.Windows.Forms.Button loadBimButton;

        private void InitializeComponent()
        {
            // element creation

            // ListBox creation
            this.stagecraftListBox = new System.Windows.Forms.ListBox();
            this.leftPanelsListBox = new System.Windows.Forms.ListBox();
            this.rightPanelsListBox = new System.Windows.Forms.ListBox();

            // ListBox titles creation
            this.stagecraftListBoxLabel = new System.Windows.Forms.Label();
            this.leftPanelsListBoxLabel = new System.Windows.Forms.Label();
            this.rightPanelsListBoxLabel = new System.Windows.Forms.Label();

            // "Load text file" button creation
            this.loadTextButton = new System.Windows.Forms.Button();
            this.SuspendLayout();

            // "Load BIM file" button creation
            this.loadBimButton = new System.Windows.Forms.Button();
            this.SuspendLayout();


            // element initialization

            // ListBox for stagecraft equipment initialization
            this.stagecraftListBox.Location = new System.Drawing.Point(12, 80);
            this.stagecraftListBox.Size = new System.Drawing.Size(240, 200);
            this.stagecraftListBox.Name = "stagecraftListBox";

            // ListBox for left panel arrays initialization
            this.leftPanelsListBox.Location = new System.Drawing.Point(270, 80);
            this.leftPanelsListBox.Size = new System.Drawing.Size(240, 200);
            this.leftPanelsListBox.Name = "leftPanelListBox";

            // ListBox for right panel arrays initialization
            this.rightPanelsListBox.Location = new System.Drawing.Point(528, 80);
            this.rightPanelsListBox.Size = new System.Drawing.Size(240, 200);
            this.rightPanelsListBox.Name = "rightPanelListBox";

            // title for stagecraft equipment ListBox initialization
            this.stagecraftListBoxLabel.Location = new System.Drawing.Point(12, 60);
            this.stagecraftListBoxLabel.Size = new System.Drawing.Size(240, 20);
            this.stagecraftListBoxLabel.Text = "Stagecraft equipment positions";
            this.stagecraftListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for left panel array ListBox initialization
            this.leftPanelsListBoxLabel.Location = new System.Drawing.Point(270, 60);
            this.leftPanelsListBoxLabel.Size = new System.Drawing.Size(240, 20);
            this.leftPanelsListBoxLabel.Text = "Left panel array positions";
            this.leftPanelsListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // title for right panel array ListBox initialization
            this.rightPanelsListBoxLabel.Location = new System.Drawing.Point(528, 60);
            this.rightPanelsListBoxLabel.Size = new System.Drawing.Size(240, 20);
            this.rightPanelsListBoxLabel.Text = "Right panel array positions";
            this.rightPanelsListBoxLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);

            // "Load text file" button initialization
            this.loadTextButton.Location = new System.Drawing.Point(12, 300); // below the ListBoxes
            this.loadTextButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadTextButton.Name = "loadTextButton";
            this.loadTextButton.Size = new System.Drawing.Size(120, 30);
            this.loadTextButton.TabIndex = 1;
            this.loadTextButton.Text = "Load text file";
            this.loadTextButton.UseVisualStyleBackColor = true;
            this.loadTextButton.Click += new System.EventHandler(this.LoadTextButton_OnClick);

            // "Load BIM file" button initialization
            this.loadBimButton.Location = new System.Drawing.Point(150, 300); // below the ListBoxes
            this.loadBimButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.loadBimButton.Name = "loadBimButton";
            this.loadBimButton.Size = new System.Drawing.Size(120, 30);
            this.loadBimButton.TabIndex = 2;
            this.loadBimButton.Text = "Load BIM file";
            this.loadBimButton.UseVisualStyleBackColor = true;
            this.loadBimButton.Click += new System.EventHandler(this.LoadBimButton_OnClick);

            // Form initialization
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.stagecraftListBox);
            this.Controls.Add(this.leftPanelsListBox);
            this.Controls.Add(this.rightPanelsListBox);
            this.Controls.Add(this.stagecraftListBoxLabel);
            this.Controls.Add(this.leftPanelsListBoxLabel);
            this.Controls.Add(this.rightPanelsListBoxLabel);
            this.Controls.Add(this.loadTextButton);
            this.Controls.Add(this.loadBimButton);
            this.Name = "CURIOsity";
            this.Text = "CURIOsity";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}

