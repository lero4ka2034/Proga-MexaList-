using System;//Дает возможность ссылаться на классы, находящиеся в пространстве имен System.
using System.Collections.Generic;//Содержит интерфейсы и классы, что позволяет пользователям создавать типизированные коллекции.
using System.Drawing;//Доступ к основным графическим функция GDI(улучшеная среда для 2D-графики)
using System.IO;//Позволяет читать и записывать файлы и потоки данных.
using System.Windows.Forms;//Содержит классы для создания приложений Windows.

namespace Курсовая__Список_покупок_ //Используется для объявления кода программного продукта
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Point dvig; //Необходим для передвижения формы при нажатии по label6 и удержании
        class Mexa //Создание класса Меха для переменных:tovar, cena, koli4.
        {
            private string tovar;
            private int cena;
            private int koli4;

            public Mexa(string tovar, int cena, int koli4)
            {
                this.tovar = tovar;
                this.cena = cena;
                this.koli4 = koli4;
            }

            public string Tovar { get => tovar; set => tovar = value; }
            public int Cena { get => cena; set => cena = value; }
            public int Koli4 { get => koli4; set => koli4 = value; }
        }
        List<Mexa> mexaList = new List<Mexa>();//Создание нового списка

        private void Button1_Click(object sender, EventArgs e) //Кнопка добавить
        {

            int tmpCena;
            bool cenaOK = int.TryParse(maskedTextBox1.Text.Trim(), out tmpCena);//Происходит проверка, ввел ли пользователь число и присваивает это значение в int tmpCena
            int tmpKoli4;
            bool koli4OK = int.TryParse(maskedTextBox2.Text.Trim(), out tmpKoli4);//Происходит проверка, ввел ли пользователь число и присваивает это значение в int tmpKoli4

            if (textBox1.Text.Length > 0 && cenaOK && koli4OK)//Проверяет, если длина текста больше 0 в textBox1 и введено число в cenaOK с koli4OK
            {
                Mexa newMexa = new Mexa(textBox1.Text, tmpCena, tmpKoli4); 
                mexaList.Add(newMexa);//Добавляет новый элемент в список
                ListPrint(mexaList);
                textBox1.Clear();
                maskedTextBox1.Clear();
                maskedTextBox2.Clear();
                SumCount(mexaList);
            }
        }
        int ListPrint(List<Mexa> listToPrint)//метод добавляет через цикл все элементы в listbox1
        {
            listBox1.Items.Clear();//чистит список и по новой выводит элементы
            foreach (Mexa food in listToPrint)
            {
                listBox1.Items.Add(food.Tovar + " " + food.Cena.ToString() + " руб." + food.Koli4.ToString() + "шт.");
            }
            return listToPrint.Count;
        }
        private void Button2_Click(object sender, EventArgs e) //Удаляет элемент из listbox1
        {
            if (listBox1.SelectedIndex != -1)//если выбраный элемент не равен -1, удаляет его из списка и выводит все элементы заного и делает перерасчет
            {
                mexaList.RemoveAt(listBox1.SelectedIndex);
                ListPrint(mexaList);
                SumCount(mexaList);
            }
        }

        private void Button3_Click(object sender, EventArgs e) //Изменить эелмент в listbox1
        {
            if (listBox1.SelectedIndex != -1) //если выбраный элемент не равен -1, меняет название, цену и количество в textBox1,maskedTextBox1, maskedTextBox2 и выводит все элементы заного и делает перерасчет
            {
                mexaList[listBox1.SelectedIndex].Tovar = textBox1.Text;
                mexaList[listBox1.SelectedIndex].Cena = int.Parse(maskedTextBox1.Text);
                mexaList[listBox1.SelectedIndex].Koli4 = int.Parse(maskedTextBox2.Text);
                ListPrint(mexaList);
                SumCount(mexaList);
            }
        }
        void SumCount(List<Mexa> mexaToSum)//Считает сумму всех элементов списка
        {
            int sum = 0;
            foreach (Mexa mexa in mexaToSum)
            {
                sum += mexa.Cena * mexa.Koli4;
            }
            label5.Text = "Итоговая стоимость: " + sum.ToString();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e) //Лист
        {
            if (listBox1.SelectedIndex != -1) //если выбраный элемент не равен -1, помещает значения выбранного элемента отображается в каждом из своих полей
            {
                textBox1.Text = mexaList[listBox1.SelectedIndex].Tovar;
                maskedTextBox1.Text = mexaList[listBox1.SelectedIndex].Cena.ToString();
                maskedTextBox2.Text = mexaList[listBox1.SelectedIndex].Koli4.ToString();
            }
        }

        private void MaskedTextBox1_Click(object sender, EventArgs e)
        {
            maskedTextBox1.SelectAll();//выделяет все элементы в maskedTextBox1
        }

        private void MaskedTextBox2_Click(object sender, EventArgs e)
        {
            maskedTextBox2.SelectAll();//выделяет все элементы в maskedTextBox2
        }

        private void ToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            Form2 frm2 = new Form2();//создается экземпляр класса Form2
            frm2.ShowDialog();//открывает Form2 
        }

        private void ToolStripMenuItem3_Click(object sender, EventArgs e)//Сохраняет всё содержимое в текстовый файл Spisok.txt из mexaList через цикл
        {
            String tmp = "";
            foreach (Mexa mexa in mexaList)
            {
                tmp += mexa.Tovar + ";" + mexa.Cena.ToString() + ";" + mexa.Koli4.ToString() + "\n";
            }
            File.WriteAllText("Spisok.txt", tmp);
        }

        private void ToolStripMenuItem4_Click(object sender, EventArgs e)//Загружает всё содержимое из текстового файла Spisok.txt в mexaList и выводит в listbox1
        {
            string[] readText = File.ReadAllLines("Spisok.txt");
            mexaList.Clear();
            for (int i = 0; i < readText.Length; i++)
            {
                string[] tmp = readText[i].Split(';');
                Mexa readMexa = new Mexa(tmp[0], int.Parse(tmp[1]), int.Parse(tmp[2]));
                mexaList.Add(readMexa);
                ListPrint(mexaList);
                SumCount(mexaList);
            }
        }

        private void Label6_MouseMove(object sender, MouseEventArgs e)//отвечает за движение формы
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - dvig.X;
                this.Top += e.Y - dvig.Y;
            }
        }

        private void Label6_MouseDown(object sender, MouseEventArgs e)//исходя из положения мышки
        {
            dvig = new Point(e.X, e.Y);
        }

        private void Label7_Click(object sender, EventArgs e)//При нажатии закрывает эту форму
        {
            this.Close();
        }

        private void Label7_MouseMove(object sender, MouseEventArgs e)//Меняет цвет на красный при наведении курсора на label7 
        {
            label7.ForeColor = Color.Red;
        }

        private void Label7_MouseLeave(object sender, EventArgs e)//Меняет цвет на черный при наведении курсора на label7 
        {
            label7.ForeColor = Color.Black;
        }

        private void Label8_Click(object sender, EventArgs e)//При нажатии сворачивает эту форму
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void label8_MouseMove(object sender, MouseEventArgs e)//Меняет цвет на красный при наведении курсора на label8 
        {
            label8.ForeColor = Color.Red;
        }

        private void label8_MouseLeave(object sender, EventArgs e)//Меняет цвет на черный при наведении курсора на label8
        {
            label8.ForeColor = Color.Black;
        }
    }
}
