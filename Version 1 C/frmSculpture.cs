using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Version_1_C
{
    public partial class frmSculpture : Version_1_C.frmWork
    {

        
        public frmSculpture()
        {
            InitializeComponent();
        }

        private void frmSculpture_Load(object sender, EventArgs e)
        {

        }

        public virtual void SetDetails(string prName, DateTime prDate, decimal prValue, float prWeight, string prMaterial)
        {
            base.SetDetails(prName, prDate, prValue);
            txtMaterial.Text = prMaterial;
            txtWeight.Text = Convert.ToString(prWeight);
        }

        public virtual void GetDetails(string prName, DateTime prDate, decimal prValue, float prWeight, string prMaterial)
        {
            base.GetDetails(ref prName, ref prDate, ref prValue);
            prMaterial = txtMaterial.Text;
            prWeight = Convert.ToSingle(txtWeight.Text);
        }
    }
}

