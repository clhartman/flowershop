using System.Data;

namespace flowershop.Repositories
{
  public class ChocolateRepository
  {
    private readonly IDbConnection _db;
    public ChocolateRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}