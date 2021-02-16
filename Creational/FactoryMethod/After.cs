using System;

namespace DesignPatterns.FactoryMethodPattern.Refactore.After
{
    #region Sample1
    public interface ICarSupplier
    {
        string CarColor { get; }

        void GetCarModel();
    }

    class Honda : ICarSupplier
    {
        public string CarColor
        {
            get { return "RED"; }
        }

        public void GetCarModel() =>
            Console.WriteLine("Honda Car Model is Honda 2014");
    }
    class BMW : ICarSupplier
    {
        public string CarColor
        {
            get { return "WHITE"; }
        }

        public void GetCarModel() =>
            Console.WriteLine("BMW Car Model is BMW 2000");
    }

    class Nano : ICarSupplier
    {
        public string CarColor
        {
            get { return "YELLOW"; }
        }
        public void GetCarModel() =>
            Console.WriteLine("Nano Car Model is Nano 2016");
    }

    class Suzuki : ICarSupplier
    {
        public string CarColor
        {
            get { return "Orange"; }
        }
        public void GetCarModel()
        {
            Console.WriteLine("Suzuki Car Model is Suzuki 2006");
        }
    }

    static class CarFactory
    {
        public static ICarSupplier GetCarInstance(int Id)
        {
            switch (Id)
            {
                case 0:
                    return new Honda();
                case 1:
                    return new BMW();
                case 2:
                    return new Nano();
                case 3:
                    return new Suzuki();
                // case 4:
                //  ....
                default:
                    return null;
            }
        }
    }
    #endregion

    #region Sample2
    public interface CreditCard
    {
        string GetCardType();

        int GetCreditLimit();

        int GetAnnualCharge();
    }

    class MoneyBack : CreditCard
    {
        public string GetCardType() =>
            "MoneyBack";

        public int GetCreditLimit() =>
            15000;

        public int GetAnnualCharge() =>
            500;
    }

    public class Titanium : CreditCard
    {
        public string GetCardType() =>
            "Titanium Edge";

        public int GetCreditLimit() =>
            25000;

        public int GetAnnualCharge() =>
            1500;
    }

    public class Platinum : CreditCard
    {
        public string GetCardType() =>
            "Platinum Plus";

        public int GetCreditLimit() =>
            35000;

        public int GetAnnualCharge() =>
            2000;
    }

    class CreditCardFactory
    {
        public static CreditCard GetCreditCard(string cardType)
        {
            CreditCard cardDetails = null;

            if (cardType == "MoneyBack")
            {
                cardDetails = new MoneyBack();
            }
            else if (cardType == "Titanium")
            {
                cardDetails = new Titanium();
            }
            else if (cardType == "Platinum")
            {
                cardDetails = new Platinum();
            }

            return cardDetails;
        }
    }
    #endregion
    class ClientProgram
    {
        static void Main(string[] args)
        {
            #region Sample1
            var objCarSupplier = CarFactory.GetCarInstance(3);
            objCarSupplier.GetCarModel();
            Console.WriteLine("And Color is " + objCarSupplier.CarColor);
            #endregion

            #region Sample2
            CreditCard cardDetails = CreditCardFactory.GetCreditCard("Platinum");

            if (cardDetails != null)
            {
                Console.WriteLine("CardType : " + cardDetails.GetCardType());
                Console.WriteLine("CreditLimit : " + cardDetails.GetCreditLimit());
                Console.WriteLine("AnnualCharge :" + cardDetails.GetAnnualCharge());
            }
            else
            {
                Console.Write("Invalid Card Type");
            }
            #endregion

            Console.ReadLine();
        }
    }
}