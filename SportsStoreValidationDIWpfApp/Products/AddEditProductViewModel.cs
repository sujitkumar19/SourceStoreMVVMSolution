using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SportsStoreDomainLibrary2.Abstract;
using SportsStoreDomainLibrary2.Entities;

namespace SportsStoreValidationDIWpfApp.Products
{
    class AddEditProductViewModel:BindableBase
    {
        private iProductRepository _ProductRepository;
        private SimpleEditableProduct _SimpleEditableProduct;
        private bool _EditFlag;
        private Product _editableProduct;

        public RelayCommand SaveCommand { get; private set; }
        public event Action<string> SaveCommandRequest = delegate { };

        public RelayCommand CancelCommand { get; private set; }
        public event Action<string> CancelCommandRequest = delegate { };

        public event Action Done = delegate { };


        public bool EditFlag
        {
            get
            {
                return _EditFlag;
            }

            set
            {
                SetProperty(ref _EditFlag, value);
            }
        }

        public SimpleEditableProduct SimpleEditableProduct
        {
            get
            {
                return _SimpleEditableProduct;
            }

            set
            {
                SetProperty(ref _SimpleEditableProduct, value);
            }
        }

        public Product EditableProduct
        {
            get
            {
                return _editableProduct;
            }

            set
            {
                SetProperty(ref _editableProduct ,value);
            }
        }

        public AddEditProductViewModel(iProductRepository ProductRepository) {
            _ProductRepository = ProductRepository;
            CancelCommand = new RelayCommand(OnCancel);
            SaveCommand = new RelayCommand(OnSave, CanSave);
        }

        private async void OnSave()
        {
            UpdateProduct(SimpleEditableProduct, EditableProduct);
            if (EditFlag)
            {
                await _ProductRepository.UpdateProdcutAsync(EditableProduct);
            }
            else {
                await _ProductRepository.AddProductAsync(EditableProduct);
            }
            Done();
            SaveCommandRequest("products");
        }

        private void UpdateProduct(SimpleEditableProduct source, Product target)
        {
            target.ProductName = source.ProductName;
            target.Description = source.Description;
            target.price = source.Price;
            target.category = source.Category;
        }

        private bool CanSave()
        {
            return !SimpleEditableProduct.HasErrors;
        }

        private void OnCancel()
        {
            Done();
            CancelCommandRequest("products");
        }

        public void SetProduct(Product product) {
            EditableProduct = product;
            if (SimpleEditableProduct != null) {
                SimpleEditableProduct.ErrorsChanged -= RaiseCanExecuteChanged;
            }
            SimpleEditableProduct = new SimpleEditableProduct();
            SimpleEditableProduct.ErrorsChanged += RaiseCanExecuteChanged;
            CopyProduct(product, SimpleEditableProduct);
        }

        private void CopyProduct(Product source, SimpleEditableProduct target)
        {
            target.ProductID = source.ProductID;
            if (EditFlag) {
                target.ProductName = source.ProductName;
                target.Description = source.Description;
                target.Price = source.price;
                target.Category = source.category;
            }
        }

        private void RaiseCanExecuteChanged(object sender, DataErrorsChangedEventArgs e)
        {
            SaveCommand.RaiseCanExecuteChanged();
        }
    }
}
