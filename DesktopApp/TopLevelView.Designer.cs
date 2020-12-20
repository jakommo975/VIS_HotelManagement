
namespace DesktopApp
{
    partial class TopLevelView
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.currentUserLabel = new System.Windows.Forms.Label();
            this.contentPanel = new System.Windows.Forms.Panel();
            this.guestsBtn = new System.Windows.Forms.Button();
            this.roomsBtn = new System.Windows.Forms.Button();
            this.bookingsBtn = new System.Windows.Forms.Button();
            this.menuBtn = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.contentPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.menuBtn);
            this.panel1.Controls.Add(this.currentUserLabel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1258, 72);
            this.panel1.TabIndex = 0;
            // 
            // currentUserLabel
            // 
            this.currentUserLabel.AutoSize = true;
            this.currentUserLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.currentUserLabel.Location = new System.Drawing.Point(265, 21);
            this.currentUserLabel.Name = "currentUserLabel";
            this.currentUserLabel.Size = new System.Drawing.Size(79, 29);
            this.currentUserLabel.TabIndex = 0;
            this.currentUserLabel.Text = "label1";
            // 
            // contentPanel
            // 
            this.contentPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.contentPanel.Controls.Add(this.guestsBtn);
            this.contentPanel.Controls.Add(this.roomsBtn);
            this.contentPanel.Controls.Add(this.bookingsBtn);
            this.contentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.contentPanel.Location = new System.Drawing.Point(0, 72);
            this.contentPanel.Name = "contentPanel";
            this.contentPanel.Size = new System.Drawing.Size(1258, 728);
            this.contentPanel.TabIndex = 1;
            // 
            // guestsBtn
            // 
            this.guestsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.guestsBtn.Location = new System.Drawing.Point(511, 406);
            this.guestsBtn.Name = "guestsBtn";
            this.guestsBtn.Size = new System.Drawing.Size(253, 90);
            this.guestsBtn.TabIndex = 2;
            this.guestsBtn.Text = "Guests";
            this.guestsBtn.UseVisualStyleBackColor = true;
            this.guestsBtn.Click += new System.EventHandler(this.guestsBtn_Click);
            // 
            // roomsBtn
            // 
            this.roomsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.roomsBtn.Location = new System.Drawing.Point(511, 298);
            this.roomsBtn.Name = "roomsBtn";
            this.roomsBtn.Size = new System.Drawing.Size(253, 90);
            this.roomsBtn.TabIndex = 1;
            this.roomsBtn.Text = "Rooms";
            this.roomsBtn.UseVisualStyleBackColor = true;
            this.roomsBtn.Click += new System.EventHandler(this.roomsBtn_Click);
            // 
            // bookingsBtn
            // 
            this.bookingsBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.bookingsBtn.Location = new System.Drawing.Point(511, 193);
            this.bookingsBtn.Name = "bookingsBtn";
            this.bookingsBtn.Size = new System.Drawing.Size(253, 90);
            this.bookingsBtn.TabIndex = 0;
            this.bookingsBtn.Text = "Bookings";
            this.bookingsBtn.UseVisualStyleBackColor = true;
            this.bookingsBtn.Click += new System.EventHandler(this.bookingsBtn_Click);
            // 
            // menuBtn
            // 
            this.menuBtn.Location = new System.Drawing.Point(34, 17);
            this.menuBtn.Name = "menuBtn";
            this.menuBtn.Size = new System.Drawing.Size(130, 44);
            this.menuBtn.TabIndex = 1;
            this.menuBtn.Text = "Menu";
            this.menuBtn.UseVisualStyleBackColor = true;
            this.menuBtn.Click += new System.EventHandler(this.menuBtn_Click);
            // 
            // TopLevelView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 800);
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.panel1);
            this.Name = "TopLevelView";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.contentPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label currentUserLabel;
        private System.Windows.Forms.Panel contentPanel;
        private System.Windows.Forms.Button guestsBtn;
        private System.Windows.Forms.Button roomsBtn;
        private System.Windows.Forms.Button bookingsBtn;
        private System.Windows.Forms.Button menuBtn;
    }
}

