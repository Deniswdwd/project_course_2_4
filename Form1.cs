using System;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Text.Json;
using System.Net;
using Microsoft.Office.Interop.Word;

namespace project_sourse_2_4
{

    public partial class Form1 : Form
    { 
        Root[] list;
        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            deserialaze2();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {  
            string[] param = new string[20]; //массив для записи данных
            param = for_all(param);
            // вывод данных в текстовый блок
            textBox1.Text = $"toplevelDomain: {param[0]}, " + '\r' + '\n' +
                            $"alpha2code: {param[1]}, " + '\r' + '\n' +
                            $"alpha3code: {param[2]}, " + '\r' + '\n' +
                            $"calling code: {param[3]}, " + '\r' + '\n' +
                            $"capital: {param[4]}, " + '\r' + '\n' +
                            $"alt spelling: {param[5]}, " + '\r' + '\n' +
                            $"region: {param[6]}, " + '\r' + '\n' +
                            $"subregion: {param[7]}, " + '\r' + '\n' +
                            $"population: {param[8]}, " + '\r' + '\n' +
                            $"latlng: {param[9]}, " + '\r' + '\n' +
                            $"demonum: {param[10]}, " + '\r' + '\n' +
                            $"area: {param[11]}, " + '\r' + '\n' +
                            $"gini: {param[12]}, " + '\r' + '\n' +
                            $"time zones: {param[13]}, " + '\r' + '\n' +
                            $"borbers: {param[14]}, " + '\r' + '\n' +
                            $"numeric code: {param[15]}, " + '\r' + '\n' +
                            $"currencies: {param[16]}, " + '\r' + '\n' +
                            $"languages: {param[17]}, " + '\r' + '\n' +
                            $"regional Block: {param[18]}, " + '\r' + '\n' +
                            $"translations: {param[19]}";
            convert_to_word();// запись в файл
        }
        public void convert_to_word()
        {       // метод для записи в файл
                Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
                Microsoft.Office.Interop.Word.Document doc = app.Documents.Open("C:\\Users\\denis\\source\\repos\\project sourse 2_4\\Save_file.docx");
                object missing = System.Reflection.Missing.Value;
                doc.Content.Text = textBox1.Text.ToString();
                doc.Save();
                doc.Close(ref missing);
                app.Quit(ref missing);
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        // открытие формы для сравнения
        private void button2_Click(object sender, EventArgs e)
        {
            comparsion comparsion1 = new comparsion();
            comparsion1.Show();
            comparsion1.Text = button2.Text;
        }
        // метод десериализации (полуавтоматичекий)
        public void deserialaze2()
        {
            try { 
                string json_name = "C:\\Users\\denis\\source\\repos\\project sourse 2_4\\all.json";
                    using (StreamReader reader = new StreamReader(json_name))
                    {
                        list = JsonSerializer.Deserialize<Root[]>(reader.ReadToEnd());
                    }
                }
            catch (Exception e)
            {
                MessageBox.Show("exception" + e + '\r' + '\n' +"choose your file");
                deserialaze();
            }
        }
        public void deserialaze() // метод десериализации, если путь к файлу указан неверно
        {
            try
            {
                using (OpenFileDialog openFileDialog = new OpenFileDialog())
                {
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
            catch(Exception e) // отлов ошибок
            {
                MessageBox.Show("exception" + e);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        // вывод выбраного критерия поиска для страны в текстовы блок
        private void button4_Click(object sender, EventArgs e)
        {
            string[] param = new string[20];
            param = for_all(param);
            int tmp = comboBox2.SelectedIndex;// check index
            textBox1.Text = param[comboBox2.SelectedIndex];
        }
        // метод для записи данних про страну в массив
        public string[] for_all(string[] param)
        {
            string str0 = "";
            string str1 = "";
            string str2 = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            string str6 = "";
            string str7 = "";
            // выбраный критерий содержит несколько значений, преобразование в строку
            for (int i = 0; i < list[comboBox1.SelectedIndex].topLevelDomain.Count(); i++)
                str0 += $"{list[comboBox1.SelectedIndex].topLevelDomain[i]}, ";
            param[0] = str0;
            param[1] = list[comboBox1.SelectedIndex].alpha2Code;
            param[2] = list[comboBox1.SelectedIndex].alpha3Code;
            // выбраный критерий содержит несколько значений, преобразование в строку
            for (int i = 0; i < list[comboBox1.SelectedIndex].callingCodes.Count(); i++)
                str1 += $"{list[comboBox1.SelectedIndex].callingCodes[i]}, ";
            param[3] = str1;
            param[4] = list[comboBox1.SelectedIndex].capital;
            // выбраный критерий содержит несколько значений, преобразование в строку
            for (int i = 0; i < list[comboBox1.SelectedIndex].altSpellings.Count(); i++)
                str2 += $"{list[comboBox1.SelectedIndex].altSpellings[i]}, ";
            param[5] = str2;
            param[6] = list[comboBox1.SelectedIndex].region;
            param[7] = list[comboBox1.SelectedIndex].subregion;
            param[8] = $"{list[comboBox1.SelectedIndex].population} people";
            // выбраный критерий содержит несколько значений, преобразование в строку
            for (int i = 0; i < list[comboBox1.SelectedIndex].latlng.Count(); i++)
                str3 += $"{list[comboBox1.SelectedIndex].latlng[i]} ";
            param[9] = "latitude - " + str3 + "- longitude";
            param[10] = list[comboBox1.SelectedIndex].demonym;
            param[11] = $"{list[comboBox1.SelectedIndex].area} sq km";
            param[12] = $"{list[comboBox1.SelectedIndex].gini}%";
            // выбраный критерий содержит несколько значений, преобразование в строку
            for (int i = 0; i < list[comboBox1.SelectedIndex].timezones.Count(); i++)
                str4 += $"{list[comboBox1.SelectedIndex].timezones[i]}, ";
            param[13] = str4;
            // выбраный критерий содержит несколько значений, преобразование в строку
            for (int i = 0; i < list[comboBox1.SelectedIndex].borders.Count(); i++)
                str5 += $"{list[comboBox1.SelectedIndex].borders[i]}, ";
            param[14] = str5;
            param[15] = list[comboBox1.SelectedIndex].numericCode;
            param[16] = $"code: {list[comboBox1.SelectedIndex].currencies[0].code}," + '\r' + '\n' +
                        $"name: {list[comboBox1.SelectedIndex].currencies[0].name}," + '\r' + '\n' +
                        $"symbol: {list[comboBox1.SelectedIndex].currencies[0].symbol}";
            param[17] = $"iso639_1: {list[comboBox1.SelectedIndex].languages[0].iso639_1}," + '\r' + '\n' +
                        $"iso639_2: {list[comboBox1.SelectedIndex].languages[0].iso639_2}," + '\r' + '\n' +
                        $"name: {list[comboBox1.SelectedIndex].languages[0].name}," + '\r' + '\n' +
                        $"nativename: {list[comboBox1.SelectedIndex].languages[0].nativeName}";
            if (list[comboBox1.SelectedIndex].regionalBlocs.Count != 0)
            {   // выбраный критерий содержит несколько значений, преобразование в строку
                for (int i = 0; i < list[comboBox1.SelectedIndex].regionalBlocs[0].otherAcronyms.Count(); i++)
                    str6 += $"{list[comboBox1.SelectedIndex].regionalBlocs[0].otherAcronyms[i]}, ";
                for (int i = 0; i < list[comboBox1.SelectedIndex].regionalBlocs[0].otherNames.Count(); i++)
                    str7 += $"{list[comboBox1.SelectedIndex].regionalBlocs[0].otherNames[i]}, ";
                param[18] = $"acronym: {list[comboBox1.SelectedIndex].regionalBlocs[0].acronym}," + '\r' + '\n' +
                            $"name: {list[comboBox1.SelectedIndex].regionalBlocs[0].name}," + '\r' + '\n' +
                            $"other acronyms: " + str6 + '\r' + '\n' +
                            $"other names: " + str7;
            }
            param[19] = $"de: {list[comboBox1.SelectedIndex].translations.de}," + '\r' + '\n' +
                        $"es: {list[comboBox1.SelectedIndex].translations.es}," + '\r' + '\n' +
                        $"fr: {list[comboBox1.SelectedIndex].translations.fr}," + '\r' + '\n' +
                        $"ja: {list[comboBox1.SelectedIndex].translations.ja}," + '\r' + '\n' +
                        $"it: {list[comboBox1.SelectedIndex].translations.it}," + '\r' + '\n' +
                        $"br: {list[comboBox1.SelectedIndex].translations.br}," + '\r' + '\n' +
                        $"pt: {list[comboBox1.SelectedIndex].translations.pt}," + '\r' + '\n' +
                        $"nl: {list[comboBox1.SelectedIndex].translations.nl}," + '\r' + '\n' +
                        $"hr: {list[comboBox1.SelectedIndex].translations.hr}," + '\r' + '\n' +
                        $"fa: {list[comboBox1.SelectedIndex].translations.fa}";
            return param;
        }
        // вывод списка стран
        private void button3_Click(object sender, EventArgs e)
        {
            string[] param = new string[250];
            textBox1.Text = "";
            for (int i = 0; i<param.Length;i++)
            { 
                param[i] = list[i].name;
                textBox1.Text += $"{i+1}. " + param[i] + '\r' + '\n';
            }
        }
        // десериализация файла, возможность выбрать другой файл
        private void button5_Click(object sender, EventArgs e)
        {
            deserialaze();
        }
        // скачивание файла из интернета 
        private void button6_Click(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            string url = "https://restcountries.eu/rest/v2/all";
            string save_path = "C:\\Users\\denis\\Downloads\\"; //C:\Users\denis\Downloads
            string name = "all.json";
            wc.DownloadFile(url, save_path + name);
        }
    }
}
