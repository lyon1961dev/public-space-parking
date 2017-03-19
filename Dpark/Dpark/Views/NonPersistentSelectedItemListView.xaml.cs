
using Xamarin.Forms;

namespace Dpark.Views
{
    public partial class NonPersistentSelectedItemListView : ListView
    {
        public NonPersistentSelectedItemListView()
        {
            InitializeComponent();
            ItemSelected += (sender, e) => SelectedItem = null;
        }
    }
}
