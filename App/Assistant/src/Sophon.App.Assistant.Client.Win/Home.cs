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
            BindEvent();


            connection = new HubConnectionBuilder()
             .WithUrl("http://localhost:5000/msghub/notify")
             .Build();


            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        private void BindEvent()
        {
            menuItemExit.Click += MenuItemExit_Click;
        }

        private void MenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private async void Home_Load(object sender, EventArgs e)
        {

            connection.On<string>("Notify", (message) =>
            {
                icnMain.Icon = SystemIcons.Exclamation;
                icnMain.Visible = true;
                icnMain.ShowBalloonTip(20000, "来自服务端推送的消息", message, ToolTipIcon.Info);
            });
            await connection.StartAsync();
        }

        private void Home_SizeChanged(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // 隐藏任务栏图标
                ShowInTaskbar = false;
                // 图标显示在托盘栏
                icnMain.Visible = true;
            }
        }

        private void notifyIconMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                // 还原窗体显示    
                WindowState = FormWindowState.Normal;
                // 激活窗体并给予它焦点
                Activate();
                // 任务栏区显示图标
                ShowInTaskbar = true;
                // 托盘区图标隐藏
                icnMain.Visible = false;
            }
        }
    }
}
