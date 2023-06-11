using System.Collections.Generic;

namespace CourseWork
{
    public class PlantList // Принцип ООП "Інкапсуляція"
    {
        private readonly List<Plant> lPlants = new List<Plant>();
        private readonly Dictionary<string, Plant> dPlants = new Dictionary<string, Plant>();
        public int Count => lPlants.Count;
        public Plant this[int id] => id >= 0 && id < Count ? lPlants[id] : null;
        public Plant this[string name] => dPlants.ContainsKey(name) ? dPlants[name] : null;
        public void Add(Plant plant)
        {
            if (!dPlants.ContainsKey(plant.Name))
            {
                lPlants.Add(plant);
                dPlants.Add(plant.Name, plant);
            }
        }
        public void SortVariety()
        {
            lPlants.Sort((@this, @other) => @this.Variety.CompareTo(@other.Variety));
        }
        public void SortName()
        {
            lPlants.Sort((@this, @other) => @this.Name.CompareTo(@other.Name));
        }
        public void SortTemperature()
        {
            lPlants.Sort((@this, @other) => @this.Temperature.CompareTo(@other.Temperature));
        }
        public void SortFlowering()
        {
            lPlants.Sort((@this, @other) => @this.Flowering.CompareTo(@other.Flowering));
        }
    }
    //
    // Використання двох індексаторів з різними типами індексів є формою поліморфізму,
    // оскільки об'єкт класу Plant може вести себе по-різному в залежності від типу індексу,
    // який використовується для доступу до рослин
    //
    // Інкапсуляція: Використання ключового слова private для змінної plants забезпечує її інкапсуляцію.
    // Це означає, що доступ до цієї змінної можливий лише всередині класу PlantList,
    // інші частини коду не можуть безпосередньо змінювати чи отримувати доступ до цього поля.
    // Це дозволяє контролювати доступ до даних і забезпечує безпеку та незалежність класу.
}
