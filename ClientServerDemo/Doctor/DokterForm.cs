using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Doctor
{
    public partial class DokterForm : Form
    {
        private FlowLayoutPanel panel;
        private List<Patient> selectedPatients;
        private List<Patient> availablePatients;

        private String broadcastMessage { get; set; }

        public DokterForm()
        {
            InitializeComponent();
            panel = LayoutPanelClient;

            selectedPatients = new List<Patient>();
            availablePatients = new List<Patient>();

            testDataAvailablePatients();



        }







        private void removeBtnFromFlowpanel(Patient p)
        {
            Button remove;

            foreach (Button b in panel.Controls)
            {
                if (b.Text.Contains(p.Name))
                {
                    LayoutPanelClient.Controls.Remove(b);
                }
            }

        }

        private void testDataAvailablePatients()
        {
            availablePatients.Add(new Patient("Pascal", 20, "Man", "0000"));
            availablePatients.Add(new Patient("Maarten", 20, "Man", "0000"));
            availablePatients.Add(new Patient("Thijs", 21, "Man", "0000"));
            availablePatients.Add(new Patient("Joelle", 20, "Vrouw", "0000"));
            availablePatients.Add(new Patient("Marleen", 20, "Vrouw", "0000"));
            availablePatients.Add(new Patient("Kirsten", 20, "Vrouw", "0000"));


        }

        private void PatientLabel_Click(object sender, EventArgs e)
        {

        }

        private void AvailableListBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void AvailableLabel_Click(object sender, EventArgs e)
        {

        }

        private void LayoutPanelClient_Paint(object sender, PaintEventArgs e)
        {

        }
    }



}