using System;
using System.Collections.Generic;
using Supermarket.API.Domain.Models;

namespace Supermarket.API.Persistence.Contexts
{
    public class chatDataManager
    {
        public static List<Chat> GetData(){
            var r = new Random();
            return new List<Chat>(){
                new Chat{Data=new List<int>{r.Next(1,40)}, Label="Data1"},
                new Chat{Data=new List<int>{r.Next(1,40)}, Label="Data2"},
                new Chat{Data=new List<int>{r.Next(1,40)}, Label="Data3"},
                new Chat{Data=new List<int>{r.Next(1,40)}, Label="Data4"},
                new Chat{Data=new List<int>{r.Next(1,40)}, Label="Data5"}
            };
        }        
    }
}