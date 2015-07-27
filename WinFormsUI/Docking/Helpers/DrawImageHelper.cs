using System.Drawing;
using System.Drawing.Imaging;

namespace WeifenLuo.WinFormsUI.Docking.Helpers
{
    class DrawImageHelper
    {
        public static void ConvertImage(Bitmap image, Graphics g, Color ForeColor, Color BackColor, bool isActive)
        {
            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                ColorMap[] colorMap = new ColorMap[2];
                colorMap[0] = new ColorMap();
                colorMap[0].OldColor = Color.FromArgb(0, 0, 0);
                colorMap[0].NewColor = ForeColor;

                colorMap[1] = new ColorMap();
                colorMap[1].OldColor = image.GetPixel(0, 0);
                colorMap[1].NewColor = isActive ? BackColor : Color.Transparent;

                imageAttributes.SetRemapTable(colorMap);

                g.DrawImage(
                   image,
                   new Rectangle(0, 0, image.Width, image.Height),
                   0, 0,
                   image.Width,
                   image.Height,
                   GraphicsUnit.Pixel,
                   imageAttributes);
            }
        }

        public static void ConvertImage(Bitmap image, Graphics g, Color ForeColor, Color BackColor, bool isActive, Rectangle rectCloseButton)
        {
            using (ImageAttributes imageAttributes = new ImageAttributes())
            {
                ColorMap[] colorMap = new ColorMap[2];
                colorMap[0] = new ColorMap();
                colorMap[0].OldColor = Color.FromArgb(0, 0, 0);
                colorMap[0].NewColor = ForeColor;

                colorMap[1] = new ColorMap();
                colorMap[1].OldColor = image.GetPixel(0, 0);
                colorMap[1].NewColor = isActive ? BackColor : Color.Transparent;

                imageAttributes.SetRemapTable(colorMap);

                g.DrawImage(
                   image,
                   rectCloseButton,
                   0, 0,
                   image.Width,
                   image.Height,
                   GraphicsUnit.Pixel,
                   imageAttributes);
            }
        }
    }
}
