using System.Collections.Generic;
namespace Supermarket.API.Domain.Models
{
    public class Chat
    {
        public Chat(){
            Data = new List<int>();
        }
        public List<int> Data{get;set;}
        public string Label{get;set;}
    }
}