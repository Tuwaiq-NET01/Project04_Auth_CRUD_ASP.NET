using System;

namespace RSDC_API
{
    public class Store
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        
        public int TypeId { get; set; }
        public Type Type { get; set; }
    }
}
