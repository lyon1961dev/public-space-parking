using Dpark.ViewModels.Search;
using Dpark.Views.Base;

namespace Dpark.Views.Search
{
    public partial class SearchSpaceDetailLocationView : SearchSpaceDetailLocationViewXaml
    {
        public SearchSpaceDetailLocationView()
        {
            InitializeComponent();
        }
    }

    public abstract class SearchSpaceDetailLocationViewXaml : ModelBoundContentView<SearchSpaceDetailViewModel>
    {

    }
}
