﻿//TODO: Move to Interfaces folder

using SnackSales.Models;

namespace SnackSales.Repositories
{
    public interface IOrderRepository
    {
        void CreateOrder(Order order);
    }
}