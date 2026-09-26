using MinhaApi.Models;

namespace MinhaApi.Services;

public interface IDepartamentoService
{
    IEnumerable<Departamento> GetAll();
    Departamento? GetById(int id);
    Departamento  Create(Departamento departamento);

    void Add (Departamento departamento);
    Departamento? Update(int id, Departamento departamento);
    bool     Delete(int id);
    void Update(Func<Departamento, Departamento> departamento);
}