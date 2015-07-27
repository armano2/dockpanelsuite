using System.Drawing;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking.Colors
{
    public class Light : IColor
    {
        public Light()
        {
            rgbTable = new Dictionary<IKnownColors, Color>();
            rgbTable[IKnownColors.btnBorder] = Color.FromArgb(145, 153, 164);
            rgbTable[IKnownColors.btnBackground] = Color.FromArgb(255, 254, 254, 254);
            rgbTable[IKnownColors.btnBackgroundPressed] = Color.FromArgb(141, 170, 253);
            rgbTable[IKnownColors.btnBackgroundChecked] = Color.FromArgb(141, 170, 253);
            rgbTable[IKnownColors.btnBackgroundSelected] = Color.FromArgb(98, 101, 252);

            rgbTable[IKnownColors.gripDark] = Color.FromArgb(255, 221, 226, 236);
            rgbTable[IKnownColors.gripLight] = Color.FromArgb(255, 204, 204, 219);

            rgbTable[IKnownColors.imageBorder] = Color.FromArgb(255, 231, 232, 236);

            rgbTable[IKnownColors.menuBg] = Color.FromArgb(255, 239, 239, 242);
            rgbTable[IKnownColors.menuBorder] = Color.FromArgb(255, 231, 232, 236);
            rgbTable[IKnownColors.menuBgSelected] = Color.FromArgb(255, 248, 249, 250);
            rgbTable[IKnownColors.menuBgPressed] = Color.FromArgb(255, 231, 232, 236);

            rgbTable[IKnownColors.statusBg] = Color.FromArgb(255, 79, 146, 219);

            rgbTable[IKnownColors.raftingBg] = Color.FromArgb(255, 186, 192, 201);

            rgbTable[IKnownColors.overflowBg] = Color.FromArgb(255, 239, 239, 242);

            rgbTable[IKnownColors.toolBorder] = Color.FromArgb(0, 0, 0, 0);
            rgbTable[IKnownColors.toolDropDown] = Color.FromArgb(255, 231, 232, 236);
            rgbTable[IKnownColors.toolBackground] = Color.FromArgb(255, 239, 239, 242);

            rgbTable[IKnownColors.dragFrom] = Color.FromArgb(255, 239, 239, 242);

            rgbTable[IKnownColors.FormBackground] = SystemColors.Control;
            rgbTable[IKnownColors.ActiveTabOrDocument] = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            rgbTable[IKnownColors.Active2TabOrDocument] = Color.FromArgb(0xFF, 220, 220, 220);
            rgbTable[IKnownColors.ActiveTabOrDocumentText] = Color.White;
            rgbTable[IKnownColors.UnactiveTabOrDocumentText] = SystemColors.GrayText;
            rgbTable[IKnownColors.ActiveMultiTabBackground] = Color.FromArgb(0xFF, 230, 230, 230);
            rgbTable[IKnownColors.ActiveMultiTabText] = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);

            rgbTable[IKnownColors.ToolWindowTabBorder] = SystemColors.ControlDark;
            rgbTable[IKnownColors.ToolWindowActivedTabBorder] = SystemColors.ControlDark;

            rgbTable[IKnownColors.SplitterControl_horizontalBrush] = Color.FromArgb(0xFF, 204, 206, 219);
            rgbTable[IKnownColors.SplitterControl_horizontalColor] = Color.FromArgb(0xFF, 204, 206, 219);
            rgbTable[IKnownColors.SplitterControl_verticalSurroundColors] = SystemColors.Control;
    }
    }
}
