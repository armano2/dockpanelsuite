using System.Collections.Generic;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking.Colors
{
    public enum IKnownColors
    {
        btnBorder = 0,
        btnBackground,
        btnBackgroundPressed,
        btnBackgroundChecked,
        btnBackgroundSelected,
        gripLight,
        gripDark,
        imageBorder,
        menuBg,
        menuBorder,
        menuBgSelected,
        menuBgPressed,
        statusBg,
        raftingBg,
        overflowBg,
        toolBorder,
        toolDropDown,
        toolBackground,
        dragFrom,

        FormBackground,
        ActiveTabOrDocument,
        Active2TabOrDocument,
        ActiveTabOrDocumentText,
        UnactiveTabOrDocumentText,
        ActiveMultiTabBackground,
        ActiveMultiTabText,

        ToolWindowTabBorder,
        ToolWindowActivedTabBorder,

        SplitterControl_horizontalBrush,
        SplitterControl_horizontalColor,
        SplitterControl_verticalSurroundColors,
    };

    public abstract class IColor
    {
        protected Dictionary<IKnownColors, Color> rgbTable;

        public Color color(IKnownColors type)
        {
            if (rgbTable.ContainsKey(type))
                return rgbTable[type];

            return Color.FromArgb(0, 0, 0); // Fill by somethink...
        }
    }
}
