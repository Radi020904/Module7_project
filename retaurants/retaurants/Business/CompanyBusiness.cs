using restaurants.Data;
using restaurants.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace restaurants.Business
{
    public class CompanyBusiness
    {
        private RestaurantsContext context;
        /// <summary>
        /// Constructer used in tests
        /// </summary>
        public CompanyBusiness(RestaurantsContext restaurantContext)
        {
            this.context = restaurantContext;
        }

        /// <summary>
        /// Constructor used in Presentation layer
        /// </summary>
        public CompanyBusiness()
        {
            this.context = new RestaurantsContext();
        }

        /// <summary>
        /// Gets all companies from the table Companies
        /// </summary>
        /// <returns>List of all companies</returns>
        public List<Company> GetAll()
        {
            return context.Companies.ToList();
        }

        /// <summary>
        /// Gets a company with a given id from the table Companies
        /// </summary>
        /// <param name="id">Id used to find the company</param>
        /// <returns>Company with the given company</returns>
        public Company Get(int id)
        {
            var company = context.Companies.FirstOrDefault(m => m.Id == id);
            return company;
        }

        /// <summary>
        /// Adds a company to the table Companies
        /// </summary>
        /// <param name="company">Company that will be added to the table</param>
        public void Add(Company company)
        {

            context.Companies.Add(company);
            context.SaveChanges();

        }

        /// <summary>
        /// Updates the changes for a given company from the table Companies
        /// </summary>
        /// <param name="company">Company that will be updated</param>
        public void Update(Company company)
        {

            var item = context.Companies.FirstOrDefault(m => m.Id == company.Id);
            if (item != null)
            {
                context.Entry(item).CurrentValues.SetValues(company);
                context.SaveChanges();
            }
        }
        /// <summary>
        /// Deletes a company with a given id from the table Companies
        /// </summary>
        /// <param name="id">Id of the given company</param>
        public void Delete(int id)
        {
            var item = context.Companies.Find(id);
            if (item != null)
            {
                context.Companies.Remove(item);
                context.SaveChanges();
            }
        }
    }
}
