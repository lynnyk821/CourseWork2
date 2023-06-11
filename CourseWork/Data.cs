using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Text;

namespace CourseWork
{
    public class Data
    {
        public enum Types { Травовидна, Деревовидна, Квітковидна, Чагарникова }
        
        public const string EmptyPicture = @"D:\Project\VS Project\CourseWork\CourseWork\Images\empty.jpg";
        
        public static PlantList Tree = new PlantList(), Flower = new PlantList(), Grass = new PlantList(), Shrub = new PlantList();
    }
}
