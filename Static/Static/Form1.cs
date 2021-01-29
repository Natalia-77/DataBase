using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Static
{
    public partial class Form1 : Form
    {
        private Random r = new Random();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Події MouseMove створюються безперервно при переміщенні курсова мишки по формі.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            //Два варіанта:зображення скаче рандомно від мишки і плавно втікає.

            //1.Нові координати задаються рандомно.Тобто зображення скаче по вікні у жовільному порядку.
            //=============================================
            //int x = r.Next(ClientSize.Width - pictureBox1.Width);
            //int y = r.Next(ClientSize.Height - pictureBox1.Height);

            //pictureBox1.Location = new Point(x, y);
            //label1.Text = $"===Coord Х:{pictureBox1.Location.X},Y{pictureBox1.Location.Y}" +
            //    $",Picture size: width:{pictureBox1.Width},height:{pictureBox1.Height}===";
            //=============================================

            //2.При наведенні курсора мишки,зображення плавно втікає від неї.Тобто не скаче.
            //Задаю "крок",на який буде стрибати наше зображення.

            int x_new = pictureBox1.Width / 10;
            int y_new = pictureBox1.Height / 10;

            //Перевірки,згідно яких будуть задані нові координати для зображення.
            //Відповідно до ширини "кроку",який прописаний вище.

            //Рух по горизонталі.
            //Якщо курсор мишки підходить зліва,то картінка втікає справо.
            if(((pictureBox1.Left+pictureBox1.Width+x_new)<(ClientSize.Width))&&e.X<pictureBox1.Width/2)
            {
                //втікає вправо по горизонталі.
                pictureBox1.Location = new Point(pictureBox1.Location.X+x_new,pictureBox1.Location.Y);
            }

            if(((pictureBox1.Left > x_new) && e.X>pictureBox1.Width/2))
            //if ((pictureBox1.Left > x_new))
            {
                //втікає вліво по горизонталі.
                pictureBox1.Location = new Point(pictureBox1.Location.X-x_new,pictureBox1.Location.Y);
            }

            //Рух по вертикалі.
            if (((pictureBox1.Top + pictureBox1.Height + y_new) < (ClientSize.Height)) && e.Y < pictureBox1.Height /2)
            {               
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y+y_new);
            }

            if (((pictureBox1.Top > y_new) && e.Y > pictureBox1.Height / 2))
            {                
                pictureBox1.Location = new Point(pictureBox1.Location.X, pictureBox1.Location.Y-y_new);
            }


        }
       

        }
}
