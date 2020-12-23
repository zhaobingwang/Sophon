using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sophon.Client.Win
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                //����Ӧ�ó������쳣��ʽ��ThreadException����
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //����UI�߳��쳣
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //�����UI�߳��쳣
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);


                Application.SetHighDpiMode(HighDpiMode.SystemAware);
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Home());
            }
            catch (Exception ex)
            {
                string str = GetExceptionMsg(ex, string.Empty);
                MessageBox.Show(str, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.Exception, e.ToString());
            MessageBox.Show(str, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = GetExceptionMsg(e.ExceptionObject as Exception, e.ToString());
            MessageBox.Show(str, "ϵͳ����", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //LogManager.WriteLog(str);
        }

        /// <summary>
        /// �����Զ����쳣��Ϣ
        /// </summary>
        /// <param name="ex">�쳣����</param>
        /// <param name="backStr">�����쳣��Ϣ����exΪnullʱ��Ч</param>
        /// <returns>�쳣�ַ����ı�</returns>
        static string GetExceptionMsg(Exception ex, string backStr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("****************************�쳣�ı�****************************");
            sb.AppendLine("������ʱ�䡿��" + DateTime.Now.ToString());
            if (ex != null)
            {
                sb.AppendLine("���쳣���͡���" + ex.GetType().Name);
                sb.AppendLine("���쳣��Ϣ����" + ex.Message);
                sb.AppendLine("����ջ���á���" + ex.StackTrace);
            }
            else
            {
                sb.AppendLine("��δ�����쳣����" + backStr);
            }
            sb.AppendLine("***************************************************************");
            return sb.ToString();
        }

    }
}
