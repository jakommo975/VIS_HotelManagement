
namespace DesktopApp.Views
{
    partial class RoomsView
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
            this.label1 = new System.Windows.Forms.Label();
            this.addRoomBtn = new System.Windows.Forms.Button();
            this.addRoomTypeBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.roomTypesGrid = new System.Windows.Forms.DataGridView();
            this.roomLabelInput = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.roomTypeInput = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.typeNameInput = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.capacityInput = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.descriptionInput = new System.Windows.Forms.RichTextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.priceInput = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.roomsGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypesGrid)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityInput)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceInput)).BeginInit();
            this.SuspendLayout();
            // 
            // roomsGrid
            // 
            this.roomsGrid.BackgroundColor = System.Drawing.Color.White;
            this.roomsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomsGrid.Location = new System.Drawing.Point(49, 325);
            this.roomsGrid.Name = "roomsGrid";
            this.roomsGrid.RowHeadersWidth = 51;
            this.roomsGrid.RowTemplate.Height = 24;
            this.roomsGrid.Size = new System.Drawing.Size(548, 344);
            this.roomsGrid.TabIndex = 1;
            this.roomsGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomsGrid_CellDoubleClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(44, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Rooms";
            // 
            // addRoomBtn
            // 
            this.addRoomBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addRoomBtn.Location = new System.Drawing.Point(179, 157);
            this.addRoomBtn.Name = "addRoomBtn";
            this.addRoomBtn.Size = new System.Drawing.Size(120, 40);
            this.addRoomBtn.TabIndex = 3;
            this.addRoomBtn.Text = "Add Room";
            this.addRoomBtn.UseVisualStyleBackColor = true;
            this.addRoomBtn.Click += new System.EventHandler(this.addRoomBtn_Click);
            // 
            // addRoomTypeBtn
            // 
            this.addRoomTypeBtn.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.addRoomTypeBtn.Location = new System.Drawing.Point(176, 157);
            this.addRoomTypeBtn.Name = "addRoomTypeBtn";
            this.addRoomTypeBtn.Size = new System.Drawing.Size(184, 40);
            this.addRoomTypeBtn.TabIndex = 6;
            this.addRoomTypeBtn.Text = "Add Room Type";
            this.addRoomTypeBtn.UseVisualStyleBackColor = true;
            this.addRoomTypeBtn.Click += new System.EventHandler(this.addRoomTypeBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(645, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(151, 29);
            this.label2.TabIndex = 5;
            this.label2.Text = "Room Types";
            // 
            // roomTypesGrid
            // 
            this.roomTypesGrid.BackgroundColor = System.Drawing.Color.White;
            this.roomTypesGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.roomTypesGrid.Location = new System.Drawing.Point(650, 325);
            this.roomTypesGrid.Name = "roomTypesGrid";
            this.roomTypesGrid.RowHeadersWidth = 51;
            this.roomTypesGrid.RowTemplate.Height = 24;
            this.roomTypesGrid.Size = new System.Drawing.Size(566, 344);
            this.roomTypesGrid.TabIndex = 4;
            this.roomTypesGrid.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.roomTypesGrid_CellDoubleClick);
            // 
            // roomLabelInput
            // 
            this.roomLabelInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.roomLabelInput.Location = new System.Drawing.Point(16, 43);
            this.roomLabelInput.Name = "roomLabelInput";
            this.roomLabelInput.Size = new System.Drawing.Size(221, 30);
            this.roomLabelInput.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(13, 19);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "Room Label";
            // 
            // roomTypeInput
            // 
            this.roomTypeInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.roomTypeInput.FormattingEnabled = true;
            this.roomTypeInput.Location = new System.Drawing.Point(273, 40);
            this.roomTypeInput.Name = "roomTypeInput";
            this.roomTypeInput.Size = new System.Drawing.Size(239, 33);
            this.roomTypeInput.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(270, 19);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 17);
            this.label4.TabIndex = 10;
            this.label4.Text = "Room Type";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.roomLabelInput);
            this.panel1.Controls.Add(this.addRoomBtn);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.roomTypeInput);
            this.panel1.Location = new System.Drawing.Point(49, 100);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(548, 212);
            this.panel1.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(44, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(134, 31);
            this.label5.TabIndex = 12;
            this.label5.Text = "New Room";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.priceInput);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.descriptionInput);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.capacityInput);
            this.panel2.Controls.Add(this.typeNameInput);
            this.panel2.Controls.Add(this.addRoomTypeBtn);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Location = new System.Drawing.Point(650, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(566, 212);
            this.panel2.TabIndex = 12;
            // 
            // typeNameInput
            // 
            this.typeNameInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.typeNameInput.Location = new System.Drawing.Point(20, 40);
            this.typeNameInput.Name = "typeNameInput";
            this.typeNameInput.Size = new System.Drawing.Size(221, 30);
            this.typeNameInput.TabIndex = 7;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(17, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 8;
            this.label7.Text = "Name";
            // 
            // capacityInput
            // 
            this.capacityInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.capacityInput.Location = new System.Drawing.Point(161, 104);
            this.capacityInput.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.capacityInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.capacityInput.Name = "capacityInput";
            this.capacityInput.Size = new System.Drawing.Size(80, 30);
            this.capacityInput.TabIndex = 9;
            this.capacityInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 84);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(91, 17);
            this.label6.TabIndex = 10;
            this.label6.Text = "Max Capacity";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(645, 66);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 25);
            this.label8.TabIndex = 13;
            this.label8.Text = "New Room Type";
            // 
            // descriptionInput
            // 
            this.descriptionInput.Location = new System.Drawing.Point(255, 38);
            this.descriptionInput.Name = "descriptionInput";
            this.descriptionInput.Size = new System.Drawing.Size(288, 96);
            this.descriptionInput.TabIndex = 14;
            this.descriptionInput.Text = "";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(252, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(79, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Description";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(17, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(129, 21);
            this.label10.TabIndex = 12;
            this.label10.Text = "Price Per Night";
            // 
            // priceInput
            // 
            this.priceInput.DecimalPlaces = 2;
            this.priceInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.priceInput.Location = new System.Drawing.Point(20, 104);
            this.priceInput.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.priceInput.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.priceInput.Name = "priceInput";
            this.priceInput.Size = new System.Drawing.Size(125, 30);
            this.priceInput.TabIndex = 16;
            this.priceInput.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(46, 681);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(359, 21);
            this.label11.TabIndex = 14;
            this.label11.Text = "* to show room detail double click on the row";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(652, 681);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(403, 21);
            this.label12.TabIndex = 15;
            this.label12.Text = "* to show  room type detail double click on the row";
            // 
            // RoomsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1273, 722);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.roomTypesGrid);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.roomsGrid);
            this.Name = "RoomsView";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.roomsGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.roomTypesGrid)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.capacityInput)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.priceInput)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView roomsGrid;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addRoomBtn;
        private System.Windows.Forms.Button addRoomTypeBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView roomTypesGrid;
        private System.Windows.Forms.TextBox roomLabelInput;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox roomTypeInput;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown capacityInput;
        private System.Windows.Forms.TextBox typeNameInput;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.RichTextBox descriptionInput;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.NumericUpDown priceInput;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
    }
}