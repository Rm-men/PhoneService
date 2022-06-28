using Npgsql;


namespace ServiceDB
{
    public class Context
    {

        //  public static ApplicationContext db = new ApplicationContext();
        // public static NpgsqlConnection npgsql = new NpgsqlConnection();
        public static ApplicationContext db { get; private set; }

        public static NpgsqlConnection npgsql { get; private set; }



        internal static void AddDb(ApplicationContext application)
        {
            db = application;
        }
        public Context(ApplicationContext applicationContext)
        {
            db = applicationContext;
            npgsql = new NpgsqlConnection(ApplicationContext.ConnectionString);
            npgsql.Open();
        }
/*        public static void InitDb()
        {
            db = new ApplicationContext();
        }*/
    }
}
