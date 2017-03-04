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

        private clsArtistList _artistlist;
        private clsWorksList _workslist;
        private byte sortOrder; // 0 = Name, 1 = Date

        private void UpdateDisplay()
        {
            txtName.Enabled = txtName.Text == "";
            if (sortOrder == 0)
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

        public void SetDetails(string prName, string prSpeciality, string prPhone, byte prSortOrder,
                               clsWorksList prWorksList, clsArtistList prArtistList)
        {
            txtName.Text = prName;
            txtSpeciality.Text = prSpeciality;
            txtPhone.Text = prPhone;
            _artistlist = prArtistList;
            _workslist = prWorksList;
            sortOrder = prSortOrder;
            UpdateDisplay();
        }

        public void GetDetails(ref string prName, ref string prSpeciality, ref string prPhone, ref byte prSortOrder)
        {
            prName = txtName.Text;
            prSpeciality = txtSpeciality.Text;
            prPhone = txtPhone.Text;
            prSortOrder = sortOrder;
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
                DialogResult = DialogResult.OK;
            }
        }

        public virtual Boolean isValid()
        {
            if (txtName.Enabled && txtName.Text != "")
                if (_artistlist.Contains(txtName.Text))
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
            sortOrder = Convert.ToByte(rbByDate.Checked);
            UpdateDisplay();
        }

    }
}