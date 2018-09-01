using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableAccess1
{
    public class CustomerUs : TableEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public CustomerUs(string name , string email)
        {
            this.Name = name;
            this.Email = email;
            this.PartitionKey = "US";
            this.RowKey = email;
        }
        public CustomerUs()
        {

        }
    }
}
