using Dpark.Views.Base;
using Dpark.ViewModels.Search;
using Dpark.Localization;

namespace Dpark.Views.Search
{
    public partial class SearchSpaceDetailOptionView : SearchSpaceDetailOptionViewXaml
    {
        public SearchSpaceDetailOptionView()
        {
            InitializeComponent();
            //labelOption.Text = TextResources.Option_FlagSpace;
        }
    }
    public abstract class SearchSpaceDetailOptionViewXaml : ModelBoundContentView<SearchSpaceDetailViewModel> { }
}
