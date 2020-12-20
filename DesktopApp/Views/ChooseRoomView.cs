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
using DesktopApp;
using DesktopApp.Models;

namespace DesktopApp.Views
{
    public partial class ChooseRoomView : Form
    {
        public IEnumerable<Room> AvailableRoomsByType {get;set; }
        public int ChosenRoomId { get; set; }
        public ChooseRoomView()
        {
            InitializeComponent();
        }

        public void InitData()
        {
            roomsGrid.ReadOnly = true;
            roomsGrid.DataSource = AvailableRoomsByType.Select(x => PrepareRoomItemModel(x)).ToBindingList();


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

        private void roomsGrid_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            this.ChosenRoomId = (int)roomsGrid.Rows[e.RowIndex].Cells["Id"].Value;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
