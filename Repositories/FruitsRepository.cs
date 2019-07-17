using System.Data;

namespace flowershop.Repositories
{
  public class FruitRepository
  {
    private readonly IDbConnection _db;
    public FruitRepository(IDbConnection db)
    {
      _db = db;
    }
  }
}