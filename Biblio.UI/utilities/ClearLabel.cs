using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Biblio.UI.utilities
{
    public static class ClearLabel
    {
        public static void ClearLabelValid(Control ctrl)
        {
            foreach (Control control in ctrl.Controls)
            {
                if (control is Label label)
                {
                    label.Text = string.Empty;
                }
                else if (control.HasControls())
                {
                    ClearLabelValid(control);
                }
            }
        }
    }
}