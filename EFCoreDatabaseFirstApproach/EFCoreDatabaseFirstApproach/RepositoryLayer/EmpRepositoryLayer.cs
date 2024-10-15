using EFCoreDatabaseFirstApproach.DataAccessLayer;
using EFCoreDatabaseFirstApproach.Models;

namespace EFCoreDatabaseFirstApproach.RepositoryLayer
{
    public class EmpRepositoryLayer : IEmpRepositoryLayer
    {
        private readonly IEmpDataAccessLayer _dal;
        public EmpRepositoryLayer(IEmpDataAccessLayer dal)
        {
            this._dal = dal;
        }
        public void AddEmployee(TblEmployee employee)
        {
            _dal.AddEmployee(employee);
        }

        public void DeleteEmployee(int id)
        {
            _dal.DeleteEmployee(id);
        }

        public TblEmployee GetEmployee(int id)
        {
            return _dal.GetEmployee(id);
        }

        public List<TblEmployee> GetEmps()
        {
            return _dal.GetEmps();
        }

        public void UpdateEmployee(TblEmployee employee)
        {
            _dal.UpdateEmployee(employee);
        }
    }
}
