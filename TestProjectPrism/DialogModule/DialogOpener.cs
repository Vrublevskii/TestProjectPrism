using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using TestProjectPrism.DatabaseManager;
using TestProjectPrism.DatabaseManager.Entity;
using TestProjectPrism.Utils;

namespace TestProjectPrism.DialogModule
{
    public static class DialogOpener
    {
        public static void ShowAddEmployee(this IDialogService dialogService, Action<IDialogResult> callBack)
        {
            var parameters = new DialogParameters
            {
                {"title", "Добавить сотрудника" },
                {"employee", EntityFactory.GetEmptyEmployee() },
                {"okButtonContent", "Добавить" }
            };
            dialogService.ShowDialog("AddEditEmployee", parameters, callBack);
        }

        public static void ShowEditEmployee(this IDialogService dialogService,
            Employee employeeFromContext,
            Employee empltyEmployeeToChange,
            List<Department> departmentList,
            List<Position> positionList,
            Action<IDialogResult> callBack)
        {
            empltyEmployeeToChange.ObjectClonerWithout(employeeFromContext, "Department", "Position");
            empltyEmployeeToChange.Department.ObjectClonerWithout(employeeFromContext.Department, "Employees");
            empltyEmployeeToChange.Position.ObjectClonerWithout(employeeFromContext.Position, "Employees");
            
            var parameters = new DialogParameters
            {
                {"title", "Редактировать сотрудника" },
                {"employee", empltyEmployeeToChange},
                {"departments", departmentList},
                {"positions", positionList},
                {"okButtonContent", "Редактировать" }
            };
            dialogService.ShowDialog("AddEditEmployee", parameters, callBack);
        }
    }
}
