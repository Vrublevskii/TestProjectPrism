using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.DatabaseManager.Entity;
using TestProjectPrism.EventAggregator.Events;

namespace TestProjectPrism.UIModule.ViewModels
{
    public class ResultViewModel : BindableBase
    {
        private IEventAggregator _eventAggregator;

        private List<Employee> _employees;
        private List<Department> _departments;
        private List<Position> _positions;


        public List<Employee> Employees
        {
            get => _employees;
            set => SetProperty(ref _employees, value);
        }

        public List<Department> Departments
        {
            get => _departments;
            set => SetProperty(ref _departments, value);
        }

        public List<Position> Positions
        {
            get => _positions;
            set => SetProperty(ref _positions, value);
        }


        public ResultViewModel(IEventAggregator eventAggregator)
        {
            _eventAggregator = eventAggregator;
            eventAggregator.GetEvent<ListEvent>().Subscribe((List<Employee> listEmployees) => Employees = listEmployees);
        }

        private DelegateCommand<DbEntity> _sendChangeCommand;

        public ICommand SendChangeCommand => _sendChangeCommand ??= new DelegateCommand<DbEntity>(dbEntity => 
        _eventAggregator.GetEvent<MouseDoubleClickEvent>().Publish(dbEntity) );

    }
}
