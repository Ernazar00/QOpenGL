using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        MyImage sourse;
        MyImage target;
        private void Form1_Load(object sender, EventArgs e)
        {
            //pictureBox1.Image = new Bitmap(@"C:\Users\User\Desktop\Items\C_Graphics\OriginalFiles\Podoshian.JPG");
        }
        private void OpenImage1Btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try 
                {
                    pictureBox1.Image = new Bitmap(openFileDialog1.FileName);
                    sourse = new MyImage(openFileDialog1.FileName);
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);    
                }
            }
        }
        private void OpenImage2Btn_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    target = new MyImage(openFileDialog1.FileName);
                    pictureBox2.Image = target.bitmap;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void ConvertBtn_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox3.Image = Convertor.resultBMP(sourse, target);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message+"\n"+ex.StackTrace);
            }
        }
    }
}