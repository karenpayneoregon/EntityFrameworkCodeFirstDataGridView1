using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace NorthWindDataLibrary
{
    /// <summary>
    /// https://www.codeproject.com/Tips/758469/Implementing-Connection-Resiliency-with-Entity-Fra
    /// </summary>
    public class MyConfiguration : DbConfiguration
    {
        public MyConfiguration()
        {
            SetExecutionStrategy(
                "System.Data.SqlClient",
                () => new DefaultExecutionStrategy());
        }
    }
}