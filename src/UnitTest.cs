namespace UnitTest
{
    using Microsoft.EntityFrameworkCore;

    public partial class UnitTest
    {
        private bool TestConnectivity()
        {
            try
            {
                if (!Beta3.Beta3Context.Context.Database.CanConnect())
                {
                    throw new Exception();
                }

                Console.WriteLine("Test #1 Connectivity Passed");
                return true;
            }
            catch
            { }

            return false;
        }

        /*
        DIRTY READ | NON-REPEATABLE READ | PHANTOM READ
        yes        | yes                 | yes
        */
        private bool TestReadUncommited()
        {
            if (Beta3.Beta3Context.Context.Database.ExecuteSqlRaw(
                "SET GLOBAL TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;" +
                "START TRANSACTION;" +
                "INSERT INTO Board(Name) values('board123');" +
                "DELETE FROM Board WHERE Name = 'board123';" +
                "COMMIT;"
            ) != 2)
            {
                return false;
            }

            Console.WriteLine("Test #2 Dirty Read/Write on Isolation Level Read Uncommited Passed");
            return true;
        }

        /*
        DIRTY READ | NON-REPEATABLE READ | PHANTOM READ
        no         | yes                 | yes
        */
        private bool TestReadCommited()
        {
            //Beta3.Beta3Context.Context.Database.ExecuteSqlRaw("SET SESSION TRANSACTION ISOLATION LEVEL READ COMMITED");

            Beta3.Beta3Context context1 = new Beta3.Beta3Context();
            context1.Database.ExecuteSqlRaw(
                "SET GLOBAL TRANSACTION ISOLATION LEVEL READ UNCOMMITTED;" +
                "START TRANSACTION;" +
                "INSERT INTO Board(Name) values('board123');"
            );

            Beta3.Beta3Context context2 = new Beta3.Beta3Context();
            Console.WriteLine(context2.Database.ExecuteSqlRaw("DELETE FROM Board WHERE Name = 'board123';"));

            return true;
        }

        /*
        DIRTY READ | NON-REPEATABLE READ | PHANTOM READ
        no         | no                  | yes
        */
        private bool TestRepeatableRead()
        {
            //Beta3.Beta3Context.Context.Database.ExecuteSqlRaw("SET SESSION TRANSACTION ISOLATION LEVEL REPEATABLE READ");
            return true;
        }

        /*
        DIRTY READ | NON-REPEATABLE READ | PHANTOM READ
        no         | no                  | no
        */
        private bool TestSerializable()
        {
            //Beta3.Beta3Context.Context.Database.ExecuteSqlRaw("SET SESSION TRANSACTION ISOLATION LEVEL SERIALIZABLE");
            return true;
        }

        public UnitTest()
        {
            Console.WriteLine("TESTING");

            if (!TestConnectivity())
            {
                return;
            }

            if (!TestReadUncommited())
            {
                return;
            }

            if (!TestReadCommited())
            {
                return;
            }

            if (!TestRepeatableRead())
            {
                return;
            }

            if (!TestSerializable())
            {
                return;
            }
        }
    }
}
