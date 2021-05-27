using System;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using LiveCharts;


namespace project_sourse_2_4
{
    public partial class comparsion : Form
    {
        Root[] list;
        public comparsion()
        {   // настройка начальных параметров
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 1;
            comboBox3.SelectedIndex = 2;
            comboBox4.SelectedIndex = 0;
            comboBox5.SelectedIndex = 0;
            comboBox6.SelectedIndex = 0;
            deserialaze();
        }

        private void comparsion_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            chart.Series[0].Name = comboBox1.SelectedItem.ToString();
            chart.Series[0].Points.Clear();// очистка диаграммы 
            double?[] param1 = new double?[3];// массивы для инициализации доступных параметров стран 
            double?[] param2 = new double?[3];
            double?[] param3 = new double?[3];
            double?[] param4 = new double?[3];
            double?[] param5 = new double?[3];
            if (comboBox2.SelectedIndex == 0)
            {   // если индекс = 0, столбец графика = 0 
                param1[0] = 0;
                param1[1] = 0;
                param1[2] = 0;
            }
            else
            {   // записываються значения для выьраной страны
                param1[0] = list[comboBox2.SelectedIndex - 1].population;
                param1[1] = list[comboBox2.SelectedIndex - 1].area;
                param1[2] = list[comboBox2.SelectedIndex - 1].gini;
            }
            chart.Series[0].Points.AddXY(1, param1[comboBox1.SelectedIndex]); // построение столбца
            if (comboBox3.SelectedIndex == 0)
            {
                param2[0] = 0;
                param2[1] = 0;
                param2[2] = 0;
            }
            else
            {
                param2[0] = list[comboBox3.SelectedIndex - 1].population;
                param2[1] = list[comboBox3.SelectedIndex - 1].area;
                param2[2] = list[comboBox3.SelectedIndex - 1].gini;
            }
            chart.Series[0].Points.AddXY(2, param2[comboBox1.SelectedIndex]);
            if (comboBox4.SelectedIndex == 0)
            {
                param3[0] = 0;
                param3[1] = 0;
                param3[2] = 0;
            }
            else
            {
                param3[0] = list[comboBox4.SelectedIndex - 1].population;
                param3[1] = list[comboBox4.SelectedIndex - 1].area;
                param3[2] = list[comboBox4.SelectedIndex - 1].gini;
            }
            chart.Series[0].Points.AddXY(3, param3[comboBox1.SelectedIndex]);
            if (comboBox5.SelectedIndex == 0)
            {
                param4[0] = 0;
                param4[1] = 0;
                param4[2] = 0;
            }
            else
            {
                param4[0] = list[comboBox5.SelectedIndex - 1].population;
                param4[1] = list[comboBox5.SelectedIndex - 1].area;
                param4[2] = list[comboBox5.SelectedIndex - 1].gini;
            }
            chart.Series[0].Points.AddXY(4, param4[comboBox1.SelectedIndex]);
            if (comboBox6.SelectedIndex == 0)
            {
                param5[0] = 0;
                param5[1] = 0;
                param5[2] = 0;
            }
            else
            {
                param5[0] = list[comboBox6.SelectedIndex - 1].population;
                param5[1] = list[comboBox6.SelectedIndex - 1].area;
                param5[2] = list[comboBox6.SelectedIndex - 1].gini;
                chart.Series[0].Points.AddXY(5, param5[comboBox1.SelectedIndex]);
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {
            
        }
        public void deserialaze()
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    // чтение из моего файла
                    string json_name = "C:\\Users\\denis\\source\\repos\\project sourse 2_4\\all.json";
                    using (StreamReader reader = new StreamReader(json_name))
                    {
                        list = JsonSerializer.Deserialize<Root[]>(reader.ReadToEnd());
                    }
                }
            }
            catch (Exception e)
            {   // в случае неверного пути, файл можно выбрать
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
                    MessageBox.Show("exception" + e);
                    openFileDialog.InitialDirectory = "c:\\";
                    openFileDialog.Filter = "json files (*.json)|*.json|All files (*.*)|*.*";
                    openFileDialog.FilterIndex = 2;
                    openFileDialog.RestoreDirectory = true;

                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        var fileStream = openFileDialog.OpenFile();
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            list = JsonSerializer.Deserialize<Root[]>(reader.ReadToEnd());
                        }
                    }
                }
            } 
        }
    }
}
