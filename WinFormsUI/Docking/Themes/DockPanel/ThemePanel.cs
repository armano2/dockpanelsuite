using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking.Themes;
using WeifenLuo.WinFormsUI.Docking.Colors;

namespace WeifenLuo.WinFormsUI.Docking
{
    /// <summary>
    /// Visual Studio 2012 Theme.
    /// </summary>
    public class ThemePanel : ThemeBase
    {
        /// <summary>
        /// Applies the specified theme to the dock panel.
        /// </summary>
        /// <param name="dockPanel">The dock panel.</param>
        public override void Apply(DockPanel dockPanel)
        {
            if (dockPanel == null)
            {
                throw new NullReferenceException("dockPanel");
            }

            Measures.SplitterSize = 6;
            dockPanel.Extender.DockPaneCaptionFactory = new ThemeDockPaneCaptionFactory();
            dockPanel.Extender.AutoHideStripFactory = new ThemeAutoHideStripFactory();
            dockPanel.Extender.AutoHideWindowFactory = new ThemeAutoHideWindowFactory();
            dockPanel.Extender.DockPaneStripFactory = new ThemeDockPaneStripFactory();
            dockPanel.Extender.DockPaneSplitterControlFactory = new ThemeDockPaneSplitterControlFactory();
            dockPanel.Extender.DockWindowSplitterControlFactory = new ThemeDockWindowSplitterControlFactory();
            dockPanel.Extender.DockWindowFactory = new ThemeDockWindowFactory();
            dockPanel.Extender.PaneIndicatorFactory = new ThemePaneIndicatorFactory();
            dockPanel.Extender.PanelIndicatorFactory = new ThemePanelIndicatorFactory();
            dockPanel.Extender.DockOutlineFactory = new ThemeDockOutlineFactory();
            dockPanel.Skin = CreatePanelThemeValues();
        }

        private class ThemeDockOutlineFactory : DockPanelExtender.IDockOutlineFactory
        {
            public DockOutlineBase CreateDockOutline()
            {
                return new ThemeDockOutline();
            }

            private class ThemeDockOutline : DockOutlineBase
            {
                public ThemeDockOutline()
                {
                    m_dragForm = new DragForm();
                    SetDragForm(Rectangle.Empty);
                    DragForm.BackColor = ThemeMgr.Instance.getColor(KnownColors.dragFrom);
                    DragForm.Opacity = 0.5;
                    DragForm.Show(false);
                }

                DragForm m_dragForm;
                private DragForm DragForm
                {
                    get { return m_dragForm; }
                }

                protected override void OnShow()
                {
                    CalculateRegion();
                }

                protected override void OnClose()
                {
                    DragForm.Close();
                }

                private void CalculateRegion()
                {
                    if (SameAsOldValue)
                        return;

                    if (!FloatWindowBounds.IsEmpty)
                        SetOutline(FloatWindowBounds);
                    else if (DockTo is DockPanel)
                        SetOutline(DockTo as DockPanel, Dock, (ContentIndex != 0));
                    else if (DockTo is DockPane)
                        SetOutline(DockTo as DockPane, Dock, ContentIndex);
                    else
                        SetOutline();
                }

                private void SetOutline()
                {
                    SetDragForm(Rectangle.Empty);
                }

                private void SetOutline(Rectangle floatWindowBounds)
                {
                    SetDragForm(floatWindowBounds);
                }

