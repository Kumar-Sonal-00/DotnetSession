using EFCoreDatabaseFirstApproach.Models;

namespace EFCoreDatabaseFirstApproach.BusinessLayer
{
    public interface IEmpBusinessLayer
    {
        List<TblEmployee> GetEmps();
        TblEmployee GetEmployee(int id);
        void AddEmployee(TblEmployee employee);
        void DeleteEmployee(int id);
        void UpdateEmployee(TblEmployee employee);

        //other logical methods
    }
}
