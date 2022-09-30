using System.Runtime.Serialization;

namespace Mainumbi.Wallet;

public static class WalletErrorCodes
{
    //Add your business exception error codes here...
    public static string NotEnoghFunds = "Wallet:00001";

    public static string NotPositive = "Wallet:00002";

    public static string PendingWithrawal = "Wallet:00003";
}
