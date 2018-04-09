using System.Data.Entity;

namespace TestNinja.Mocking
{
    public class EmployeeController
    {
        private IEmployeeRepository _empRepository;


        public EmployeeController(IEmployeeRepository empRepository = null)
        {
            _empRepository = empRepository ?? new EmployeeRepository();
        }

        public ActionResult DeleteEmployee(int id)
        {

            _empRepository.DeleteEmployee(id);

            return RedirectToAction("Employees");
        }

        private ActionResult RedirectToAction(string employees)
        {
            return new RedirectResult();
        }
    }

    public class ActionResult { }
 
    public class RedirectResult : ActionResult { }

    public class EmployeeRepository : IEmployeeRepository
    {
        private EmployeeContext _empContext = new EmployeeContext();

        public void DeleteEmployee(int ID)
        {
            var employee = _empContext.Employees.Find(ID);
            if (employee == null) return;
            _empContext.Employees.Remove(employee);
            _empContext.SaveChanges();

        }

    }

    public interface IEmployeeRepository
    {
        void DeleteEmployee(int ID);
    }

    public class EmployeeContext
    {
        public DbSet<Employee> Employees { get; set; }

        public void SaveChanges()
        {
        }
    }

    public class Employee
    {
    }
}