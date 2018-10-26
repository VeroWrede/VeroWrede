using System;
using System.ComponentModel.DataAnnotations;

namespace DouQuo.Models 
{
    public class Quote
    {
        public int QuoteId {get; set;}
        [Required]
        public string Content {get; set;}
        [Required]
        public string user {get; set;}
        public DateTime CreatedAt {get; set;}
        public DateTime UpdatedAt {get; set;}
    }
}