using System;
using System.Linq;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form2 : Form
    {
        private string imagePath;
        private void SetComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(Data.Types.Травовидна.ToString());
            comboBox1.Items.Add(Data.Types.Деревовидна.ToString());
            comboBox1.Items.Add(Data.Types.Квітковидна.ToString());
            comboBox1.Items.Add(Data.Types.Чагарникова.ToString());
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        public Form2()
        {
            InitializeComponent();
            SetComboBox();
        }
        private void ShowMainWindow(object sender, EventArgs e)
        {
            new Form1().Show();
            Hide();
        }
        private void Photo(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Файли зображень (*.jpg)|*.jpg",
                Title = "Виберіть зображення",
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK)
                imagePath = openFileDialog.FileName;
        }
        private bool IsNumber(string number) => number.All(n => char.IsNumber(n));
        private bool IsCorrectDataToSave()
        {
            return comboBox1.SelectedItem != null && !string.IsNullOrEmpty(textBox1.Text) && IsNumber(textBox2.Text) && IsNumber(textBox3.Text) &&
                IsNumber(textBox4.Text) && IsNumber(textBox5.Text) && !string.IsNullOrEmpty(textBox6.Text);
        }
        private void SavePlant()
        {
            string type = comboBox1.SelectedItem.ToString(), name = textBox1.Text, soil = textBox6.Text;
            
            int temperature = int.Parse(textBox2.Text), flowering = int.Parse(textBox3.Text),
                lighting = int.Parse(textBox4.Text), watering = int.Parse(textBox5.Text);

            imagePath = !string.IsNullOrEmpty(imagePath) ? imagePath : Data.EmptyPicture;
           
            if (type.Equals(Data.Types.Травовидна.ToString()))
                Data.Grass.Add(GetGrass(type, name, temperature, flowering, lighting, imagePath));

            if (type.Equals(Data.Types.Квітковидна.ToString()))
                Data.Flower.Add(GetFlower(type, name, temperature, flowering, lighting, watering, soil, imagePath));

            if (type.Equals(Data.Types.Деревовидна.ToString()))
                Data.Tree.Add(GetTree(type, name, temperature, flowering, soil, imagePath));

            if (type.Equals(Data.Types.Чагарникова.ToString()))
                Data.Shrub.Add(GetShrub(type, name, temperature, flowering, imagePath));
        }
        private void Save(object sender, EventArgs e)
        {
            if (IsCorrectDataToSave()) SavePlant(); 
            
            else MessageBox.Show("Введіть інформацію правильно!");
            imagePath = string.Empty;

            MessageBox.Show($"{Data.Flower.Count} {Data.Tree.Count} {Data.Shrub.Count} {Data.Grass.Count}");
        }
        private Flower GetFlower(string type, string n, int t, int f, int l, int w, string s, string p)
        {
            return new Flower
            {
                Variety = type,
                Name = n,
                Temperature = t,
                Flowering = f,
                Lighting = l,
                Watering = w,
                Soil = s,
                PathPhoto = p,
            };
        }
        private Tree GetTree(string type, string n, int t, int f, string s, string p)
        {
            return new Tree
            {
                Variety = type,
                Name = n,
                Temperature = t,
                Flowering = f,
                Soil = s,
                PathPhoto = p,
            };
        }
        private Grass GetGrass(string type, string n, int t, int f, int l, string p)
        {
            return new Grass
            {
                Variety = type,
                Name = n,
                Temperature = t,
                Flowering = f,
                Lighting = l,
                PathPhoto = p,
            };
        }
        private Shrub GetShrub(string type, string n, int t, int f, string p)
        {
            return new Shrub
            {
                Variety = type,
                Name = n,
                Temperature = t,
                Flowering = f,
                PathPhoto = p,
            };
        }
    }
}
