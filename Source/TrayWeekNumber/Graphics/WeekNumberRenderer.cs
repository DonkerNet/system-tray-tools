using System.Drawing;
using DrawingSurface = System.Drawing.Graphics;

namespace TrayWeekNumber.Graphics
{
    public class WeekNumberRenderer
    {
        private readonly Color _foreColor;
        private readonly Color _backColor;
        private const string FontFamily = "Verdana";
        private const float FontSize = 11F;
        private readonly FontStyle _fontStyle;
        private readonly Size _iconSize;

        public WeekNumberRenderer(AppSettings appSettings)
        {
            _foreColor = appSettings.ForeColor;
            _backColor = appSettings.ShowBackColor ? appSettings.BackColor : Color.Transparent;
            _fontStyle = FontStyle.Bold;
            _iconSize = new Size(16, 16);
        }

        public Bitmap RenderBitmap(int weekNumber)
        {
            string weekNumberString = weekNumber.ToString("G");
            
            Bitmap image = new Bitmap(_iconSize.Width, _iconSize.Height);

            using (DrawingSurface g = DrawingSurface.FromImage(image))
            {
                g.Clear(_backColor);

                using (Font iconFont = new Font(FontFamily, FontSize, _fontStyle, GraphicsUnit.Pixel))
                {
                    SizeF textSize = g.MeasureString(weekNumberString, iconFont);

                    using (Brush iconBrush = new SolidBrush(_foreColor))
                    {
                        g.DrawString(
                            weekNumberString,
                            iconFont,
                            iconBrush,
                            image.Width / 2F - textSize.Width / 2F,
                            image.Height / 2F - textSize.Height / 2F);
                    }
                }

                g.Save();
            }

            return image;
        }

        public Icon RenderIcon(int weekNumber)
        {
            Icon icon;

            using (Bitmap iconImage = RenderBitmap(weekNumber))
            {
                icon = Icon.FromHandle(iconImage.GetHicon());
            }

            return icon;
        }
    }
}