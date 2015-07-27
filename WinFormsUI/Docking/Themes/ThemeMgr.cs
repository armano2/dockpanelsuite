using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking.Colors;

namespace WeifenLuo.WinFormsUI.Docking.Themes
{
    public class ThemeMgr
    {
        private static ThemeMgr _instance;

        public ToolStripRenderer Renderer { get; protected set; }
        protected IColor colors { get; set; }
        public ProfessionalColorTable ColorTable { get; protected set; }
        public ThemePanel DockPanelTheme { get; protected set; }

        public Color getColor(KnownColors colorType)
        {
            return this.colors.color(colorType);
        }

        private ThemeMgr()
        {
            this.colors = new Light();
            this.ColorTable = new ColorTable();
            this.Renderer = new ToolStripRenderer(this.ColorTable);
            this.DockPanelTheme = new ThemePanel();
        }

        public void SetColorTable(IColor colors)
        {
            this.colors = colors;
            this.ColorTable = new ColorTable();
            this.Renderer = new ToolStripRenderer(this.ColorTable); // Update Renderer
            this.DockPanelTheme = new ThemePanel();
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
