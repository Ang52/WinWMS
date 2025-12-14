namespace WinWMS
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            
            // 先显示登录窗口
            using (LoginForm loginForm = new LoginForm())
            {
                if (loginForm.ShowDialog() == DialogResult.OK)
                {
                    // 登录成功后启动主窗体
                    Application.Run(new Form1());
                }
                else
                {
                    // 用户取消登录或登录失败，退出程序
                    Application.Exit();
                }
            }
        }
    }
}