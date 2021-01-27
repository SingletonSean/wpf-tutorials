using NavigationMVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NavigationMVVM.Stores
{
    public class AccountStore
    {
        private Account _currentAccount;
        public Account CurrentAccount
        {
            get => _currentAccount;
            set
            {
                _currentAccount = value;
            }
        }
    }
}
