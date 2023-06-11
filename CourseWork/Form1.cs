using System;
using System.Drawing;
using System.Windows.Forms;

namespace CourseWork
{
    public partial class Form1 : Form
    {
        private readonly PlantList[] plantLists;
        public Form1()
        {
            InitializeComponent();
            plantLists = new PlantList[] { Data.Flower, Data.Tree, Data.Grass, Data.Shrub };

            AddComboBox();
            AddAllNodes(plantLists);
        }
        private void ShowSecondWindow(object sender, EventArgs e)
        {
            new Form2().Show();
            Hide();
        }
        private void SortElements(string sort)
        {
            for (int i = 0; i < plantLists.Length; i++)
            {
                if (IsNotEmptyPlantList(plantLists[i]))
                {
                    if (sort.Equals(TypeSort.Різновид.ToString())) plantLists[i].SortVariety();

                    if (sort.Equals(TypeSort.Назва.ToString())) plantLists[i].SortName();

                    if (sort.Equals(TypeSort.Температура.ToString())) plantLists[i].SortTemperature();

                    if (sort.Equals(TypeSort.Цвітіння.ToString())) plantLists[i].SortFlowering();
                }
            }
        }
        private void Sort(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            if (comboBox1.SelectedItem != null)
            {
                SortElements(comboBox1.SelectedItem.ToString());
                AddAllNodes(plantLists);
            }
        }
        private void Find(object sender, EventArgs e)
        {
            treeView1.Nodes.Clear();
            string dataToSearch = textBox1.Text;

            if (string.IsNullOrEmpty(dataToSearch)) AddAllNodes(plantLists);

            else SearchAllNameInPlantLists(plantLists, dataToSearch);
        }
        private void AddComboBox()
        {
            comboBox1.Items.Clear();
            comboBox1.Items.Add(TypeSort.Різновид.ToString());
            comboBox1.Items.Add(TypeSort.Назва.ToString());
            comboBox1.Items.Add(TypeSort.Температура.ToString());
            comboBox1.Items.Add(TypeSort.Цвітіння.ToString());

            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }
        private void AddNodes(PlantList plantList)
        {
            TreeNode parentNode = treeView1.Nodes.Add(plantList[0].Variety);
            for (int i = 0; i < plantList.Count; i++)
                parentNode.Nodes.Add(plantList[i].Name); // Додати підвузол
        }
        private bool IsNotEmptyPlantList(PlantList plantList)
        {
            return !plantList.Count.Equals(0);
        }
        private void AddAllNodes(PlantList[] plantLists)
        {
            for (int i = 0; i < plantLists.Length; i++)
                if (IsNotEmptyPlantList(plantLists[i])) AddNodes(plantLists[i]);
        }
        private void SearchNameInPlantList(PlantList plantList, string name)
        {
            if (plantList[name] != null)
            {
                TreeNode parentNode = treeView1.Nodes.Add(plantList[0].Variety);
                parentNode.Nodes.Add(plantList[name].Name);
            }
        }
        private void SearchAllNameInPlantLists(PlantList[] plantLists, string dataToSearch)
        {
            for (int i = 0; i < plantLists.Length; i++)
                if (IsNotEmptyPlantList(plantLists[i])) SearchNameInPlantList(plantLists[i], dataToSearch);
        }
        private enum TypeSort
        {
            Різновид, Назва, Температура, Цвітіння
        }

        private void TreeDoubleClick(object sender, MouseEventArgs e)
        {
            listBox1.Items.Clear();
            Plant plant = new Plant();
            string name = treeView1.SelectedNode.Text, parentNode = treeView1.SelectedNode.Parent.Text;

            for(int i = 0; i < plantLists.Length; i++)
                if (IsNotEmptyPlantList(plantLists[i])) 
                    if(parentNode == plantLists[i][0].Variety) plant = plantLists[i][name];

            foreach (string s in plant.GetInformation()) listBox1.Items.Add(s);
            
            pictureBox1.Image = Image.FromFile(plant.PathPhoto);

            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
        }
    }
}
