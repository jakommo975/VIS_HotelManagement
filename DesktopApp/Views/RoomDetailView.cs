using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ServiceLayer;
using DomainLayer.Rooms;

namespace DesktopApp.Views
{
    public partial class RoomDetailView : Form
    {
        private readonly IRoomService _roomService;
        private readonly TopLevelView _topLevelView;
        private Room CurrentRoom {get;set;}

        public RoomDetailView(IRoomService roomService, TopLevelView topLevelView)
        {
            _roomService = roomService;
            _topLevelView = topLevelView;
            InitializeComponent();
        }

        public void InitData()
        {
            CurrentRoom = _roomService.GetRoomById(_topLevelView.EditedRoomId);

            labelInput.Text = CurrentRoom.Label;

            List<RoomType> roomTypes = _roomService.GetRoomTypes();

            typeInput.DisplayMember = "Text";
            typeInput.ValueMember = "Value";

            var roomTypeItems = roomTypes.Select(x => new ComboBoxItem { Text = x.Name, Value = x.Id }).ToArray();

            typeInput.DataSource = roomTypeItems;
            typeInput.SelectedValue = CurrentRoom.RoomType.Id;

            statusInput.DisplayMember = "Text";
            statusInput.ValueMember = "Value";
            var statusItems = new[] {
                new ComboBoxItem { Text = "Available", Value = 1 },
                new ComboBoxItem { Text = "Occupied", Value = 2 },
                new ComboBoxItem { Text = "Being Serviced", Value = 3 },
                new ComboBoxItem { Text = "Unavailable", Value = 4}
            };
            statusInput.DataSource = statusItems;
            statusInput.SelectedValue = (int)CurrentRoom.Status;
        }

        private void RoomDetailView_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string label = labelInput.Text;
            if (label == string.Empty)
            {
                MessageBox.Show($"Label field cannot be empty.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!label.Equals(CurrentRoom.Label) && !_roomService.IsLabelUnique(label))
            {
                MessageBox.Show($"Room with this label already exists.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int roomTypeId = (int)(typeInput.SelectedItem as ComboBoxItem).Value;
            int roomStatus = (int)(statusInput.SelectedItem as ComboBoxItem).Value;
            CurrentRoom.Label = label;
            CurrentRoom.RoomType.Id = roomTypeId;
            CurrentRoom.Status = (Room.RoomStatus)roomStatus;
            CurrentRoom = _roomService.EditRoom(CurrentRoom);
            InitData();
            MessageBox.Show($"Room has been edited.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
