using SimpleMVVM.Models;
using SimpleMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SimpleMVVM.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class InboundView : ContentPage
    {
        public InboundView()
        {
            InitializeComponent();
        }

        private async void listItem_Tapped(object sender, EventArgs e)
        {
            //InboundModel selectedItem = (InboundModel)(BindingContext as InboundViewModel).InboundList.Where(i => i.InvoiceNumber == ((TappedEventArgs)e).Parameter).FirstOrDefault();
            //this.collectionView.SelectedItem = selectedItem;


            //await Navigation.PushAsync(new InboundItemsView(selectedItem));
            //await Navigation.PushAsync(new InboundItemsView());
        }

        private void collectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach (var item in e.PreviousSelection)
            {
                Console.WriteLine((item as InboundModel).InvoiceNumber);
            }

            foreach (var item in e.CurrentSelection)
            {
                Console.WriteLine((item as InboundModel).InvoiceNumber);
            }
        }

    }
}