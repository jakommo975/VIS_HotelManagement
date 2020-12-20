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
using DesktopApp.Views;

namespace DesktopApp.Views
{
    public partial class GuestsView : Form
    {
        private readonly IUserService _userService;
        private readonly TopLevelView _topLevelForm;
        private List<User> Guests { get; set; }
        public GuestsView(IUserService userService, TopLevelView topLevelForm)
        {
            _userService = userService;
            _topLevelForm = topLevelForm;
            InitializeComponent();
            InitData();
        }

        private void InitData()
        {
            Guests = _userService.GetGuests();
            guestsGrid.ReadOnly = true;
            guestsGrid.DataSource = Guests.Select(x => PrepareGuestItemModel(x)).ToBindingList();
        }


        private GuestItemModel PrepareGuestItemModel(User guest)
        {
            GuestItemModel model = new GuestItemModel();
            model.Id = guest.Id;
            model.Account_Status = guest.UserAccountStatus.ToString();
            model.Email = guest.Email;
            model.Phone = guest.Phone;
            model.Name = guest.Name;
            return model;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }



        private void exportBtn_Click_1(object sender, EventArgs e)
        {
            var sfd = new SaveFileDialog();
            sfd.Filter = "XML File (*.xml)|";
            var dialog = sfd.ShowDialog();
            var filePath = string.Empty;
            sfd.DefaultExt = ".xml";

            if (dialog == DialogResult.OK)
            {
                filePath = sfd.FileName;
                _userService.ExportGuestsToXml(filePath);
            }
            /*
        string fileName = fileNameInput.Text;

        if (fileName == string.Empty)
        {
            MessageBox.Show($"File name field cannot be empty.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            return;
        }

        _userService.ExportGuestsToXml(fileName);
            */
        }
    }
}
