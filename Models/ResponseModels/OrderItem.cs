﻿using System;

namespace KPI.SportStuffInternetShop.Models.ResponseModels {
    public class OrderItem {
        public Guid ProductId { get; set; }

        public string ProductName { get; set; }

        public string PictureUrl { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
