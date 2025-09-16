using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace APP_REQUERIMIENTOS.Convertidores
{
    class Convertcolores : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // string colorDevolver = "";
            Color colorDevolver = Colors.Transparent;
            int colorvalor = (int)value;

            switch (colorvalor)
            {
                case 1:
                    colorDevolver = Colors.Red;
                    break;
                case 2:
                    colorDevolver = Colors.Orange;
                    break;
                case 3:
                    colorDevolver = Colors.Blue;
                    break;
                case 4:
                    colorDevolver = Colors.Green;
                    break;

            }
            return colorDevolver;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }
    
}
