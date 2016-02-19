using Mobile.Model;

namespace Mobile.ViewModel.Messages
{
    public class CustomerStatus
    {
        public CustomerStatus(Customer customer)
        {
            Customer = customer;
        }

        public Customer Customer { get; private set; }
    }
}