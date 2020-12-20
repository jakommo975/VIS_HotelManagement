
namespace DesktopApp.Views
{
    partial class GuestsView
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
            this.label5 = new System.Windows.Forms.Label();
            this.guestsGrid = new System.Windows.Forms.DataGridView();
            this.exportBtn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.guestsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(61, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 31);
            this.label5.TabIndex = 18;
            this.label5.Text = "Guests";
            // 
            // guestsGrid
            // 
            this.guestsGrid.BackgroundColor = System.Drawing.Color.White;
            this.guestsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.guestsGrid.Location = new System.Drawing.Point(67, 93);
            this.guestsGrid.Name = "guestsGrid";
            this.guestsGrid.RowHeadersWidth = 51;
            this.guestsGrid.RowTemplate.Height = 24;
            this.guestsGrid.Size = new System.Drawing.Size(1090, 520);
            this.guestsGrid.TabIndex = 16;
            // 
            // exportBtn
            // 
            this.exportBtn.Location = new System.Drawing.Point(67, 640);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(188, 50);
            this.exportBtn.TabIndex = 19;
            this.exportBtn.Text = "Export to XML";
            this.exportBtn.UseVisualStyleBackColor = true;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click_1);
            // 
            // GuestsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1268, 717);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.guestsGrid);
            this.Name = "GuestsView";
            this.Text = "GuestsView";
            ((System.ComponentModel.ISupportInitialize)(this.guestsGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView guestsGrid;
        private System.Windows.Forms.Button exportBtn;
    }
}