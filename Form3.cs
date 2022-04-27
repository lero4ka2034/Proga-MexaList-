using System;//Дает возможность ссылаться на классы, находящиеся в пространстве имен System.
using System.Windows.Forms;//Содержит классы для создания приложений Windows.

namespace Курсовая__Список_покупок_ //Используется для объявления области действия.
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)//Событие Form3
        {
            timer1.Interval = 3000;//Задаёт интервал таймеру в милиисекундах
            timer1.Enabled = true; //Начинает отчёт таймера
        }
        private void Timer1_Tick(object sender, EventArgs e)//Событие timer1
        {
            timer1.Enabled = false; //Заканчивает отчёт таймер
            Form1 frm = new Form1(); //дает название frm для Form1  
            this.Hide();//скрывает эту форму
            frm.Show();//открывает Form1
        }

    }
}
