using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZeinAkrobbi_Praktikum7
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxData.Items.Clear();
            listBoxData.Items.Add("Data : \n");
            int tanggal = 1;
            string[] bulan;
            bulan = new string[]
            {
                "Januari","Februari","Maret","April","Mei","Juni","Juli","Agustus","September","Oktober","November","Desember"
            };
            for (tanggal = 1; tanggal <= 31; tanggal++)
            {
                comboBoxTanggal.Items.Add(tanggal);
            }
            for (int i = 0; i < bulan.Length; i++)
            {
                comboBoxBulan.Items.Add(bulan[i]);
            }
            for (int i = 2000; i <= 2021; i++)
            {
                comboBoxTahun.Items.Add(i);
            }

        }

        private void TambahData_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(textBoxNama.Text) && String.IsNullOrEmpty(textBoxUsia.Text))
            {
                MessageBox.Show("Nama dan Usia Tidak Boleh Kosong", "Peringatan");
                textBoxNama.Focus();
            }
            if (String.IsNullOrEmpty(comboBoxTanggal.Text) && String.IsNullOrEmpty(comboBoxBulan.Text) && String.IsNullOrEmpty(comboBoxTahun.Text))
            {
                MessageBox.Show("Tanggal Lahir Tidak Boleh Kosong", "Peringatan");
                comboBoxTanggal.Focus();
            }
            else if (String.IsNullOrEmpty(textBoxNama.Text))
            {
                MessageBox.Show("Nama Tidak Boleh Kosong", "Peringatan");
                textBoxNama.Focus();
            }
            else if (String.IsNullOrEmpty(textBoxUsia.Text))
            {
                MessageBox.Show("Usia Tidak Boleh Kosong", "Peringatan");
                textBoxUsia.Focus();
            }
            else
            {

                String tanggalLahir = " " + comboBoxTanggal.GetItemText(comboBoxTanggal.SelectedItem) + "-" + comboBoxBulan.GetItemText(comboBoxBulan.SelectedItem) + "-" +
                    comboBoxTahun.GetItemText(comboBoxTahun.SelectedItem);
                String dataPasien = textBoxNama.Text + tanggalLahir + " /" + textBoxUsia.Text + "th ";

                if (RB_L.Checked == true) { dataPasien += "(" + RB_L.Text + ")" + " Riwayat : "; }
                if (RB_P.Checked == true) { dataPasien += "(" + RB_P.Text + ")" + " Riwayat : "; }

                if (checkBoxMagg.Checked == true) { dataPasien += checkBoxMagg.Text + "; "; }
                if (checkBoxJantung.Checked == true) { dataPasien += checkBoxJantung.Text + "; "; }
                if (checkBoxDiabetes.Checked == true) { dataPasien += checkBoxDiabetes.Text + "; "; }
                if (checkBoxTifus.Checked == true) { dataPasien += checkBoxTifus.Text + "; "; }
                if (checkBoxDarahRendah.Checked == true) { dataPasien += checkBoxDarahRendah.Text + "; "; }
                if (checkBoxDarahTinggi.Checked == true) { dataPasien += checkBoxDarahTinggi.Text + "; "; }
                if (checkBoxAsamUrat.Checked == true) { dataPasien += checkBoxAsamUrat.Text + "; "; }
                if (checkBoxAsma.Checked == true) { dataPasien += checkBoxAsma.Text + "; "; }

                listBoxData.Items.Add(dataPasien);
            }
        }

        private void textBoxNama_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsWhiteSpace(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void textBoxUsia_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
            {
                e.Handled = Enabled;
            }
        }

        private void ResetData_Click(object sender, EventArgs e)
        {
        
        }

        private void comboBoxTanggal_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBoxBulan_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBoxTahun_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void comboBoxTahun_TextChanged(object sender, EventArgs e)
        {

            if (!String.IsNullOrEmpty(comboBoxTahun.GetItemText(comboBoxTahun.SelectedItem)))
            {
                int usia = Int16.Parse(comboBoxTahun.GetItemText(comboBoxTahun.SelectedItem));
                int jumlahUsia = 2022 - usia;
                int getTanggal = DateTime.Today.Day;
                int getBulan = DateTime.Now.Month;
                if ((comboBoxTanggal.SelectedIndex + 1) > getTanggal && (comboBoxBulan.SelectedIndex + 1) == getBulan)
                {
                    jumlahUsia = jumlahUsia - 1;
                    textBoxUsia.Text = jumlahUsia.ToString();
                }
                else if ((comboBoxBulan.SelectedIndex + 1) > getBulan)
                {
                    jumlahUsia = jumlahUsia - 1;
                    textBoxUsia.Text = jumlahUsia.ToString();
                }
                else
                {
                    textBoxUsia.Text = jumlahUsia.ToString();
                }
            }
        }

        private void ResetData_Click_1(object sender, EventArgs e)
        {
            listBoxData.Items.Clear();
            listBoxData.Items.Add("Data : \n");
        }
    }
}
