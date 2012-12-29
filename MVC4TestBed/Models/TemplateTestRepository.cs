using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MVC4TestBed.Models
{ 
    public class TemplateTestRepository : ITemplateTestRepository
    {
        MVC4TestBedContext context = new MVC4TestBedContext();

        public IQueryable<TemplateTest> All
        {
            get { return context.TemplateTests; }
        }

        public IQueryable<TemplateTest> AllIncluding(params Expression<Func<TemplateTest, object>>[] includeProperties)
        {
            IQueryable<TemplateTest> query = context.TemplateTests;
            foreach (var includeProperty in includeProperties) {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public TemplateTest Find(int id)
        {
            return context.TemplateTests.Find(id);
        }

        public void InsertOrUpdate(TemplateTest templatetest)
        {
            if (templatetest.Id == default(int)) {
                // New entity
                context.TemplateTests.Add(templatetest);
            } else {
                // Existing entity
                context.Entry(templatetest).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var templatetest = context.TemplateTests.Find(id);
            context.TemplateTests.Remove(templatetest);
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public void Dispose() 
        {
            context.Dispose();
        }
    }

    public interface ITemplateTestRepository : IDisposable
    {
        IQueryable<TemplateTest> All { get; }
        IQueryable<TemplateTest> AllIncluding(params Expression<Func<TemplateTest, object>>[] includeProperties);
        TemplateTest Find(int id);
        void InsertOrUpdate(TemplateTest templatetest);
        void Delete(int id);
        void Save();
    }
}