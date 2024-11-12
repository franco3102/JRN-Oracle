using JRN_Oracle;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
        APIHandler apiHandler = new APIHandler();
        //apiHandler.GetSinglePayloadCreateInvoice();

        Task.Run(async () => 
        {
            await apiHandler.PostCreateInvoiceAsync();
        }).Wait();
    }
}