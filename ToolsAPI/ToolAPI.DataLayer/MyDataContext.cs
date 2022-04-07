using Microsoft.EntityFrameworkCore;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ToolAPI.DataLayer.Entities;

namespace ToolAPI.DataLayer;

public class MyDataContext: DbContext, IDataContext
{
   // public DbSet<Person> People { get; set; }

    public MyDataContext(DbContextOptions<MyDataContext> opzioni): base(opzioni)
    {

    }

    public IQueryable<T> GetData<T>(bool trackingChanges = false) where T : class
    {
        var set = Set<T>().AsQueryable();

        if(trackingChanges == true)
        {
           return  set.AsTracking();
        } else
        {
           return set.AsNoTracking();
        }
    }

    public void Insert<T>(T item) where T : class
    {
        Set<T>().Add(item);
    }

    public Task SaveAsync()
    {
        return SaveChangesAsync();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        base.OnModelCreating(modelBuilder);
    }
}

