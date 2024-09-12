using SellingKoi.Models.Entities;

namespace SellingKoi.Services
{
    public interface ICustomerService
    {
        Task<IEnumerable<Customer>> GetAllCustomersAsync();
        Task<Customer> GetCustomerByIdAsync(Guid id);
        Task<Guid?> GetIdByNameAsync(string name);
        Task AddCustomerAsync(Customer customer);
        Task UpdateCustomerAsync(Customer customer);
        Task NegateCustomerAsync(Guid id);
    }
}
