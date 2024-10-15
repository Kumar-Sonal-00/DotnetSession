using EFCoreDatabaseFirstApproach.Models;

namespace EFCoreDatabaseFirstApproach.DataAccessLayer
{
    public class EmpDataAccessLayer : IEmpDataAccessLayer
    {
        private readonly EmpDbContext _dbContext;
        public EmpDataAccessLayer(EmpDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public void AddEmployee(TblEmployee employee)
        {
            _dbContext.Add(employee);
            _dbContext.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            //find the record and delete
            var record=_dbContext.tbl_employee.Find(id);
            if (record != null)
            {
                _dbContext.tbl_employee.Remove(record);
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }

        public TblEmployee GetEmployee(int id)
        {
            //find the record and return
            var record = _dbContext.tbl_employee.Find(id);
            if (record != null)
            {
                return record;
            }
            else
            {
                throw new Exception("Record not found");
            }
        }

        public List<TblEmployee> GetEmps()
        {
            return _dbContext.tbl_employee.ToList();
        }

        public void UpdateEmployee(TblEmployee employee)
        {
            //find the record and update
            var record = _dbContext.tbl_employee.Find(employee.Ecode);
            if (record != null)
            {
                record.Ename  = employee.Ename;
                record.Salary= employee.Salary;
                record.Deptid = employee.Deptid;
                _dbContext.SaveChanges();
            }
            else
            {
                throw new Exception("Record not found");
            }
        }
    }
}
