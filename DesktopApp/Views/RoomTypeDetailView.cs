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
    public partial class RoomTypeDetailView : Form
    {
        private readonly IRoomService _roomService;
        private readonly TopLevelView _topLevelView;
        private RoomType CurrentRoomType {get;set;}
        public RoomTypeDetailView(IRoomService roomService, TopLevelView topLevelView)
        {
            _roomService = roomService;
            _topLevelView = topLevelView;
            InitializeComponent();
            
        }

        public void InitData()
        {
            CurrentRoomType = _roomService.GetRoomTypeById(_topLevelView.EditedRoomTypeId);

            nameInput.Text = CurrentRoomType.Name;
            priceInput.Value = CurrentRoomType.BookingPrice;
            capacityInput.Value = CurrentRoomType.MaxCapacity;
            descriptionInput.Text = CurrentRoomType.Description;
        }
        private void RoomTypeDetailView_Load(object sender, EventArgs e)
        {
            InitData();
        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            string name = nameInput.Text;
            if (name == string.Empty)
            {
                MessageBox.Show($"Name field cannot be empty.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CurrentRoomType.Description = descriptionInput.Text;
            CurrentRoomType.BookingPrice = priceInput.Value;
            CurrentRoomType.MaxCapacity = (int)capacityInput.Value;

            CurrentRoomType.Name = name;
            _roomService.EditeRoomType(CurrentRoomType);
            InitData();
            MessageBox.Show($"Room type has been edited.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
