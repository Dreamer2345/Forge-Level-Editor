using System;
using System.Windows.Forms;

namespace RogueboyLevelEditor.Tools
{
    public interface ITool<TControl> where TControl : Control
    {
        event EventHandler<TileChangedEventArgs> tileChanged;

        // Attaches this tool and its event handlers to the control.
        void Attach(TControl control);

        // Detaches this tool and its event handlers from the control.
        void Detach(TControl control);
    }
}
