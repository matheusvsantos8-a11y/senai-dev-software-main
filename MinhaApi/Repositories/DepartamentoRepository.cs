using System.Runtime.CompilerServices;
using MinhaApi.Models;
using MinhaApi.Repositories;
using MySqlConnector;

public class DepartamentoRepository : IDepartamentoRepository
{

    private readonly string _connectionString;
    public DepartamentoRepository(IConfiguration config) 
    => _connectionString = config.GetConnectionString("DefaultConnection")!;


    private static List<Departamento> _db = new()
    {
        new Departamento { Id = 1, Nome = "Saogustavo", Descricao = "Contra violações de direito"},

        new Departamento {Id = 2, Nome = "conves", Descricao = "Ajudando a melhorar seu dia"}
    };

     public IEnumerable<Departamento> GetAll() 
     {
        var lista = new List<Departamento>();
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();

        string sql = "SELECT id, nome, descricao, ativo FROM produto";
        using var cmd = new MySqlCommand(sql, conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read()) 
        {
            lista.Add(new Departamento 
            {
                Id = reader.GetInt32("id"),
                Nome = reader.GetString("nome"),
                Descricao = reader.GetString("descricao"),
                Ativo = reader.GetBoolean("ativo")
            });
        }
        return lista;
     }
    
    public Departamento? GetById(int id)
        => _db.FirstOrDefault(D => D.Id == id);

    public void Add(Departamento D) 
    {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();

        string sql = @"INSERT INTO departamento (nome, descricao, ativo) 
                    VALUES (@Nome, @Descricao, @Ativo);
                    SELECT LAST_INSERT_ID();";

        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Nome", D.Nome);
        cmd.Parameters.AddWithValue("@Descricao", D.Descricao);
        cmd.Parameters.AddWithValue("@Ativo", D.Ativo);

        var idGerado = cmd.ExecuteScalar();
        D.Id = Convert.ToInt32(idGerado);
    }

    public void Update(Departamento D)
    {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = @"UPDATE departamento
                     SET nome = @Nome, Descricao = @Descricao, ativo = @Ativo WHERE id = @Id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", D.Id);
        cmd.Parameters.AddWithValue("@Nome", D.Nome);
        cmd.Parameters.AddWithValue("@Descricao", D.Descricao);
        cmd.Parameters.AddWithValue("@Ativo", D.Ativo);
        cmd.ExecuteNonQuery();
    }

    public void Delete(int id)
    {
        using var conn = new MySqlConnection(_connectionString);
        conn.Open();
        string sql = "DELETE FROM produto WHERE id = @Id";
        using var cmd = new MySqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@Id", id);
        cmd.ExecuteNonQuery();
    }

}




