using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace proiect_m
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        List<Materie> lista_m = new List<Materie>();
        string linie1;
        string linie2;
        StreamReader file1 = new StreamReader("Student1.txt");
        StreamReader file2 = new StreamReader("Student1Note.txt");

        TreeNode parent1 = new TreeNode();
        TreeNode parent2 = new TreeNode();
        TreeNode parent3 = new TreeNode();
        TreeNode parent4 = new TreeNode();

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            foreach (Materie mat in lista_m)
            {
                if (e.Node.Text == mat.Denumire)
                {
                    propertyGrid1.SelectedObject = mat;
                    if (mat.Nota_finala == 0)
                    {
                        propertyGrid1.ViewForeColor = Color.Red;
                    }
                    else
                    {
                        propertyGrid1.ViewForeColor = Color.Black;
                    }

                }
                else
                {
                    foreach (Prezentare pr in mat.Prezentari)
                    {
                        if (e.Node.Text == pr.Nr_prezentare)
                        {
                            propertyGrid1.SelectedObject = pr;
                            break;
                        }
                    }
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           FormLogin log = new FormLogin();
            if (log.ShowDialog() == DialogResult.Cancel)
            {
                this.Close();
            }

            /* DateTime data = Convert.ToDateTime("0/0/0");
             listBox1.Items.Add(data);
             */
            parent1.Text = "An I";
            treeView1.Nodes.Add(parent1);
            parent2.Text = "An II";
            treeView1.Nodes.Add(parent2);
            parent3.Text = "An III";
            treeView1.Nodes.Add(parent3);
            parent4.Text = "An IV";
            treeView1.Nodes.Add(parent4);

            while ((linie1 = file1.ReadLine()) != null)
            {
                string[] parts1 = linie1.Split(';');
                List<Prezentare> lista_p = new List<Prezentare>();
                while ((linie2 = file2.ReadLine()) != null)
                {
                    string[] parts2 = linie2.Split(';');
                   // string[] partsData = parts2[3].Split('/');
                    //DateTime data = Convert.ToDateTime("0/0/0");
                    //data.AddDays(Convert.ToDouble(partsData[0]));
                    if (parts1[0] == parts2[0])
                    {
                        Prezentare p = new Prezentare(parts2[1], Convert.ToDouble(parts2[2]), DateTime.Now);
                        lista_p.Add(p);
                    }
                }

                file2.DiscardBufferedData();
                file2.BaseStream.Seek(0, SeekOrigin.Begin);
                Materie m = new Materie(parts1[1], parts1[2], Convert.ToDouble(parts1[3]), lista_p);
                lista_m.Add(m);

                TreeNode child;

                if (m.An == "I")
                {
                    child = new TreeNode();
                    child.Text = m.Denumire;
                    parent1.Nodes.Add(child);
                    foreach (Prezentare prez in lista_p)
                    {
                        TreeNode child2 = new TreeNode();
                        child2.Text = prez.Nr_prezentare;
                        child.Nodes.Add(child2);
                    }


                }
                if (m.An == "II")
                {
                    child = new TreeNode();
                    child.Text = m.Denumire;
                    parent2.Nodes.Add(child);
                    foreach (Prezentare prez in lista_p)
                    {
                        TreeNode child2 = new TreeNode();
                        child2.Text = prez.Nr_prezentare;
                        child.Nodes.Add(child2);
                    }
                }
                if (m.An == "III")
                {
                    child = new TreeNode();
                    child.Text = m.Denumire;
                    parent3.Nodes.Add(child);
                    foreach (Prezentare prez in lista_p)
                    {
                        TreeNode child2 = new TreeNode();
                        child2.Text = prez.Nr_prezentare;
                        child.Nodes.Add(child2);
                    }
                }
                if (m.An == "IV")
                {
                    child = new TreeNode();
                    child.Text = m.Denumire;
                    parent4.Nodes.Add(child);
                    foreach (Prezentare prez in lista_p)
                    {
                        TreeNode child2 = new TreeNode();
                        child2.Text = prez.Nr_prezentare;
                        child.Nodes.Add(child2);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Materie mat in lista_m)
            {
                int nr_rest_mat = 0;
                foreach (Prezentare pr in mat.Prezentari)
                {

                    if (pr.Nota_examen < 5)
                    {
                        nr_rest_mat++;

                    }
                }
                if (nr_rest_mat >= 2)
                {
                    listBox1.Items.Add(mat.Denumire);
                }
            }
        }
    }

}
