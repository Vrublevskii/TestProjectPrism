using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using TestProjectPrism.DatabaseManager.Entity;
using TestProjectPrism.UIModule.ViewModels;
using TestProjectPrism.Utils;

namespace TestProjectPrism.DialogModule
{
    public static class DialogOpener
    {
        public static void ShowAddEmployee(this IDialogService dialogService,
            List<Department> departmentsList,
            List<Position> positionsList,
            Action<IDialogResult> callBack)
        {
            var parameters = new DialogParameters
            {
                {"title", "Добавить сотрудника" },
                {"employee", new Employee() },
                {"departments", departmentsList},
                {"positions", positionsList},
                {"okButtonContent", "Добавить" }
            };
            dialogService.ShowDialog("AddEditEmployee", parameters, callBack);
        }

        /*
        public static void ShowEditEmployee(this IDialogService dialogService,
            Employee employeeFromContext,
            Employee empltyEmployeeToChange,
            List<Department> departmentsList,
            List<Position> positionsList,
            Action<IDialogResult> callBack)
        {
            empltyEmployeeToChange.ObjectClonerWithout(employeeFromContext, "Department", "Position");
            empltyEmployeeToChange.Department = departmentsList.Find(d =>
                d.NameDepartment.Equals(employeeFromContext.Department.NameDepartment));
            empltyEmployeeToChange.Position = positionsList.Find(d =>
                d.NamePosition.Equals(employeeFromContext.Position.NamePosition));

            var parameters = new DialogParameters
            {
                {"title", "Редактировать сотрудника" },
                {"employee", empltyEmployeeToChange},
                {"departments", departmentsList},
                {"positions", positionsList},
                {"okButtonContent", "Редактировать" }
            };
            dialogService.ShowDialog("AddEditEmployee", parameters, callBack);
        }
        */

        public static void ShowEditDialog(this IDialogService dialogService,
           DbEntity entityFromContext,
           DbEntity entityEmployeeToChange,
           ControlsViewModel viewModel,
           Action<IDialogResult> callBack)
        {
            List<Department> deps = viewModel.Departments;
            List<Position> pos = viewModel.Positions;
            Employee employeeFromContext = (Employee)entityFromContext;
            Employee empltyEmployeeToChange = (Employee)entityEmployeeToChange;

            empltyEmployeeToChange.ObjectClonerWithout(employeeFromContext, "Department", "Position");
            empltyEmployeeToChange.Department = deps.Find(d =>
                d.NameDepartment.Equals(employeeFromContext.Department.NameDepartment));
            empltyEmployeeToChange.Position = pos.Find(d =>
                d.NamePosition.Equals(employeeFromContext.Position.NamePosition));

            var parameters = new DialogParameters
            {
                {"title", "Редактировать сотрудника" },
                {"employee", empltyEmployeeToChange},
                {"departments", deps},
                {"positions", pos},
                {"okButtonContent", "Редактировать" }
            };
            dialogService.ShowDialog("AddEditEmployee", parameters, callBack);
        }
        /*
        public static void ShowEditDialog(this IDialogService dialogService,
           DbEntity employeeFromContext,
           DbEntity empltyEmployeeToChange,
           ControlsViewModel viewModel,
           Action<IDialogResult> callBack)
        {
            List<Department> deps = viewModel.Departments;
            List<Position> pos = viewModel.Positions;

            empltyEmployeeToChange.ObjectClonerWithout(employeeFromContext, "Department", "Position");
            empltyEmployeeToChange.Department = deps.Find(d =>
                d.NameDepartment.Equals(employeeFromContext.Department.NameDepartment));
            empltyEmployeeToChange.Position = pos.Find(d =>
                d.NamePosition.Equals(employeeFromContext.Position.NamePosition));

            var parameters = new DialogParameters
            {
                {"title", "Редактировать сотрудника" },
                {"employee", empltyEmployeeToChange},
                {"departments", deps},
                {"positions", pos},
                {"okButtonContent", "Редактировать" }
            };
            dialogService.ShowDialog("AddEditEmployee", parameters, callBack);
        }

        public static void ShowEditDialog(this IDialogService dialogService,
           DbEntity employeeFromContext,
           DbEntity empltyEmployeeToChange,
           ControlsViewModel viewModel,
           Action<IDialogResult> callBack)
        {
            List<Department> deps = viewModel.Departments;
            List<Position> pos = viewModel.Positions;

            empltyEmployeeToChange.ObjectClonerWithout(employeeFromContext, "Department", "Position");
            empltyEmployeeToChange.Department = deps.Find(d =>
                d.NameDepartment.Equals(employeeFromContext.Department.NameDepartment));
            empltyEmployeeToChange.Position = pos.Find(d =>
                d.NamePosition.Equals(employeeFromContext.Position.NamePosition));

            var parameters = new DialogParameters
            {
                {"title", "Редактировать сотрудника" },
                {"employee", empltyEmployeeToChange},
                {"departments", deps},
                {"positions", pos},
                {"okButtonContent", "Редактировать" }
            };
            dialogService.ShowDialog("AddEditEmployee", parameters, callBack);
        }*/
    }
}