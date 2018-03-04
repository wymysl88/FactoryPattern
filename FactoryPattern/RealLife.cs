using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactoryPattern
{
    public enum EPaymentMethod
    {
        BANK_ONE,
        BANK_TWO
    }

    public interface IPaymentGateway
    {
        void MakePayment(Product product);
    }

    public class Product
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
    }

    public class BankOne : IPaymentGateway
    {
        public void MakePayment(Product product)
        {
            Console.WriteLine("Pierwszy rodzaj płatności za {0}, kwota {1}", product.Name, product.Price);
        }
    }

    public class BankTwo : IPaymentGateway
    {
        public void MakePayment(Product product)
        {
            Console.WriteLine("Drugi rodzaj płatności za {0}, kwota {1}", product.Name, product.Price);
        }
    }

    public class PaymentGatewayFactory
    {
        public virtual IPaymentGateway CreatePaymentGateway(EPaymentMethod method, Product prod)
        {
            IPaymentGateway gateway = null;

            switch (method)
            {
                case EPaymentMethod.BANK_ONE:
                    gateway = new BankOne();
                    break;
                case EPaymentMethod.BANK_TWO:
                    gateway = new BankTwo();
                    break;
                default:
                    break;
            }

            return gateway;
        }
    }

    public class PaymentProcessor
    {
        IPaymentGateway gateway = null;

        public void MakePayment(EPaymentMethod method, Product product)
        {
            PaymentGatewayFactory factory = new PaymentGatewayFactory();
            this.gateway = factory.CreatePaymentGateway(method, product);
            this.gateway.MakePayment(product);
        }
    }
}
