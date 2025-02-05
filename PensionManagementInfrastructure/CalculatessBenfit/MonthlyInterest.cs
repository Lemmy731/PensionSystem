using Microsoft.EntityFrameworkCore;
using PensionManagementInfrastructure.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PensionManagementInfrastructure.CalculatessBenfit
{
    public class MonthlyInterest: IMonthlyInterest
    {
        private readonly AppDbContext _context;

        public MonthlyInterest(AppDbContext context)
        {
            _context = context;
        }

        public void CalculateMonthlyInterest()
        {
            var members = _context.Members.ToList();

            foreach (var member in members)
            {
                decimal interest = member.TotalContribution * 0.005m; // 0.5% interest
                member.TotalContribution += interest;
                _context.Members.Update(member);
            }
            _context.SaveChanges();
        }
    }
}
