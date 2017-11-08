using ES.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ES.Data.Repositories.Interfaces
{
    public interface ICustomerRepository : Repository<Customer>
    {
        IEnumerable<Customer> GetTopActiveCustomers(int count);
        IEnumerable<Customer> GetAllCustomersData();
    }
}
