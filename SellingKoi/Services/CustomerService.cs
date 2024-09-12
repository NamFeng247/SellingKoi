using SellingKoi.Data;
using SellingKoi.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace SellingKoi.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly DataContext _context;

        public CustomerService(DataContext context)
        {
            _context = context;
        }

        // Create
        public async Task AddCustomerAsync(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
        }

        // Read
        public async Task<IEnumerable<Customer>> GetAllCustomersAsync()
        {
            return await _context.Customers.Where(c => c.Status == true).ToListAsync();
        }
        
        //get id by customer name
        public async Task<Guid?> GetIdByNameAsync(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return null;
            }

            var customer = await _context.Customers
                .Where(c => c.Name.ToLower() == name.ToLower())
                .FirstOrDefaultAsync();
            return customer?.Id;
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id)
        {

            return await _context.Customers.FindAsync(id);
        }

        // Update
        public async Task UpdateCustomerAsync(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        // Delete
        public async Task NegateCustomerAsync(Guid id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer != null)
            {
                
                try
                {
                    customer.Status = false;
                    _context.Customers.Update(customer);
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Log the exception
                    throw new Exception("An error occurred while deactivating the customer.", ex);
                }
            }
            else
            {
                throw new KeyNotFoundException($"Customer with ID {id} not found.");
            }
        }

       
    }
}
