using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services;

public class OrderService : IOrderService
{
    private readonly ApplicationDbContext _context;

    public OrderService(ApplicationDbContext context) => _context = context;

    public async Task<Order?> GetOrder() => await _context.Orders
        .OrderByDescending(o => o.Quantity * o.Price)
        .FirstOrDefaultAsync();


    public async Task<List<Order>> GetOrders() => await _context.Orders
        .Where(o => o.Quantity > 10)
        .ToListAsync();
}