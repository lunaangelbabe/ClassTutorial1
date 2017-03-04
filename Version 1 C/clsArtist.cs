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

        public string Name
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Speciality
        {
            get
            {
                return speciality;
            }

            set
            {
                speciality = value;
            }
        }

        public string Phone
        {
            get
            {
                return phone;
            }

            set
            {
                phone = value;
            }
        }


        public clsWorksList Workslist
        {
            get
            {
                return _workslist;
            }
        }

        public clsArtistList Artistlist
        {
            get
            {
                return _artistlist;
            }
        }

        public decimal Totalvalue
        {
            get
            {
                return _totalvalue;
            }
        }

        public clsArtist(clsArtistList prArtistList)
        {
            _workslist = new clsWorksList();
            _artistlist = prArtistList;
            EditDetails();
        }
        
        public void EditDetails()
        {
            artistDialog.SetDetails(this);
            if (artistDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                _totalvalue = Workslist.GetTotalValue();
            }
        }

        public bool IsDuplicate(string prArtistName)
        {
            return _artistlist.ContainsKey(prArtistName);
        }

    //    public string GetKey()
    //    {
    //        return Name;
    //    }

    //    public decimal GetWorksValue()
    //    {
    //        return Totalvalue;
    //    }
    }
}
