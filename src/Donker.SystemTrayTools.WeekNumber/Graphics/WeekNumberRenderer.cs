using System.Drawing.Text;
using DrawingSurface = System.Drawing.Graphics;

namespace Donker.SystemTrayTools.WeekNumber.Graphics;

public class WeekNumberRenderer(AppSettings appSettings)
{
    private readonly Color _foreColor = appSettings.ForeColor;
    private readonly Color _backColor = appSettings.ShowBackColor ? appSettings.BackColor : Color.Transparent;
    private const string FontFamily = "Verdana";
    private const float FontSize = 12F;
    private readonly FontStyle _fontStyle = FontStyle.Bold;
    private readonly Size _iconSize = new(16, 16);

    public Bitmap RenderBitmap(int weekNumber)
    {
        string weekNumberString = weekNumber.ToString("G");

        var image = new Bitmap(_iconSize.Width, _iconSize.Height);

        using var g = DrawingSurface.FromImage(image);

        g.TextRenderingHint = TextRenderingHint.AntiAlias;

        g.Clear(_backColor);

        using var iconFont = new Font(FontFamily, FontSize, _fontStyle, GraphicsUnit.Pixel);

        SizeF textSize = g.MeasureString(weekNumberString, iconFont);

        using Brush iconBrush = new SolidBrush(_foreColor);

        g.DrawString(
            weekNumberString,
            iconFont,
            iconBrush,
            (image.Width / 2F) - (textSize.Width / 2F),
            (image.Height / 2F) - (textSize.Height / 2F));

        g.Save();

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