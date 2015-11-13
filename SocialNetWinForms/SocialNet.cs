using System;
using System.Windows.Forms;

namespace SocialNetWinForms
{
    public partial class SocialNet : Form
    {
        public SocialNet()
        {
            this.InitializeComponent();
        }

        private void SocialNet_Load(object sender, EventArgs e)
        {
            this.actualiserToolStripMenuItem_Click(sender, e);
            this.toolStripStatusLabel1.Text = "Chargement effectué avec succès.";
        }

        private void SocialNet_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.sauvegarderToolStripMenuItem_Click(sender, e);
        }

        private void sauvegarderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter.Update(this.socialNetDataSet.Categories);
            this.usersTableAdapter.Update(this.socialNetDataSet.Users);
            this.eventsTableAdapter.Update(this.socialNetDataSet.Events);
            this.toolStripStatusLabel1.Text = "Sauvegarde effectuée avec succès.";
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void actualiserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.categoriesTableAdapter.Fill(this.socialNetDataSet.Categories);
            this.usersTableAdapter.Fill(this.socialNetDataSet.Users);
            this.eventsTableAdapter.Fill(this.socialNetDataSet.Events);
            this.toolStripStatusLabel1.Text = "Actualisation effectuée avec succès.";
        }
    }
}