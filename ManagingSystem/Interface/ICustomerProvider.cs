using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagingSystem.Interface
{
    interface ICustomerProvider
    {
        List<Customer> GetAllCustomers();
        Customer SearchCustomerByName(string customerName);
    }
}
