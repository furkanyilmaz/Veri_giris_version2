using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
// using System.Web.WebPages;
using System.Windows.Forms;
using System.Data.SQLite;

namespace VeriGirisEkrani
{
    public partial class UI : Form
    {



        public string KayitNo { get; private set; }
        // db ile 1er 1er arttırılacak..!!!!!
        public UI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void UI_Load(object sender, EventArgs e)
        {

        }

        private void exit_button_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void yazdir_button_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(textBox1.Text)
                && String.IsNullOrEmpty(textBox1.Text)
                && String.IsNullOrEmpty(tel_no_giris.Text)
                && String.IsNullOrEmpty(il_giris.Text) 
                && String.IsNullOrEmpty(ilce_giris.Text)
                && String.IsNullOrEmpty(textBox2.Text) 
                && String.IsNullOrEmpty(textBox3.Text) 
                && String.IsNullOrEmpty(musteri_tel_no_giris.Text)
                && String.IsNullOrEmpty(musteri_il_giris.Text)&& String.IsNullOrEmpty(musteri_ilce_giris.Text))
            {
                MessageBox.Show("Tüm alanları doldurun");
            }

            //// tc numaraları dogrulama
            int toplam = 0;
            int toplam1 = 0;
            string c, d;
            string c1, d1;
            string sayi1 = tc_giris.Text;
            string sayim1 = textBox2.Text;
            string sayi2 = sayi1[sayi1.Length - 1].ToString();
            string sayim2 = sayim1[sayim1.Length - 1].ToString();


            foreach (var i in sayi1)
            {
                c = i.ToString();

                toplam = toplam + int.Parse(c);
            }

            toplam = toplam - int.Parse(sayi2);

            d = toplam.ToString();

            d = d[d.Length - 1].ToString();


            foreach (var i in sayim1)
            {
                c1 = i.ToString();

                toplam1 = toplam1 + int.Parse(c1);
            }

            toplam1 = toplam1 - int.Parse(sayim2);

            d1 = toplam1.ToString();

            d1 = d1[d1.Length - 1].ToString();

            //

            if (d == sayi2 && d1 == sayim2)
            {

                // printBarCode();
                printPreviewDialog1.ShowDialog();
                //  printDocument1.Print();
            }


            else
            {
                MessageBox.Show("Girilen Değer Bir Tc Kimlik Numarası Olamaz.");

            }


            string yol = "Data source=veri_giris_db.db";
            SQLiteConnection baglanti = new SQLiteConnection(yol);
            baglanti.Open();

            string sql = "insert into KayitTablosu" +
                "(gonderen_tcno,gonderen_adres,gonderen_telefon,gonderen_il,gonderen_ilce,alici_tcno,alici_adres,alici_telefon,alici_il,alici_ilce) " +
                "values(@gonderen_tcno,@gonderen_adres,@gonderen_telefon,@gonderen_il,@gonderen_ilce,@alici_tcno,@alici_adres,@alici_telefon,@alici_il,@alici_ilce)";

            SQLiteCommand komut = new SQLiteCommand(sql, baglanti);
            komut.Parameters.AddWithValue("@gonderen_tcno", tc_giris.Text);
            komut.Parameters.AddWithValue("@gonderen_adres", textBox1.Text);
            komut.Parameters.AddWithValue("@gonderen_telefon", tel_no_giris.Text);
            komut.Parameters.AddWithValue("@gonderen_il", il_giris.Text);
            komut.Parameters.AddWithValue("@gonderen_ilce", ilce_giris.Text);

            komut.Parameters.AddWithValue("@alici_tcno", textBox2.Text);
            komut.Parameters.AddWithValue("@alici_adres", textBox3.Text);
            komut.Parameters.AddWithValue("@alici_telefon", musteri_tel_no_giris.Text);
            komut.Parameters.AddWithValue("@alici_il", musteri_il_giris.Text);
            komut.Parameters.AddWithValue("@alici_ilce", musteri_ilce_giris.Text);

