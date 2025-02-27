﻿namespace DvdApi.Models
{
    public class Staff
    {
        public int StaffId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int AddressId { get; set; }
        public string Email { get; set; }
        public int StoreId { get; set; }
        public bool Active { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public DateTime LastUpdate { get; set; }
    }
}
