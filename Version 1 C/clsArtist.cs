using System;

namespace Version_1_C
{
    [Serializable()] 
    public class clsArtist
    {
        private string name;
        private string speciality;
        private string phone;
        
        private decimal _totalvalue;

        private clsWorksList _workslist;
        private clsArtistList _artistlist;
        
        private static frmArtist artistDialog = new frmArtist();

        public clsArtist(clsArtistList prArtistList)
        {
            _workslist = new clsWorksList();
            _artistlist = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()
        {
            artistDialog.SetDetails(name, speciality, phone, _workslist, _artistlist);
            if (artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                artistDialog.GetDetails(ref name, ref speciality, ref phone);
                _totalvalue = _workslist.GetTotalValue();
            }
        }

        public string GetKey()
        {
            return name;
        }

        public decimal GetWorksValue()
        {
            return _totalvalue;
        }
    }
}
