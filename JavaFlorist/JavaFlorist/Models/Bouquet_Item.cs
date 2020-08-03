using JavaFlorist.Models.EFCore;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace JavaFlorist.Models
{
    public class BouquetItem : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal? Price { get; set; }
        public string Photo { get; set; }
        public bool? Status { get; set; }

    }

    //[ModelMetadataType(typeof(BouquetItem))]
    //public partial class Bouquet
    //{
    //}
}
