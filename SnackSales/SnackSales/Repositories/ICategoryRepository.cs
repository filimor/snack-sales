//TODO: Move to Interfaces folder
using System.Collections.Generic;
using SnackSales.Models;

namespace SnackSales.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}