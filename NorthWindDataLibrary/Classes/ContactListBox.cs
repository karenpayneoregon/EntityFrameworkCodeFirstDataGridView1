namespace NorthWindDataLibrary.Classes
{
    public class ContactListBox
    {
        public int? ContactId { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
