using System.Drawing;
using System.Collections.Generic;

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
var darkText = Color.FromArgb(255, 208, 208, 208);
*/

namespace WeifenLuo.WinFormsUI.Docking.Colors
{
    public class Dark : IColor
    {
        public Dark()
        {
            rgbTable = new Dictionary<IKnownColors, Color>();
            //rgbTable[IKnownColors.btnBorder] = Color.FromArgb(145, 153, 164);
            //rgbTable[IKnownColors.btnBackground] = Color.FromArgb(255, 254, 254, 254);
            //rgbTable[IKnownColors.btnBackgroundPressed] = Color.FromArgb(141, 170, 253);
            //rgbTable[IKnownColors.btnBackgroundChecked] = Color.FromArgb(141, 170, 253);
            //rgbTable[IKnownColors.btnBackgroundSelected] = Color.FromArgb(98, 101, 252);

            //rgbTable[IKnownColors.gripDark] = Color.FromArgb(255, 221, 226, 236);
            //rgbTable[IKnownColors.gripLight] = Color.FromArgb(255, 204, 204, 219);

            //rgbTable[IKnownColors.imageBorder] = Color.FromArgb(255, 231, 232, 236);

            rgbTable[IKnownColors.menuBg] = Color.FromArgb(255, 45, 45, 48);
            rgbTable[IKnownColors.menuBorder] = Color.FromArgb(255, 45, 45, 48);
            rgbTable[IKnownColors.menuBgSelected] = Color.FromArgb(255, 45, 45, 48);
            rgbTable[IKnownColors.menuBgPressed] = Color.FromArgb(255, 45, 45, 48);

            //rgbTable[IKnownColors.statusBg] = Color.FromArgb(255, 79, 146, 219);

            //rgbTable[IKnownColors.raftingBg] = Color.FromArgb(255, 186, 192, 201);

            //rgbTable[IKnownColors.overflowBg] = Color.FromArgb(255, 239, 239, 242);

            //rgbTable[IKnownColors.toolBorder] = Color.FromArgb(0, 0, 0, 0);
            //rgbTable[IKnownColors.toolDropDown] = Color.FromArgb(255, 231, 232, 236);
            //rgbTable[IKnownColors.toolBackground] = Color.FromArgb(255, 239, 239, 242);

            rgbTable[IKnownColors.dragFrom] = Color.FromArgb(0xff, 91, 173, 255);

            rgbTable[IKnownColors.FormBackground] = Color.FromArgb(255, 45, 45, 48);
            rgbTable[IKnownColors.FormText] = Color.White;

            rgbTable[IKnownColors.ActiveTabOrDocument] = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            //rgbTable[IKnownColors.Active2TabOrDocument] = Color.FromArgb(0xFF, 220, 220, 220);
            rgbTable[IKnownColors.ActiveTabOrDocumentText] = Color.White;
            rgbTable[IKnownColors.UnactiveTabOrDocumentText] = Color.White;
            //rgbTable[IKnownColors.ActiveMultiTabBackground] = Color.FromArgb(0xFF, 230, 230, 230);
            //rgbTable[IKnownColors.ActiveMultiTabText] = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);

            rgbTable[IKnownColors.ToolWindowTabBorder] = Color.FromArgb(255, 63, 63, 70);
            rgbTable[IKnownColors.ToolWindowActivedTabBorder] = Color.FromArgb(255, 30, 30, 30);

            rgbTable[IKnownColors.SplitterControl_horizontalBrush] = Color.FromArgb(0xFF, 37, 37, 38);
            rgbTable[IKnownColors.SplitterControl_horizontalColor] = Color.FromArgb(255, 37, 37, 38);
            rgbTable[IKnownColors.SplitterControl_verticalSurroundColors] = Color.FromArgb(255, 45, 45, 48);
        }
    }
}
