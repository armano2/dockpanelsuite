using System;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking
{
    [ProvideProperty("EnableVS2012Style", typeof(ToolStrip))]
    public partial class VS2012ToolStripExtender : Component, IExtenderProvider
    {
        private class ToolStripProperties
        {
            private readonly ToolStrip strip;
            private readonly Dictionary<ToolStripItem, string> menuText = new Dictionary<ToolStripItem, string>();
            

            public ToolStripProperties(ToolStrip toolstrip)
            {
                if (toolstrip == null)
                    throw new ArgumentNullException("toolstrip");
                strip = toolstrip;

                if (strip is MenuStrip)
                    SaveMenuStripText();
            }

            private void SaveMenuStripText()
            {
                foreach (ToolStripItem item in strip.Items)
                    menuText.Add(item, item.Text);
            }

            public void UpdateMenuText(bool caps = true)
            {
                foreach (ToolStripItem item in menuText.Keys)
                {
                    var text = menuText[item];
                    item.Text = caps ? text.ToUpper() : text;
                }
            }
        }

        private readonly Dictionary<ToolStrip, ToolStripProperties> strips = new Dictionary<ToolStrip, ToolStripProperties>();

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

        public void SetVS2012Style(ToolStrip strip, ToolStripRenderer render)
        {
            ToolStripProperties properties = null;

            if (!strips.ContainsKey(strip))
            {
                properties = new ToolStripProperties(strip);
                strips.Add(strip, properties);
            }
            else
            {
                properties = strips[strip];
            }

            strip.Renderer = render;
        }
    }
}
