using SoftUni.Data;
using System;
using System.Text;
using System.Linq;
using SoftUni.Models;

namespace SoftUni
{
    public class StartUp
    {
       public static void Main(string[] args)
       {
            SoftUniContext context = new SoftUniContext();
            Console.WriteLine(GetEmployeesInPeriod(context)); 
       }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Select(e => new
                {
                    Id = e.EmployeeId,
                    Name = String.Join(" ",e.FirstName, e.LastName, e.MiddleName),
                    e.JobTitle,
                    e.Salary
                })
            .OrderBy(e => e.Id);

            foreach (var item in employees)
            {
                sb.AppendLine($"{item.Name} {item.JobTitle} {item.Salary:f2}");
            }
            
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                            .Select(e => new
                            {
                                FirstName = e.FirstName,
                                Salary = e.Salary,
                            })
                            .Where(e=> e.Salary > 50000)
                            .OrderBy(e => e.FirstName);
            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} - {e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                                   .Select(e => new
                                   {
                                       FirstName = e.FirstName,
                                       LastName = e.LastName,
                                       Department = e.Department,
                                       Salary = e.Salary,
                                   })
                                   .Where(e => e.Department.Name == "Research and Development")
                                   .OrderBy(e => e.Salary)
                                   .OrderBy(e => e.FirstName);


            foreach (var e in employees)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} from {e.Department.Name} - ${e.Salary:f2}");
            }
            return sb.ToString().TrimEnd();
        }

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var address = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            Employee nakov = context.Employees.First(e=>e.LastName == "Nakov");

            nakov.Address = address;

            context.SaveChanges();

            var addressTexts = context.Employees
                                     .OrderByDescending(e => e.AddressId)
                                     .Select(e => new
                                     {
                                         AddressText = e.Address.AddressText,
                                         
                                     })
                                     .Take(10)
                                     .ToList();

            foreach (var item in addressTexts)
            {
                sb.AppendLine(item.AddressText);
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees
                .Select(e => new
                {
                    EmployeeFirstName = e.FirstName,
                    EmployeeLastName = e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                })
                .Take(10)
                .ToList();

            var projects = context.Projects
                .Select(e => new
                {
                    StartDate = e.StartDate,
                    EndDate = e.EndDate,
                    ProjectName = e.Name
                });
                
            foreach (var item in employees)
            {
                sb.AppendLine($"{item.EmployeeFirstName} {item.EmployeeLastName} - Manager: {item.ManagerFirstName} {item.ManagerLastName}");
                foreach (var project in projects)
                {
                    if (project.EndDate == null)
                    {
                        sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - not finished");
                    }
                    else
                    {
                        sb.AppendLine($"--{project.ProjectName} - {project.StartDate} - {project.EndDate}");
                    }
                }
               
            }
            return sb.ToString().TrimEnd();
        }

        public static string GetAddressesByTown(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var addresses = context.Addresses.Select(a => new
            {
                AddressText = a.AddressText,
                TownName = a.Town.Name,
                EmployeeCount = a.Employees.Count
            })
            .OrderByDescending(a => a.EmployeeCount)
            .OrderBy(a => a.TownName)
            .OrderBy(a => a.AddressText)
            .Take(10);
            

            foreach (var item in addresses)
            {
                sb.AppendLine($"{item.AddressText}, {item.TownName} - {item.EmployeeCount} employees");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployee147(SoftUniContext context)
        {
            var sb = new StringBuilder();
            var employees = context.Employees.Select(e => new
            {
                FirstName = e.FirstName,
                Id = e.EmployeeId,
                LastName = e.LastName,
                JobTitle = e.JobTitle,
                Projects = e.EmployeesProjects.OrderBy(p=> p.Project.Name).ToList()
            })
            .Where(e => e.Id == 147)
            .ToList();


            foreach (var employee in employees)
            {
                
                sb.AppendLine($"{employee.FirstName} {employee.LastName} - {employee.JobTitle}");
                foreach (var project in employee.Projects)
                {
                    var singleProjectName = employee.Projects.First().Project.Name;
                    sb.AppendLine(singleProjectName);
                }
            }
            

            return sb.ToString().TrimEnd();
        }
    }
}
