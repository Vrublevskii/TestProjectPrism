using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.UIModule.ViewModuleManager
{
    internal class ControlsManager
    {



        /*

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
        */



    }
}
