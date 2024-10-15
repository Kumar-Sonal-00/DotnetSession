using EFCoreDatabaseFirstApproach.Models;
using EFCoreDatabaseFirstApproach.RepositoryLayer;

namespace EFCoreDatabaseFirstApproach.BusinessLayer
{
    public class EmpBusinessLayer : IEmpBusinessLayer
    {
        private readonly IEmpRepositoryLayer repository;
        public EmpBusinessLayer(IEmpRepositoryLayer repo)
        {
            this.repository = repo;
        }
        public void AddEmployee(TblEmployee employee)
        {
            repository.AddEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            repository.DeleteEmployee(id);
        }

        public TblEmployee GetEmployee(int id)
        {
            return repository.GetEmployee(id);
        }

        public List<TblEmployee> GetEmps()
        {
            return repository.GetEmps();
        }

        public void UpdateEmployee(TblEmployee employee)
        {
            repository.UpdateEmployee(employee);
        }
    }
}
