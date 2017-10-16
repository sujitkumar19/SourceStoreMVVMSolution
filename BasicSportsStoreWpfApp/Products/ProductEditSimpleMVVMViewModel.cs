using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreDomainLibrary2.Abstract;
using SportsStoreDomainLibrary2.Concrete;
using SportsStoreDomainLibrary2.Entities;

namespace BasicSportsStoreWpfApp.Products
{
    class ProductEditSimpleMVVMViewModel : INotifyPropertyChanged
    {
        iProductRepository _prodcutRepository;
        Product _product;
        public int productID { get; set; }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };

        public RelayCommand SaveCommand { get; private set; }

        public Product Product
        {
            get
            {
                return _product;
            }

            set
            {
                _product = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Product"));
            }
        }

        public ProductEditSimpleMVVMViewModel() {
            _prodcutRepository = new FfProductRepository();
            SaveCommand = new RelayCommand(OnSave);
        }

        public async void LoadProduct() {
            Product = await _prodcutRepository.GetProductAsync(productID);
        }

        private async void OnSave()
        {
            Product = await _prodcutRepository.UpdateProdcutAsync(_product);
        }
    }
}
