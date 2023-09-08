using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestProjectPrism.DatabaseManager;
using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.DatabaseManager.Entity;
using TestProjectPrism.DialogModule;

namespace TestProjectPrism.UIModule.ViewModels
{
    public class ControlsViewModel : BindableBase
    {
        private string _title = "Prism Application";
        private IDialogService _dialogService;
        private EmployeeContext _employeeContext;
        private List<Employee> _employees;
        private List<Department> _departments;
        private List<Position> _positions;

        private DelegateCommand _reloadCommand;
        private DelegateCommand _addCommand;
        private DelegateCommand<Employee> _changeCommand;
        private DelegateCommand<Employee> _deleteCommand;
        private DelegateCommand<string> _filterCommand;

        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

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

        public ControlsViewModel(IDialogService dialogService, EmployeeContext employeeContext)
        {
            _dialogService = dialogService;
            _employeeContext = employeeContext;
        }

        public ICommand ReloadCommand => _reloadCommand ??= new DelegateCommand(async () => await LoadData());
        public ICommand AddCommand => _addCommand ??= new DelegateCommand(AddEmployee);
        public ICommand ChangeCommand => _changeCommand ??= new DelegateCommand<Employee>(Change);
        public ICommand DeleteCommand => _deleteCommand ??= new DelegateCommand<Employee>(async (Employee employee) => await Delete(employee));
        public ICommand FilterCommand => _filterCommand ??= new DelegateCommand<string>(async (string filterParam) => await Filter(filterParam));


        private async Task LoadData()
        {
            Employees = await _employeeContext.Employees.ToListAsync();
            Departments = await _employeeContext.Departments.ToListAsync();
            Positions = await _employeeContext.Positions.ToListAsync();
        }

        private void AddEmployee()
        {
            _dialogService.ShowAddEmployee(async r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    var employee = r.Parameters.GetValue<Employee>("employee");
                    await CRUDRepository.CreateEmployee(_employeeContext, employee);
                    await LoadData();//не работает?
                }
            });
        }

        private void Change(Employee employee)
        {
            if (employee == null) return;

            Employee dialogEmployee = EntityFactory.GetEmptyEmployee();

            _dialogService.ShowEditEmployee(employee, dialogEmployee, Departments, Positions, async r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    await CRUDRepository.UpdateEmployee(_employeeContext, employee, dialogEmployee);
                    await LoadData();//не работает?
                }
            });
        }

        private async Task Delete(Employee employee)
        {
            if (employee != null)
            {
                _employeeContext.Employees.Remove(employee);
                await _employeeContext.SaveChangesAsync();
                await LoadData();//не работает?
            }
        }

        private async Task Filter(string filterParam)
        {
            if (filterParam != null)
            {
                /*Employees = (from employee in _employeeContext.Employees
                             where employee.Name == filterParam
                             select employee).ToList();*/
                //не работает!
                Employees = await _employeeContext.Employees.Where(e => e.Name == filterParam).ToListAsync();
            }
        }
    }
}