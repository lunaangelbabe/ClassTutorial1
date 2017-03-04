using System;
//using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmArtist : Form
    {
        public frmArtist()
        {
            InitializeComponent();
        }

        //private clsArtistList _artistlist;
        private clsWorksList _workslist;
        private byte _SortOrder; // 0 = Name, 1 = Date
        private clsArtist _Artist;

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (_SortOrder == 0)
            {
                _workslist.SortByName();
                rbByName.Checked = true;
            }
            else
            {
                _workslist.SortByDate();
                rbByDate.Checked = true;
            }

            lstWorks.DataSource = null;
            lstWorks.DataSource = _workslist;
            lblTotal.Text = Convert.ToString(_workslist.GetTotalValue());
        }

        public void SetDetails(clsArtist prArtist)
        {
            _Artist = prArtist;
            updateForm();
            UpdateDisplay();
            ShowDialog();
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            _workslist.DeleteWork(lstWorks.SelectedIndex);
            UpdateDisplay();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _workslist.AddWork();
            UpdateDisplay();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (isValid())
            {
                pushData();
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_Artist.IsDuplicate(txtName.Text))
                {
                    MessageBox.Show("Artist with that name already exists!");
                    return false;
                }
                else
                    return true;
            else
                return true;
        }

        private void lstWorks_DoubleClick(object sender, EventArgs e)
        {
            int lcIndex = lstWorks.SelectedIndex;
            if (lcIndex >= 0)
            {
                _workslist.EditWork(lcIndex);
                UpdateDisplay();
            }
        }

        private void rbByDate_CheckedChanged(object sender, EventArgs e)
        {
            _SortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

        private void frmArtist_Load(object sender, EventArgs e)
        {

        }

        private void updateForm()
        {
            txtName.Text = _Artist.Name;
            txtSpeciality.Text = _Artist.Speciality;
            txtPhone.Text = _Artist.Phone;
            //_artistlist = _Artist.Artistlist;
            _workslist = _Artist.Workslist;
        }

        private void pushData()
        {
            _Artist.Name = txtName.Text;
            _Artist.Speciality = txtSpeciality.Text;
            _Artist.Phone = txtPhone.Text;
        }
    }
}