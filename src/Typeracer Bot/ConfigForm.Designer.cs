namespace Typeracer_Bot
{
    partial class ConfigForm
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.enabledCB = new System.Windows.Forms.CheckBox();
            this.wpmNup = new System.Windows.Forms.NumericUpDown();
            this.infoLabel1 = new System.Windows.Forms.Label();
            this.instantModeCB = new System.Windows.Forms.CheckBox();
            this.autoraceCB = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.wpmNup)).BeginInit();
            this.SuspendLayout();
            // 
            // enabledCB
            // 
            this.enabledCB.AutoSize = true;
            this.enabledCB.Location = new System.Drawing.Point(81, 12);
            this.enabledCB.Name = "enabledCB";
            this.enabledCB.Size = new System.Drawing.Size(65, 17);
            this.enabledCB.TabIndex = 0;
            this.enabledCB.Text = "Enabled";
            this.enabledCB.UseVisualStyleBackColor = true;
            this.enabledCB.CheckedChanged += new System.EventHandler(this.EnabledCB_CheckedChanged);
            // 
            // wpmNup
            // 
            this.wpmNup.Location = new System.Drawing.Point(111, 59);
            this.wpmNup.Maximum = new decimal(new int[] {
            200,
            0,
            0,
            0});
            this.wpmNup.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.wpmNup.Name = "wpmNup";
            this.wpmNup.Size = new System.Drawing.Size(120, 20);
            this.wpmNup.TabIndex = 1;
            this.wpmNup.Value = new decimal(new int[] {
            80,
            0,
            0,
            0});
            this.wpmNup.ValueChanged += new System.EventHandler(this.WpmNup_ValueChanged);
            // 
            // infoLabel1
            // 
            this.infoLabel1.AutoSize = true;
            this.infoLabel1.Location = new System.Drawing.Point(12, 61);
            this.infoLabel1.Name = "infoLabel1";
            this.infoLabel1.Size = new System.Drawing.Size(93, 13);
            this.infoLabel1.TabIndex = 2;
            this.infoLabel1.Text = "Words per minute:";
            // 
            // instantModeCB
            // 
            this.instantModeCB.AutoSize = true;
            this.instantModeCB.Location = new System.Drawing.Point(81, 35);
            this.instantModeCB.Name = "instantModeCB";
            this.instantModeCB.Size = new System.Drawing.Size(88, 17);
            this.instantModeCB.TabIndex = 4;
            this.instantModeCB.Text = "Instant Mode";
            this.instantModeCB.UseVisualStyleBackColor = true;
            this.instantModeCB.CheckedChanged += new System.EventHandler(this.InstantModeCB_CheckedChanged);
            // 
            // autoraceCB
            // 
            this.autoraceCB.AutoSize = true;
            this.autoraceCB.Location = new System.Drawing.Point(81, 85);
            this.autoraceCB.Name = "autoraceCB";
            this.autoraceCB.Size = new System.Drawing.Size(69, 17);
            this.autoraceCB.TabIndex = 5;
            this.autoraceCB.Text = "Autorace";
            this.autoraceCB.UseVisualStyleBackColor = true;
            this.autoraceCB.CheckedChanged += new System.EventHandler(this.AutoraceCB_CheckedChanged);
            // 
            // ConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(242, 113);
            this.Controls.Add(this.autoraceCB);
            this.Controls.Add(this.instantModeCB);
            this.Controls.Add(this.infoLabel1);
            this.Controls.Add(this.wpmNup);
            this.Controls.Add(this.enabledCB);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "ConfigForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Typeracer Bot";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ConfigForm_FormClosing);
            this.Shown += new System.EventHandler(this.ConfigForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.wpmNup)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox enabledCB;
        private System.Windows.Forms.NumericUpDown wpmNup;
        private System.Windows.Forms.Label infoLabel1;
        private System.Windows.Forms.CheckBox instantModeCB;
        private System.Windows.Forms.CheckBox autoraceCB;
    }
}

