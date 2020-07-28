//TODO: Move to Interfaces folder

using System.Collections.Generic;
using SnackSales.Models;

namespace SnackSales.Repositories
{
    public interface ISnackRepository
    {
        IEnumerable<Snack> Snacks { get; }
        IEnumerable<Snack> FavoriteSnacks { get; }

        Snack GetSnackById(int snackId);
    }
}