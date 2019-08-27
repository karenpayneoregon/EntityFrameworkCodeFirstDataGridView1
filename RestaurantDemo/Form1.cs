using System;
using System.Windows.Forms;

namespace RestaurantDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Shown += Form1_Shown;
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            var ops = new Operations();
            listBox1.DataSource = ops.TodayGuest();
        }

        private void GetBreakfastOrderButton_Click(object sender, EventArgs e)
        {
            var guest = (Guest) listBox1.SelectedItem;
            var ops = new Operations();
            var guestOrder =  ops.GuestBreakfastOrderForToday(guest.GuestIdentifier);
            
            // ReSharper disable once LocalizableElement
            MessageBox.Show($"{guest}\nOrder\n{guestOrder}");
        }
    }
}
