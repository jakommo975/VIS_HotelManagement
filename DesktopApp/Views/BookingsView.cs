using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.ObjectModel;

using DomainLayer.Users;
using DomainLayer.Bookings;
using ServiceLayer;
using ServiceLayer.Bookings;
using DesktopApp.Models;
using DesktopApp.Views;


namespace DesktopApp
{
    public partial class BookingsView : Form
    {
        private readonly IBookingService _bookingService;
        private readonly IUserService _userService;
        private readonly IRoomService _roomService;

        private readonly TopLevelView _topLevelForm;

        private User CurrentUser;

        
        public BookingsView(IUserService userService, IBookingService bookingService, IRoomService roomService, TopLevelView topLevelForm)
        {
            _bookingService = bookingService;
            _userService = userService;
            _roomService = roomService;
            _topLevelForm = topLevelForm;
            
            InitializeComponent();
            InitData();
        }

        private void BookingsView_Load(object sender, EventArgs e)
        {
        }

        private void InitData()
        {
            var bookings = _bookingService.GetAllBaookings();

            statusInput.DisplayMember = "Text";
            statusInput.ValueMember = "Value";
            var items = new[] {
                new { Text = "Any", Value = 0 },
                new { Text = "Confirmed", Value = 1 },
                new { Text = "Checked-in", Value = 2 },
                new { Text = "Checked-out", Value = 3 },
                new { Text = "Cancelled", Value = 4}
            };

            statusInput.DataSource = items;

            bookingsGrid.ReadOnly = true;
            bookingsGrid.AllowUserToAddRows = false;

            bookingsGrid.MultiSelect = false;
            bookingsGrid.DataSource = bookings.Skip(590).Take(20).Select(x => PrepareBookingItemModel(x)).ToBindingList();
        }


        private void BookingsView_Shown(object sender, EventArgs e)
        {
            
        }


        private void searchBtn_Click(object sender, EventArgs e)
        {
            var filteredBookings = _bookingService.GetAllBaookings().AsEnumerable();
            string id = idInput.Text;
            string name = nameInput.Text;
            string room = roomInput.Text;

            int status = (int)(statusInput.SelectedItem as dynamic).Value;

            if (id != string.Empty)
            {
                filteredBookings = filteredBookings.
                Where(x => x.Id.ToString().StartsWith(id));
            }
            if (name != string.Empty)
            {
                filteredBookings = filteredBookings.
                Where(x => x.User.Name.ToLower().Contains(name.ToLower()));
            }
            if (room != string.Empty)
            {
                filteredBookings = filteredBookings.
                Where(x => x.Room.Label.ToString().StartsWith(room));
            }

            if (status != 0)
            {
                filteredBookings = filteredBookings.
                Where(x => x.Status == (RoomBooking.RoomBookingStatus)status);
            }

            bookingsGrid.DataSource = filteredBookings.Select(x => PrepareBookingItemModel(x)).ToBindingList();

        }



        private BookingItemModel PrepareBookingItemModel(RoomBooking booking)
        {
            BookingItemModel model = new BookingItemModel();

            model.Id = booking.Id;
            model.CheckIn = booking.CheckIn;
            model.CheckOut = booking.CheckOut;
            model.DurationInNights = booking.DurationInNights;
            model.StartDate = booking.StartDate;
            model.EndDate = booking.EndDate;
            model.GuestName = booking.User.Name;
            model.NumberOfPersons = booking.NumberOfPersons;
            model.Status = booking.Status.ToString("g");
            model.RoomLabel = booking.Room.Label.ToString();

            return model;
        }

        private void bookingsGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            int bookingId = (int)bookingsGrid.Rows[e.RowIndex].Cells["Id"].Value;
            _topLevelForm.EditedBookingId = bookingId;
            _topLevelForm.openChildForm(new BookingDetailView(_userService, _bookingService, _roomService, _topLevelForm));
        }
    }
}
