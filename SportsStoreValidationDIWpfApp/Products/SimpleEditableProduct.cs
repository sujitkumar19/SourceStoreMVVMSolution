﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SportsStoreValidationDIWpfApp.Products
{
    public class SimpleEditableProduct:ValidatableBindableBase
    {
        private int _productID;
        private string _productName;
        private string _description;
        private decimal _price;
        private string _category;

        public int ProductID
        {
            get
            {
                return _productID;
            }

            set
            {
                SetProperty(ref _productID, value);
            }
        }

        [Required(ErrorMessage ="Enter a Product Name")]
        public string ProductName
        {
            get
            {
                return _productName;
            }

            set
            {
                SetProperty(ref _productName, value);
            }
        }
        [Required(ErrorMessage = "Enter a Description")]
        public string Description
        {
            get
            {
                return _description;
            }

            set
            {
                SetProperty(ref _description, value);
            }
        }
        [Required(ErrorMessage = "Enter a positive price")]
        public decimal Price
        {
            get
            {
                return _price;
            }

            set
            {
                SetProperty(ref _price, value);
            }
        }
        [Required(ErrorMessage = "Enter a Category")]
        public string Category
        {
            get
            {
                return _category;
            }

            set
            {
                SetProperty(ref _category, value);
            }
        }
    }
}
