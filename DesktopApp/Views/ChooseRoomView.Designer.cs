
namespace DesktopApp.Views
{
    partial class ChooseRoomView
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
            this.roomsGrid = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.roomsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // roomsGrid
            // 
            this.roomsGrid.BackgroundColor = System.Drawing.Color.White;
            this.roomsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomsGrid.Location = new System.Drawing.Point(0, 0);
            this.roomsGrid.Name = "roomsGrid";
            this.roomsGrid.RowHeadersWidth = 51;
            this.roomsGrid.RowTemplate.Height = 24;
            this.roomsGrid.Size = new System.Drawing.Size(624, 343);
            this.roomsGrid.TabIndex = 0;
            this.roomsGrid.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.roomsGrid_CellMouseDoubleClick);
            // 
            // ChooseRoomView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 345);
            this.Controls.Add(this.roomsGrid);
            this.Name = "ChooseRoomView";
            this.Text = "ChooseRoomView";
            ((System.ComponentModel.ISupportInitialize)(this.roomsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView roomsGrid;
    }
}