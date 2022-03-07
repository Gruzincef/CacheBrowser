﻿using System;
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
                WindowsProxy Pr = new WindowsProxy(folderBrowserDialog1.SelectedPath);
                Pr.GetProxi();
                Firefox fr = new Firefox(folderBrowserDialog1.SelectedPath);
                fr.ImportData();
                Hrome hr = new Hrome(folderBrowserDialog1.SelectedPath);
                hr.ImportData();
                Yandex Ya = new Yandex(folderBrowserDialog1.SelectedPath);
                Ya.ImportData();
                Opera Op = new Opera(folderBrowserDialog1.SelectedPath);
                Op.ImportData();
                Сhromium Ch = new Сhromium(folderBrowserDialog1.SelectedPath);
                Ch.ImportData();
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
                    fr.ExportData();
                    Hrome hr = new Hrome(folderBrowserDialog1.SelectedPath);
                    hr.ExportData();
                    Yandex Ya = new Yandex(folderBrowserDialog1.SelectedPath);
                    Ya.ExportData();
                    Opera Op = new Opera(folderBrowserDialog1.SelectedPath);
                    Op.ExportData();
                    Сhromium Ch = new Сhromium(folderBrowserDialog1.SelectedPath);
                    Ch.ExportData();
                    DialogResult dialogresult;
                    dialogresult = MessageBox.Show("Настройки загружены.", "Настройки загружены.", MessageBoxButtons.OK);
                }
            }
        }
    }
}
