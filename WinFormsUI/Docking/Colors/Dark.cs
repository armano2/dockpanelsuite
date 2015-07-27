using System.Drawing;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking.Colors
{
    public class Dark : IColor
    {
        public Dark()
        {
            rgbTable = new Dictionary<IKnownColors, Color>();

            /*
            var back = Color.FromArgb(255, 45, 45, 48);
            var specialBlue = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            var darkdot = Color.FromArgb(255, 70, 70, 74);
            var bluedot = Color.FromArgb(255, 89, 168, 222);
            var activeTab = specialBlue;
            var mouseHoverTab = Color.FromArgb(0xFF, 28, 151, 234);
            var toolActiveTab = Color.FromArgb(255, 30, 30, 30);
            var inactiveTab = back;
            var lostFocusTab = Color.FromArgb(0xFF, 63, 63, 70);
            var inactiveText = Color.FromArgb(255, 241, 241, 241);
            var darkText = Color.FromArgb(255, 208, 208, 208);*/

            // TODO setup colors from VS2012DarkColorTable
            rgbTable[IKnownColors.dragFrom] = Color.FromArgb(0xff, 91, 173, 255);

            rgbTable[IKnownColors.ToolWindowTabBorder] = Color.FromArgb(255, 63, 63, 70);
            rgbTable[IKnownColors.ToolWindowActivedTabBorder] = Color.FromArgb(255, 30, 30, 30);

            rgbTable[IKnownColors.SplitterControl_horizontalBrush] = Color.FromArgb(0xFF, 37, 37, 38);
            rgbTable[IKnownColors.SplitterControl_horizontalColor] = Color.FromArgb(255, 37, 37, 38);
            rgbTable[IKnownColors.SplitterControl_verticalSurroundColors] = Color.FromArgb(255, 45, 45, 48);
        }
    }
}
