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
                fr.GetConfig();
                Hrome hr = new Hrome(folderBrowserDialog1.SelectedPath);
                hr.GetConfig();
                Yandex Ya = new Yandex(folderBrowserDialog1.SelectedPath);
                Ya.GetConfig();
                Opera Op = new Opera(folderBrowserDialog1.SelectedPath);
                Op.GetConfig();
                Сhromium Ch = new Сhromium(folderBrowserDialog1.SelectedPath);
                Ch.GetConfig();
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
                    fr.SetConfig();
                    Hrome hr = new Hrome(folderBrowserDialog1.SelectedPath);
                    hr.SetConfig();
                    Yandex Ya = new Yandex(folderBrowserDialog1.SelectedPath);
                    Ya.SetConfig();
                    Opera Op = new Opera(folderBrowserDialog1.SelectedPath);
                    Op.SetConfig();
                    Сhromium Ch = new Сhromium(folderBrowserDialog1.SelectedPath);
                    Ch.SetConfig();
                    DialogResult dialogresult;
                    dialogresult = MessageBox.Show("Настройки загружены.", "Настройки загружены.", MessageBoxButtons.OK);
                }
            }
        }
    }
}
