
namespace DesktopApp.Views
{
    partial class BookingDetailView
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
            this.noteInput = new System.Windows.Forms.RichTextBox();
            this.guestLabel = new System.Windows.Forms.Label();
            this.statusInput = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.roomLabel = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.durationLabel = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.emailLabel = new System.Windows.Forms.Label();
            this.phoneLabel = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.guestNameLabel = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.totalPriceLabel = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.acommTotalLabel = new System.Windows.Forms.Label();
            this.serviceFeeLabel = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.priecPerNightLabel = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.issueKeyBtn = new System.Windows.Forms.Button();
            this.changeRoomBtn = new System.Windows.Forms.Button();
            this.startDatelabel = new System.Windows.Forms.Label();
            this.endDateLabel = new System.Windows.Forms.Label();
            this.numberofGuestsLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.numberofGuestsLabel);
            this.panel1.Controls.Add(this.endDateLabel);
            this.panel1.Controls.Add(this.startDatelabel);
            this.panel1.Controls.Add(this.changeRoomBtn);
            this.panel1.Controls.Add(this.noteInput);
            this.panel1.Controls.Add(this.guestLabel);
            this.panel1.Controls.Add(this.statusInput);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.roomLabel);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.durationLabel);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(72, 110);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(572, 489);
            this.panel1.TabIndex = 0;
            // 
            // noteInput
            // 
            this.noteInput.Location = new System.Drawing.Point(147, 316);
            this.noteInput.Name = "noteInput";
            this.noteInput.ReadOnly = true;
            this.noteInput.Size = new System.Drawing.Size(385, 146);
            this.noteInput.TabIndex = 16;
            this.noteInput.Text = "";
            // 
            // guestLabel
            // 
            this.guestLabel.AutoSize = true;
            this.guestLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.guestLabel.Location = new System.Drawing.Point(142, 221);
            this.guestLabel.Name = "guestLabel";
            this.guestLabel.Size = new System.Drawing.Size(151, 25);
            this.guestLabel.TabIndex = 15;
            this.guestLabel.Text = "Jakub Bystrican";
            // 
            // statusInput
            // 
            this.statusInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.statusInput.FormattingEnabled = true;
            this.statusInput.Location = new System.Drawing.Point(147, 18);
            this.statusInput.Name = "statusInput";
            this.statusInput.Size = new System.Drawing.Size(250, 33);
            this.statusInput.TabIndex = 11;
            this.statusInput.SelectedIndexChanged += new System.EventHandler(this.statusInput_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label11.Location = new System.Drawing.Point(61, 312);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(59, 25);
            this.label11.TabIndex = 10;
            this.label11.Text = "Note:";
            // 
            // roomLabel
            // 
            this.roomLabel.AutoSize = true;
            this.roomLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.roomLabel.Location = new System.Drawing.Point(142, 177);
            this.roomLabel.Name = "roomLabel";
            this.roomLabel.Size = new System.Drawing.Size(101, 25);
            this.roomLabel.TabIndex = 9;
            this.roomLabel.Text = "Room 214";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label7.Location = new System.Drawing.Point(40, 265);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 25);
            this.label7.TabIndex = 6;
            this.label7.Text = "Guests:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label6.Location = new System.Drawing.Point(51, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 25);
            this.label6.TabIndex = 5;
            this.label6.Text = "Room:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label5.Location = new System.Drawing.Point(24, 221);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(96, 25);
            this.label5.TabIndex = 4;
            this.label5.Text = "Made By:";
            // 
            // durationLabel
            // 
            this.durationLabel.AutoSize = true;
            this.durationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.durationLabel.Location = new System.Drawing.Point(296, 126);
            this.durationLabel.Name = "durationLabel";
            this.durationLabel.Size = new System.Drawing.Size(129, 25);
            this.durationLabel.TabIndex = 3;
            this.durationLabel.Text = "Total 6 nights";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label3.Location = new System.Drawing.Point(41, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(87, 25);
            this.label3.TabIndex = 2;
            this.label3.Text = "Leaving:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label2.Location = new System.Drawing.Point(44, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Arriving:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label1.Location = new System.Drawing.Point(54, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Status:";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.emailLabel);
            this.panel2.Controls.Add(this.phoneLabel);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.label17);
            this.panel2.Controls.Add(this.guestNameLabel);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Location = new System.Drawing.Point(679, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(478, 219);
            this.panel2.TabIndex = 15;
            // 
            // emailLabel
            // 
            this.emailLabel.AutoSize = true;
            this.emailLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.emailLabel.Location = new System.Drawing.Point(149, 74);
            this.emailLabel.Name = "emailLabel";
            this.emailLabel.Size = new System.Drawing.Size(184, 25);
            this.emailLabel.TabIndex = 5;
            this.emailLabel.Text = "jh.depp@gmail.com";
            // 
            // phoneLabel
            // 
            this.phoneLabel.AutoSize = true;
            this.phoneLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.phoneLabel.Location = new System.Drawing.Point(137, 122);
            this.phoneLabel.Name = "phoneLabel";
            this.phoneLabel.Size = new System.Drawing.Size(156, 25);
            this.phoneLabel.TabIndex = 4;
            this.phoneLabel.Text = "+421987487952";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label18.Location = new System.Drawing.Point(55, 74);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(66, 25);
            this.label18.TabIndex = 3;
            this.label18.Text = "Email:";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label17.Location = new System.Drawing.Point(47, 122);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(75, 25);
            this.label17.TabIndex = 2;
            this.label17.Text = "Phone:";
            // 
            // guestNameLabel
            // 
            this.guestNameLabel.AutoSize = true;
            this.guestNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.guestNameLabel.Location = new System.Drawing.Point(149, 26);
            this.guestNameLabel.Name = "guestNameLabel";
            this.guestNameLabel.Size = new System.Drawing.Size(129, 25);
            this.guestNameLabel.TabIndex = 1;
            this.guestNameLabel.Text = "Johnny Depp";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label15.Location = new System.Drawing.Point(25, 26);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(106, 25);
            this.label15.TabIndex = 0;
            this.label15.Text = "Full Name:";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.totalPriceLabel);
            this.panel3.Controls.Add(this.label29);
            this.panel3.Controls.Add(this.label28);
            this.panel3.Controls.Add(this.label27);
            this.panel3.Controls.Add(this.acommTotalLabel);
            this.panel3.Controls.Add(this.serviceFeeLabel);
            this.panel3.Controls.Add(this.label26);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.priecPerNightLabel);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Location = new System.Drawing.Point(680, 394);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(478, 205);
            this.panel3.TabIndex = 16;
            // 
            // totalPriceLabel
            // 
            this.totalPriceLabel.AutoSize = true;
            this.totalPriceLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.totalPriceLabel.Location = new System.Drawing.Point(219, 153);
            this.totalPriceLabel.Name = "totalPriceLabel";
            this.totalPriceLabel.Size = new System.Drawing.Size(97, 25);
            this.totalPriceLabel.TabIndex = 15;
            this.totalPriceLabel.Text = "195 euro";
            // 
            // label29
            // 
            this.label29.AutoSize = true;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label29.Location = new System.Drawing.Point(109, 153);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(68, 25);
            this.label29.TabIndex = 14;
            this.label29.Text = "Total:";
            // 
            // label28
            // 
            this.label28.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label28.Location = new System.Drawing.Point(19, 140);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(425, 1);
            this.label28.TabIndex = 13;
            // 
            // label27
            // 
            this.label27.AutoSize = true;
            this.label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label27.Location = new System.Drawing.Point(54, 106);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(123, 25);
            this.label27.TabIndex = 12;
            this.label27.Text = "Service Fee:";
            // 
            // acommTotalLabel
            // 
            this.acommTotalLabel.AutoSize = true;
            this.acommTotalLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.acommTotalLabel.Location = new System.Drawing.Point(219, 63);
            this.acommTotalLabel.Name = "acommTotalLabel";
            this.acommTotalLabel.Size = new System.Drawing.Size(89, 25);
            this.acommTotalLabel.TabIndex = 11;
            this.acommTotalLabel.Text = "192 euro";
            // 
            // serviceFeeLabel
            // 
            this.serviceFeeLabel.AutoSize = true;
            this.serviceFeeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.serviceFeeLabel.Location = new System.Drawing.Point(219, 106);
            this.serviceFeeLabel.Name = "serviceFeeLabel";
            this.serviceFeeLabel.Size = new System.Drawing.Size(89, 25);
            this.serviceFeeLabel.TabIndex = 10;
            this.serviceFeeLabel.Text = "195 euro";
            // 
            // label26
            // 
            this.label26.AutoSize = true;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label26.Location = new System.Drawing.Point(64, 24);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(113, 25);
            this.label26.TabIndex = 6;
            this.label26.Text = "RoomPrice:";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label23.Location = new System.Drawing.Point(46, 63);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(131, 25);
            this.label23.TabIndex = 9;
            this.label23.Text = "Acomm. total:";
            // 
            // priecPerNightLabel
            // 
            this.priecPerNightLabel.AutoSize = true;
            this.priecPerNightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.priecPerNightLabel.Location = new System.Drawing.Point(219, 24);
            this.priecPerNightLabel.Name = "priecPerNightLabel";
            this.priecPerNightLabel.Size = new System.Drawing.Size(136, 25);
            this.priecPerNightLabel.TabIndex = 7;
            this.priecPerNightLabel.Text = "32 euro / night";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label24.Location = new System.Drawing.Point(732, 252);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(123, 25);
            this.label24.TabIndex = 8;
            this.label24.Text = "Service Fee:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.Location = new System.Drawing.Point(66, 25);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(162, 31);
            this.label8.TabIndex = 15;
            this.label8.Text = "Booking ID: ";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label9.Location = new System.Drawing.Point(67, 82);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(83, 25);
            this.label9.TabIndex = 15;
            this.label9.Text = "Booking";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label12.Location = new System.Drawing.Point(674, 82);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 25);
            this.label12.TabIndex = 17;
            this.label12.Text = "Guest";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label13.Location = new System.Drawing.Point(675, 366);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 25);
            this.label13.TabIndex = 18;
            this.label13.Text = "Billing";
            // 
            // issueKeyBtn
            // 
            this.issueKeyBtn.Location = new System.Drawing.Point(549, 633);
            this.issueKeyBtn.Name = "issueKeyBtn";
            this.issueKeyBtn.Size = new System.Drawing.Size(175, 58);
            this.issueKeyBtn.TabIndex = 20;
            this.issueKeyBtn.Text = "Issue Room Key";
            this.issueKeyBtn.UseVisualStyleBackColor = true;
            this.issueKeyBtn.Click += new System.EventHandler(this.issueKeyBtn_Click);
            // 
            // changeRoomBtn
            // 
            this.changeRoomBtn.Location = new System.Drawing.Point(261, 176);
            this.changeRoomBtn.Name = "changeRoomBtn";
            this.changeRoomBtn.Size = new System.Drawing.Size(146, 32);
            this.changeRoomBtn.TabIndex = 22;
            this.changeRoomBtn.Text = "Change Room";
            this.changeRoomBtn.UseVisualStyleBackColor = true;
            this.changeRoomBtn.Click += new System.EventHandler(this.changeRoomBtn_Click);
            // 
            // startDatelabel
            // 
            this.startDatelabel.AutoSize = true;
            this.startDatelabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.startDatelabel.Location = new System.Drawing.Point(142, 74);
            this.startDatelabel.Name = "startDatelabel";
            this.startDatelabel.Size = new System.Drawing.Size(138, 31);
            this.startDatelabel.TabIndex = 23;
            this.startDatelabel.Text = "20.12.2020";
            // 
            // endDateLabel
            // 
            this.endDateLabel.AutoSize = true;
            this.endDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.endDateLabel.Location = new System.Drawing.Point(142, 126);
            this.endDateLabel.Name = "endDateLabel";
            this.endDateLabel.Size = new System.Drawing.Size(138, 31);
            this.endDateLabel.TabIndex = 24;
            this.endDateLabel.Text = "26.12.2020";
            // 
            // numberofGuestsLabel
            // 
            this.numberofGuestsLabel.AutoSize = true;
            this.numberofGuestsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.numberofGuestsLabel.Location = new System.Drawing.Point(142, 265);
            this.numberofGuestsLabel.Name = "numberofGuestsLabel";
            this.numberofGuestsLabel.Size = new System.Drawing.Size(29, 31);
            this.numberofGuestsLabel.TabIndex = 25;
            this.numberofGuestsLabel.Text = "4";
            // 
            // BookingDetailView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1326, 725);
            this.Controls.Add(this.issueKeyBtn);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Name = "BookingDetailView";
            this.Text = "Booking Detail";
            this.Load += new System.EventHandler(this.BookingDetailView_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label roomLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label durationLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox statusInput;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.RichTextBox noteInput;
        private System.Windows.Forms.Label guestLabel;
        private System.Windows.Forms.Label emailLabel;
        private System.Windows.Forms.Label phoneLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label guestNameLabel;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label acommTotalLabel;
        private System.Windows.Forms.Label serviceFeeLabel;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label priecPerNightLabel;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label totalPriceLabel;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Button issueKeyBtn;
        private System.Windows.Forms.Button changeRoomBtn;
        private System.Windows.Forms.Label numberofGuestsLabel;
        private System.Windows.Forms.Label endDateLabel;
        private System.Windows.Forms.Label startDatelabel;
    }
}