using System;
namespace BLEPractice.Droid.Views
{
    public class BaseView<T> : MvxAppCompatActivity<T> where T : MvxViewModel
    {
        private IMvxInteraction<string> _errorInteraction;

        public IMvxInteraction<string> ErrorInteraction
        {
            get => _errorInteraction;

            set
            {
                if (_errorInteraction != null)
                {
                    _errorInteraction.Requested -= OnErrorInteraction;
                }

                _errorInteraction = value;
                _errorInteraction.Requested += OnErrorInteraction;
            }
        }



        private void OnErrorInteraction(object sender, MvxValueEventArgs<string> e)
        {
            var toast = Toast.MakeText(ApplicationContext, e.Value, ToastLength.Short);
            toast.Show();
        }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        protected virtual void CreateBindings()
        {

        }


    }
}
