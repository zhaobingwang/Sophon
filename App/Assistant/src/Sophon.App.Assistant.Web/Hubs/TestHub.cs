using Hangfire;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Logging;
using Sophon.Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sophon.Web.Hubs
{
    public class TestHub : Hub
    {
        public async Task PushMessage(string message)
        {
            //RecurringJob.AddOrUpdate(() => Push(), "*/1 * * * *", TimeZoneInfo.Utc);
            await Clients.All.SendAsync("ReceiveMessage", message);
        }

        public async Task Push()
        {
            string message = $"{DateTime.Now}# 来自服务端的消息推送";
            //await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
