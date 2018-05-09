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
    public partial class FormEdit : Form
    {
        public FormEdit(BaiHat bh)
        {
            //InitializeComponent();
            //this.Load += new EventHandler(FormEdit_Load);
            //this.btnSave_
        }
        private BaiHat bh;

        private void FormEdit_Load(object sender, EventArgs e)
        {
            this.txtName.Text = this.bh.Song;
            this.txtSinger.Text = this.bh.Singer;
            this.txtWriter.Text = this.bh.Songwriter;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                var db = new DBGoMusicEntities();
                var updatE = db.BaiHats.Find(this.bh.id);
                updatE.Song = this.txtName.Text;
                updatE.Singer = this.txtSinger.Text;
                updatE.Songwriter = this.txtWriter.Text;
                db.Entry(updatE).State = System.Data.Entity.EntityState.Modified;
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
