using System.Collections.Generic;

namespace DigitalWalletApi.Domain
{
    public interface ICategoryService
    {
        IEnumerable<Category> GetAll();
        bool Add(string description);
        bool Delete(int id);
    }
}