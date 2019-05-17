using System.Drawing;
namespace NormalChart
{
    public static class Style
    {

        public class StyleItem
        {
            public Color MainColor = ColorTranslator.FromHtml("#F1F1F1");
            public Color BackgroundColor = ColorTranslator.FromHtml("#1E1E1E");
            public float FontSize = 11f;
            public FontFamily FontStyle = new FontFamily("Times New Roman");
            public int XAxisFontAngle = 90;
        }

        public static StyleItem[] Styles =
         {
           new StyleItem
           {
             // Default black theme  
           },
           new StyleItem
           {
               BackgroundColor = Color.White,
               MainColor = Color.Black,
               FontSize = 11f,
               FontStyle = new FontFamily("Times New Roman"),
               XAxisFontAngle = 65
            }

        };
    }
}


