using System.Windows.Forms;

namespace ReadEditCustomerWithSpecialClass.LanguageExtensions
{
    public static class ExtensionMethods
    {
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                // ensure we are not attempting to do this on a Entity
                if (col.ValueType != null && col.ValueType.Name != "ICollection`1")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }
        public static bool IsComboBoxCell(this DataGridViewCell sender)
        {
            bool result = false;
            if (sender.EditType != null)
            {
                if (sender.EditType == typeof(DataGridViewComboBoxEditingControl))
                {
                    result = true;
                }
            }
            return result;
        }
    }
}