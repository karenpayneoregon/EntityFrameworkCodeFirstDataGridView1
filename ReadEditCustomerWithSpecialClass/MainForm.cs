﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using NorthWindDataLibrary;
using NorthWindDataLibrary.Classes;
using NorthWindDataLibrary.NorthWindModels;
using ReadEditCustomerWithSpecialClass.LanguageExtensions;
using static ReadEditCustomerWithSpecialClass.Classes.Dialogs;

namespace ReadEditCustomerWithSpecialClass
{
    public partial class MainForm : Form
    {
        // responsible for obtaining data
        private readonly Operations _operations = new Operations();

        // must be form level to keep track of changes 
        private readonly NorthWindAzureContext context = new NorthWindAzureContext();

        //https://github.com/waynebloss/BindingListView
        private BindingListView<CustomerEntity> _customersView;

        private readonly BindingSource _customersBindingSource = new BindingSource();

        public MainForm()
        {
            InitializeComponent();

            //context.Database.Log = Console.Write;
            context.Database.Log = FileLogger.Log;
            Shown += Form1_Shown;
            Closing += MainForm_Closing;
            gridView.DataError += CustomersDataGridView_DataError;
            gridView.CellPainting += GridView_CellPainting;
            gridView.CellContentClick += GridView_CellContentClick;

            EditContactColumn.Width = 50;

            gridView.CellToolTipTextNeeded += GridView_CellToolTipTextNeeded;
            gridView.ShowCellToolTips = true;
            
        }

        /// <summary>
        /// Handles DataGridViewButtonColumn on current row in the DataGridView
        /// to allow changing the contact for the current customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) || e.RowIndex < 0) return;

            var customerEntity = _customersBindingSource.CurrentCustomerEntity();
            
            var f = new ContactSelectionForm(customerEntity.ContactIdentifier);

