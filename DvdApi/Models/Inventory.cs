﻿namespace DvdApi.Models
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int FilmId { get; set; }
        public int StoreId { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
