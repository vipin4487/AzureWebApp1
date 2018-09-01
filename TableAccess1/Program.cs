using Microsoft.WindowsAzure.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure;
using Microsoft.WindowsAzure.Storage.Table;

namespace TableAccess1
{
    class Program
    {
        static void Main(string[] args)
        {
            //create connection
            CloudStorageAccount storageAccount = CloudStorageAccount.Parse(
                CloudConfigurationManager.GetSetting("StorageConnection")
                );

            //create table client connection
            CloudTableClient cloudTable = storageAccount.CreateCloudTableClient();
            //create/get table reference
            CloudTable table = cloudTable.GetTableReference("customers");
            table.CreateIfNotExists();

            //add the entity
            //CreateCustomer(table, new CustomerUs("vipin2", "vipin2.bhardwaj4487@gmail.com"));

            //GetCustomer(table, "US", "vipin.bhardwaj4487@gmail.com");

            GetAllCustomer(table);

            Console.ReadKey();
        }

        static void CreateCustomer(CloudTable table, CustomerUs customer)
        {
            TableOperation operation = TableOperation.Insert(customer);
            table.Execute(operation);
        }

        static void GetCustomer(CloudTable table, string partitionkey, string rowkey)
        {
            TableOperation operation = TableOperation.Retrieve<CustomerUs>(partitionkey, rowkey);
            TableResult result = table.Execute(operation);
            Console.WriteLine(((CustomerUs)result.Result).Name);
        }

        static void GetAllCustomer(CloudTable table)
        {
            TableQuery<CustomerUs> query = new TableQuery<CustomerUs>().Where(TableQuery.GenerateFilterCondition("PartitionKey", QueryComparisons.Equal, "US"));
            foreach (CustomerUs customer in table.ExecuteQuery(query))
            {
                Console.WriteLine(customer.Name);
            }

        }
    }
}
