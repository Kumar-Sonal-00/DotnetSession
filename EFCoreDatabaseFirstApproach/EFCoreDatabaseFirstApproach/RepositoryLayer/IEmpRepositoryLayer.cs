using EFCoreDatabaseFirstApproach.Models;

namespace EFCoreDatabaseFirstApproach.RepositoryLayer
{
    public interface IEmpRepositoryLayer
    {
        List<TblEmployee> GetEmps();
        TblEmployee GetEmployee(int id);
        void AddEmployee(TblEmployee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(TblEmployee employee);
    }
}