                private void SetOutline(DockPanel dockPanel, DockStyle dock, bool fullPanelEdge)
                {
                    Rectangle rect = fullPanelEdge ? dockPanel.DockArea : dockPanel.DocumentWindowBounds;
                    rect.Location = dockPanel.PointToScreen(rect.Location);
                    if (dock == DockStyle.Top)
                    {
                        int height = dockPanel.GetDockWindowSize(DockState.DockTop);
                        rect = new Rectangle(rect.X, rect.Y, rect.Width, height);
                    }
                    else if (dock == DockStyle.Bottom)
                    {
                        int height = dockPanel.GetDockWindowSize(DockState.DockBottom);
                        rect = new Rectangle(rect.X, rect.Bottom - height, rect.Width, height);
                    }
                    else if (dock == DockStyle.Left)
                    {
                        int width = dockPanel.GetDockWindowSize(DockState.DockLeft);
                        rect = new Rectangle(rect.X, rect.Y, width, rect.Height);
                    }
                    else if (dock == DockStyle.Right)
                    {
                        int width = dockPanel.GetDockWindowSize(DockState.DockRight);
                        rect = new Rectangle(rect.Right - width, rect.Y, width, rect.Height);
                    }
                    else if (dock == DockStyle.Fill)
                    {
                        rect = dockPanel.DocumentWindowBounds;
                        rect.Location = dockPanel.PointToScreen(rect.Location);
                    }

                    SetDragForm(rect);
                }

                private void SetOutline(DockPane pane, DockStyle dock, int contentIndex)
                {
                    if (dock != DockStyle.Fill)
                    {
                        Rectangle rect = pane.DisplayingRectangle;
                        if (dock == DockStyle.Right)
                            rect.X += rect.Width / 2;
                        if (dock == DockStyle.Bottom)
                            rect.Y += rect.Height / 2;
                        if (dock == DockStyle.Left || dock == DockStyle.Right)
                            rect.Width -= rect.Width / 2;
                        if (dock == DockStyle.Top || dock == DockStyle.Bottom)
                            rect.Height -= rect.Height / 2;
                        rect.Location = pane.PointToScreen(rect.Location);

                        SetDragForm(rect);
                    }
                    else if (contentIndex == -1)
                    {
                        Rectangle rect = pane.DisplayingRectangle;
                        rect.Location = pane.PointToScreen(rect.Location);
                        SetDragForm(rect);
                    }
                    else
                    {
                        using (GraphicsPath path = pane.TabStripControl.GetOutline(contentIndex))
                        {
                            RectangleF rectF = path.GetBounds();
                            Rectangle rect = new Rectangle((int)rectF.X, (int)rectF.Y, (int)rectF.Width, (int)rectF.Height);
                            using (Matrix matrix = new Matrix(rect, new Point[] { new Point(0, 0), new Point(rect.Width, 0), new Point(0, rect.Height) }))
                            {
                                path.Transform(matrix);
                            }

                            Region region = new Region(path);
                            SetDragForm(rect, region);
                        }
                    }
                }

                private void SetDragForm(Rectangle rect)
                {
                    DragForm.Bounds = rect;
                    if (rect == Rectangle.Empty)
                    {
                        if (DragForm.Region != null)
                        {
                            DragForm.Region.Dispose();
                        }

                        DragForm.Region = new Region(Rectangle.Empty);
                    }
                    else if (DragForm.Region != null)
                    {
                        DragForm.Region.Dispose();
                        DragForm.Region = null;
                    }
                }

                private void SetDragForm(Rectangle rect, Region region)
                {
                    DragForm.Bounds = rect;
                    if (DragForm.Region != null)
                    {
                        DragForm.Region.Dispose();
                    }

                    DragForm.Region = region;
                }
            }
        }

        private class ThemePanelIndicatorFactory : DockPanelExtender.IPanelIndicatorFactory
        {
            public DockPanel.IPanelIndicator CreatePanelIndicator(DockStyle style)
            {
                return new ThemePanelIndicator(style);
            }

            private class ThemePanelIndicator : PictureBox, DockPanel.IPanelIndicator
            {
                private static Image _imagePanelLeft = Resources.DockIndicator_PanelLeft_VS2012;
                private static Image _imagePanelRight = Resources.DockIndicator_PanelRight_VS2012;
                private static Image _imagePanelTop = Resources.DockIndicator_PanelTop_VS2012;
                private static Image _imagePanelBottom = Resources.DockIndicator_PanelBottom_VS2012;
                private static Image _imagePanelFill = Resources.DockIndicator_PanelFill_VS2012;

