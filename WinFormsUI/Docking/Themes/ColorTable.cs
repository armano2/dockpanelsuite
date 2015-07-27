using System.Drawing;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking.Colors;

namespace WeifenLuo.WinFormsUI.Docking.Themes
{
    class ColorTable : ProfessionalColorTable
    {
        public override Color ButtonSelectedHighlight
        {
            get { return ButtonSelectedGradientMiddle; }
        }
        public override Color ButtonSelectedHighlightBorder
        {
            get { return ButtonSelectedBorder; }
        }
        public override Color ButtonPressedHighlight
        {
            get { return ButtonPressedGradientMiddle; }
        }
        public override Color ButtonPressedHighlightBorder
        {
            get { return ButtonPressedBorder; }
        }
        public override Color ButtonCheckedHighlight
        {
            get { return ButtonCheckedGradientMiddle; }
        }
        public override Color ButtonCheckedHighlightBorder
        {
            get { return ButtonSelectedBorder; }
        }
        public override Color ButtonPressedBorder
        {
            get { return ButtonSelectedBorder; }
        }
        // btnBorder
        public override Color ButtonSelectedBorder
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.btnBorder); }
        }
        // btnBackgroundChecked
        public override Color ButtonCheckedGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.btnBackgroundChecked); }
        }
        public override Color ButtonCheckedGradientMiddle
        {
            get { return ButtonCheckedGradientBegin; }
        }
        public override Color ButtonCheckedGradientEnd
        {
            get { return ButtonCheckedGradientBegin; }
        }
        // btnBackground
        public override Color ButtonSelectedGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.btnBackground); }
        }
        public override Color ButtonSelectedGradientMiddle
        {
            get { return ButtonSelectedGradientBegin; }
        }
        public override Color ButtonSelectedGradientEnd
        {
            get { return ButtonSelectedGradientBegin; }
        }
        // btnBackgroundPressed
        public override Color ButtonPressedGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.btnBackgroundPressed); }
        }
        public override Color ButtonPressedGradientMiddle
        {
            get { return ButtonPressedGradientBegin; }
        }
        public override Color ButtonPressedGradientEnd
        {
            get { return ButtonPressedGradientBegin; }
        }


        public override Color CheckBackground
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.btnBackground); }
        }
        public override Color CheckSelectedBackground
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.btnBackground); }
        }
        public override Color CheckPressedBackground
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.btnBackgroundSelected); }
        }
        // Grip
        public override Color GripDark
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.gripDark); }
        }
        public override Color GripLight
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.gripLight); }
        }
        // Separator
        public override Color SeparatorDark
        {
            get { return GripDark; }
        }
        public override Color SeparatorLight
        {
            get { return GripLight; }
        }
        // Image
        public override Color ImageMarginGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.imageBorder); }
        }
        public override Color ImageMarginGradientMiddle
        {
            get { return ImageMarginGradientBegin; }
        }
        public override Color ImageMarginGradientEnd
        {
            get { return ImageMarginGradientBegin; }
        }
        public override Color ImageMarginRevealedGradientBegin
        {
            get { return ImageMarginGradientBegin; }
        }
        public override Color ImageMarginRevealedGradientMiddle
        {
            get { return ImageMarginGradientBegin; }
        }
        public override Color ImageMarginRevealedGradientEnd
        {
            get { return ImageMarginGradientBegin; }
        }
        // Menu
        public override Color MenuStripGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.menuBg); }
        }
        public override Color MenuStripGradientEnd
        {
            get { return MenuStripGradientBegin; }
        }
        public override Color MenuItemSelected
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.menuBgSelected); }
        }
        public override Color MenuItemBorder
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.menuBorder); }
        }
        public override Color MenuBorder
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.menuBg); }
        }
        public override Color MenuItemSelectedGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.menuBgSelected); }
        }
        public override Color MenuItemSelectedGradientEnd
        {
            get { return MenuItemSelectedGradientBegin; }
        }
        public override Color MenuItemPressedGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.menuBgPressed); }
        }
        public override Color MenuItemPressedGradientMiddle
        {
            get { return MenuItemPressedGradientBegin; }
        }
        public override Color MenuItemPressedGradientEnd
        {
            get { return MenuItemPressedGradientBegin; }
        }
        // Rafting
        public override Color RaftingContainerGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.raftingBg); }
        }
        public override Color RaftingContainerGradientEnd
        {
            get { return RaftingContainerGradientBegin; }
        }
        // Status
        public override Color StatusStripGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.statusBg); }
        }
        public override Color StatusStripGradientEnd
        {
            get { return StatusStripGradientBegin; }
        }
        // ToolStrip
        public override Color ToolStripBorder
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.toolBorder); }
        }
        public override Color ToolStripDropDownBackground
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.toolDropDown); }
        }
        public override Color ToolStripGradientBegin
        {
            get { return ToolStripContentPanelGradientBegin; }
        }
        public override Color ToolStripGradientMiddle
        {
            get { return ToolStripGradientBegin; }
        }
        public override Color ToolStripGradientEnd
        {
            get { return ToolStripGradientBegin; }
        }
        public override Color ToolStripContentPanelGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.toolBackground); }
        }
        public override Color ToolStripContentPanelGradientEnd
        {
            get { return ToolStripContentPanelGradientBegin; }
        }
        public override Color ToolStripPanelGradientBegin
        {
            get { return ToolStripContentPanelGradientBegin; }
        }
        public override Color ToolStripPanelGradientEnd
        {
            get { return ToolStripContentPanelGradientBegin; }
        }
        // Overflow
        public override Color OverflowButtonGradientBegin
        {
            get { return ThemeMgr.Instance.getColor(KnownColors.overflowBg); }
        }
        public override Color OverflowButtonGradientMiddle
        {
            get { return OverflowButtonGradientBegin; }
        }
        public override Color OverflowButtonGradientEnd
        {
            get { return OverflowButtonGradientBegin; }
        }
    }
}
