using System.Drawing;
using System.Collections.Generic;

namespace WeifenLuo.WinFormsUI.Docking.Colors
{
    public class Light : IColor
    {
        public Light()
        {
            rgbTable = new Dictionary<KnownColors, Color>();
            rgbTable[KnownColors.btnBorder] = Color.FromArgb(145, 153, 164);
            rgbTable[KnownColors.btnBackground] = Color.FromArgb(255, 254, 254, 254);
            rgbTable[KnownColors.btnBackgroundPressed] = Color.FromArgb(141, 170, 253);
            rgbTable[KnownColors.btnBackgroundChecked] = Color.FromArgb(141, 170, 253);
            rgbTable[KnownColors.btnBackgroundSelected] = Color.FromArgb(98, 101, 252);

            rgbTable[KnownColors.gripDark] = Color.FromArgb(255, 221, 226, 236);
            rgbTable[KnownColors.gripLight] = Color.FromArgb(255, 204, 204, 219);

            rgbTable[KnownColors.imageBorder] = Color.FromArgb(255, 231, 232, 236);

            rgbTable[KnownColors.menuBg] = Color.FromArgb(255, 239, 239, 242);
            rgbTable[KnownColors.menuBorder] = Color.FromArgb(255, 231, 232, 236);
            rgbTable[KnownColors.menuBgSelected] = Color.FromArgb(255, 248, 249, 250);
            rgbTable[KnownColors.menuBgPressed] = Color.FromArgb(255, 231, 232, 236);

            rgbTable[KnownColors.statusBg] = Color.FromArgb(255, 79, 146, 219);

            rgbTable[KnownColors.raftingBg] = Color.FromArgb(255, 186, 192, 201);

            rgbTable[KnownColors.overflowBg] = Color.FromArgb(255, 239, 239, 242);

            rgbTable[KnownColors.toolBorder] = Color.FromArgb(0, 0, 0, 0);
            rgbTable[KnownColors.toolDropDown] = Color.FromArgb(255, 231, 232, 236);
            rgbTable[KnownColors.toolBackground] = Color.FromArgb(255, 239, 239, 242);

            rgbTable[KnownColors.dragFrom] = Color.FromArgb(255, 239, 239, 242);

            rgbTable[KnownColors.FormBackground] = SystemColors.Control;
            rgbTable[KnownColors.ActiveTabOrDocument] = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);
            rgbTable[KnownColors.Active2TabOrDocument] = Color.FromArgb(0xFF, 220, 220, 220);
            rgbTable[KnownColors.ActiveTabOrDocumentText] = Color.White;
            rgbTable[KnownColors.UnactiveTabOrDocumentText] = SystemColors.GrayText;
            rgbTable[KnownColors.ActiveMultiTabBackground] = Color.FromArgb(0xFF, 230, 230, 230);
            rgbTable[KnownColors.ActiveMultiTabText] = Color.FromArgb(0xFF, 0x00, 0x7A, 0xCC);

            rgbTable[KnownColors.ToolWindowTabBorder] = SystemColors.ControlDark;
            rgbTable[KnownColors.ToolWindowActivedTabBorder] = SystemColors.ControlDark;

            rgbTable[KnownColors.SplitterControl_horizontalBrush] = Color.FromArgb(0xFF, 204, 206, 219);
            rgbTable[KnownColors.SplitterControl_horizontalColor] = Color.FromArgb(0xFF, 204, 206, 219);
            rgbTable[KnownColors.SplitterControl_verticalSurroundColors] = SystemColors.Control;
    }
    }
}
