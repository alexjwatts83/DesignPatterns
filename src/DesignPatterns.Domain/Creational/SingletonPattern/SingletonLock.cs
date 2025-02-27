namespace DesignPatterns.Domain.Creational.SingletonPattern;

public class SingletonLock
{
    // this field holds the singleton instance
    private static SingletonLock _instance = null;

    // this field holds the lock handle for thread locking
    private static object _handle = new object();

    public static int Count;

    private SingletonLock()
    {
        Count = 1;
    }

    public static SingletonLock Instance
    {
        get
        {
            // thread-safe lazy initialization
            // remove this lock statement if your code is not multi-threaded
            lock (_handle)
            {
                _instance ??= new SingletonLock();
            }

            return _instance;
        }
    }
}
