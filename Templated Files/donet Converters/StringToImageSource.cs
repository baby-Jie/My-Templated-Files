using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace FloatToolBarMini.Converters
{
    public class StringToImageSource:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            try
            {
                string path = System.IO.Path.Combine(Directory.GetCurrentDirectory(), "..\\..\\Resources\\Images", value.ToString());
                BitmapImage image = new BitmapImage(new Uri(path));
                ImageSource img = image;
                return img;
            }
            catch (Exception)
            {

                return null;
            }
           

        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
