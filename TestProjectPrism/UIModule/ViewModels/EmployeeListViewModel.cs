using Prism.Mvvm;
using System.Collections.Generic;
using System.Linq;
using TestProjectPrism.DatabaseManager.Contexts;
using TestProjectPrism.DatabaseManager.Entity;

namespace TestProjectPrism.UIModule.ViewModels
{
    public class EmployeeListViewModel : BindableBase
    {

        private UserContext _userContext;
        private List<User> _users;

        public List<User> Users 
        {
            get => _users;
            set => SetProperty(ref _users, value);
        }


        public EmployeeListViewModel(UserContext userContext)
        {            
            _userContext = userContext;
            _users = _userContext.Users.ToList();
        }

    }
}
