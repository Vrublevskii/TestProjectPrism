﻿using Prism.Mvvm;

namespace TestProjectPrism.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title = "Employee list";
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public MainWindowViewModel()
        {

        }
    }
}
