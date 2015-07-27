using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using WeifenLuo.WinFormsUI.Docking.Helpers;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal abstract class InertButtonBase : Control
    {
        protected InertButtonBase()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        public abstract Bitmap Image
        {
            get;
        }

        private bool m_isMouseOver = false;
        protected bool IsMouseOver
        {
            get { return m_isMouseOver; }
            private set
            {
                if (m_isMouseOver == value)
                    return;

                m_isMouseOver = value;
                Invalidate();
            }
        }

        protected override Size DefaultSize
        {
            get { return Resources.DockPane_Close.Size; }
        }

        protected override void OnMouseMove(MouseEventArgs e)
        {
            base.OnMouseMove(e);
            bool over = ClientRectangle.Contains(e.X, e.Y);
            if (IsMouseOver != over)
                IsMouseOver = over;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (!IsMouseOver)
                IsMouseOver = true;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (IsMouseOver)
                IsMouseOver = false;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            if (IsMouseOver && Enabled)
            {
                using (Pen pen = new Pen(ForeColor))
                {
                    e.Graphics.DrawRectangle(pen, Rectangle.Inflate(ClientRectangle, -1, -1));
                }
            }

            DrawImageHelper.ConvertImage(Image, e.Graphics, ForeColor, Color.Transparent, false);
            base.OnPaint(e);
        }

        public void RefreshChanges()
        {
            if (IsDisposed)
                return;

            bool mouseOver = ClientRectangle.Contains(PointToClient(Control.MousePosition));
            if (mouseOver != IsMouseOver)
                IsMouseOver = mouseOver;

            OnRefreshChanges();
        }

        protected virtual void OnRefreshChanges()
        {
        }
    }
}
