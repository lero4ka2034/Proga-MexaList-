using System;//Дает возможность ссылаться на классы, находящиеся в пространстве имен System.
using System.Windows.Forms;//Содержит классы для создания приложений Windows.d

namespace Курсовая__Список_покупок_
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form3());
        }
    }
}
