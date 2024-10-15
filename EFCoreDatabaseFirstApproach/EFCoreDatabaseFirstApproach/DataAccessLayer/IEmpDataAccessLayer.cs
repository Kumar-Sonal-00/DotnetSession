using EFCoreDatabaseFirstApproach.Models;

namespace EFCoreDatabaseFirstApproach.DataAccessLayer
{
    public interface IEmpDataAccessLayer
    {
        List<TblEmployee> GetEmps();
        TblEmployee GetEmployee(int id);
        void AddEmployee(TblEmployee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(TblEmployee employee);
    }
}
