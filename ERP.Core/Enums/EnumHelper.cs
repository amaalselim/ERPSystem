namespace ERP.Domain.Enums
{
    public static class EnumHelper
    {
        public enum eUnit
        {
            peice = 1,
            Meter,
            Liter,
            Gallon,
            Unit,
            Box,
            KG
        }
        public enum eCurrency
        {
            EGP = 1,
            USD,
            KWD
        }
        public enum ePaymentMethod
        {
            Cash = 1,
            BankTransfer,
            Delayed
        }
    }
}
