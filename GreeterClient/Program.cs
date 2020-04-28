

using System;
using Grpc.Core;
using Helloworld;
using System.Globalization;
namespace GreeterClient
{
    class Program
    {

        public static bool Check(String data)
        {
          DateTime dt;

          bool isValid = DateTime.TryParseExact(
          data,
          "mm/dd/yyyy",
          CultureInfo.InvariantCulture,
          DateTimeStyles.None,
          out dt);


          return isValid;

        }
        public static void Main(string[] args)
        {
            Channel channel = new Channel("127.0.0.1:50051", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);
            String data = Console.ReadLine();
            if (Check(data))
            {

              var reply = client.SayHello(new HelloRequest { Name = data });
              Console.WriteLine(reply.Message);

              channel.ShutdownAsync().Wait();
              Console.WriteLine("Press any key to exit...");
              Console.ReadKey();
            }
            else {
              Console.WriteLine("Wrong input"); 
            }





        }
    }
}