                private static Image _imagePanelLeftActive = Resources.DockIndicator_PanelLeft_VS2012;
                private static Image _imagePanelRightActive = Resources.DockIndicator_PanelRight_VS2012;
                private static Image _imagePanelTopActive = Resources.DockIndicator_PanelTop_VS2012;
                private static Image _imagePanelBottomActive = Resources.DockIndicator_PanelBottom_VS2012;
                private static Image _imagePanelFillActive = Resources.DockIndicator_PanelFill_VS2012;

                public ThemePanelIndicator(DockStyle dockStyle)
                {
                    m_dockStyle = dockStyle;
                    SizeMode = PictureBoxSizeMode.AutoSize;
                    Image = ImageInactive;
                }

                private DockStyle m_dockStyle;

                private DockStyle DockStyle
                {
                    get { return m_dockStyle; }
                }

                private DockStyle m_status;

                public DockStyle Status
                {
                    get { return m_status; }
                    set
                    {
                        if (value != DockStyle && value != DockStyle.None)
                            throw new InvalidEnumArgumentException();

                        if (m_status == value)
                            return;

                        m_status = value;
                        IsActivated = (m_status != DockStyle.None);
                    }
                }

                private Image ImageInactive
                {
                    get
                    {
                        if (DockStyle == DockStyle.Left)
                            return _imagePanelLeft;
                        else if (DockStyle == DockStyle.Right)
                            return _imagePanelRight;
                        else if (DockStyle == DockStyle.Top)
                            return _imagePanelTop;
                        else if (DockStyle == DockStyle.Bottom)
                            return _imagePanelBottom;
                        else if (DockStyle == DockStyle.Fill)
                            return _imagePanelFill;
                        else
                            return null;
                    }
                }

                private Image ImageActive
                {
                    get
                    {
                        if (DockStyle == DockStyle.Left)
                            return _imagePanelLeftActive;
                        else if (DockStyle == DockStyle.Right)
                            return _imagePanelRightActive;
                        else if (DockStyle == DockStyle.Top)
                            return _imagePanelTopActive;
                        else if (DockStyle == DockStyle.Bottom)
                            return _imagePanelBottomActive;
                        else if (DockStyle == DockStyle.Fill)
                            return _imagePanelFillActive;
                        else
                            return null;
                    }
                }

                private bool m_isActivated = false;

                private bool IsActivated
                {
                    get { return m_isActivated; }
                    set
                    {
                        m_isActivated = value;
                        Image = IsActivated ? ImageActive : ImageInactive;
                    }
                }

                public DockStyle HitTest(Point pt)
                {
                    return this.Visible && ClientRectangle.Contains(PointToClient(pt)) ? DockStyle : DockStyle.None;
                }
            }
        }

        private class ThemePaneIndicatorFactory : DockPanelExtender.IPaneIndicatorFactory
        {
            public DockPanel.IPaneIndicator CreatePaneIndicator()
            {
                return new ThemePaneIndicator();
            }

            private class ThemePaneIndicator : PictureBox, DockPanel.IPaneIndicator
            {
                private static Bitmap _bitmapPaneDiamond = Resources.DockIndicator_PaneDiamond_VS2012;
                private static Bitmap _bitmapPaneDiamondLeft = Resources.DockIndicator_PaneDiamond_Fill_VS2012;
                private static Bitmap _bitmapPaneDiamondRight = Resources.DockIndicator_PaneDiamond_Fill_VS2012;
                private static Bitmap _bitmapPaneDiamondTop = Resources.DockIndicator_PaneDiamond_Fill_VS2012;
                private static Bitmap _bitmapPaneDiamondBottom = Resources.DockIndicator_PaneDiamond_Fill_VS2012;
                private static Bitmap _bitmapPaneDiamondFill = Resources.DockIndicator_PaneDiamond_Fill_VS2012;
                private static Bitmap _bitmapPaneDiamondHotSpot = Resources.DockIndicator_PaneDiamond_Hotspot_VS2012;
                private static Bitmap _bitmapPaneDiamondHotSpotIndex = Resources.DockIndicator_PaneDiamond_HotspotIndex_VS2012;

