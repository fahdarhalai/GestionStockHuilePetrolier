using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HuileWinForm
{
    public partial class Gestionnaire : Form
    {
        ArrayList T = new ArrayList();
        
        public Gestionnaire()
        {
            InitializeComponent();

            buttonLister.Controls.Add(pictureBox1);
            pictureBox1.Location = new Point(12, 0);
            pictureBox1.BackColor = Color.Transparent;

            buttonSaisir.Controls.Add(pictureBox2);
            pictureBox2.Location = new Point(12, 0);
            pictureBox2.BackColor = Color.Transparent;

            buttonSupprimer.Controls.Add(pictureBox3);
            pictureBox3.Location = new Point(12, 0);
            pictureBox3.BackColor = Color.Transparent;

            buttonTrier.Controls.Add(pictureBox4);
            pictureBox4.Location = new Point(12, 0);
            pictureBox4.BackColor = Color.Transparent;

            buttonSauvegarder.Controls.Add(pictureBox5);
            pictureBox5.Location = new Point(12, 0);
            pictureBox5.BackColor = Color.Transparent;

            buttonRestaurer.Controls.Add(pictureBox6);
            pictureBox6.Location = new Point(12, 0);
            pictureBox6.BackColor = Color.Transparent;

            buttonStockRepture.Controls.Add(pictureBox7);
            pictureBox7.Location = new Point(12, 0);
            pictureBox7.BackColor = Color.Transparent;

            buttonReduction40.Controls.Add(pictureBox8);
            pictureBox8.Location = new Point(12, 0);
            pictureBox8.BackColor = Color.Transparent;

            lister(T);
        }

        private void buttonRetourner_Click(object sender, EventArgs e)
        {
            Acceuil acceuil = new Acceuil();
            acceuil.Location = this.Location;
            acceuil.StartPosition = FormStartPosition.Manual;
            acceuil.FormClosing += delegate { this.Show(); };
            acceuil.Show();
            this.Hide();
            acceuil.Closed += (s, args) => this.Close();
        }

        private void lister(ArrayList huiles)
        {
            dataGridView.Rows.Clear();

            foreach (Huile h in huiles)
            {
                this.dataGridView.Rows.Add(h.Nom, h.Petrolier, h.VF, h.VC, h.Prix, h.Stock);
            }
        }

        private void buttonLister_Click(object sender, EventArgs e)
        {
            lister(T);

            this.labelLister.Visible = true;
            this.labelMaxVC.Visible = false;
            this.labelMaxVF.Visible = false;
            this.labelMaxViscosite.Visible = false;
            this.labelStockRepture.Visible = false;
            this.labelStockReduction.Visible = false;
            this.panelTable.Visible = true;
            this.panelSaisie.Visible = false;
            this.panelSuppression.Visible = false;
        }

        private void buttonSaisir_Click(object sender, EventArgs e)
        {
            this.panelTable.Visible = false;
            this.panelSaisie.Visible = true;
            this.panelSuppression.Visible = false;
        }

        private void buttonSupprimer_Click(object sender, EventArgs e)
        {
            this.panelTable.Visible = false;
            this.panelSaisie.Visible = false;
            this.panelSuppression.Visible = true;
        }

        private void buttonTrier_Click(object sender, EventArgs e)
        {
            T.Sort(new Huile.HuileComparator());

            lister(T);

            this.panelTable.Visible = true;
            this.panelSaisie.Visible = false;
            this.panelSuppression.Visible = false;

            string message;
            if (T.Count == 0)
            {
                message = "Pas de stock huile.";
            }
            else
            {
                message = "Le stock a été trié.";
            }
            
            string caption = "Information";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            DialogResult result;

            result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
        }

        private void buttonSauvegarder_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            if(saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(saveFileDialog.FileName, FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(stream, T);
                stream.Close();
            }
        }

        private void buttonRestaurer_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if(openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileStream stream = new FileStream(openFileDialog.FileName, FileMode.OpenOrCreate);
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    T = (ArrayList)formatter.Deserialize(stream);
                }
                catch(Exception exception)
                {
                    string caption = "Information";
                    string message = "Le fichier ne représente pas des objets serialisés.";
                    MessageBoxButtons buttons = MessageBoxButtons.OK;
                    MessageBox.Show(message, caption, buttons, MessageBoxIcon.Stop);
                }
                stream.Close();

                lister(T);
            }
        }

        private void buttonStockRepture_Click(object sender, EventArgs e)
        {
            ArrayList T2 = new ArrayList();

            foreach (Huile h in T)
            {
                if (h.Stock == 0)
                {
                    T2.Add(h);
                }
            }

            lister(T2);

            this.labelLister.Visible = false;
            this.labelMaxVC.Visible = false;
            this.labelMaxVF.Visible = false;
            this.labelMaxViscosite.Visible = false;
            this.labelStockRepture.Visible = true;
            this.labelStockReduction.Visible = false;
            this.panelTable.Visible = true;
            this.panelSaisie.Visible = false;
            this.panelSuppression.Visible = false;
        }

        private void buttonReduction40_Click(object sender, EventArgs e)
        {
            ArrayList T2 = new ArrayList();

            foreach (Huile h in T)
            {
                if (h.Stock <= 5)
                {
                    h.Prix = (h.Prix * 40) / 100;
                    T2.Add(h);
                }
            }

            lister(T2);

            this.labelLister.Visible = false;
            this.labelMaxVC.Visible = false;
            this.labelMaxVF.Visible = false;
            this.labelMaxViscosite.Visible = false;
            this.labelStockRepture.Visible = false;
            this.labelStockReduction.Visible = true;
            this.panelTable.Visible = true;
            this.panelSaisie.Visible = false;
            this.panelSuppression.Visible = false;

            string message;
            if (T.Count == 0)
            {
                message = "Pas de stock huile.";
            }
            else
            {
                message = "Une réduction à 40% du prix unitaire a été effectuée au stock huile ayant une quantité inférieure ou égale à 5.";
            }

            string caption = "Information";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
        }

        private void buttonAjouter_Click(object sender, EventArgs e)
        {
            this.pictureBoxErreur1.Visible = false;
            this.pictureBoxErreur2.Visible = false;
            this.pictureBoxErreur3.Visible = false;
            this.pictureBoxErreur4.Visible = false;
            this.pictureBoxErreur5.Visible = false;
            this.pictureBoxErreur6.Visible = false;

            bool erreur = false;

            // Nom huile
            string nom = this.richTextBoxNom.Text;
            if (nom == "")
            {
                this.pictureBoxErreur1.Visible = true;
                erreur = true;
            }

            // Petrolier
            string petrolier = this.richTextBoxPetrolier.Text;
            if (petrolier == "")
            {
                this.pictureBoxErreur2.Visible = true;
                erreur = true;
            }

            // VF
            int vf = -1;
            if (this.VF0.Checked)
            {
                vf = Convert.ToInt32(this.VF0.Text);
            }
            else if (this.VF5.Checked)
            {
                vf = Convert.ToInt32(this.VF5.Text);
            }
            else if (this.VF10.Checked)
            {
                vf = Convert.ToInt32(this.VF10.Text);
            }
            else if (this.VF15.Checked)
            {
                vf = Convert.ToInt32(this.VF15.Text);
            }
            else if (this.VF20.Checked)
            {
                vf = Convert.ToInt32(this.VF20.Text);
            }
            else
            {
                this.pictureBoxErreur5.Visible = true;
                erreur = true;
            }

            // VC
            int vc = -1;
            if (this.VC30.Checked)
            {
                vc = Convert.ToInt32(this.VC30.Text);
            }
            else if (this.VC40.Checked)
            {
                vc = Convert.ToInt32(this.VC40.Text);
            }
            else if (this.VC50.Checked)
            {
                vc = Convert.ToInt32(this.VC50.Text);
            }
            else
            {
                this.pictureBoxErreur6.Visible = true;
                erreur = true;
            }

            // prix
            double prix = 0;
            if (this.richTextBoxPrix.Text == "" || (prix = Convert.ToDouble(this.richTextBoxPrix.Text)) <= 0)
            {
                this.pictureBoxErreur3.Visible = true;
                erreur = true;
            }

            // stock
            int stock = 0;
            if (this.richTextBoxStock.Text == "" || (stock = Convert.ToInt32(this.richTextBoxStock.Text)) < 0)
            {
                this.pictureBoxErreur4.Visible = true;
                erreur = true;
            }

            if (!erreur)
            {
                Huile h = new Huile(nom, vf, vc, prix, stock, petrolier);
                T.Add(h);
                foreach(Huile x in T)
                {
                    Console.WriteLine(x.ToString());
                }

                string message = "Huile a bien été ajouté.";
                string caption = "Information";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
            }
        }

        private void richTextBoxPrix_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != ','))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == ',') && (richTextBoxPrix.Text.IndexOf(',') > -1))
            {
                e.Handled = true;
            }
        }

        private void richTextBoxStock_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void buttonSuppression_Click(object sender, EventArgs e)
        {
            this.pictureBoxErreur7.Visible = false;
            this.pictureBoxErreur8.Visible = false;

            bool erreur = false;

            // VF
            int vf = -1;
            if (this.radioButtonVF0.Checked)
            {
                vf = Convert.ToInt32(this.radioButtonVF0.Text);
            }
            else if (this.radioButtonVF5.Checked)
            {
                vf = Convert.ToInt32(this.radioButtonVF5.Text);
            }
            else if (this.radioButtonVF10.Checked)
            {
                vf = Convert.ToInt32(this.radioButtonVF10.Text);
            }
            else if (this.radioButtonVF15.Checked)
            {
                vf = Convert.ToInt32(this.radioButtonVF15.Text);
            }
            else if (this.radioButtonVF20.Checked)
            {
                vf = Convert.ToInt32(this.radioButtonVF20.Text);
            }
            else
            {
                this.pictureBoxErreur7.Visible = true;
                erreur = true;
            }

            // VC
            int vc = -1;
            if (this.radioButtonVC30.Checked)
            {
                vc = Convert.ToInt32(this.radioButtonVC30.Text);
            }
            else if (this.radioButtonVC40.Checked)
            {
                vc = Convert.ToInt32(this.radioButtonVC40.Text);
            }
            else if (this.radioButtonVC50.Checked)
            {
                vc = Convert.ToInt32(this.radioButtonVC50.Text);
            }
            else
            {
                this.pictureBoxErreur8.Visible = true;
                erreur = true;
            }

            if (!erreur)
            {
                string message = "Cet opération pourait supprimer plusieurs enregistrements.\nVoulez vous continuer?";
                string caption = "Confirmation";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Warning);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    for (int i = 0; i < T.Count; i++)
                    {
                        if (((Huile)T[i]).VC == vc && ((Huile)T[i]).VF == vf)
                        {
                            T.RemoveAt(i);
                            i--;
                        }
                    }
                }
            }

        }

        private void buttonMaxVF_Click(object sender, EventArgs e)
        {
            ArrayList temp = new ArrayList();

            foreach (Huile h in T)
            {
                if (h.VF == 20)
                {
                    temp.Add(h);
                }
            }

            lister(temp);

            this.labelLister.Visible = false;
            this.labelMaxVC.Visible = false;
            this.labelMaxVF.Visible = true;
            this.labelMaxViscosite.Visible = false;
            this.labelStockRepture.Visible = false;
            this.labelStockReduction.Visible = false;
            this.panelTable.Visible = true;
            this.panelSaisie.Visible = false;
            this.panelSuppression.Visible = false;
        }

        private void buttonMaxVC_Click(object sender, EventArgs e)
        {
            ArrayList temp = new ArrayList();

            foreach (Huile h in T)
            {
                if (h.VC == 50)
                {
                    temp.Add(h);
                }
            }

            lister(temp);

            this.labelLister.Visible = false;
            this.labelMaxVC.Visible = true;
            this.labelMaxVF.Visible = false;
            this.labelMaxViscosite.Visible = false;
            this.labelStockRepture.Visible = false;
            this.labelStockReduction.Visible = false;
            this.panelTable.Visible = true;
            this.panelSaisie.Visible = false;
            this.panelSuppression.Visible = false;
        }

        private void buttonMaxV_Click(object sender, EventArgs e)
        {
            ArrayList temp = new ArrayList();

            foreach (Huile h in T.ToArray())
            {
                if (h.VF == 20 && h.VC == 50)
                {
                    temp.Add(h);
                }
            }

            lister(temp);

            this.labelLister.Visible = false;
            this.labelMaxVC.Visible = false;
            this.labelMaxVF.Visible = false;
            this.labelMaxViscosite.Visible = true;
            this.labelStockRepture.Visible = false;
            this.labelStockReduction.Visible = false;
            this.panelTable.Visible = true;
            this.panelSaisie.Visible = false;
            this.panelSuppression.Visible = false;
        }

        private string prixTotal()
        {
            Form prompt = new Form()
            {
                Width = 463,
                Height = 225,
                FormBorderStyle = FormBorderStyle.SizableToolWindow,
                Text = "Prix Total",
                StartPosition = FormStartPosition.CenterScreen
            };
            Label textLabel = new Label();
            textLabel.AutoSize = true;
            textLabel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            textLabel.Location = new System.Drawing.Point(55, 27);
            textLabel.Name = "label18";
            textLabel.Size = new System.Drawing.Size(95, 16);
            textLabel.TabIndex = 29;
            textLabel.Text = "PETROLIER :";

            RichTextBox textBox = new RichTextBox();
            textBox.BackColor = System.Drawing.SystemColors.Control;
            textBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            textBox.Location = new System.Drawing.Point(58, 58);
            textBox.Multiline = false;
            textBox.Name = "richTextBoxPetrolierTotal";
            textBox.Size = new System.Drawing.Size(360, 30);
            textBox.TabIndex = 31;
            textBox.Text = "";

            Panel panel = new Panel();
            panel.BackColor = System.Drawing.SystemColors.ControlDark;
            panel.Location = new System.Drawing.Point(58, 90);
            panel.Name = "panel16";
            panel.Size = new System.Drawing.Size(360, 1);
            panel.TabIndex = 30;

            Button confirmation = new Button() { DialogResult = DialogResult.OK };
            confirmation.BackColor = System.Drawing.SystemColors.Control;
            confirmation.Cursor = System.Windows.Forms.Cursors.Hand;
            confirmation.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            confirmation.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            confirmation.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            confirmation.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            confirmation.Location = new System.Drawing.Point(164, 113);
            confirmation.Name = "buttonValeurTotal";
            confirmation.Size = new System.Drawing.Size(140, 43);
            confirmation.TabIndex = 33;
            confirmation.Text = "OK";
            confirmation.UseVisualStyleBackColor = false;
            confirmation.Click += (mySender, myEvent) => { prompt.Close(); };

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;

            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }

        private void buttonPrixTotal_Click(object sender, EventArgs e)
        {
            bool erreur = false;

            double total = 0;

            string fournisseur =  prixTotal();
            if(fournisseur == "")
            {
                erreur = true;
            }

            if (!erreur) {
                bool trouve = false;
                foreach (Huile h in T)
                {
                    if (h.Petrolier == fournisseur)
                    {
                        total += h.Prix * h.Stock;
                        trouve = true;
                    }
                }
                string message;
                if (trouve)
                {
                    message = "La valeur total du stock huile de: " + fournisseur + ", est:\n" + total + " DH";
                }
                else
                {
                    message = "Le fournisseur: " + fournisseur + ", n'éxiste pas.";
                }
                 
                string caption = "Valeur Total";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons, MessageBoxIcon.Information);
            }
            
        }
        
    }
}
