using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking
{
    [ProvideProperty("EnableVS2012Style", typeof(ToolStrip))]
    public partial class VS2012ToolStripExtender : Component, IExtenderProvider
    {
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

        public void SetVS2012Style(Control c, ThemeBase theme)
        {
            if (c is DockPanel)
            {
                var p = c as DockPanel;
                p.Theme = theme;
                return; // prevent recursive in this case
            }
            else if (c is ToolStrip)
            {
                var p = c as ToolStrip;
                p.RenderMode = ToolStripRenderMode.Professional;
                p.Renderer = theme.Renderer;
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
                /*p.BackColor = this.PropertyGridThemeColors.PropertyGridBackColor;
                p.CategorySplitterColor = this.PropertyGridThemeColors.PropertyGridCategorySplitterColor;
                p.HelpBackColor = this.PropertyGridThemeColors.PropertyGridHelpBackColor;
                p.LineColor = this.PropertyGridThemeColors.PropertyGridLineColor;
                p.SelectedItemWithFocusBackColor = this.PropertyGridThemeColors.PropertyGridSelectedItemWithFocusBackColor;
                p.ViewBackColor = this.PropertyGridThemeColors.PropertyGridViewBackColor;
                p.ViewBorderColor = this.PropertyGridThemeColors.PropertyGridViewBorderColor;
                p.HelpBorderColor = this.PropertyGridThemeColors.PropertyGridHelpBorderColor;*/
            }
            else if (c is TreeView)
            {
                // TODO...
            }
            else if (c is ListView)
            {
                // TODO...
            }

            if (c.HasChildren)  // Recurse into containers.
                FindAndRecolorControls(c, theme);
        }

        /// <summary>
        /// Search recursively for themeable controls and apply the theme colours to any found.
        /// </summary>
        public virtual void FindAndRecolorControls(Control control, ThemeBase theme)
        {
            for (int i = control.Controls.Count - 1; i >= 0; i--)
            {
                SetVS2012Style(control.Controls[i], theme);
            }
        }
    }
}
