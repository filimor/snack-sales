using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SnackSales.Models;

namespace SnackSales.Repositories
{
    public interface ICategoryRepository
    {
        IEnumerable<Category> Categories { get; }
    }
}
