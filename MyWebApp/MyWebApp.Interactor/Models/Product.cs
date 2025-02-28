using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Azure.Core;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Data.Models;

public class Product
{
    [Key]
    public int Id { get; set; }

    [Required] 
    public string Title { get; set; }
    public string Description { get; set; }
    [Required]
    public string ISBN { get; set; }
    [Required]
    public string Author { get; set; }
    [Required]
    [Display(Name = "List Price")]
    public decimal ListPrice { get; set; }
    
    [Required]
    [Display(Name = "Price for 1-50")]
    public decimal Price { get; set; }
    
    [Required]
    [Display(Name = "Price for 50+")]
    public decimal Price50 { get; set; }
    
    [Required]
    [Display(Name = "Price for 100+")]
    public decimal Price100 { get; set; }
    
    public int CategoryId { get; set; }
    [ForeignKey("CategoryId")]
    [ValidateNever]
    public Category Category { get; set; }
    [ValidateNever]
    public string ImageUrl { get; set; }
}