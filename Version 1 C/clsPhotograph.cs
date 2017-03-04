using System;
using System.Windows.Forms;

namespace Version_1_C
{
    [Serializable()]
    public class clsPhotograph : clsWork
    {
        private float _width;
        private float _height;
        private string _type;

        // change made 2/03/2017
        [NonSerialized()]
        private static frmPhotograph photoDialog;




        public override void EditDetails()
        {
            if (photoDialog == null)
            {
                photoDialog = new frmPhotograph();
            }
            photoDialog.SetDetails(_Name, _Date, _Value, _width, _height, _type);
            if (photoDialog.ShowDialog() == DialogResult.OK)
            {
                photoDialog.GetDetails(ref _Name, ref _Date, ref _Value, ref _width, ref _height, ref _type);
            }
        }
    }
}
