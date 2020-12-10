using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace MPEGtest.Common.Helpers
{
    public static class RoutingHelper
    {
        public static void ReplaceView(this Form oldForm, Form newForm)
        {
            oldForm.Hide();
            newForm.Closed += (s, args) => oldForm.Close();
            newForm.Show();
        }
    }
}