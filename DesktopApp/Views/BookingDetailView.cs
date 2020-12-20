using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using DomainLayer.Users;
using DomainLayer.Bookings;
using ServiceLayer;
using ServiceLayer.Bookings;
using DesktopApp.Models;
using DomainLayer.Rooms;

namespace DesktopApp.Views
{
    public partial class BookingDetailView : Form
    {
        private readonly IBookingService _bookingService;
        private readonly IUserService _userService;
        private readonly IRoomService _roomService;
        private readonly TopLevelView _topLevelView;
        private readonly int _bookingId;
        private RoomBooking _currentBooking;
        public BookingDetailView(IUserService userService, IBookingService bookingService, IRoomService roomService, TopLevelView topLevelView)
        {
            _bookingService = bookingService;
            _userService = userService;
            _roomService = roomService;
            _topLevelView = topLevelView;
            
            InitializeComponent();
            
        }

        private void initData()
        {
            RoomBooking booking = _bookingService.GetRoomBookingById(_topLevelView.EditedBookingId);
            _currentBooking = booking;

            statusInput.DisplayMember = "Text";
            statusInput.ValueMember = "Value";
            var items = new[] {
                new ComboBoxItem { Text = "Confirmed", Value = 1 },
                new ComboBoxItem { Text = "Checked-in", Value = 2 },
                new ComboBoxItem { Text = "Checked-out", Value = 3 },
                new ComboBoxItem { Text = "Cancelled", Value = 4}
            };

            statusInput.SelectedIndexChanged -= OnStatusChanged;

            statusInput.DataSource = items;
            statusInput.SelectedIndex = Array.IndexOf(items ,items.Where(x => x.Value == (int)booking.Status).FirstOrDefault());

            statusInput.SelectedIndexChanged += OnStatusChanged;

            startDatelabel.Text = booking.StartDate.ToShortDateString();
            endDateLabel.Text = booking.EndDate.ToShortDateString(); ;

            roomLabel.Text = booking.Room.Label.ToString();

            guestLabel.Text = booking.User.Name;
            numberofGuestsLabel.Text = booking.NumberOfPersons.ToString();

            noteInput.Text = booking.Note;

            durationLabel.Text = $"Total {booking.DurationInNights} nights";

            guestNameLabel.Text = booking.User.Name;
            phoneLabel.Text = booking.User.Phone;
            emailLabel.Text = booking.User.Email;

            priecPerNightLabel.Text = $"{booking.Invoice.UnitPrice.ToString("#.##")} € / night";
            serviceFeeLabel.Text = $"{booking.Invoice.ServiceFee.ToString("#.##")} €";
            acommTotalLabel.Text = $"{booking.Invoice.AccomodadtionPrice.ToString("#.##")} €";
            totalPriceLabel.Text = $"{booking.Invoice.TotalPrice.ToString("#.##")} €";
        }


        private void BookingDetailView_Load(object sender, EventArgs e)
        {
            initData();
        }

