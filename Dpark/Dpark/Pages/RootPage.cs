using Xamarin.Forms;
using Dpark.ViewModels.Base;
using Dpark.Pages.Search;
using Dpark.Pages.About;
using Dpark.Pages.Flag;
using Dpark.ViewModels.About;
using Dpark.Localization;
using Dpark.Statics;
using System.Collections.Generic;
using Dpark.ViewModels;
using Dpark.ViewModels.Search;

namespace Dpark.Pages
{

    public class RootTabPage : TabbedPage
    {
        public RootTabPage()
        {
            Children.Add(new DparkNavigationPage(new SearchPage
                {
                    Title = TextResources.MainTabs_Search,
                    Icon = new FileImageSource { File = "search.png" }
                })
                {
                    Title = TextResources.MainTabs_Search,
                    Icon = new FileImageSource { File = "search.png" }
                });

            Children.Add(new DparkNavigationPage(new AboutPage
                {
                    Title = TextResources.MainTabs_About,
                    Icon = new FileImageSource { File = "about.png" },
                    BindingContext = new AboutViewModel() { Navigation = this.Navigation }
                })
                {
                    Title = TextResources.MainTabs_About,
                    Icon = new FileImageSource { File = "about.png" }
                });

            Children.Add(new DparkNavigationPage(new FlagSpace
                {
                    Title = TextResources.MainTabs_FlagSpace,
                    Icon = new FileImageSource { File = "flag.png" }
                })
                {
                    Title = TextResources.MainTabs_FlagSpace,
                    Icon = new FileImageSource { File = "flag.png" }
                });
        }
        protected override void OnCurrentPageChanged()
        {
            base.OnCurrentPageChanged();
            this.Title = this.CurrentPage.Title;
        }

    }

    public class DparkNavigationPage : NavigationPage
    {
        public DparkNavigationPage(Page root)
            :base(root)
        {
            Init();
        }
        public DparkNavigationPage()
        {
            Init();
        }
        void Init()
        {
            BarBackgroundColor = Palette._001;
            BarTextColor = Color.White;
        }
    }

}