            komut.ExecuteNonQuery();
            baglanti.Dispose();
            komut.Dispose();
            MessageBox.Show("kayıt tamamlandı");


        }



        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {


            Font font = new Font("Arial", 14);
            SolidBrush firca = new SolidBrush(Color.Black);
            e.Graphics.DrawString($"Tarih = {DateTime.Now.ToString("dd.MM.yyyy HH:mm.ss")}", font, firca, 50, 25); 


            ///////////////////////////////////

            font = new Font("Arial", 11, FontStyle.Regular);
            e.Graphics.DrawString("Kayıt No: ", font, firca, 100, 70);
            //kayıt no: 



            e.Graphics.DrawString("Tc No: ", font, firca, 100, 150);
            e.Graphics.DrawString(tc_giris.Text, font, firca, 200, 150);

            e.Graphics.DrawString("Adres: ", font, firca, 100, 230);
            e.Graphics.DrawString(textBox1.Text, font, firca, 200, 230);


            e.Graphics.DrawString("Müşteri Tc No: ", font, firca, 100, 350);
            e.Graphics.DrawString(textBox2.Text, font, firca, 210, 350);

            e.Graphics.DrawString("Müşteri Adresi: ", font, firca, 100, 430);
            e.Graphics.DrawString(textBox3.Text, font, firca, 210, 430);
            //////

            e.Graphics.DrawString("Telefon No: ", font, firca, 450, 150);
            e.Graphics.DrawString(tel_no_giris.Text, font, firca, 550, 150);

            e.Graphics.DrawString("İl: ", font, firca, 450, 200);
            e.Graphics.DrawString(il_giris.Text, font, firca, 550, 200);

            e.Graphics.DrawString("İlçe: ", font, firca, 450, 250);
            e.Graphics.DrawString(ilce_giris.Text, font, firca, 550, 250);

            e.Graphics.DrawString("Posta Kodu: ", font, firca, 450, 300);


            e.Graphics.DrawString("Müşteri Tel No: ", font, firca, 450, 350);
            e.Graphics.DrawString(musteri_tel_no_giris.Text, font, firca, 560, 350);

            e.Graphics.DrawString("Müşteri İl: ", font, firca, 450, 400);
            e.Graphics.DrawString(musteri_il_giris.Text, font, firca, 550, 400);

            e.Graphics.DrawString("Müşteri ilçe: ", font, firca, 450, 450);
            e.Graphics.DrawString(musteri_ilce_giris.Text, font, firca, 550, 450);

            e.Graphics.DrawString("Müşteri Posta Kodu: ", font, firca, 450, 500);

            //QrCode
            e.Graphics.DrawString("Qr Kod: ", font, firca, 450, 550);
            e.Graphics.DrawImage(pictureBox1.Image, 550, 600);


        }

        private void tc_giris_TextChanged(object sender, EventArgs e)
        {
            
            string rakam = tc_giris.Text;
            if (rakam.Length < 11)
            {
                errorProvider1.SetError(tc_giris, "11 rakam giriniz");
            }
            else
            {
                errorProvider1.SetError(tc_giris, "");
            }

        }



        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string metin = textBox1.Text;
            if (metin.Length < 10)
            {
                errorProvider2.SetError(textBox1, "adres çok kısa");
            }
            else
            {
                errorProvider2.SetError(textBox1, "");
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            string rakam = textBox2.Text;
            if (rakam.Length < 11)
            {
                errorProvider3.SetError(textBox2, "11 rakam giriniz");
            }
            else
            {
                errorProvider3.SetError(textBox2, "");
            }

        }

        private void textBox_TextChanged(object sender, EventArgs e)
        {
            string metin = textBox3.Text;
            if (metin.Length < 10)
            {
                errorProvider4.SetError(textBox3, "adres çok kısa");
            }
            else
            {
                errorProvider4.SetError(textBox3, "");
            }
        }

        private void tel_no_giris_TextChanged(object sender, EventArgs e)
        {
            string rakam = tel_no_giris.Text;
            if (rakam.Length < 11)
            {
                errorProvider5.SetError(tel_no_giris, "11 rakam giriniz");

            }
            else
            {
                errorProvider5.SetError(tel_no_giris, "");

            }
        }

        private void il_giris_TextChanged(object sender, EventArgs e)
        {
            string metin = il_giris.Text;
            if (metin.Length < 2)
            {
                errorProvider6.SetError(il_giris, "il giriniz");
            }
            else
            {
                errorProvider6.SetError(il_giris, "");
            }
        }

        private void ilce_giris_TextChanged(object sender, EventArgs e)
        {
            string metin = ilce_giris.Text;
            if (metin.Length < 2)
            {
                errorProvider7.SetError(ilce_giris, "ilçe giriniz");
            }
            else
            {
                errorProvider7.SetError(ilce_giris, "");
            }

        }

        private void musteri_tel_no_giris_TextChanged(object sender, EventArgs e)
        {
            string metin = musteri_tel_no.Text;
            if (metin.Length < 11)
            {
                errorProvider8.SetError(musteri_tel_no, "11 rakam giriniz");
            }
            else
            {
                errorProvider8.SetError(musteri_tel_no, "");
            }

        }

        private void musteri_il_giris_TextChanged(object sender, EventArgs e)
        {
            string metin = musteri_il_giris.Text;
            if (metin.Length < 2)
            {
                errorProvider9.SetError(musteri_il_giris, "il giriniz");
            }
            else
            {
                errorProvider9.SetError(musteri_il_giris, "");
            }
        }

        private void musteri_ilce_giris_TextChanged(object sender, EventArgs e)
        {
            string metin = musteri_ilce_giris.Text;
            if (metin.Length < 2)
            {
                errorProvider10.SetError(musteri_ilce_giris, "ilçe giriniz");
            }
            else
            {
                errorProvider10.SetError(musteri_ilce_giris, "");
            }
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            // PaperSize CustomSize1 = new PaperSize("Benim sayfam", 250, 100);
        }

        private void barcode_button_Click(object sender, EventArgs e)
        {
            Zen.Barcode.CodeQrBarcodeDraw brc = Zen.Barcode.BarcodeDrawFactory.CodeQr;
            pictureBox1.Image = brc.Draw(txtBarcode.Text, 25);

        }

        private void printBarCode()
        {
            PrintDialog pd = new PrintDialog();
            PrintDocument doc = new PrintDocument();
            doc.PrintPage += doc_PrintPage;
            pd.Document = doc;
            if (pd.ShowDialog() == DialogResult.OK)
            {
                doc.Print();
            }
        }

        private void doc_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(bm, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            bm.Dispose();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        // Keyboard key;
        private void UI_MouseClick_1(object sender, EventArgs e)
        {
            // System.Diagnostics.Process.Start("");




            //if (key == null || key.IsDisposed)
            //{
            //    key = new Keyboard();
            //    key.Show();
            //}
        }

        ///keyboard Design //////////////////////////

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams param = base.CreateParams;
                param.ExStyle |= 0X08000000;
                return param;

            }
        }

        private void enter_Click_1(object sender, EventArgs e)      // ENTER
        {
            this.AcceptButton = this.enter;
        }
        private void back_space_Click_1(object sender, EventArgs e) //BACKSPACE
        {
            if ((string.IsNullOrEmpty(tc_giris.Text)))
            {
                
            }
            else
            {
                tc_giris.Text = tc_giris.Text.Remove(tc_giris.Text.Length - 1, 1);    /// textbox boş iken hatalı..
            }

        }

        private void letterQ_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("Q");
            tc_giris.Text += "Q";
        }

        private void letterW_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("W");
            tc_giris.Text += "W";
        }

        private void letterE_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("E");
            tc_giris.Text += "E";
        }

        private void lettterR_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("R");
            tc_giris.Text += "R";
        }

        private void lettterT_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("T");
            tc_giris.Text += "T";
        }

        private void lettterY_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("Y");
            tc_giris.Text += "Y";
        }

        private void lettterU_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("U");
            tc_giris.Text += "U";
        }

        private void lettterI_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("I");
            tc_giris.Text += "I";
        }

        private void lettterO_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("O");
            tc_giris.Text += "O";
        }

        private void lettterP_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("P");
            tc_giris.Text += "P";
        }

        private void lettterG2_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("Ğ");
            tc_giris.Text += "Ğ";
        }

        private void lettterU2_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("Ü");
            tc_giris.Text += "Ü";
        }

        private void lettterA_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("A");
            tc_giris.Text += "A";
        }

        private void letterS_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("S");
            tc_giris.Text += "S";
        }

        private void lettterD_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("D");
            tc_giris.Text += "D";
        }

        private void lettterF_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("F");
            tc_giris.Text += "F";
        }

        private void lettterG_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("G");
            tc_giris.Text += "G";
        }

        private void lettterH_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("H");
            tc_giris.Text += "H";
        }

        private void lettterJ_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("J");
            tc_giris.Text += "J";
        }

        private void lettterK_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("K");
            tc_giris.Text += "K";
        }

        private void lettterL_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("L");
            tc_giris.Text += "L";
        }

        private void lettterS2_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("Ş");
            tc_giris.Text += "Ş";
        }

        private void lettter_i_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("İ");
            tc_giris.Text += "İ";
        }

        private void letterZ_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("Z");
            tc_giris.Text += "Z";
        }

        private void letterX_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("X");
            tc_giris.Text += "X";
        }

        private void letterC_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("C");
            tc_giris.Text += "C";
        }

        private void letterV_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("V");
            tc_giris.Text += "V";
        }

        private void letterB_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("B");
            tc_giris.Text += "B";
        }

        private void letterN_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("N");
            tc_giris.Text += "N";
        }

        private void letterM_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("M");
            tc_giris.Text += "M";
        }

        private void letterO2_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("Ö");
            tc_giris.Text += "Ö";
        }

        private void letterC2_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("Ç");
            tc_giris.Text += "Ç";
        }

        private void space_button_Click_1(object sender, EventArgs e)
        {
            tc_giris.Text += " ";
        }

        private void number0_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("0");
            tc_giris.Text += "0";
        }

        private void number1_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("1");
            tc_giris.Text += "1";
        }

        private void number2_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("2");
            tc_giris.Text += "2";
        }

        private void number3_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("3");
            tc_giris.Text += "3";
        }

        private void number4_Click_1(object sender, EventArgs e)
        {
            //SendKeys.Send("4");
            tc_giris.Text += "4";
        }

        private void number5_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("5");
            tc_giris.Text += "5";
        }

        private void number6_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("6");
            tc_giris.Text += "6";
        }

        private void number7_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("7");
            tc_giris.Text += "7";
        }

        private void number8_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("8");
            tc_giris.Text += "8";

        }

        private void number9_Click_1(object sender, EventArgs e)
        {
            // SendKeys.Send("9");
            tc_giris.Text += "9";
        }

        private void left_button_Click(object sender, EventArgs e)
        {

        }

        private void right_button_Click(object sender, EventArgs e)
        {
            tc_giris.Text += " ";
        }

                                                                    /// KEYPRESS ---------------------------------------------------------------
        private void tc_giris_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        

        private void il_giris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void ilce_giris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void musteri_il_giris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void musteri_ilce_giris_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tel_no_giris_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void musteri_tel_no_giris_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

      
  

                                                                    /// KEYDOWN-------------------------------------------------------
        private void tc_giris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox1;      // textBox1.Focus();
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = tel_no_giris;         // tel_no_giris.Focus();     
            }
        }

        private void tel_no_giris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = il_giris;              // il_giris.Focus();
            }
        }

        private void il_giris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = ilce_giris;            // ilce_giris.Focus();
            }
        }

        private void ilce_giris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox2;              // textBox2.Focus();
            }
        }

        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = textBox3;              // textBox3.Focus();
            }
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = musteri_tel_no_giris;      // musteri_tel_no_giris.Focus();
            }
        }

        private void musteri_tel_no_giris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = musteri_il_giris;          // musteri_il_giris.Focus();
            }
        }

        private void musteri_il_giris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = musteri_ilce_giris;        // musteri_ilce_giris.Focus();
            }
        }

        private void musteri_ilce_giris_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ActiveControl = yazdir_button;                 // yazdir_button.Focus();
            }
        }


    }
}




