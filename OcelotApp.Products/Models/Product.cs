﻿namespace OcelotApp.Products.Models
{
	public class Product
	{
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
