using System.Windows.Forms;

namespace ForgeLevelEditor.Tools
{
    public interface ITool<TControl> where TControl : Control
    {
        
        // Attaches this tool and its event handlers to the control.
        void Attach(TControl control);

        // Detaches this tool and its event handlers from the control.
        void Detach(TControl control);
    }
}
