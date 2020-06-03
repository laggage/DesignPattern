using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DesignParttern.Shared
{
    public class SampleClientManager
    {
        List<Type> _clients;

        public SampleClientManager()
        {
            _clients = GetSampleClientTypeInExecuteAssembly();
        }

        protected List<Type> GetSampleClientTypeInExecuteAssembly()
        {
            Type[] types = Assembly.GetEntryAssembly().GetTypes();
            var clients = new List<Type>();
            foreach (Type type in types)
            {
                bool res = type.GetInterfaces().Contains(typeof(ISampleClient));
                if (res) clients.Add(type);
            }
            return clients;
        }

        protected ISampleClient ChooseSampleClient()
        {
            byte index = 0;
            Console.WriteLine("选择一个要运行的例子： ");
            Console.WriteLine(new string('-', 20));
            var clients = new List<ISampleClient>();
            foreach (Type type in _clients)
            {
                var client = Assembly.GetEntryAssembly().CreateInstance(type.FullName) as ISampleClient;
                clients.Add(client);
                Console.WriteLine($"{++index}.{client.ToString()}");
            }
            string input = Console.ReadLine();
            if (byte.TryParse(input, out index))
            {
                return clients[index-1];
            }
            else return null;
        }

        public void Run()
        {
            while(true)
            {
                ISampleClient client = ChooseSampleClient();
                if (client == null) continue;

                Console.Clear();
                Console.WriteLine(client.ToString());
                Console.WriteLine(new string('-', 20));
                client.Run();

                Console.ReadKey();
                Console.Clear();
            }
            
        }
    }
}
