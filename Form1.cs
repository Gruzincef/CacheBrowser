using System;
using System.Windows.Forms;


namespace CacheBrowser
{
    public partial class Form1 : Form
    {
        private MenegerEvent ME = MenegerEvent.getInstance();
        public Form1()
        {
            InitializeComponent();
            MenegerEvent ME = MenegerEvent.getInstance();
            ME.Event_Messeg += new MenegerEvent.OperationDelegate(Messege);
        }
        private void Messege(string messeg)
        {
            DialogResult dialogresult;
            dialogresult = MessageBox.Show(messeg, messeg, MessageBoxButtons.OK);

        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult;
            dialogresult = MessageBox.Show("Вы уверены что хотите удалить пароли из всех браузеров?", "Вы уверены что хотите удалить пароли из всех браузеров?", MessageBoxButtons.OK);
            if (dialogresult == DialogResult.OK) {
                Threaders th = new Threaders();
                th.StartThead(DelConfig);
                }

        }
        

        private void button3_Click(object sender, EventArgs e)
        {
           
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                Threaders th = new Threaders();
                th.StartThead(GetConfig, (object)folderBrowserDialog1.SelectedPath);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            {
                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
                {

                    Threaders th = new Threaders();
                    th.StartThead(SetConfig, (object)folderBrowserDialog1.SelectedPath);
                }
            }
        }

        private void DelConfig()
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
            ME.SetEvent("Данные удалены.");
        }
        private void GetConfig(object path)
        {
            Firefox fr = new Firefox((string)path);
            fr.GetConfig();
            Hrome hr = new Hrome((string) path);
            hr.GetConfig();
            Yandex Ya = new Yandex((string)path);
            Ya.GetConfig();
            Opera Op = new Opera((string)path);
            Op.GetConfig();
            Сhromium Ch = new Сhromium((string)path);
            Ch.GetConfig();
            ME.SetEvent("Настройки сохранены.");
        }
        private void SetConfig(object path)
        {
            Firefox fr = new Firefox((string)path);
            fr.SetConfig();
            Hrome hr = new Hrome((string)path);
            hr.SetConfig();
            Yandex Ya = new Yandex((string)path);
            Ya.SetConfig();
            Opera Op = new Opera((string)path);
            Op.SetConfig();
            Сhromium Ch = new Сhromium((string)path);
            Ch.SetConfig();
            ME.SetEvent("Настройки загружены.");

        }
    }
}
