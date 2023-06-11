using System;

namespace CourseWork
{
    public class Plant
    {
        public string Variety { get; set; }
        public string Name { get; set; }
        public int Temperature { get; set; }
        public int Flowering { get; set; }
        public string PathPhoto { get; set; }
        public virtual string[] GetInformation() { return null; }
    }
}