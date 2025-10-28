using System;
using System.IO;
using System.Text;
using System.Windows.Forms;
namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        // Объявляем диалог выбора шрифта
        private FontDialog fontDialog1;

        // Конструктор формы
        public Form1()
        {
            InitializeComponent(); // Инициализация компонентов формы
            // Создаём экземпляр диалога выбора шрифта
            fontDialog1 = new FontDialog();
        }
        // Обработчик события нажатия кнопки "Открыть файл"
        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Rich Text Format|*.rtf";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.LoadFile(ofd.FileName, RichTextBoxStreamType.RichText);
                }
                catch (Exception z)
                {
                    MessageBox.Show(z.Message);
                }
            }
        }

        // Обработчик события нажатия кнопки "Сохранить файл"
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Rich Text Format|*.rtf";
            sfd.Title = "Save File";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    richTextBox1.SaveFile(sfd.FileName, RichTextBoxStreamType.RichText);
                }
                catch (Exception z)
                {
                    MessageBox.Show(z.Message);
                }
            }
        }


        // Обработчик события нажатия кнопки "Выбрать шрифт"
        private void button3_Click(object sender, EventArgs e)
        {
            // Открываем диалог выбора шрифта
            if (fontDialog1.ShowDialog() == DialogResult.OK)
            {
                // Применяем выбранный шрифт к richTextBox1
                richTextBox1.Font = fontDialog1.Font;
            }
        }
    }
}
