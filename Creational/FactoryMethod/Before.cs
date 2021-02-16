using System;

namespace DesignPatterns.FactoryMethodPattern.Refactore.Before
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
    #endregion

    class ClientProgram
    {
        static void Main(string[] args)
        {
            #region Sample1
            var objHonda = new Honda();
            objHonda.GetCarModel();

            var objBMW = new BMW();
            objBMW.GetCarModel();

            var objNano = new Nano();
            objNano.GetCarModel();

            // more objects more line of code and ....
            #endregion

            #region Sample2
            //Generally we will get the Card Type from UI.
            //Here we are hardcoded the card type
            string cardType = "MoneyBack";
            CreditCard cardDetails = null;
            //Based of the CreditCard Type we are creating the
            //appropriate type instance using if else condition
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