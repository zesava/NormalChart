using System;
using System.Data;
using System.Windows.Forms;

namespace NormalChart
{
    class CustomListBox: ListBox
    {
        public CustomListBox()
        {
            DrawMode = DrawMode.OwnerDrawFixed;
            ItemHeight = 18;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            const TextFormatFlags flags = TextFormatFlags.Left | TextFormatFlags.VerticalCenter;

            if (e.Index >= 0)
            {
                e.DrawBackground();
                //  e.Graphics.DrawRectangle(Pens.Red, 2, e.Bounds.Y + 2, 14, 14); // Simulate an icon.

                var c0_rect = e.Bounds;
                //c0_rect.X += 20;
                c0_rect.Width -= 20;

                var textRect1 = e.Bounds;
                textRect1.X += 25;
                textRect1.Width -= 20;

        string c0_text = DesignMode ? "001" : ((DataRowView)Items[e.Index])[0].ToString();
                string itemText1 = DesignMode ? "LogName" : ((DataRowView)Items[e.Index])[1].ToString();

                TextRenderer.DrawText(e.Graphics, c0_text, e.Font, c0_rect, e.ForeColor, flags);
                TextRenderer.DrawText(e.Graphics, itemText1, e.Font, textRect1, e.ForeColor, flags);
                e.DrawFocusRectangle();
            }
        }

    }
}
