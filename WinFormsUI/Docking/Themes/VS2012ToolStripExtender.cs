using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking
{
    [ProvideProperty("EnableVS2012Style", typeof(ToolStrip))]
    public partial class VS2012ToolStripExtender : Component, IExtenderProvider
    {
        protected ThemeBase theme { set; get; }

        public VS2012ToolStripExtender()
        {
            InitializeComponent();
        }

        public VS2012ToolStripExtender(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region IExtenderProvider Members

        public bool CanExtend(object extendee)
        {
            return extendee is ToolStrip;
        }

        #endregion

        public void SetTheme(ThemeBase theme)
        {
            this.theme = theme;
        }

        public void SetVS2012Style(Control c)
        {
            if (c is DockPanel)
            {
                var p = c as DockPanel;
                p.Theme = theme;
                //return; // prevent recursive in this case
            }
            else if (c is ToolStrip || c is MenuStrip)
            {
                var p = c as ToolStrip;
                //p.RenderMode = ToolStripRenderMode.Professional;
                p.Renderer = theme.Renderer;
                p.Refresh();
                return; // prevent recursive in this case
                //p.ForeColor = theme.ColorTable.SeparatorDark;
            }
            else if (c is Panel && !(c is SplitterPanel) && !(c is ToolStripContentPanel) && !(c is FlowLayoutPanel)) // Anything that derives from Panel.
            {
                if (c.BackgroundImage == null)
                    c.BackColor = theme.ColorTable.MenuItemPressedGradientBegin;
            }
            else if (c is PropertyGrid) // A PropertyGrid.
            {
                var p = c as PropertyGrid;
                p.BackColor = theme.ColorTable.GripDark;
                //p.CategorySplitterColor = theme.ColorTable.PropertyGridCategorySplitterColor;
                p.HelpBackColor = theme.ColorTable.GripDark;
                p.LineColor = theme.ColorTable.GripLight;
                //p.SelectedItemWithFocusBackColor = theme.ColorTable.PropertyGridSelectedItemWithFocusBackColor;
                p.ViewBackColor = theme.ColorTable.GripDark;
                //p.ViewBorderColor = theme.ColorTable.PropertyGridViewBorderColor;
                //p.HelpBorderColor = theme.ColorTable.PropertyGridHelpBorderColor;
            }
            else if (c is TreeView)
            {
                var p = c as TreeView;
                p.BackColor = theme.ColorTable.GripDark;
                p.LineColor = theme.ColorTable.GripLight;

                // TODO...
            }
            else if (c is ListView)
            {
                // TODO...
            }

            if (c.HasChildren)  // Recurse into containers.
                FindAndRecolorControls(c);
        }

        /// <summary>
        /// Search recursively for themeable controls and apply the theme colours to any found.
        /// </summary>
        private void FindAndRecolorControls(Control control)
        {
            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                SetVS2012Style(control.Controls[i]);
            }
        }
    }
}
