using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System;

namespace TheBotUI.CustomComponents {
    public class CustomListView : ListView {
        private bool scrollDown;
        private int lastScroll;
        public Color GridLineColor { get; set; }
        public new bool GridLines { get; set; }

        [DllImport("user32")]
        public static extern int GetScrollPos(IntPtr hwnd, int nBar);

        public CustomListView() {
            GridLineColor = Color.FromArgb(60, 60, 60);
            this.DoubleBuffered = true;
            base.GridLines = false;
        }

        protected override void WndProc(ref Message m) {
            if (m.Msg == 0x20a) { //WM_MOUSEWHEEL
                scrollDown = (m.WParam.ToInt64() >> 16) < 0;
            }
            if (m.Msg == 0x115) { //WM_VSCROLL
                int n = (m.WParam.ToInt32() >> 16);
                scrollDown = n > lastScroll;
                lastScroll = n;
            }

            base.WndProc(ref m);

            if (m.Msg == 0xf && GridLines && Items.Count > 0 && View == View.Details) {
                using (Graphics g = CreateGraphics()) {
                    using (Pen p = new Pen(GridLineColor)) {
                        int w = -GetScrollPos(Handle, 0);
                        for (int i = 0; i < Columns.Count; i++) {
                            w += Columns[i].Width;
                            g.DrawLine(p, new System.Drawing.Point(w, 0), new System.Drawing.Point(w, ClientSize.Height));
                        }
                        int a = Items[0].Bounds.Bottom - 1;
                        int b = Height - Items[0].Bounds.Y;
                        int c = Items[0].Bounds.Height;
                        for (int i = scrollDown ? a + (b / c) * c : a; scrollDown ? i >= a : i < b; i += scrollDown ? -c : c) {
                            g.DrawLine(p, new System.Drawing.Point(0, i), new System.Drawing.Point(ClientSize.Width, i));
                        }
                    }
                }
            }
        }
    }
}