                private static DockPanel.HotSpotIndex[] _hotSpots = new[]
                    {
                        new DockPanel.HotSpotIndex(1, 0, DockStyle.Top),
                        new DockPanel.HotSpotIndex(0, 1, DockStyle.Left),
                        new DockPanel.HotSpotIndex(1, 1, DockStyle.Fill),
                        new DockPanel.HotSpotIndex(2, 1, DockStyle.Right),
                        new DockPanel.HotSpotIndex(1, 2, DockStyle.Bottom)
                    };

                private GraphicsPath _displayingGraphicsPath = DrawHelper.CalculateGraphicsPathFromBitmap(_bitmapPaneDiamond);

                public ThemePaneIndicator()
                {
                    SizeMode = PictureBoxSizeMode.AutoSize;
                    Image = _bitmapPaneDiamond;
                    Region = new Region(DisplayingGraphicsPath);
                }

                public GraphicsPath DisplayingGraphicsPath
                {
                    get { return _displayingGraphicsPath; }
                }

                public DockStyle HitTest(Point pt)
                {
                    if (!Visible)
                        return DockStyle.None;

                    pt = PointToClient(pt);
                    if (!ClientRectangle.Contains(pt))
                        return DockStyle.None;

                    for (int i = _hotSpots.GetLowerBound(0); i <= _hotSpots.GetUpperBound(0); i++)
                    {
                        if (_bitmapPaneDiamondHotSpot.GetPixel(pt.X, pt.Y) == _bitmapPaneDiamondHotSpotIndex.GetPixel(_hotSpots[i].X, _hotSpots[i].Y))
                            return _hotSpots[i].DockStyle;
                    }

                    return DockStyle.None;
                }

                private DockStyle m_status = DockStyle.None;

                public DockStyle Status
                {
                    get { return m_status; }
                    set
                    {
                        m_status = value;
                        if (m_status == DockStyle.None)
                            Image = _bitmapPaneDiamond;
                        else if (m_status == DockStyle.Left)
                            Image = _bitmapPaneDiamondLeft;
                        else if (m_status == DockStyle.Right)
                            Image = _bitmapPaneDiamondRight;
                        else if (m_status == DockStyle.Top)
                            Image = _bitmapPaneDiamondTop;
                        else if (m_status == DockStyle.Bottom)
                            Image = _bitmapPaneDiamondBottom;
                        else if (m_status == DockStyle.Fill)
                            Image = _bitmapPaneDiamondFill;
                    }
                }
            }
        }

        private class ThemeAutoHideWindowFactory : DockPanelExtender.IAutoHideWindowFactory
        {
            public DockPanel.AutoHideWindowControl CreateAutoHideWindow(DockPanel panel)
            {
                return new ThemeAutoHideWindowControl(panel);
            }
        }

        private class ThemeDockPaneSplitterControlFactory : DockPanelExtender.IDockPaneSplitterControlFactory
        {
            public DockPane.SplitterControlBase CreateSplitterControl(DockPane pane)
            {
                return new ThemeSplitterControl(pane);
            }
        }

        private class ThemeDockWindowSplitterControlFactory : DockPanelExtender.IDockWindowSplitterControlFactory
        {
            public SplitterBase CreateSplitterControl()
            {
                return new ThemeDockWindow.ThemeDockWindowSplitterControl();
            }
        }

        private class ThemeDockPaneStripFactory : DockPanelExtender.IDockPaneStripFactory
        {
            public DockPaneStripBase CreateDockPaneStrip(DockPane pane)
            {
                return new ThemeDockPaneStrip(pane);
            }
        }

        private class ThemeAutoHideStripFactory : DockPanelExtender.IAutoHideStripFactory
        {
            public AutoHideStripBase CreateAutoHideStrip(DockPanel panel)
            {
                return new ThemeAutoHideStrip(panel);
            }
        }

