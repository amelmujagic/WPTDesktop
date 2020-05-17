using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace WPTDesktop
{
    public partial class Form1 : Form
    {
        WPTService.WebService proxy = new WPTService.WebService();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            int organisationID = 1; //samo za test
            string printersList = proxy.GetPrinters(organisationID);
            DataTable dtPrinters = new DataTable();

            //Dodan package Microsoft.AspNet.WebApi.Client za json

            dtPrinters = JsonConvert.DeserializeObject<DataTable>(printersList);

            dataGridView1.DataSource = dtPrinters;
        }
    }
}
