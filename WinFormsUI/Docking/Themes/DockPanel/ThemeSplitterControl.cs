using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking.Themes;
using WeifenLuo.WinFormsUI.Docking.Colors;

namespace WeifenLuo.WinFormsUI.Docking
{
    internal class ThemeSplitterControl : DockPane.SplitterControlBase
    {
        private static readonly SolidBrush _horizontalBrush = new SolidBrush(ThemeMgr.Instance.getColor(KnownColors.SplitterControl_horizontalBrush));
        private static readonly Color[] _verticalSurroundColors = new[] { ThemeMgr.Instance.getColor(KnownColors.SplitterControl_verticalSurroundColors) };


        public ThemeSplitterControl(DockPane pane)
            : base(pane)
        {
			this.BackColor = ThemeMgr.Instance.getColor(KnownColors.SplitterControl_horizontalColor);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            Rectangle rect = ClientRectangle;

            if (rect.Width <= 0 || rect.Height <= 0)
                return;

            switch (Alignment)
            {
                case DockAlignment.Right:
                case DockAlignment.Left:
                    {
                        using (var path = new GraphicsPath())
                        {
                            path.AddRectangle(rect);
                            using (var brush = new PathGradientBrush(path)
                                {
                                    CenterColor = ThemeMgr.Instance.getColor(KnownColors.SplitterControl_horizontalColor),
                                    SurroundColors = _verticalSurroundColors
                                })
                            {
                                e.Graphics.FillRectangle(brush, rect.X + Measures.SplitterSize / 2 - 1, rect.Y,
                                                         Measures.SplitterSize / 3, rect.Height);
                            }
                        }
                    }
                    break;
                case DockAlignment.Bottom:
                case DockAlignment.Top:
                    {
                        e.Graphics.FillRectangle(_horizontalBrush, rect.X, rect.Y,
                                        rect.Width, Measures.SplitterSize);
                    }
                    break;
            }
        }
    }
}