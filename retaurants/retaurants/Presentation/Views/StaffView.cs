using restaurants.Business;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Presentation.Views
{
    public class StaffView
    {
        private StaffBusiness StaffBusiness = new StaffBusiness();

        /// <summary>
        /// Constructor used by the display.
        /// </summary>
        public StaffView()
        {
            Input();
        }

        /// <summary>
        /// Shows all the commands that the user can use.
        /// </summary>
        private void ShowMenu()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 15) + "Staff MENU" + new string(' ', 16));
            Console.WriteLine(new string('-', 40));
            Console.WriteLine("1. List all staff");
            Console.WriteLine("2. Add new staff");
            Console.WriteLine("3. Update staff");
            Console.WriteLine("4. Fetch staff by ID");
            Console.WriteLine("5. Delete staff by ID");
            Console.WriteLine("6. Back to MAIN MENU");
        }

        /// <summary>
        /// Converts the input and does the selected command.
        /// </summary>
        private void Input()
        {

            int command = 0;
            int closedCommandId = 6;
            do
            {
                ShowMenu();
                command = int.Parse(Console.ReadLine());
                switch (command)
                {
                    case 1: ListAll(); break;
                    case 2: Add(); break;
                    case 3: Update(); break;
                    case 4: Fetch(); break;
                    case 5: Delete(); break;
                    default: break;
                }
            } while (command != closedCommandId);
        }

        /// <summary>
        /// Aks the user for staff characteristics and creates staff with those characteristics, after that adds that staff to the table Staffs.
        /// </summary>
        private void Add()
        {
            Staff staff = new Staff();
            Console.WriteLine("Enter staff first name: ");
            staff.FirstName = Console.ReadLine();
            Console.WriteLine("Enter staff last name: ");
            staff.LastName = Console.ReadLine();
            Console.WriteLine("Enter age: ");
            staff.Age = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter job: ");
            staff.Job = Console.ReadLine();
            Console.WriteLine("Enter salary");
            staff.Salary = int.Parse(Console.ReadLine());
            StaffBusiness.Add(staff);
        }

        /// <summary>
        /// Lists all staff from the table Staffs.
        /// </summary>
        private void ListAll()
        {
            Console.WriteLine(new string('-', 40));
            Console.WriteLine(new string(' ', 18) + "Staffs" + new string(' ', 17));
            Console.WriteLine(new string('-', 40));
            List<Staff> staffs = StaffBusiness.GetAll();
            Console.WriteLine("Id || FirstName || LastName || Age || Job || Salary");
            foreach (Staff staff in staffs)
            {
                Console.WriteLine($"{staff.Id} || {staff.FirstName} || {staff.LastName} || {staff.Age} || {staff.Job} || {staff.Salary}");
            }
            Console.WriteLine(new string('-', 40));
        }

        /// <summary>
        /// Asks the user for id, after that finds the staff with that id and asks for changes.
        /// </summary>
        private void Update()
        {
            Console.WriteLine("Enter ID to update: ");
            int id = int.Parse(Console.ReadLine());
            Staff staff = StaffBusiness.Get(id);
            if (staff != null)
            {
                Console.WriteLine("Enter staff first name: ");
                staff.FirstName = Console.ReadLine();
                Console.WriteLine("Enter staff last name: ");
                staff.LastName = Console.ReadLine();
                Console.WriteLine("Enter age: ");
                staff.Age = int.Parse(Console.ReadLine());
                Console.WriteLine("Enter job: ");
                staff.Job = Console.ReadLine();
                Console.WriteLine("Enter salary: ");
                staff.Salary = int.Parse(Console.ReadLine());
                StaffBusiness.Update(staff);
            }
            else
            {
                Console.WriteLine("Staff not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that lists the staff with that id.
        /// </summary>
        private void Fetch()
        {
            Console.WriteLine("Enter ID to fetch: ");
            int id = int.Parse(Console.ReadLine());
            Staff staff = StaffBusiness.Get(id);
            if (staff != null)
            {
                Console.WriteLine(new string('-', 40));
                Console.WriteLine("Id: " + staff.Id);
                Console.WriteLine("FirstName: " + staff.FirstName);
                Console.WriteLine("LastName: " + staff.LastName);
                Console.WriteLine("Age: " + staff.Age);
                Console.WriteLine("Job: " + staff.Job);
                Console.WriteLine("Salary: " + staff.Salary);
                Console.WriteLine(new string('-', 40));
            }
            else
            {
                Console.WriteLine("Staff not found!");
            }
        }

        /// <summary>
        /// Asks the user for id, after that deletes the staff with that id.
        /// </summary>
        private void Delete()
        {
            Console.WriteLine("Enter ID to delete: ");
            int id = int.Parse(Console.ReadLine());
            StaffBusiness.Delete(id);
            Console.WriteLine("Done.");
        }
    }
}
