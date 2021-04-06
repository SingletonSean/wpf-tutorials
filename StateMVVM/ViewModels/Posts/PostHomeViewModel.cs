using MVVMEssentials.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace StateMVVM.ViewModels.Posts
{
    public class PostHomeViewModel : ViewModelBase
    {
        public CreatePostViewModel CreatePostViewModel { get; }
        public RecentPostListingViewModel RecentPostListingViewModel { get; }

        public PostHomeViewModel(CreatePostViewModel createPostViewModel, RecentPostListingViewModel recentPostListingViewModel)
        {
            CreatePostViewModel = createPostViewModel;
            RecentPostListingViewModel = recentPostListingViewModel;
        }
    }
}
