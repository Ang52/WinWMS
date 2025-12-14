namespace WinWMS
{
    /// <summary>
    /// 用户会话管理类 - 存储当前登录用户信息
    /// </summary>
    public static class UserSession
    {
        /// <summary>
        /// 当前登录用户的ID
        /// </summary>
        public static int UserId { get; set; }

        /// <summary>
        /// 当前登录用户的用户名
        /// </summary>
        public static string Username { get; set; } = string.Empty;

        /// <summary>
        /// 当前登录用户的角色（Admin 或 Operator）
        /// </summary>
        public static string Role { get; set; } = string.Empty;

        /// <summary>
        /// 判断当前用户是否为管理员
        /// </summary>
        public static bool IsAdmin => Role.Equals("Admin", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// 判断当前用户是否为操作员
        /// </summary>
        public static bool IsOperator => Role.Equals("Operator", StringComparison.OrdinalIgnoreCase);

        /// <summary>
        /// 清空会话信息（用于退出登录）
        /// </summary>
        public static void Clear()
        {
            UserId = 0;
            Username = string.Empty;
            Role = string.Empty;
        }
    }
}
