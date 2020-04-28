

using System;
using System.IO;
using System.Threading.Tasks;
using Grpc.Core;
using Helloworld;

namespace GreeterServer
{
    class GreeterImpl : Greeter.GreeterBase
    {
          public static string Date(HelloRequest request)
          {

            
            string[] lines = File.ReadAllLines("C:\\Users\\Mezei\\Desktop\\grpc-master\\examples\\csharp\\Helloworld\\GreeterServer\\input.txt");

            foreach (string line in lines)
              Console.WriteLine(line);
            

            string b= request.Name;
            int a = Int32.Parse(b.Substring(0,2));

            switch (a)
            {
               case 1: return lines[0];
                case 2: return lines[1];
                case 3: return lines[2];
                case 4: return lines[3];
                case 5: return lines[4];
                case 6: return lines[5];
                case 7: return lines[6];
                case 8: return lines[7];
                case 9: return lines[8];
                case 10: return lines[9];
                case 11: return lines[10];
                case 12: return lines[12-1];

             }

              return null;
          }


          
          public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
          {
               
      
                return Task.FromResult(new HelloReply { Message = "The sing is: " + Date(request) });
          }
    }

    class Program
    {
        const int Port = 50051;

        
        public static void Main(string[] args)
        {
            Server server = new Server
            {
                Services = { Greeter.BindService(new GreeterImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
