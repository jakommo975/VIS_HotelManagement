using DesktopApp.Views;
using DomainLayer.Users;
using ServiceLayer;
using ServiceLayer.Bookings;
using System;
using System.Windows.Forms;

namespace DesktopApp
{
    public partial class TopLevelView : Form
    {
        private readonly IUserService _userService;
        private readonly IBookingService _bookingService;
        private readonly IRoomService _roomService;

        public User LoggedUser { get; set; }
        public int EditedBookingId { get; set; }
        public int EditedRoomId { get; set; }
        public int EditedRoomTypeId { get; set; }

        public TopLevelView(IUserService userService, IBookingService bookingService, IRoomService roomService)
        {
            _roomService = roomService;
            _userService = userService;
            _bookingService = bookingService;
            InitializeComponent();
        }


        

        private void Form1_Load(object sender, EventArgs e)
        {
            LoggedUser = _userService.GetUserById(1);

            currentUserLabel.Text = $"Logged as {LoggedUser.Name}";
        }

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();

            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(childForm);
            contentPanel.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        public void CloseChildForm()
        {
            if (activeForm != null)
                activeForm.Close();
        }

        private void bookingsBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new BookingsView(_userService, _bookingService, _roomService, this));
        }

        private void menuBtn_Click(object sender, EventArgs e)
        {
            CloseChildForm();
        }

        private void roomsBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new RoomsView(_roomService, this));
        }

        private void guestsBtn_Click(object sender, EventArgs e)
        {
            openChildForm(new GuestsView(_userService, this));
        }
    }
}
