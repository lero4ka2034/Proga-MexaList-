using System;//Дает возможность ссылаться на классы, находящиеся в пространстве имен System.
using System.Windows.Forms;//Содержит классы для создания приложений Windows.

namespace Курсовая__Список_покупок_ //Используется для объявления области действия.
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)//Событие button2_Click
        {
            this.Close();//Закрывает эту форму
        }

        private void button1_Click(object sender, EventArgs e)//Событие button1_Click
        {
            Form4 frm = new Form4();//дает название frm для Form4 
            frm.Show();//открывает Form1
        }
    }
}
