namespace AcmeCorp.Interface
{
    using Model;
    public interface ICustomerRepository
    {
        public Customer GetById(int id);
        public Task<int> Create(Customer user);
        public void Update(Customer user);
        public void Delete(Customer user);
    }
}
