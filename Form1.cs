using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WorkBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Firefox fr = new Firefox();
            fr.DeleteData();
            Hrome hr = new Hrome();
            hr.DeleteData();
            Yandex Ya = new Yandex();
            Ya.DeleteData();
            Opera Op = new Opera();
            Op.DeleteData();
            Сhromium Ch = new Сhromium();
            Ch.DeleteData();
            DialogResult dialogresult;
            dialogresult = MessageBox.Show("Данные удалены.", "Данные удалены.", MessageBoxButtons.OK);
          
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Firefox fr = new Firefox(folderBrowserDialog1.SelectedPath);
                fr.UnloadConfig();
                Hrome hr = new Hrome(folderBrowserDialog1.SelectedPath);
                hr.UnloadConfig();
                Yandex Ya = new Yandex(folderBrowserDialog1.SelectedPath);
                Ya.UnloadConfig();
                Opera Op = new Opera(folderBrowserDialog1.SelectedPath);
                Op.UnloadConfig();
                Сhromium Ch = new Сhromium(folderBrowserDialog1.SelectedPath);
                Ch.UnloadConfig();
                DialogResult dialogresult;
                dialogresult = MessageBox.Show("Настройки сохранены.", "Настройки сохранены.", MessageBoxButtons.OK);
            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {

                    Firefox fr = new Firefox(folderBrowserDialog1.SelectedPath);
                    fr.LoadConfig();
                    Hrome hr = new Hrome(folderBrowserDialog1.SelectedPath);
                    hr.LoadConfig();
                    Yandex Ya = new Yandex(folderBrowserDialog1.SelectedPath);
                    Ya.LoadConfig();
                    Opera Op = new Opera(folderBrowserDialog1.SelectedPath);
                    Op.LoadConfig();
                    Сhromium Ch = new Сhromium(folderBrowserDialog1.SelectedPath);
                    Ch.LoadConfig();
                    DialogResult dialogresult;
                    dialogresult = MessageBox.Show("Настройки загружены.", "Настройки загружены.", MessageBoxButtons.OK);
                }
            }
        }
    }
}
