using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Подключаем обработчики вручную
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;
        }
        // Добавление задачи
        private void button1_Click(object sender, EventArgs e)
        {
            string task = textBox1.Text.Trim();
            if (!string.IsNullOrEmpty(task))
            {
                listBox1.Items.Add("☐ " + task);
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Введите текст задачи!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // Удаление выбранной задачи
        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            }
            else
            {
                MessageBox.Show("Выберите задачу для удаления.", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Отметить как выполненную
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex != -1)
            {
                string selected = listBox1.SelectedItem.ToString();
                if (selected.StartsWith("☐"))
                {
                    listBox1.Items[listBox1.SelectedIndex] = selected.Replace("☐", "☑");
                }
                else if (selected.StartsWith("☑"))
                {
                    listBox1.Items[listBox1.SelectedIndex] = selected.Replace("☑", "☐");
                }
            }
            else
            {
                MessageBox.Show("Выберите задачу для изменения статуса.", "Подсказка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
