using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IntergalaticCalculator
{
    public partial class frmIntergalaticCalculator : Form
    {
        public frmIntergalaticCalculator()
        {
            InitializeComponent();
        }

        private void btnConvertToCredits_Click(object sender, EventArgs e)
        {
            // get the query file location
            string stQueryFileLocation = txtQuery.Text;

            // validating if the query file location was informed
            if (stQueryFileLocation.Length > 0)
            {
                // load the query file into an array
                string[] arQueryLines = File.loadQueryFile(stQueryFileLocation);

                // run all the queries in the file
                List<String> arOutput = Query.run(arQueryLines);

                // display the output in the textbox
                txtOutput.Text = string.Join(Environment.NewLine, arOutput);
            }
            else {
                MessageBox.Show("Please inform the query file location.");       
            }
        }
    }
}
