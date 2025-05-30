﻿using Ambev.DeveloperEvaluation.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Shopping.CreateOrder.AddItemToCart
{
    public class CreateOrderResult
    {
        public Guid OrderId { get; set; }
        public DateTime CreatedOn { get; set; }
        public decimal Total { get; set; }

        public CreateOrderResult(Guid orderId, DateTime createdOn, decimal total)
        {
            OrderId = orderId;
            CreatedOn = createdOn;
            Total = total;
        }
    }

}
