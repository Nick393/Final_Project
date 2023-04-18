using Hello_World.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Hello_World.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}