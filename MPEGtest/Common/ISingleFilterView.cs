using System.Drawing;
using MPEGtest.Models;

namespace MPEGtest.Common
{
    public interface ISingleFilterView 
    {
        public void DiscardChanges();
        public void PreviewFilter();
        public void ApplyFilter();
        public void SetupInputComponents(SingleFilterConfiguration config);
    }    
}