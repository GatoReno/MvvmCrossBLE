using System;
using System.Threading.Tasks;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace BLEPractice.Core.ViewModels
{
    public class BaseNavigationViewModel : MvxNavigationViewModel
    {
        private string _title;
        private bool _isRefreshing;
        private MvxInteraction<string> _errorInteraction;

        public MvxInteraction<string> ErrorInteraction
        {
            get
            {
                if (_errorInteraction == null)
                {
                    _errorInteraction = new MvxInteraction<string>();
                }

                return _errorInteraction;
            }

            private set
            {
                _errorInteraction = value;
            }
        }

        public bool IsRefreshing
        {
            get => _isRefreshing;
            set => SetProperty(ref _isRefreshing, value);
        }

        public string Title
        {
            get => _title;
            set => SetProperty(ref _title, value);
        }

        public IMvxAsyncCommand BackCommand { get; private set; }

        public BaseNavigationViewModel(IMvxLogProvider logProvider,
            IMvxNavigationService navigationService) : base(logProvider, navigationService)
        {
            BackCommand = new MvxAsyncCommand(OnBackCommand);
        }

     
        protected virtual async Task OnBackCommand()
        {
            await NavigationService.Close(this);
        }
    }
}
