using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()] 
    public class clsSculpture : clsWork
    {
        private float _weight;
        private string _material;
        [NonSerialized()]
        private static frmSculpture sculptureDialog;

        public override void EditDetails()
        {
            if (sculptureDialog == null)
            {
                sculptureDialog = new frmSculpture();
            }
            sculptureDialog.SetDetails(_Name, _Date, _Value, _weight, _material);
            if(sculptureDialog.ShowDialog() == DialogResult.OK)
            {
                sculptureDialog.GetDetails(ref _Name, ref _Date, ref _Value);

                // keep getting an error when i try to add in the weight and material
            }
        }
    }
}