        private class ThemeDockPaneCaptionFactory : DockPanelExtender.IDockPaneCaptionFactory
        {
            public DockPaneCaptionBase CreateDockPaneCaption(DockPane pane)
            {
                return new ThemeDockPaneCaption(pane);
            }
        }

        private class ThemeDockWindowFactory : DockPanelExtender.IDockWindowFactory
        {
            public DockWindow CreateDockWindow(DockPanel dockPanel, DockState dockState)
            {
                return new ThemeDockWindow(dockPanel, dockState);
            }
        }

        public static DockPanelSkin CreatePanelThemeValues()
        {
            var FormBackground = ThemeMgr.Instance.getColor(KnownColors.FormBackground);
            var ActiveTabOrDocument = ThemeMgr.Instance.getColor(KnownColors.ActiveTabOrDocument);
            var Active2TabOrDocument = ThemeMgr.Instance.getColor(KnownColors.Active2TabOrDocument);
            var ActiveTabOrDocumentText = ThemeMgr.Instance.getColor(KnownColors.ActiveTabOrDocumentText);
            var UnactiveTabOrDocumentText = ThemeMgr.Instance.getColor(KnownColors.UnactiveTabOrDocumentText);
            var ActiveMultiTabBackground = ThemeMgr.Instance.getColor(KnownColors.ActiveMultiTabBackground);
            var ActiveMultiTabText = ThemeMgr.Instance.getColor(KnownColors.ActiveMultiTabText);

            // ------------------------------------------------------------
            var skin = new DockPanelSkin();
            // Unactived, unselected tabs or documents - Should be same as parent background
            skin.DockPaneStripSkin.DocumentGradient.DockStripGradient.StartColor = FormBackground;
            skin.DockPaneStripSkin.DocumentGradient.DockStripGradient.EndColor = FormBackground;
            skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.StartColor = FormBackground;
            skin.DockPaneStripSkin.ToolWindowGradient.DockStripGradient.EndColor = FormBackground;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.StartColor = FormBackground;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.EndColor = FormBackground;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.StartColor = FormBackground;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.EndColor = FormBackground;
            skin.DockPaneStripSkin.DocumentGradient.InactiveTabGradient.EndColor = FormBackground;
            skin.DockPaneStripSkin.DocumentGradient.InactiveTabGradient.StartColor = FormBackground;
            // Active and selected document/tab header
            skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.StartColor = ActiveTabOrDocument;
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.StartColor = ActiveTabOrDocument;
            skin.AutoHideStripSkin.DockStripGradient.StartColor = ActiveTabOrDocument;
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.TextColor = ActiveTabOrDocument;
            // Active and unselected document/tab header
            skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.EndColor = Active2TabOrDocument;
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.EndColor = Active2TabOrDocument;
            skin.AutoHideStripSkin.DockStripGradient.EndColor = Active2TabOrDocument;
            // Active document/tab header text
            skin.DockPaneStripSkin.DocumentGradient.ActiveTabGradient.TextColor = ActiveTabOrDocumentText;
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveCaptionGradient.TextColor = ActiveTabOrDocumentText;
            // Unactive, unselected strip tab text
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveTabGradient.TextColor = UnactiveTabOrDocumentText;
            skin.DockPaneStripSkin.ToolWindowGradient.InactiveCaptionGradient.TextColor = UnactiveTabOrDocumentText;
            skin.DockPaneStripSkin.DocumentGradient.InactiveTabGradient.TextColor = UnactiveTabOrDocumentText;
            // Active, multitab background
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.StartColor = ActiveMultiTabBackground;
            skin.DockPaneStripSkin.ToolWindowGradient.ActiveTabGradient.EndColor = ActiveMultiTabBackground;
            // ------------------------------------------------------------
            // Unused, fix it
            skin.AutoHideStripSkin.TabGradient.TextColor = Color.Red;
            return skin;
        }
    }
}