            if (f.ShowDialog() == DialogResult.OK)
            {
                var newIdentifier = f.ContactIdentifier;
                var contact = _operations.GetContacts().FirstOrDefault(cont => cont.ContactId == newIdentifier);
                var customer = context.Customers
                    .FirstOrDefault(cust => cust.CustomerIdentifier == customerEntity.CustomerIdentifier);

                customerEntity.FirstName = contact.FirstName;
                customerEntity.LastName = contact.LastName;
                customerEntity.ContactIdentifier = newIdentifier;
                customer.ContactId = newIdentifier;
                customer.ContactName = $"{contact.FirstName} {contact.LastName}";
                _customersBindingSource.ResetCurrentItem();
            }

        }
        /// <summary>
        /// Show tooltip for DataGridViewButtonColumn on current DataGridViewRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_CellToolTipTextNeeded(object sender, DataGridViewCellToolTipTextNeededEventArgs e)
        {
            if (e.ColumnIndex == gridView.Columns["EditContactColumn"].Index && e.RowIndex >= 0)
            {
                e.ToolTipText = "Change contact";
            }
        }
        /// <summary>
        /// Paint DataGridViewButtonColumn image
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void GridView_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            if (e.ColumnIndex == gridView.Columns["EditContactColumn"].Index)
            {
                e.Paint(e.CellBounds, DataGridViewPaintParts.All);

                var w = Properties.Resources.Edit_16x.Width;
                var h = Properties.Resources.Edit_16x.Height;
                var x = e.CellBounds.Left + (e.CellBounds.Width - w) / 2;
                var y = e.CellBounds.Top + (e.CellBounds.Height - h) / 2;

                e.Graphics.DrawImage(Properties.Resources.Edit_16x, new Rectangle(x, y, w, h));
                e.Handled = true;
            }
        }

        /// <summary>
        /// Starter for showing there are errors in the DataGridView, this needs the developer
        /// to decide how to handle as this is just a starting point e.g. this may be only need
        /// during development for instance many developer get setting up DataGridViewComboBox
        /// properties incorrect and this is a sure indicator.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomersDataGridView_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            Console.WriteLine($"Encountered: {e.Exception.Message}");
            //MessageBox.Show($"Encountered: {e.Exception.Message}");
            e.Cancel = true;
        }
        /// <summary>
        /// Check if there are any pending changes, if so ask user if
        /// they want to cancel closing the form to save changes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainForm_Closing(object sender, CancelEventArgs e)
        {
            if (context.ChangeTracker.HasChanges())
            {
                if (!Question("There are pending changes, abort?"))
                {
                    e.Cancel = true;
                }
            }
        }
        /// <summary>
        /// * Get data from database tables
        /// * Setup events to work with data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Form1_Shown(object sender, EventArgs e)
        {
            gridView.SuspendLayout();
            gridView.EditingControlShowing += DataGridView1_EditingControlShowing;

            gridView.AutoGenerateColumns = false;

            var result = await _operations.AllCustomersAsync(context)
                .ConfigureAwait(false);

            _customersView = 
                new BindingListView<CustomerEntity>(result);

            Console.WriteLine();
            /*
             * Setup DataGridViewComboBox columns 
             */
            CountyNameColumn.DisplayMember = "CountyName";
            CountyNameColumn.ValueMember = "CountryIdentifier";
            CountyNameColumn.DataPropertyName = "CountryIdentifier";
            CountyNameColumn.DataSource = _operations.GetCountries();
            CountyNameColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            ContactTitleColumn.DisplayMember = "ContactTitle";
            ContactTitleColumn.ValueMember = "ContactTypeIdentifier";
            ContactTitleColumn.DataPropertyName = "ContactTypeIdentifier";
            ContactTitleColumn.DataSource = _operations.GetContactTypes();
            ContactTitleColumn.DisplayStyle = DataGridViewComboBoxDisplayStyle.Nothing;

            /*
             * Assign list of customers to the BindingSource which then
             * in turn is used to display customers in the DataGridView
             * with sorting capability via the BindingListView
             */
            _customersBindingSource.DataSource = _customersView;

            gridView.Invoke(new Action(() => 
                gridView.DataSource = _customersBindingSource));

            gridView.Invoke(new Action(() => 
                gridView.ExpandColumns()));

            bindingNavigator1.Invoke(new Action(() => 
                bindingNavigator1.BindingSource = 
                    _customersBindingSource));

            var contactTypes = _operations.GetContactTypes();
            contactTypes.Insert(0, new ContactType() { ContactTypeIdentifier = 0, ContactTitle = "All"});
            ContactTypeComboBox.DataSource = contactTypes;
            ContactTypeComboBox.DisplayMember = "ContactTitle";

            gridView.Invoke(new Action(() =>
                gridView.ResumeLayout()));

        }
        /// <summary>
        /// Handles changes for both DataGridViewComboBox columns
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_EditingControlShowing(
            object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (!gridView.CurrentCell.IsComboBoxCell()) return;

            var comboBox = e.Control as ComboBox;
            // ReSharper disable once PossibleNullReferenceException
            comboBox.SelectionChangeCommitted -= SelectionChangeCommittedForCountryColumn;
            comboBox.SelectionChangeCommitted -= SelectionChangeCommittedForContactTitleColumn;

            if (gridView.Columns[gridView.CurrentCell.ColumnIndex].Name == "CountyNameColumn")
            {
                comboBox.SelectionChangeCommitted += SelectionChangeCommittedForCountryColumn;
            }
            else if (gridView.Columns[gridView.CurrentCell.ColumnIndex].Name == "ContactTitleColumn")
            {
                comboBox.SelectionChangeCommitted += SelectionChangeCommittedForContactTitleColumn;
            }
        }
        /// <summary>
        /// Set backing customer field foreign key for Country for current customer record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionChangeCommittedForCountryColumn(object sender, EventArgs e)
        {
            var customer = _customersBindingSource.CurrentCustomerEntity();
            var identifier = ((CountryItem)(((DataGridViewComboBoxEditingControl)sender).SelectedItem))
                .CountryIdentifier;

            customer.CountryIdentifier = identifier;
            // ReSharper disable once PossibleNullReferenceException
            context.Customers
                .FirstOrDefault(cust => cust.CustomerIdentifier == customer.CustomerIdentifier)
                .CountryIdentifier = identifier;
        }
        /// <summary>
        /// Set backing customer field foreign key for contact title type for current customer record
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SelectionChangeCommittedForContactTitleColumn(object sender, EventArgs e)
        {
            var customer = _customersBindingSource.CurrentCustomerEntity();
            var identifier = ((ContactType)(((DataGridViewComboBoxEditingControl)sender).SelectedItem))
                .ContactTypeIdentifier;

            customer.ContactTypeIdentifier = identifier;
            // ReSharper disable once PossibleNullReferenceException
            context.Customers
                .FirstOrDefault(cust => cust.CustomerIdentifier == customer.CustomerIdentifier)
                .ContactTypeIdentifier = identifier;
        }
        /// <summary>
        /// Save all changes, for learning the number of changes
        /// are shown in the IDE Output window, if there were changes
        /// and the result is zero there is an issue if there are no
        /// exceptions thrown prior to this save operation.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveAllChangesButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine(context.SaveChanges());
            try
            {
                //context.Customers.Add(new Customer());
                
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var entityErr in dbEx.EntityValidationErrors)
                {
                    Console.WriteLine($@"Entity of type ""{entityErr.Entry.Entity.GetType().Name}"" in state ""{entityErr.Entry.State}"" has the following validation errors:");
                    foreach (var error in entityErr.ValidationErrors)
                    {
                        Console.WriteLine($@"- Property: ""{error.PropertyName}"", Value: ""{entityErr.Entry.CurrentValues.GetValue<object>(error.PropertyName)}"", Error: ""{error.ErrorMessage}""");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //

        private async void SaveAllChangesButtonAsync_Click(object sender, EventArgs e)
        {
            Console.WriteLine(await context.SaveChangesAsync());
        }

        /// <summary>
        /// Handles changes for all fields except contact as contact in this case
        /// is a derived class used to represent data from a child class, contact title
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            /*
             * We need to know which column the current cell name is to set properties
             * below
             */
            var currentColumnName = gridView.CurrentCell.OwningColumn.Name;

            var customerEntity = _customersBindingSource.CurrentCustomerEntity();
            var customer = context.Customers
                .FirstOrDefault(cust => 
                    cust.CustomerIdentifier == customerEntity.CustomerIdentifier);

            /*
             * Handle DataGridViewComboBox columns
             *
             * IMPORTANT: Here FirstOrDefault is used without checking if the returning
             * item is null or not, for your project check for null.
             */
            try
            {
                if (currentColumnName == "ContactTitleColumn")
                {
                    // ReSharper disable once PossibleNullReferenceException
                    var contactTitleIdentifier = context.ContactTypes
                        .FirstOrDefault(contactType => contactType.ContactTitle == gridView.EditingControl.Text)
                        .ContactTypeIdentifier;

                    context.Entry(customer).Property(x => x.ContactTypeIdentifier)
                        .CurrentValue = contactTitleIdentifier;

                }
                else if (currentColumnName == "CountyNameColumn")
                {
                    var countryIdentifier = context.Countries
                        .FirstOrDefault(country => country.Name == gridView.EditingControl.Text)
                        .CountryIdentifier;

                    context.Entry(customer).Property(x => x.CountryIdentifier)
                        .CurrentValue = countryIdentifier;
                }
                else
                {
                    context.Entry(customer).Property(gridView.CurrentCell.OwningColumn.DataPropertyName)
                        .CurrentValue = gridView.EditingControl.Text;
                }
            }
            catch (Exception ex)
            {
                /*
                 * rule violations e.g. max length exceeded, required field empty
                 * which would be annotated on class properties used to communicate
                 * with tables in the database.
                 */
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// Delete customer
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorDeleteCustomer_Click(object sender, EventArgs e)
        {
            var currentCustomer = _customersBindingSource.CurrentCustomerEntity();

            if (Question($"Delete '{currentCustomer.CompanyName}'"))
            {
                var customer = context.Customers
                    .FirstOrDefault(cust => 
                        cust.CustomerIdentifier == currentCustomer.CustomerIdentifier);

                context.Entry(customer).State = EntityState.Deleted;
                _customersBindingSource.RemoveCurrent();
            }
        }
        /// <summary>
        /// Add new customer, this could be done inline yet
        /// the best option is to show a modal form, present
        /// options for contact type and country. Also use data annotation
        /// for validating against attributes e.g. required, length of a
        /// field etc.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorAddNewCustomer_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Example of a like condition on company name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripButtonFindCustomer_Click(object sender, EventArgs e)
        {
            _customersView.ApplyFilter(customer => customer.CompanyName.Contains("suey"));
        }
        /// <summary>
        /// Example of a filter on an exact type, in this case contact type
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FilterByContactTypeButton_Click(object sender, EventArgs e)
        {
            var selectedContactType = (ContactType)ContactTypeComboBox.SelectedItem;

            if (selectedContactType.ContactTypeIdentifier == 0)
            {
                _customersView.Filter = null;
            }
            else
            {
                _customersView.ApplyFilter(customer => customer.ContactTypeIdentifier == selectedContactType.ContactTypeIdentifier);

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _operations.Casing();
        }
    }
}
