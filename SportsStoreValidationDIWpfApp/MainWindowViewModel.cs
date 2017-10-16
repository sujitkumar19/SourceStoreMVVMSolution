using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SportsStoreValidationDIWpfApp.Products;
using Microsoft.Practices.Unity;
using SportsStoreDomainLibrary2.Entities;

namespace SportsStoreValidationDIWpfApp
{
    class MainWindowViewModel:BindableBase
    {
        private BindableBase _CurrentViewModel;
        private ProductListViewModel _ProductListViewModel;
        private AddEditProductViewModel _AddEditProductViewModel;

        public RelayCommand<string> NavigateCommand { get; private set; }
        public RelayCommand<string> AddNewProductCommand { get; private set; }

        public BindableBase CurrentViewModel
        {
            get
            {
                return _CurrentViewModel;
            }

            set
            {
                SetProperty(ref _CurrentViewModel, value);
            }
        }

        public MainWindowViewModel() {
            _ProductListViewModel = SportsStoreContainer.Container.Resolve<ProductListViewModel>();
            _ProductListViewModel.EditProductRequested += NavigateToEditProduct;

            _AddEditProductViewModel = SportsStoreContainer.Container.Resolve<AddEditProductViewModel>();
            _AddEditProductViewModel.CancelCommandRequest += OnNavigate;
            _AddEditProductViewModel.SaveCommandRequest += OnNavigate;

            NavigateCommand = new RelayCommand<string>(OnNavigate);
            AddNewProductCommand = new RelayCommand<string>(OnAddNewProduct);
        }

        private void NavigateToEditProduct(SportsStoreDomainLibrary2.Entities.Product product)
        {
            _AddEditProductViewModel.EditFlag = true;
            _AddEditProductViewModel.SetProduct(product);
            CurrentViewModel = _AddEditProductViewModel;
        }

        private void OnAddNewProduct(string obj)
        {
            _AddEditProductViewModel.EditFlag = false;
            _AddEditProductViewModel.SetProduct(new Product());
            CurrentViewModel = _AddEditProductViewModel;
        }

        private void OnNavigate(string destination)
        {
            switch (destination)
            {
                case "addNewProduct":
                    _AddEditProductViewModel.EditFlag = false;
                    CurrentViewModel = _AddEditProductViewModel;
                    break;
                default:
                    CurrentViewModel = _ProductListViewModel;
                    break;
            }
        }
    }
}
