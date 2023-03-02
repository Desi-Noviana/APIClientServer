using API.Contexts;
using API.Handler;
using API.Models;
using API.Repositories.Interface;
using API.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Repositories.Data
{
    public class AccountRepository : GeneralRepository<string, Account>
    {
        private readonly MyContexts context;
        public AccountRepository(MyContexts context) : base(context) // base ---> constraktor dari general revo dimana memilki context
        {
            this.context = context;
        }
        public async Task<int> Register(RegisterVM registerVM)
        {
            int result = 0;
            University university = new University
            {
                Name = registerVM.UniversityName
            };

            // Bikin kondisi untuk mengecek apakah data university sudah ada
            if (await context.Universities.AnyAsync(u => u.Name == university.Name))
            {
                university.Id = context.Universities
                    .FirstOrDefault(u => u.Name == university.Name)
                    .Id;
            }
            else
            {
                await context.Universities.AddAsync(university);
                result = await context.SaveChangesAsync();
            }

            Education education = new Education
            {
                Major = registerVM.Major,
                Degree = registerVM.Degree,
                GPA = registerVM.GPA,
                UniversityId = university.Id
            };
            await context.Educations.AddAsync(education);
            result = await context.SaveChangesAsync();

            Employee employee = new Employee
            {
                NIK = registerVM.NIK,
                FirstName = registerVM.FirstName,
                LastName = registerVM.LastName,
                Birthdate = registerVM.BirthDate,
                Gender =registerVM.Gender,
                HiringDate = registerVM.HiringDate,
                Email = registerVM.Email,
                PhoneNumber = registerVM.PhoneNumber,
            };
            await context.Employees.AddAsync(employee);
            result = await context.SaveChangesAsync();

            Account account = new Account
            {
                EmployeeNIK = registerVM.NIK,
                Password = Hashing.HashPassword(registerVM.Password), //
            };
            await context.Accounts.AddAsync(account);
            result = await context.SaveChangesAsync();

            AccountRole accountRole = new AccountRole
            {
                AccountNIK = registerVM.NIK,
                RoleId = 2
            };

            await context.AccountRoles.AddAsync(accountRole);
            result = await context.SaveChangesAsync();

            Profilling profiling = new Profilling
            {
                EmployeeNIK = registerVM.NIK,
                EducationId = education.Id
            };
            await context.Profilings.AddAsync(profiling);
            result = await context.SaveChangesAsync();

            return result;
        }
        public async Task<bool> Login(LoginVM loginVM)
        {
            var getAccounts = await context.Employees
                .Include(e => e.Account)
                .Select(e => new LoginVM
                {
                    Email = e.Email,
                    Password = e.Account.Password
                }).SingleOrDefaultAsync(a => a.Email == loginVM.Email);

            if (getAccounts is null)
            {
                return false;
            }
            return Hashing.ValidatePassword(loginVM.Password, getAccounts.Password);
        }

    }
}
