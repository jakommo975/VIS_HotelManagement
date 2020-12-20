using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer.Bookings;
using ServiceLayer;
using DesktopApp.Models;
using DomainLayer.Rooms;

namespace DesktopApp.Views
{
    public partial class RoomsView : Form
    {
        private readonly IRoomService _roomService;
        private readonly TopLevelView _topLevelView;
        public RoomsView(IRoomService roomService, TopLevelView topLevelView)
        {
            _roomService = roomService;
            _topLevelView = topLevelView;
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {


            List<RoomType> roomTypes = _roomService.GetRoomTypes();

            roomTypeInput.DisplayMember = "Text";
            roomTypeInput.ValueMember = "Value";

            var items = roomTypes.Select(x => new ComboBoxItem { Text = x.Name, Value=x.Id}).ToArray();

            roomTypeInput.DataSource = items;

            roomsGrid.ReadOnly = true;
            roomsGrid.DataSource = _roomService.GetRooms().OrderBy(x => x.Id).Select(x => PrepareRoomItemModel(x)).ToBindingList();

            roomTypesGrid.DataSource = _roomService.GetRoomTypes().Select(x => PrepareRoomTypeItemModel(x)).ToBindingList();
            roomTypesGrid.ReadOnly = true;
        }

        private RoomItemModel PrepareRoomItemModel(Room room)
        {
            RoomItemModel model = new RoomItemModel();
            model.Id = room.Id;
            model.Label = room.Label.ToString();
            model.Status = room.Status.ToString();
            model.RoomType = room.RoomType.Name;
            return model;
        }

        private RoomTypeItemModel PrepareRoomTypeItemModel(RoomType roomType)
        {
            RoomTypeItemModel model = new RoomTypeItemModel();
            model.BookingPrice = roomType.BookingPrice;
            model.Id = roomType.Id;
            model.MaxCapacity = roomType.MaxCapacity;
            model.Name = roomType.Name;

            return model;
        }

        private void addRoomBtn_Click(object sender, EventArgs e)
        {
            string label = roomLabelInput.Text;
            if (label == string.Empty)
            {
                MessageBox.Show($"Label field cannot be empty.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!_roomService.IsLabelUnique(label))
            {
                MessageBox.Show($"Room with this label already exists.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomTypeId = (int)(roomTypeInput.SelectedItem as ComboBoxItem).Value;

            _roomService.AddRoom(label, roomTypeId);
            InitData();
            MessageBox.Show($"Room was added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void addRoomTypeBtn_Click(object sender, EventArgs e)
        {
            string name = typeNameInput.Text;
            if (name == string.Empty)
            {
                MessageBox.Show($"Name field cannot be empty.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal price = (decimal)priceInput.Value;
            int maxCapacity = (int)capacityInput.Value;
            string description = descriptionInput.Text;

            _roomService.AddRoomType(price, name, description, maxCapacity);
            MessageBox.Show($"Room Type has been added.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            InitData();
        }

        private void roomsGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int roomId = (int)roomsGrid.Rows[e.RowIndex].Cells["Id"].Value;
            _topLevelView.EditedRoomId = roomId;
            _topLevelView.openChildForm(new RoomDetailView(_roomService, _topLevelView));
        }

        private void roomTypesGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            int roomTypeId = (int)roomTypesGrid.Rows[e.RowIndex].Cells["Id"].Value;
            _topLevelView.EditedRoomTypeId = roomTypeId;
            _topLevelView.openChildForm(new RoomTypeDetailView(_roomService, _topLevelView));
        }
    }


}
