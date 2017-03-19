using Dpark.Views.Base;
using Dpark.ViewModels.Search;

namespace Dpark.Views.Search
{
    public partial class SearchSpaceDetailTitleView : SearchSpaceDetailTitleViewXaml
    {
        public SearchSpaceDetailTitleView()
        {
            InitializeComponent();
        }
    }

    public abstract class SearchSpaceDetailTitleViewXaml: ModelBoundContentView<SearchSpaceDetailViewModel> { }
}
