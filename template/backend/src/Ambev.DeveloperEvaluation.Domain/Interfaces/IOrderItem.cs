﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Interfaces
{
    public interface IOrderItem
    {
        public Guid Id { get;  set; }                  
        public Guid OrderId { get;  set; }             
        public Guid ProductId { get;  set; }           
        public string ProductName { get;  set; }       
        public string? ProductSku { get;  set; }       
        public decimal UnitPrice { get;  set; }        
        public int Quantity { get;  set; }             
    }
}
