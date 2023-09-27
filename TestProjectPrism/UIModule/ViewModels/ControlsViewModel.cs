using Microsoft.EntityFrameworkCore;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.DatabaseManager.Entity;
using TestProjectPrism.DialogModule;
using TestProjectPrism.EventAggregator.Events;

namespace TestProjectPrism.UIModule.ViewModels
{
    public class ControlsViewModel : BindableBase
    {
        private IDialogService _dialogService;
        private EmployeeContext _employeeContext;
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


        public ControlsViewModel(IDialogService dialogService, EmployeeContext employeeContext, IEventAggregator eventAggregator)
        {
            _dialogService = dialogService;
            _employeeContext = employeeContext;
            _eventAggregator = eventAggregator;

            _eventAggregator.GetEvent<MouseDoubleClickEvent>().Subscribe(dbEntity => Change((Employee)dbEntity));
        }

        private DelegateCommand _reloadCommand;
        public ICommand ReloadCommand => _reloadCommand ??= new DelegateCommand(async () => await LoadData());

        private DelegateCommand<List<Employee>> _sendEmployeesCommand;
        public ICommand SendEmployeesCommand => _sendEmployeesCommand ??= new DelegateCommand<List<Employee>>(
            async (List<Employee> employees) => await LoadData());

        private DelegateCommand _addCommand;
        public ICommand AddCommand => _addCommand ??= new DelegateCommand(Add);

        private DelegateCommand<Employee> _changeCommand;
        public ICommand ChangeCommand => _changeCommand ??= new DelegateCommand<Employee>(Change);

        private DelegateCommand<Employee> _deleteCommand;
        public ICommand DeleteCommand => _deleteCommand ??= new DelegateCommand<Employee>(async (employee) => await Delete(employee));

        private DelegateCommand<string> _filterCommand;
        public ICommand FilterCommand => _filterCommand ??= new DelegateCommand<string>(async (filterParam) => await Filter(filterParam));


        private async Task LoadData()
        {
            Employees = await _employeeContext.Employees.ToListAsync();
            Departments = await _employeeContext.Departments.ToListAsync();
            Positions = await _employeeContext.Positions.ToListAsync();

            _eventAggregator.GetEvent<ListEvent>().Publish(Employees);
        }

        private void Add()
        {
            _dialogService.ShowAddEmployee(Departments, Positions, async r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    Employee employee = r.Parameters.GetValue<Employee>("employee");

                    string email = employee.Email;
                    foreach (var empl in _employees)
                    {
                        if (empl.Email.Equals(email))
                        {
                            //написать в UI, что мыло уже занято
                        }
                    }

                    employee.GetManager().CreateInContext(_employeeContext, employee);
                    await _employeeContext.SaveChangesAsync();
                    await LoadData();//не работает?

                    _eventAggregator.GetEvent<ListEvent>().Publish(Employees);
                }
            });
        }

        private void Change(Employee employee)
        {
            if (employee == null) return;

            Employee dialogEmployee = new Employee()
            {
                Department = new Department(),
                Position = new Position()
            };

            _dialogService.ShowEditDialog(employee, dialogEmployee, this, async r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    employee.GetManager().UpdateInContext(_employeeContext, employee, dialogEmployee);
                    //_employeeContext.UpdateInContext(employee, dialogEmployee);
                    await _employeeContext.SaveChangesAsync();

                    await LoadData();//тут не работает?

                    _eventAggregator.GetEvent<ListEvent>().Publish(Employees);
                }
            });
        }

        private async Task Delete(Employee employee)
        {
            if (employee != null)
            {
                employee.GetManager().DeleteInContext(_employeeContext, employee);
                //_employeeContext.DeleteInContext(employee);
                await _employeeContext.SaveChangesAsync();

                await LoadData();//тут не работает?

                _eventAggregator.GetEvent<ListEvent>().Publish(Employees);
            }
        }

        private async Task Filter(string filterParam)
        {
            if (filterParam != null)
            {
                //Employees = (from employee in _employeeContext.Employees
                //      where employee.Name == filterParam
                //      select employee).ToList();
                //не работает!
                Employees = await _employeeContext.Employees.Where(e => EF.Functions.Like(e.Name!, $"%{filterParam}%")).ToListAsync();

                _eventAggregator.GetEvent<ListEvent>().Publish(Employees);

            }
        }








        /*
        private void Add()
        {
            _dialogService.ShowAddEmployee(Departments, Positions, async r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    var employee = r.Parameters.GetValue<Employee>("employee");

                    string email = employee.Email;
                    foreach (var empl in _employees)
                    {
                        if (empl.Email.Equals(email))
                        {
                            //написать в UI, что мыло уже занято
                        }
                    }

                    await _employeeContext.CreateInContextAsync(employee);
                    await _employeeContext.SaveChangesAsync();
                    await LoadData();//не работает?

                    _eventAggregator.GetEvent<ListEvent>().Publish(Employees);
                }
            });
        }
        
        private void Change(Employee employee)
        {
            if (employee == null) return;

            Employee dialogEmployee = new Employee()
            {
                Department = new Department(),
                Position = new Position()
            };

            _dialogService.ShowEditEmployee(employee, dialogEmployee, Departments, Positions, async r =>
            {
                if (r.Result == ButtonResult.OK)
                {
                    _employeeContext.UpdateInContext(employee, dialogEmployee);
                    await _employeeContext.SaveChangesAsync();

                    await LoadData();//тут не работает?

                    _eventAggregator.GetEvent<ListEvent>().Publish(Employees);
                }
            });
        }

        private async Task Delete(Employee employee)
        {
            if (employee != null)
            {
                _employeeContext.DeleteInContext(employee);
                await _employeeContext.SaveChangesAsync();

                await LoadData();//тут не работает?

                _eventAggregator.GetEvent<ListEvent>().Publish(Employees);
            }
        }

        private async Task Filter(string filterParam)
        {
            if (filterParam != null)
            {
                //Employees = (from employee in _employeeContext.Employees
                //      where employee.Name == filterParam
                //      select employee).ToList();
                //не работает!
                Employees = await _employeeContext.Employees.Where(e => EF.Functions.Like(e.Name!, $"%{filterParam}%")).ToListAsync();

                _eventAggregator.GetEvent<ListEvent>().Publish(Employees);

            }
        }
        */
    }
}