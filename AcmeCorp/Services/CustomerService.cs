using AcmeCorp.Interface;
using AcmeCorp.Model;

namespace AcmeCorp.Services
{
    public class CustomerService : ICustomerRepository
    {
        //private readonly ICustomerRepository _customerRepository;
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            //_customerRepository = userRepository;
            _context = context;
        }

        public Task<int> Create(Customer user)
        {
            _context.Add<Customer>(user);
            return _context.SaveChangesAsync();
        }

        public void Delete(Customer user)
        {
            throw new NotImplementedException();
        }

        public Customer GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Customer user)
        {
            throw new NotImplementedException();
        }
    }
}
