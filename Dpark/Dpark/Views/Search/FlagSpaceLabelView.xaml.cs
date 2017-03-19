using Dpark.Views.Base;
using Dpark.ViewModels.Search;
using Dpark.Localization;

namespace Dpark.Views.Search
{
    public partial class FlagSpaceLabelView : FlagSpaceLabelViewXaml
    {
        public FlagSpaceLabelView()
        {
            InitializeComponent();         
        }
    }
    public abstract class FlagSpaceLabelViewXaml : ModelBoundContentView<SearchSpaceDetailViewModel> { }
}
