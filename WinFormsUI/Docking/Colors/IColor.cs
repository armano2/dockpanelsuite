using System.Collections.Generic;
using System.Drawing;

namespace WeifenLuo.WinFormsUI.Docking.Colors
{
    public enum IKnownColors
    {
        FormBackground = 0,
        FormText,

        btnBorder,
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
        contentBackcolor,

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

        ScrollBarBackground,
        ScrollBarDragBackground,
        ScrollBarDragHoverBackground,
        ScrollBarDragDownBackground,
        ScrollBarArrowBackground,
        ScrollBarArrowHoverBackground,
        ScrollBarArrowDownBackground,
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
