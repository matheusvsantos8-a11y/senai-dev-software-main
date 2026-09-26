using System.Runtime.CompilerServices;
using MinhaApi.Models;
using MinhaApi.Repositories;
using MinhaApi.Services;

public class DepartamentoService : IDepartamentoService 
{


private readonly IDepartamentoService _repo;

public DepartamentoService(IFornecedorRepository repo)
      => _repo = repo;

public IEnumerable <Departamento> GetAll()
=> _repo.GetAll();

public Departamento? GetById(int id)
=> _repo.GetById(id);


public Departamento departamento  (Departamento departamento)
{
      if (departamento.Descricao == null && departamento.Nome == null )
          throw new ArgumentException("Nome inválido");
      _repo.Add(departamento);
      return departamento;
  }

  public Departamento? Update(int id, Departamento D)
  {
      if (_repo.GetById(id) == null) return null;
      D.Id = id;
      _repo.Update(departamento);
      return D;
  }

  public bool Delete(int id)
  {
        if (_repo.GetById(id) == null) return false;
            _repo.Delete(id);
        return true;
  }
}

