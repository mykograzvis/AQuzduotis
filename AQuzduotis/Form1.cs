using Microsoft.Data.Sqlite;
using System.Data.SQLite;
using System.Data;
using System.Windows.Forms;
using AQuzduotis.Models;
using AQuzduotis.Tasks;

namespace AQuzduotis
{
    public partial class Form1 : Form
    {
        private static InOutUtils InOut = new InOutUtils();
        private static SetCalculations SetCalc = new SetCalculations();
        private List<Harness> harness = new List<Harness>();
        private List<Wires> wires = new List<Wires>();
        private List<HarnessSet> Sets = new List<HarnessSet>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            harness = InOut.ReadDrawings();
            wires = InOut.ReadWires();
            LoadTable("SELECT * FROM Harness_drawing", dataGridView1);
            LoadTable("SELECT * FROM Harness_wires", dataGridView2);
        }

        private void LoadTable(string query, DataGridView dataTable)
        {
            string connectionString = "Data Source=AQ.db";
            var con = new SQLiteConnection(connectionString);
            SQLiteCommand cmd = new SQLiteCommand(query, con);
            DataTable dt = new DataTable();
            SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
            adapter.Fill(dt);

            dataTable.DataSource = dt;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView3.Rows.Clear();
            Sets = SetCalc.GenerateSets(harness, wires);
            if (Sets == null || Sets.Count == 0)
                label3.Text = "Negalima sugeneruoti pyniu komplektu";
            else
            {
                for(int i = 0; i< 3; i++)
                {
                    dataGridView3.Rows.Add(Sets[i].Harness1.ToString(), Sets[i].Harness2.ToString());
                    if (!Sets[i].Valid)
                    {
                        DataGridViewCell colorCell = dataGridView3.Rows[i].Cells[2];
                        colorCell.Style.BackColor = Color.Red;
                    }
                }
            }
        }
    }
}
