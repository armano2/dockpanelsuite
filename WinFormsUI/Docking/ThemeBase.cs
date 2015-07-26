using System.ComponentModel;

namespace WeifenLuo.WinFormsUI.Docking
{
	public abstract class ThemeBase : Component, ITheme
    {
        public VS2012ToolStripRenderer Renderer { get; protected set; }

        public abstract void Apply(DockPanel dockPanel);
	}
}
