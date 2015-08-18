namespace ImageConverter.View.ViewClass
{
    partial class NameConflictsView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.conflictsNameListView = new System.Windows.Forms.ListView();
            this.nameConflictsLabel = new System.Windows.Forms.Label();
            this.ignoreButton = new System.Windows.Forms.Button();
            this.renameButton = new System.Windows.Forms.Button();
            this.replaceButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // conflictsNameListView
            // 
            this.conflictsNameListView.Location = new System.Drawing.Point(12, 25);
            this.conflictsNameListView.Name = "conflictsNameListView";
            this.conflictsNameListView.Size = new System.Drawing.Size(286, 96);
            this.conflictsNameListView.TabIndex = 0;
            this.conflictsNameListView.UseCompatibleStateImageBehavior = false;
            this.conflictsNameListView.View = System.Windows.Forms.View.List;
            // 
            // nameConflictsLabel
            // 
            this.nameConflictsLabel.AutoSize = true;
            this.nameConflictsLabel.Location = new System.Drawing.Point(12, 9);
            this.nameConflictsLabel.Name = "nameConflictsLabel";
            this.nameConflictsLabel.Size = new System.Drawing.Size(77, 13);
            this.nameConflictsLabel.TabIndex = 1;
            this.nameConflictsLabel.Text = "Name conflicts";
            // 
            // ignoreButton
            // 
            this.ignoreButton.Location = new System.Drawing.Point(223, 127);
            this.ignoreButton.Name = "ignoreButton";
            this.ignoreButton.Size = new System.Drawing.Size(75, 23);
            this.ignoreButton.TabIndex = 2;
            this.ignoreButton.Text = "Ignore";
            this.ignoreButton.UseVisualStyleBackColor = true;
            this.ignoreButton.Click += new System.EventHandler(this.IgnorePaths);
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(61, 127);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(75, 23);
            this.renameButton.TabIndex = 3;
            this.renameButton.Text = "Rename";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.RenamePaths);
            // 
            // replaceButton
            // 
            this.replaceButton.Location = new System.Drawing.Point(142, 127);
            this.replaceButton.Name = "replaceButton";
            this.replaceButton.Size = new System.Drawing.Size(75, 23);
            this.replaceButton.TabIndex = 4;
            this.replaceButton.Text = "Replace";
            this.replaceButton.UseVisualStyleBackColor = true;
            this.replaceButton.Click += new System.EventHandler(this.ReplacePaths);
            // 
            // NameConflictsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 163);
            this.Controls.Add(this.replaceButton);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.ignoreButton);
            this.Controls.Add(this.nameConflictsLabel);
            this.Controls.Add(this.conflictsNameListView);
            this.Name = "NameConflictsView";
            this.Text = "Name conflicts";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView conflictsNameListView;
        private System.Windows.Forms.Label nameConflictsLabel;
        private System.Windows.Forms.Button ignoreButton;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button replaceButton;
    }
}