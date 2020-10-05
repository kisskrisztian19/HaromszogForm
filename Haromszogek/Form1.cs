﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                MessageBox.Show("Nincs mit törölni.", "Hiba");
            }
        }

        private void btnFajlbol_Click(object sender, EventArgs e)
        {
            lbHaromszogLista.Items.Clear();
            ofdMegnyitas.ShowDialog();
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
            catch (Exception ex)
            {
                MessageBox.Show("Számot adj meg!", "Hiba", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                tbAoldal.Focus();
            }
            
        }
    }
}
