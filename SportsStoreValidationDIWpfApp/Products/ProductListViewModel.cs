using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Collections.ObjectModel;
using SportsStoreDomainLibrary2.Abstract;
using SportsStoreDomainLibrary2.Entities;


namespace SportsStoreValidationDIWpfApp.Products
{
    class ProductListViewModel: BindableBase
    {
        private iProductRepository _ProductRepository;
        private ObservableCollection<Product> _Products;
        private List<Product> _allProducts;
        
        public ObservableCollection<Product> Products
        {
            get
            {
                return _Products;
            }

            set
            {
                SetProperty(ref _Products, value);
            }
        }

        public RelayCommand<Product> EditProductCommand { get; set; }
        public event Action<Product> EditProductRequested = delegate { };

        public RelayCommand<Product> DeleteProductCommand { get; set; }

        public ProductListViewModel(iProductRepository ProductRepository) {
            _ProductRepository = ProductRepository;
            EditProductCommand = new RelayCommand<Product>(OnEditProduct);
            DeleteProductCommand= new RelayCommand<Product>(OnDeleteProduct);
        }

        private void OnDeleteProduct(Product product)
        {
            Products.Remove(product);
        }

        private void OnEditProduct(Product product)
        {
            EditProductRequested(product);
        }

        public void LoadProjects() {
            GetAllProducts();
            GetProducts();
        }

        private void GetAllProducts() {
            _allProducts = _ProductRepository.getProductsAsync().Result;
        }

        private void GetProducts()
        {
            Products = new ObservableCollection<Product>(_allProducts);
        }
    }
}
