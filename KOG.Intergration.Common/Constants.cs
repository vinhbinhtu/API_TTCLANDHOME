namespace KOG.Intergration.Common
{
    public struct Constants
    {
        public const string ADMIN_AUTH = "Admin";

        public const string USER_AUTH = "User";

        public const int ADMIN_ROLE_KEY = 1;

        public const int USER_ROLE_KEY = 2;
        public const string Entry = "_Entry";
        public const string Users = "_Users";

        public struct SyncType
        {
            public const int NewRecord = 0;

            public const int SyncRecord = 1;

            public const int UpdateRecord = 2;

            public const int Cancel = 3;
        }

        public struct DefaultValues
        {
            public const int MillisecondsTimeout = 2000;
            public const string No = "0";
            public const string Yes = "1";
            public const string KeyGenerateCode = "S01";
            public const string ParentDivisionCodeRosy = "A00";
            public const string DivisionCodeRosy = "A01";
            public const string BusinessUnitCode = "SAN";
            public const string EmployeeCode = "KD";
            public const string ProjectCode = "SP";
            public const string BatchRelease = "SP";
            public const string Customer = "KHACHHANG";
            public const string CurrencyCode = "VND";
            public const string ProductAvailable = "xây sẵn";
            public const string ProductInFuture = "NHTTTL";
            public const string ReservationCode = "QLDC";
            public const string DepositCode = "QLDC";
            public const string CashReceiptVoucher = "PT";
            public const string BankReceiptVoucher = "BC";
            public const string CashPaymentVoucher = "PC";
            public const string BankPaymentVoucher = "BN";
            public const string ContractTransfer = "HDCN";
            public const string ContractService = "HDKT";
            public const int MaxPaymentTime = 20;

            public struct AccountingEntry
            {
                public const string Deposit = "33881";
            }

            public struct PostedValues
            {
                public const int Draft = 0;
                public const int Posted = 1;
            }

            public struct ContractTypeValues
            {
                public const int Normal = 1;
                public const int BuyOrLoan = 2;
            }

            public struct ContractStatusCodeValues
            {
                public const int Processing = 1;
                public const int CancelOrLiquidation = 2;
                public const int ReBrokerage = 3;
                public const int Deposit = 4;
            }
        }
    }
}