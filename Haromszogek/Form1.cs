using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Haromszogek
{
    public partial class frmfo : Form
    {
        private double aOldal, bOldal, cOldal;

        public frmfo()
        {
            aOldal = 0;
            bOldal = 0;
            cOldal = 0;
            InitializeComponent();
            tbAoldal.Text = aOldal.ToString();
            tbBoldal.Text = bOldal.ToString();
            tbColdal.Text = cOldal.ToString();
            lbHaromszogLista.Items.Clear();
        }

        private void btnTorol_Click(object sender, EventArgs e)
        {
            if (lbHaromszogLista.Items.Count > 0)
            {
                lbHaromszogLista.Items.Clear();
            }
            else
            {
                MessageBox.Show("Nincs mit törölni.", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFajlbol_Click(object sender, EventArgs e)
        {
            lbHaromszogLista.Items.Clear();
            if (ofdMegnyitas.ShowDialog() == DialogResult.OK)
            {
                List<string> Lista;
                StreamReader olvas = new StreamReader(ofdMegnyitas.FileName);
                while (!olvas.EndOfStream)
                {
                    string[] seged = olvas.ReadLine().Split(';');
                    aOldal = double.Parse(seged[0]);
                    bOldal = double.Parse(seged[1]);
                    cOldal = double.Parse(seged[2]);
                    var fajlhszog = new Haromszog(aOldal, bOldal, cOldal);
                    Lista = fajlhszog.AdatokSzoveg();
                    foreach (var l in Lista)
                    {
                        lbHaromszogLista.Items.Add(l);
                    }
                    Lista.Clear();
                }
                olvas.Close();
                
            }
            
        }

        private void btnKilepes_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnSzamol_Click(object sender, EventArgs e)
        {
            try
            {
                aOldal = double.Parse(tbAoldal.Text);
                bOldal = double.Parse(tbBoldal.Text);
                cOldal = double.Parse(tbColdal.Text);



                if (aOldal == 0 || bOldal == 0 || cOldal == 0)
                {
                    MessageBox.Show("A háromszög oldala nem lehet 0", "Hiba",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    var h = new Haromszog(aOldal, bOldal, cOldal);

                    List<string> adatok = h.AdatokSzoveg();

                    foreach (var a in adatok)
                    {
                        lbHaromszogLista.Items.Add(a);
                    }

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Számot adj meg!", "Hiba", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbAoldal.Focus();
            }
            
        }
    }
}
