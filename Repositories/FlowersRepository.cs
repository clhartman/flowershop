using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using flowershop.Models;

namespace flowershop.Repositories
{
  public class FlowerRepository
  {
    private readonly IDbConnection _db;
    public FlowerRepository(IDbConnection db)
    {
      _db = db;
    }

    public IEnumerable<Flower> GetAll()
    {
      return _db.Query<Flower>("SELECT * FROM flowers");
    }

    public Flower GetById(int id)
    {
      string query = "SELECT * FROM flowers WHERE id = @id";
      Flower data = _db.QueryFirstOrDefault<Flower>(query, new { id });
      if (data == null) throw new Exception("Invalid ID");
      return data;
    }

    public Flower Create(Flower value)
    {
      string query = @"INSERT INTO flowers (type, description, quantity, price) VALUES (@Type, @Description, @Quantity, @Price); SELECT LAST_INSERT_ID();";
      int id = _db.ExecuteScalar<int>(query, value);
      value.Id = id;
      return value;
    }

    public Flower Update(Flower value)
    {
      string query = @"
        UPDATE flowers
        SET
          type = @Type,
          description = @Description,
          quantity = @Quantity,
          price = @Price
        WHERE id = @Id;
        SELECT * FROM flowers WHERE id = @Id
        ";
      return _db.QueryFirstOrDefault<Flower>(query, value);
    }

    public string Delete(int id)
    {
      string query = "DELETE FROM flowers WHERE id = @id";
      int ChangedRows = _db.Execute(query, new { id });
      if (ChangedRows < 1) throw new Exception("Invalid ID");
      return "Successfully Deleted Flower";
    }
  }
}