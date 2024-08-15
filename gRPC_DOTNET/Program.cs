using Grpc.Net.Client;

namespace gRPC_DOTNET
{
    class Program
    {
        static void Main(string[] agrs)
        {
            AppContext.SetSwitch("System.Net.Http.SocketHttpHandler.Http2UnencryptedSupport", true);
            var channel = GrpcChannel.ForAddress("http://localhost:50000");
            var client = new Company.CompanyClient(channel);

            client.Ready(new VoidInvocation());

            var devOpsEngineer = new Job
            {
                Priority = 1
            };

            devOpsEngineer.Duties.Add("CI/CD Management");
            devOpsEngineer.Duties.Add("Database Administration");
            devOpsEngineer.Duties.Add("Create Pipelines");

            var developer = new Job
            {
                Priority = 3
            };

            developer.Duties.Add("Fix Issues");
            developer.Duties.Add("Update Resposotories");

            var person = new Person
            {
                Name = "Francisco Torreglosa"
            };
            
            person.Jobs.Add(devOpsEngineer);
            person.Jobs.Add(developer);

            var application = client.SendApplication(person);
            
            // 140820241025
            Console.WriteLine($"Application sent at: {application.ApplicationDate}");
        }
    }
}