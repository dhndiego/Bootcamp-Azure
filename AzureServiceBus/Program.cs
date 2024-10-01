


using AzureServiceBus;
using Microsoft.Azure.ServiceBus;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json;
using System.Threading;

Console.WriteLine("Hello, World!");

var connection = "Endpoint=sb://bootcamp-randstad.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=5ap+wsTcMAIEir3+BMswrtbkttOytlGqV+ASbGdPOuQ=";
var queuename = "register";

var objTeste = new Teste
{
    Id = 1,
    Name = "ola mundo"
};

//var client = new QueueClient(connection, queuename, ReceiveMode.PeekLock);
//string messageBody = JsonSerializer.Serialize(objTeste);
//var message = new Message(Encoding.UTF8.GetBytes(messageBody));

//message.TimeToLive = TimeSpan.FromMinutes(1);

//await client.SendAsync(message);
//await client.CloseAsync();

Console.WriteLine("done");


