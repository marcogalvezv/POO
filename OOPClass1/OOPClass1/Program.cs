using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPClass1
{
    interface IProduct {
        float GetPrice();
        string GetDescription();
    }
    struct Customer
    {
        public string name;
        public long nit;

        private void test()
        {
            Console.WriteLine("test");
        }
    }

    class Milk : IProduct
    {
        public float price;
        public DateTime expiredDate;
        public string description;

        public string GetDescription()
        {
            return description + " " + expiredDate.ToLongDateString();
        }

        public float GetPrice()
        {
            return price;
        }
    }
    class Meat : IProduct
    {
        public float priceByKilogram;
        public string description;
        public float weigth;

        public string GetDescription()
        {
            return string.Format("price by kilogram: {0} Weigth: {1}", priceByKilogram, weigth, weigth * priceByKilogram);
        }

        public float GetPrice()
        {
            return weigth * priceByKilogram;
        }
    }

    struct Receipt
    {
        Customer customer;
        public List<IProduct> items;

        public Receipt(Customer customer)
        {
            this.customer = customer;
            items = new List<IProduct>();
        }
        public void print()
        {
            float total = 0.0F;
            Console.WriteLine("Nombre: {0} \t Nit: {1}", customer.name, customer.nit);
            foreach (var item in items)
            {
                Console.WriteLine("{0} \t {1}", item.GetDescription(), item.GetPrice() );
                total = total + item.GetPrice();

                //if (item is Milk)
                //{
                //    Console.WriteLine("{0} \t {1}",((Milk)item).description, ((Milk)item).price);
                //    total = total + ((Milk)item).price;
                //}

                //if (item is Meat)
                //{
                //    Console.WriteLine("{0} \t {1}", ((Meat)item).description, ((Meat)item).priceByKilogram);
                //    total = total + ((Meat)item).priceByKilogram * ((Meat)item).weigth;
                //}
            }
            Console.WriteLine("Total {0}", total);
        }
    }





    class Program
    {
        static void Main(string[] args)
        {
            Customer marcoCustomer = new Customer();
            marcoCustomer.name = "Marco";
            marcoCustomer.nit = 1233243;

            Milk regularPilMilk = new Milk();
            regularPilMilk.price = 7.0F;
            regularPilMilk.description = "Leche Pil Natural";
            regularPilMilk.expiredDate = new DateTime(2018, 9, 13);

            Meat chuletaMeat = new Meat() { description = "Chuleta", priceByKilogram = 24.0F, weigth = 5 };

            Receipt receipt = new Receipt(marcoCustomer);
            receipt.items.Add(regularPilMilk);
            receipt.items.Add(chuletaMeat);

            receipt.print();
            
        }
    }
}
