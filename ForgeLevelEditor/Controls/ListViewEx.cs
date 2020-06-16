using System.Windows.Forms;

namespace ForgeLevelEditor.Controls
{
    public class ListViewEx : ListView
    {

        public event ScrollEventHandler Scroll;

        protected virtual void OnScroll(ScrollEventArgs e) {
            ScrollEventHandler handler = this.Scroll;
            if (handler != null) handler(this, e);
        }

        protected override void WndProc(ref Message m) {
            base.WndProc(ref m);
            if (m.Msg == 0x115) { // Trap WM_VSCROLL
                OnScroll(new ScrollEventArgs((ScrollEventType)(m.WParam.ToInt32() & 0xffff), 0));
            }
        }

    }
}
