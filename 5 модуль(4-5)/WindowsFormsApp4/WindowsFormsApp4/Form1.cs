using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        private Image originalImage;
        private float zoom = 1.0f; // коэффициент масштабирования
        private Button btnOpen;
        private TrackBar zoomBar;

        public Form1()
        {
            this.Text = "Простой просмотрщик изображений";
            this.Width = 800;
            this.Height = 600;
            this.DoubleBuffered = true; // убираем мерцание

            // Кнопка "Открыть"
            btnOpen = new Button();
            btnOpen.Text = "Открыть изображение";
            btnOpen.Left = 10;
            btnOpen.Top = 10;
            btnOpen.Click += BtnOpen_Click;
            this.Controls.Add(btnOpen);

            // Ползунок зума
            zoomBar = new TrackBar();
            zoomBar.Minimum = 1;
            zoomBar.Maximum = 20;
            zoomBar.Value = 10;
            zoomBar.TickFrequency = 1;
            zoomBar.Left = 180;
            zoomBar.Width = 200;
            zoomBar.Top = 10;
            zoomBar.Scroll += ZoomBar_Scroll;
            this.Controls.Add(zoomBar);

            this.Paint += Form1_Paint;
        }

        private void BtnOpen_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.Filter = "Изображения|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    originalImage = Image.FromFile(ofd.FileName);
                    this.Invalidate(); // перерисовать окно
                }
            }
        }

        private void ZoomBar_Scroll(object sender, EventArgs e)
        {
            zoom = zoomBar.Value / 10f;
            this.Invalidate(); // обновить изображение
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            if (originalImage == null) return;

            int newWidth = (int)(originalImage.Width * zoom);
            int newHeight = (int)(originalImage.Height * zoom);

            // Рисуем изображение по центру окна
            int x = (this.ClientSize.Width - newWidth) / 2;
            int y = (this.ClientSize.Height - newHeight) / 2;

            e.Graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
            e.Graphics.DrawImage(originalImage, x, y, newWidth, newHeight);
        }
             private void Form1_Load(object sender, EventArgs e)
        {

        }
    } 
}

