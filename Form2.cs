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

namespace _20181986_20188768_assign5
{
    public partial class Form2 : Form
    {
        String [] id_array;
        String [] name_array;
        String [] phone_array;

        public Form2()
        {
            InitializeComponent();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AboutBox1 object2 = new AboutBox1();
            object2.labelCompanyName.Text = "Section 02- 20181986, 20188768";
            object2.labelProductName.Text = "Employee Directory";
            object2.textBoxDescription.Text = "Employee directory application that shows employee names and allows the user to view employee details";
            
            object2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //reading file for employee details
            StreamReader file = new StreamReader("employee_details.txt");
            String ln = file.ReadLine();
            name_array = new string[int.Parse(ln)];
            int numberOfLinesLeft = 1 + int.Parse(ln) + 1; //1st line has number of entries (already read), next line has all the ids, next "ln" lines has names, then 1 line has the phone numbers
            for (int i=2; (ln = file.ReadLine()) != null; ++i )
            {
                if (i == 2)
                    id_array = ln.Split(' ');
                else if (i >= 3 && i <= numberOfLinesLeft)
                {
                    name_array[i - 3] = ln;
                    listBox1.Items.Add(ln);
                    //Console.WriteLine(ln + "-" + i);
                }
                else
                    phone_array = ln.Split(' ');
            }
            file.Close();
            
            /*
            for(int x=0;x<numberOfLinesLeft-2; ++x)
            {
                Console.WriteLine(id_array[x]+ " ");
                Console.WriteLine(name_array[x] + " ");
                Console.WriteLine(phone_array[x] + " ");
            }
            */
            



        }

        private void showAllEmployeesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int index= int.Parse(listBox1.SelectedIndex.ToString());
            Form3 object3 = new Form3();
            object3.textBox1_id.Text = id_array[index];
            object3.textBox2_name.Text = name_array[index];
            object3.textBox3_phone.Text = phone_array[index];

            object3.Show();

        }
    }
}
