using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace zadanie4Molotova
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class welcome : ContentPage
    {
        public welcome()
        {
            InitializeComponent();

            
        }

        private async void signIn_Clicked(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (login.Text.Length == 0)
                {
                    await DisplayAlert("Ошибка", "Необходимо ввести логин", "Ок");
                }
                else if (login.Text.Length < 3)
                {
                    await DisplayAlert("Ошибка", "Логин не может быть короче 3 символов", "Ок");
                }
                else if(password.Text.Length == 0)
                {
                    await DisplayAlert("Ошибка", "Необходимо ввести пароль", "Ок");
                }
                else if(password.Text.Length < 6)
                {
                    await DisplayAlert("Ошибка", "Пароль не может быть короче 6 символов", "Ок");
                }
                else
                {
                    await Navigation.PushAsync(new MainPage());
                }
            }
            catch
            {
                await DisplayAlert("Ошибка", "Необходимо ввести логин и пароль", "Ок");
            }

        }
    }
}