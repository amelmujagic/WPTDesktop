using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WPTDesktop
{
    public partial class Main : Form
    {
        WPTService.WebService proxy = new WPTService.WebService();

        public Main()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Main_Load(object sender, EventArgs e)
        {
            int organisationID = 1; //samo za test

            //pod References /AddService Reference/ Advanced /Ad web reference/dodati URL web servisa
            string printersList = proxy.GetOrganizationPrinters(organisationID);

            DataTable dtPrinters = new DataTable();

            //Dodan package Microsoft.AspNet.WebApi.Client za json

            dtPrinters = JsonConvert.DeserializeObject<DataTable>(printersList);

            dataGridView1.DataSource = dtPrinters;
        }
    }
}
