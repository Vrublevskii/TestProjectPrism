using Prism.Commands;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.DialogModule.ViewModels;

public class AddEditEmployeeViewModel : BindableBase, IDialogAware
{
    private string _title;
    private Employee _employee;
    List<Department> _departments;
    List<Position> _positions;
    private string _okButtinContent;

    private DelegateCommand<string> _closeCommand;

    public event Action<IDialogResult> RequestClose;

    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    public Employee Employee
    {
        get => _employee;
        set => SetProperty(ref _employee, value);
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

    public string OkButtinContent
    {
        get => _okButtinContent;
        set => SetProperty(ref _okButtinContent, value);
    }

    public bool CanCloseDialog()
    {
        return true;
    }

    public void OnDialogClosed()
    {

    }

    public void OnDialogOpened(IDialogParameters parameters)
    {
        Title = parameters.GetValue<string>("title");
        Employee = parameters.GetValue<Employee>("employee");
        Departments = parameters.GetValue<List<Department>>("departments");
        Positions = parameters.GetValue<List<Position>>("positions");
        OkButtinContent = parameters.GetValue<string>("okButtonContent");
    }

    public ICommand CloseCommand => _closeCommand ??= new DelegateCommand<string>(CloseDialog);


    protected virtual void CloseDialog(string parameter)
    {
        ButtonResult result = ButtonResult.None;

        if (parameter?.ToLower() == "true") result = ButtonResult.OK;
        else if (parameter?.ToLower() == "false") result = ButtonResult.Cancel;

        RaiseRequestClose(new DialogResult(result, new DialogParameters()
        {
            { "employee", Employee }
        }));
    }

    public virtual void RaiseRequestClose(DialogResult dialogResult) => RequestClose?.Invoke(dialogResult);
}
