using System.Windows.Forms;
using Microsoft.Extensions.DependencyInjection;
using MPEGtest.Views.ViewInterfaces;

namespace MPEGtest.Common.Helpers
{
    public static class RoutingHelper
    {
        public static ServiceProvider ServiceProvider;

        public static void ReplaceView<T>(this Form oldForm)
        {
            oldForm.Hide();
            if (!(ServiceProvider.GetService<T>() is Form newForm)) return;
            newForm.Closed += (s, args) => oldForm.Close();
            newForm.Show();
        }

        public static T OpenAdditionalView<T>()
        {
            var newForm = (IForm) ServiceProvider.GetService<T>() ;
            newForm?.Show();
            return (T) newForm;

        }
        
        public static T OpenDialogView<T>()
        {
            var newForm = (IForm) ServiceProvider.GetService<T>() ;
            newForm?.ShowDialog();
            return (T) newForm;
        }
    }
}

