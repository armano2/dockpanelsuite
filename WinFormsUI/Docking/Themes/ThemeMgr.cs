using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking.Colors;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking.Themes
{
    public class ThemeMgr
    {
        private static ThemeMgr _instance;

        public ToolStripRenderer Renderer { get; protected set; }
        protected IColor colors { get; set; }
        public ProfessionalColorTable ColorTable { get; protected set; }
        public ThemePanel DockPanelTheme { get; protected set; }
        public List<IReloadable> controllList;

        public Color getColor(IKnownColors colorType)
        {
            return this.colors.color(colorType);
        }

        private ThemeMgr()
        {
            this.colors = new Light();
            this.ColorTable = new ColorTable();
            this.Renderer = new ToolStripRenderer(this.ColorTable);
            this.DockPanelTheme = new ThemePanel();
            this.controllList = new List<IReloadable>();
        }

        public void SetColorTable(IColor colors)
        {
            this.colors = colors;
            this.ColorTable = new ColorTable();
            this.Renderer = new ToolStripRenderer(this.ColorTable); // Update Renderer
            this.DockPanelTheme = new ThemePanel();

            foreach (IReloadable key in this.controllList)
            {
                key.ReloadTheme();
            }
        }

        public void RegisterControl(IReloadable c)
        {
            this.controllList.Add(c);
        }

        public void UnregisterControl(IReloadable c)
        {
            this.controllList.Remove(c);
        }

        public static ThemeMgr Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new ThemeMgr();
                }
                return _instance;
            }
        }
    }
}
