using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces.Interfaces
{
    public interface IServiceBus
    {
        Task<bool?> SendMessage(string queueName, string message);
    }
}
