using Microsoft.AspNetCore.SignalR.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sophon.Client.Win
{
    public partial class Home : Form
    {
        HubConnection connection;
        public Home()
        {
            InitializeComponent();

            connection = new HubConnectionBuilder()
             .WithUrl("http://localhost:5000/msghub/notify")
             .Build();


            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        private async void Home_Load(object sender, EventArgs e)
        {

            connection.On<string>("Notify", (message) =>
            {
                notifyIcon1.Icon = SystemIcons.Exclamation;
                notifyIcon1.Visible = true;
                notifyIcon1.ShowBalloonTip(20000, "来自服务端推送的消息", message, ToolTipIcon.Info);
            });
            await connection.StartAsync();
        }

    }
}