        private void statusInput_SelectedIndexChanged(object sender, EventArgs e)
        {
            

            //MessageBox.Show( "Some title", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void OnStatusChanged(object sender, EventArgs e)
        {
            RoomBooking booking = _bookingService.GetRoomBookingById(_topLevelView.EditedBookingId);

            int selectedStatus = (int)(statusInput.SelectedItem as dynamic).Value;


            if (selectedStatus == (int)RoomBooking.RoomBookingStatus.CheckedIn)
            {
                OnStatusChangedToCheckedIn(booking);
            }

            if (selectedStatus == (int)RoomBooking.RoomBookingStatus.CheckedOut)
            {
                OnStatusChangedToCheckedOut(booking);
            }

            if (selectedStatus == (int)RoomBooking.RoomBookingStatus.Cancelled)
            {
                OnStatusChangedToCancelled(booking);
            }
            if (selectedStatus == (int)RoomBooking.RoomBookingStatus.Confirmed)
            {
                OnStatusChangedToConfirmed(booking);
            }

            initData();
        }

        

        private void OnStatusChangedToCheckedIn(RoomBooking booking)
        {
            if (!_bookingService.CanCheckIn(booking))
            {
                statusInput.SelectedIndexChanged -= OnStatusChanged;
                statusInput.SelectedIndex = GetIndexOfItemByValue(statusInput.Items, (int)booking.Status);
                MessageBox.Show("Guest cannot be checked in.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusInput.SelectedIndexChanged += OnStatusChanged;
                return;
            }

            if (booking.Room.Status != Room.RoomStatus.Available)
            {
                statusInput.SelectedIndexChanged -= OnStatusChanged;
                statusInput.SelectedIndex = GetIndexOfItemByValue(statusInput.Items, (int)booking.Status);
                MessageBox.Show("Room is not ready yet.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusInput.SelectedIndexChanged += OnStatusChanged;
                return;
            }

            _bookingService.CheckIn(booking);
            MessageBox.Show("Guest has been checked in", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnStatusChangedToCheckedOut(RoomBooking booking)
        {
            if (!_bookingService.CanCheckOut(booking))
            {
                statusInput.SelectedIndexChanged -= OnStatusChanged;
                statusInput.SelectedIndex = GetIndexOfItemByValue(statusInput.Items, (int)booking.Status);
                MessageBox.Show("Guest cannot be checked out.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                statusInput.SelectedIndexChanged += OnStatusChanged;
                return;
            }

            _bookingService.CheckOut(booking);
            MessageBox.Show("Guest has been checked out", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnStatusChangedToConfirmed(RoomBooking booking)
        {
            if (booking.EndDate.Date.CompareTo(DateTime.Now.Date) == -1)
            {
                statusInput.SelectedIndexChanged -= OnStatusChanged;
                statusInput.SelectedIndex = GetIndexOfItemByValue(statusInput.Items, (int)booking.Status);
                MessageBox.Show("Booking has already ended.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusInput.SelectedIndexChanged += OnStatusChanged;
                return;
            }
            _bookingService.ConfirmBooking(booking);
            MessageBox.Show("Status has been changed to confirmed.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void OnStatusChangedToCancelled(RoomBooking booking)
        {
            if (booking.EndDate.Date.CompareTo(DateTime.Now.Date) == -1)
            {
                statusInput.SelectedIndexChanged -= OnStatusChanged;
                statusInput.SelectedIndex = GetIndexOfItemByValue(statusInput.Items, (int)booking.Status);
                MessageBox.Show("Booking has already ended.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
                statusInput.SelectedIndexChanged += OnStatusChanged;
                return;
            }
            _bookingService.CancelBooking(booking);
            MessageBox.Show("Booking has been canceleld.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private int GetIndexOfItemByValue(ComboBox.ObjectCollection items, int value)
        {
            for (int i =0; i< items.Count; i++)
            {
                if((items[i] as ComboBoxItem).Value == value)
                    return i;
            }

            return -1;
        }

        private void changeRoomBtn_Click(object sender, EventArgs e)
        {
            ChooseRoomView view = new ChooseRoomView();
            view.AvailableRoomsByType = _roomService.GetAvailableRoomsForDateSpan(_currentBooking.Room.RoomType.Id, _currentBooking.StartDate, _currentBooking.EndDate);
            view.InitData();
            var result = view.ShowDialog();

            if (result == DialogResult.OK)
            {
                _bookingService.ChangeRoom(_currentBooking, view.ChosenRoomId);
                initData();
            }
        }

        private void issueKeyBtn_Click(object sender, EventArgs e)
        {
            _roomService.IssueRoomKey(_currentBooking.Room.Id, _topLevelView.LoggedUser.Id);
            MessageBox.Show($"Room key was created for room {_currentBooking.Room.Label}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
