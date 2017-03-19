using Dpark.Views.Base;
using Dpark.ViewModels.Search;
using Xamarin.Forms;

namespace Dpark.Views.Search
{
    public partial class SearchSpaceDetailHeaderView : SearchSpaceDetailHeaderViewXaml
    {
        public SearchSpaceDetailHeaderView()
        {
            InitializeComponent();
        }
    }

    public abstract class SearchSpaceDetailHeaderViewXaml: ModelBoundContentView<SearchSpaceDetailViewModel>
    {

    }
}
