using System;
using System.Drawing;
using System.Data;
using System.Windows.Forms;

namespace WinWMS
{
    /// <summary>
    /// ComboBox样式辅助类 - 统一设置下拉框样式
    /// </summary>
    public static class ComboBoxStyleHelper
    {
        /// <summary>
        /// 应用统一的ComboBox样式
        /// </summary>
        /// <param name="comboBox">要设置样式的ComboBox</param>
        public static void ApplyStyle(ComboBox comboBox)
        {
            if (comboBox == null) return;

            // 设置白色背景
            comboBox.BackColor = Color.White;
            
            // 设置边框样式
            comboBox.FlatStyle = FlatStyle.Standard;
            
            // 启用自绘模式
            comboBox.DrawMode = DrawMode.OwnerDrawFixed;
            
            // 设置下拉列表高度（显示更多项）
            comboBox.MaxDropDownItems = 10;
            
            // 绑定绘制事件
            comboBox.DrawItem += ComboBox_DrawItem;
        }

        /// <summary>
        /// ComboBox自定义绘制事件
        /// </summary>
        private static void ComboBox_DrawItem(object? sender, DrawItemEventArgs e)
        {
            if (e.Index < 0) return;

            ComboBox? cmb = sender as ComboBox;
            if (cmb == null) return;

            // 设置背景色
            Color backgroundColor = Color.White;
            Color textColor = Color.Black;

            if ((e.State & DrawItemState.Selected) == DrawItemState.Selected)
            {
                // 选中项使用浅粉色背景
                backgroundColor = Color.FromArgb(255, 218, 224);
                textColor = Color.FromArgb(64, 64, 64);
            }

            // 绘制背景
            e.Graphics.FillRectangle(new SolidBrush(backgroundColor), e.Bounds);

            // 绘制文本
            string text = "";
            
            // 处理不同的数据源类型
            if (cmb.Items[e.Index] is DataRowView drv)
            {
                // DataTable 数据源 - 优先使用 DisplayMember 指定的字段
                if (!string.IsNullOrEmpty(cmb.DisplayMember) && 
                    drv.Row.Table.Columns.Contains(cmb.DisplayMember))
                {
                    text = drv[cmb.DisplayMember]?.ToString() ?? "";
                }
                else if (drv.Row.Table.Columns.Contains("name"))
                {
                    text = drv["name"]?.ToString() ?? "";
                }
                else if (drv.Row.Table.Columns.Contains("display_spec"))
                {
                    text = drv["display_spec"]?.ToString() ?? "";
                }
                else
                {
                    text = drv[0]?.ToString() ?? "";
                }
            }
            else
            {
                // 普通字符串或对象
                text = cmb.Items[e.Index]?.ToString() ?? "";
            }

            // 绘制文本（添加左边距）
            RectangleF textBounds = new RectangleF(
                e.Bounds.X + 5, 
                e.Bounds.Y, 
                e.Bounds.Width - 5, 
                e.Bounds.Height
            );
            
            StringFormat sf = new StringFormat
            {
                LineAlignment = StringAlignment.Center,
                Alignment = StringAlignment.Near
            };

            e.Graphics.DrawString(text, e.Font ?? cmb.Font, new SolidBrush(textColor), textBounds, sf);

            // 绘制焦点框
            e.DrawFocusRectangle();
        }

        /// <summary>
        /// 为窗体中所有ComboBox应用统一样式
        /// </summary>
        /// <param name="form">目标窗体</param>
        public static void ApplyToAllComboBoxes(Form form)
        {
            if (form == null) return;

            ApplyToAllComboBoxesRecursive(form.Controls);
        }

        /// <summary>
        /// 递归遍历所有控件并应用样式
        /// </summary>
        private static void ApplyToAllComboBoxesRecursive(Control.ControlCollection controls)
        {
            foreach (Control control in controls)
            {
                if (control is ComboBox comboBox)
                {
                    ApplyStyle(comboBox);
                }
                else if (control.HasChildren)
                {
                    ApplyToAllComboBoxesRecursive(control.Controls);
                }
            }
        }
    }
}
