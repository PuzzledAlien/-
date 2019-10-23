static class Program
{
    static int Main(string[] args)
    {
        try
        {
            return AsyncContext.Run(() => MainAsync(args));
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine(ex);
            return -1;
        }
    }
    static async void MainAsync(string[] args)
    {
        //...
    }
}