using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SimpleMVVM.Models
{
    public class InboundItemsModel : BindableObject
    {
        private int _orderQty;

        public InboundItemsModel()
        {

        }


        public string ProdCode { get; set; }
        public string ProdName { get; set; }

        public int OrderQty 
        {
            get { return this._orderQty; }
            set
            {
                if (this._orderQty == value) return;
                this._orderQty = value;
                OnPropertyChanged();
            } 
        }
    }
}
