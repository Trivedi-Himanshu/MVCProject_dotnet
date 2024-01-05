using HRAPP.Entities;
using HRAPP.Repositories;
namespace HRAPP.Services;

public class EmployeeService:IEmployeeService{
    public List<Employee> GetAll(){
       List<Employee> employees=new List<Employee>();
       /*employees.Add(new Employee{Id=1, Name="Shivam"});
       employees.Add(new Employee{Id=2, Name="Chirag"});
       employees.Add(new Employee{Id=1, Name="Manisha"});
       employees.Add(new Employee{Id=1, Name="shailesh"});*/
       RepositoryManager mgr=new RepositoryManager();
       string fileName=@"D:\Ravi\employees.json";
       employees=mgr.DeSerialize(fileName);
       return employees;
    }
    public Employee GetById(int id){
      List<Employee> employees=new List<Employee>();
      RepositoryManager mgr=new RepositoryManager();
      string fileName=@"D:\Ravi\employees.json";
      employees=mgr.DeSerialize(fileName);
      Employee emp=employees.Find(emp=>emp.Id==id);
      return emp;
    }
    public void Insert(Employee emp){}
     public void Update(Employee emp){}
     public void Delete(int id){

     }

}