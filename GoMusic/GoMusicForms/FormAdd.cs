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
    public partial class FormAdd : Form
    {
        public FormAdd()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            BaiHat bh = new BaiHat();
            bh.Song = this.txtName.Text;
            bh.Singer = this.txtSinger.Text;
            bh.Songwriter = this.txtWriter.Text;
            bh.Album = this.txtAlbum.Text;
            try
            {
                var db = new DBGoMusicEntities();
                db.BaiHats.Add(bh);
                db.SaveChanges();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
