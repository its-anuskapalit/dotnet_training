using System;
using System.Threading.Tasks;

namespace MoreInterfaceExamples;

class Program
{
    static async Task Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        Banner.Print();

        Demo_IFormattable.Run();
        Demo_IConvertible.Run();
        Demo_ICloneable.Run();

        Demo_IEnumerable_IEnumerator.Run();
        Demo_GenericCollections.Run();
        Demo_Comparers.Run();

        Demo_IProducerConsumerCollection.Run();

        await Demo_IAsyncEnumerable.RunAsync();

        Demo_NotifyInterfaces.Run();
        Demo_ObserverPattern.Run();

        await Demo_IProgress.RunAsync();

        Demo_IAsyncResult.Run();

        Demo_IParsable.Run();
        Demo_ISpanParsable.Run();

        await Demo_DI_Host_Logging.RunAsync();

        Console.WriteLine("\n✅ Done. Press ENTER to exit...");
        Console.ReadLine();
    }
}
