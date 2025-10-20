using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private TextBox textBox;

        public Form1()
        {
            InitializeComponent();
            SetupUI(); // всё создаём здесь
        }
        private void Form1_Load(object sender, EventArgs e) { }
        private void SetupUI()
        {
            // Меню
            MenuStrip menuStrip = new MenuStrip();
            ToolStripMenuItem fileMenu = new ToolStripMenuItem("Файл");
            ToolStripMenuItem openItem = new ToolStripMenuItem("Открыть");
            ToolStripMenuItem saveItem = new ToolStripMenuItem("Сохранить");
            ToolStripMenuItem exitItem = new ToolStripMenuItem("Выход");

            fileMenu.DropDownItems.Add(openItem);
            fileMenu.DropDownItems.Add(saveItem);
            fileMenu.DropDownItems.Add(new ToolStripSeparator());
            fileMenu.DropDownItems.Add(exitItem);
            menuStrip.Items.Add(fileMenu);

            // Текстовое поле
            textBox = new TextBox();
            textBox.Multiline = true;
            textBox.Dock = DockStyle.Fill;
            textBox.ScrollBars = ScrollBars.Both;
            textBox.Font = new System.Drawing.Font("Consolas", 12);

            // Добавляем элементы на форму
            this.Controls.Add(textBox);
            this.Controls.Add(menuStrip);
            this.MainMenuStrip = menuStrip;

            // События
            openItem.Click += OpenFile;
            saveItem.Click += SaveFile;
            exitItem.Click += (s, e) => Application.Exit();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    textBox.Text = File.ReadAllText(ofd.FileName, Encoding.UTF8);
                }
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {
            using (SaveFileDialog sfd = new SaveFileDialog())
            {
                sfd.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
                if (sfd.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(sfd.FileName, textBox.Text, Encoding.UTF8);
                }
            }
        }
    }
}
