using System;

namespace CourseWork
{
    public class Flower : Plant
    {
        public int Lighting { get; set; }
        public int Watering { get; set; }
        public string Soil { get; set; }
        public override string[] GetInformation()
        {
            return new string[]
            {
                $"Різновид рослини: {Variety}",
                $"Назва рослини: {Name}",
                $"Оптимальний температурний режим: {Temperature}°C",
                $"Період цвітіння: {Flowering}",
                $"Режим освітлення: {Lighting}",
                $"Режим поливу: {Watering}",
                $"Вимоги до грунту: {Soil}",
            };
        }
    }
    public class Tree : Plant
    {
        public string Soil { get; set; }
        public override string[] GetInformation()
        {
            return new string[]
            {
                $"Різновид рослини: {Variety}",
                $"Назва рослини: {Name}",
                $"Оптимальний температурний режим: {Temperature}°C",
                $"Період цвітіння: {Flowering}",
                $"Вимоги до грунту: {Soil}",
            };
        }
    }
    public class Grass : Plant 
    {
        public int Lighting { get; set; }
        public override string[] GetInformation()
        {
            return new string[]
            {
                $"Різновид рослини: {Variety}",
                $"Назва рослини: {Name}",
                $"Оптимальний температурний режим: {Temperature}°C",
                $"Період цвітіння: {Flowering}",
                $"Режим освітлення: {Lighting}",
            };
        }
    }
    public class Shrub : Plant 
    {
        public override string[] GetInformation()
        {
            return new string[]
            {
                $"Різновид рослини: {Variety}",
                $"Назва рослини: {Name}",
                $"Оптимальний температурний режим: {Temperature}°C",
                $"Період цвітіння: {Flowering}",
            };
        }
    }
}
