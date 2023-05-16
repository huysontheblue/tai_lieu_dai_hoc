using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Drawing;


    class CListBox:System.Windows.Forms.ListBox
    {
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);

        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd,IntPtr hDC);

        protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
        {
            if (Items.Count > 0)
            {
                Graphics g = e.Graphics;
                string itmStr = Items[e.Index].ToString();
                if (itmStr.Contains("成功"))
                {
                    SolidBrush sb = new SolidBrush(Color.White);
                    g.FillRectangle(sb, e.Bounds);
                    sb = new SolidBrush(Color.Blue);
                    g.DrawString(itmStr, e.Font, sb, e.Bounds);
                }
                else
                {
                    SolidBrush sb = new SolidBrush(Color.White);
                    g.FillRectangle(sb, e.Bounds);
                    sb = new SolidBrush(Color.Red);
                    g.DrawString(itmStr, e.Font, sb, e.Bounds);
                }

                e.DrawFocusRectangle();
                g.Dispose();
                base.OnDrawItem(e);
            }
        }

        protected override void WndProc(ref System.Windows.Forms.Message m)
        {
            if (m.Msg == 0xf || m.Msg == 0x133)
            {
                IntPtr hDC = GetWindowDC(m.HWnd);
                Pen pen = new Pen(Color.GreenYellow,1);
                Graphics g = Graphics.FromHdc(hDC);
                g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    g.DrawRectangle(pen,0,0,this.Width-1,this.Height-1);
                pen.Dispose();
                g.Dispose();
                ReleaseDC(m.HWnd,hDC);
            }
            base.WndProc(ref m);
        }
    }

