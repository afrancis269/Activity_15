using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Activity_15
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            MonthCbx.DataSource = CultureInfo.InvariantCulture.DateTimeFormat
                                                     .MonthNames.Take(12).ToList();
            MonthCbx.SelectedItem = CultureInfo.InvariantCulture.DateTimeFormat
                                                    .MonthNames[DateTime.Now.AddMonths(-1).Month - 1];

            YearCbx.DataSource = Enumerable.Range(1983, DateTime.Now.Year - 1983 + 1).ToList();
            YearCbx.SelectedItem = DateTime.Now.Year;
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int month = MonthCbx.SelectedIndex + 1;
            int year = DateTime.Now.Year;
            if (YearCbx.SelectedIndex != -1)
            {
                year = Int32.Parse(YearCbx.Items[YearCbx.SelectedIndex].ToString());
            }
            int num = year - month * (DayCbx.SelectedIndex + 1);
            Form2 frm2 = new Form2(num);
            frm2.Show();

        }

        private void SetDates()
        {
            DayCbx.Items.Clear();
            int month = MonthCbx.SelectedIndex + 1;
            int year = DateTime.Now.Year;
            if (YearCbx.SelectedIndex != -1)
            {
                year = Int32.Parse(YearCbx.Items[YearCbx.SelectedIndex].ToString());
            }

            for (int i = 1; i <= DateTime.DaysInMonth(year, month); i++)
            {
                DayCbx.Items.Add(i);
            }
        }

        private void MonthCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDates();
            
        }

        private void YearCbx_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetDates();
        }
    }
}
