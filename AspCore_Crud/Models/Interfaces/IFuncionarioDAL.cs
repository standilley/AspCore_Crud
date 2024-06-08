using System.Collections;

namespace AspCore_Crud.Models.Interfaces
{
    public interface IFuncionarioDAL
    {
        IEnumerable<Funcionario> GetAllFuncionarios();
        void AddFuncionario(Funcionario funcionario);
        void UpdateFuncionario(Funcionario funcionario);
        Funcionario GetFuncionario(int id);
        void DeleteFuncionario(int? id);
    }
}
