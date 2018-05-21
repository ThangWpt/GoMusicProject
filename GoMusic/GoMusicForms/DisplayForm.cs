using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GoMusic.GoMusicForms
{
    public partial class DisplayForm : Form
    {
        public DisplayForm()
        {
            InitializeComponent();
        }
        private void DisplayForm_Load(object sender, EventArgs e)
        {
            this.ShowBaiHat();
        }
        private void ShowBaiHat()
        {
            var db = new DBGoMusicEntities();
            var list = db.BaiHats.ToList();
            this.lstSong.DataSource = list;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var form = new FormAdd();
            form.ShowDialog();
            this.ShowBaiHat();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var db = new DBGoMusicEntities();
            if (MessageBox.Show("Do you want to delete this song?", "Confirm", MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)
            {
                for (int i = 0; i < this.lstSong.SelectedRows.Count; i++)
                {
                    var row = this.lstSong.SelectedRows[i];
                    var item = (BaiHat)row.DataBoundItem;

                    try
                    {
                        BaiHat bh = db.BaiHats.Find(item.id);
                        db.BaiHats.Remove(bh);
                        db.SaveChanges(); //Do it
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
                this.ShowBaiHat();
            }
        }

        private void DisplayForm_DoubleClick(object sender, EventArgs e)
        {

        }
        

        private void lstSong_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        string[] files, paths;

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            axWindowsMediaPlayer1.URL = paths[listBox1.SelectedIndex];
        }

        private void btnOpen_MouseEnter(object sender, EventArgs e)
        {
            btnOpen.BackColor = Color.Orange;
        }

        private void btnOpen_MouseLeave(object sender, EventArgs e)
        {
            btnOpen.BackColor = Color.LightGray;
        }

      


        private void lstSong_DoubleClick(object sender, EventArgs e)
        {
            if (this.lstSong.SelectedRows.Count == 1)
            {
                var row = this.lstSong.SelectedRows[0];
                var item = (BaiHat)row.DataBoundItem;

                var form = new FormEdit(item);
                form.ShowDialog();
                this.ShowBaiHat();
            }
        }
        BaiHat s = new BaiHat();

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {

            DBGoMusicEntities db = new DBGoMusicEntities();
            lstSong.DataSource = db.BaiHats.ToList().Where(s => s.Song.ToLower().Contains(txtSearch.Text.ToLower().Trim())).ToList();

        }

        private void axWindowsMediaPlayer1_Enter(object sender, EventArgs e)
        {

        }

        private void btnOpen_Click_1(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                files = openFileDialog1.SafeFileNames;
                paths = openFileDialog1.FileNames;
                for (int i = 0; i < files.Length; i++)
                {
                    listBox1.Items.Add(files[i]);
                }
            }

        }

    }
}
