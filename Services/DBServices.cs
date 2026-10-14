using prakt6_Leshukov.Models;
using System.Collections.ObjectModel;

namespace prakt6_Leshukov.Services
{
    public class DBServices
    {
        private WebApiDatabaseContext context;
        private static DBServices? instance;
        public WebApiDatabaseContext Context => context;
        public static DBServices Instance
        {
            get
            {
                if (instance == null)
                    instance = new DBServices( );
                return instance;
            }
        }

        private DBServices ()
        {
            context = new WebApiDatabaseContext( );
        }
       
       
    }
}
