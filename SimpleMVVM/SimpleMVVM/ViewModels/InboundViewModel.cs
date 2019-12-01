using SimpleMVVM.Controls;
using SimpleMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleMVVM.ViewModels
{
    public class InboundViewModel : ViewModelBase
    {
        private ObservableRangeCollection<InboundModel> _inboundList = new ObservableRangeCollection<InboundModel>();

        private DateTime _inboundDate = Convert.ToDateTime("1900-01-01");
        private string _invoiceNumber;

        private ObservableRangeCollection<object> _selectedOrders;
        public ICommand SearchCommand { get; private set; }
        public ICommand SelectionChangedCommand { get; }


        public InboundViewModel()
        {

            SearchCommand = new Command(Search);
            SelectionChangedCommand = new Command<SelectionChangedEventArgs>((e) => SelectionChanged(e));

            List<InboundModel> lst = new List<InboundModel>
            {
                new InboundModel{ InvoiceNumber ="ABC1234", InboundDate ="2019-10-11",  VenderCode="Z101", VenderName="매입업체 Z101", Remark ="긴급 주문입니다." },
                new InboundModel{ InvoiceNumber ="ABC1235", InboundDate ="2019-10-12",  VenderCode="Z102", VenderName="매입업체 Z102", Remark ="영업팀 확인 요망"  },
                new InboundModel{ InvoiceNumber ="ABC1236", InboundDate ="2019-10-13",  VenderCode="Z103", VenderName="매입업체 Z103", Remark = string.Empty },
                new InboundModel{ InvoiceNumber ="ABC1237", InboundDate ="2019-10-14",  VenderCode="Z104", VenderName="매입업체 Z104", Remark = string.Empty }
            };

            InboundList.AddRange(lst);

            InboundDate = DateTime.Now;

            SelectedOrders = new ObservableRangeCollection<object>()
            {
                InboundList[0], InboundList[1]
            };
        }

        private void SelectionChanged(SelectionChangedEventArgs e)
        {
            foreach (var item in e.PreviousSelection)
            {
                Console.WriteLine((item as InboundModel).InvoiceNumber);
            }

            foreach (var item in e.CurrentSelection)
            {
                Console.WriteLine((item as InboundModel).InvoiceNumber);
            };
        }

        private void Search()
        {

            foreach (var item in SelectedOrders)
            {

                Console.WriteLine((item as InboundModel).InvoiceNumber);
            }

        }


        public ObservableRangeCollection<InboundModel> InboundList
        {
            get => _inboundList;
            set => SetProperty(ref this._inboundList, value);
        }

        public ObservableRangeCollection<object> SelectedOrders
        {
            get => _selectedOrders;
            set => SetProperty(ref this._selectedOrders, value);
        }


        public DateTime InboundDate { get => _inboundDate; set => SetProperty(ref _inboundDate, value); }
        public string InvoiceNumber { get => _invoiceNumber; set => SetProperty(ref _invoiceNumber, value); }

    }
}
