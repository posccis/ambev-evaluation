using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    public class Product : BaseEntity, IProduct
    {

        public Guid Id { get; set; }                
        public string Name { get; set; }            
        public string Description { get; set; }     
        public decimal Price { get; set; }          
        public int StockQuantity { get; set; }      
        public string SKU { get; set; }             
        public Guid CategoryId { get; set; }        
        public string Category { get; set; }        
        public bool IsActive { get; set; } = true;  
        public DateTime CreatedAt { get; set; }     
        public DateTime? UpdatedAt { get; set; }    
        public string ImageUrl { get; set; }        
        public decimal? DiscountPrice { get; set; }
    }
}
