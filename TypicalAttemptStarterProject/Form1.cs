using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TypicalAttemptStarterProject
{
    /// <summary>
    /// What many first time developer try, 
    /// </summary>
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private NorthContext _content = new NorthContext();
        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.DataError += DataGridView1_DataError;
            using (var context = new NorthContext())
            {
                //dataGridView1.DataSource = context.Customers.ToList();
            }

            // yes and wonder why the data grid view is empty
            dataGridView1.DataSource = _content.Customers; //.ToList();

        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine(e.Exception.Message);
            e.Cancel = true;
        }
    }
}
