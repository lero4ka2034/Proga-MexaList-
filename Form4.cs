using System;//Дает возможность ссылаться на классы, находящиеся в пространстве имен System.
using System.Windows.Forms;//Содержит классы для создания приложений Windows.

namespace Курсовая__Список_покупок_ //Используется для объявления области действия.
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)//Событие pictureBox1_Click
        {
            this.Close();//Закрывает форму
        }
    }
}
