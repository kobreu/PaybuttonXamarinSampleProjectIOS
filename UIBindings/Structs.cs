using System;
using System.Runtime.InteropServices;
using ObjCRuntime;



[Native]
public enum MPUTransactionResult : long
{
    Approved = 0,
    Failed
}

[Native]
public enum MPUPrintReceiptResult : long
{
    Successful = 0,
    Failed
}

[Native]
public enum MPULoginResult : long
{
    Successful = 0,
    Failed
}

[Native]
public enum MPUApplicationName : long
{
    Mcashier = 0,
    Concardis,
    SecureRetail,
    YourBrand,
    Barclaycard
}

[Native]
public enum MPUMposUiConfigurationSignatureCapture : long
{
    Screen = 0,
    Receipt
}

[Native]
public enum MPUMposUiConfigurationSummaryFeature : long
{
    None = 0,
    SendReceiptViaEmail = 1 << 0,
    PrintReceipt = 1 << 1,
    RefundTransaction = 1 << 2,
    CaptureTransaction = 1 << 3
}

[Native]
public enum MPUMposUiConfigurationResultDisplayBehavior : long
{
    DisplayIndefinitely,
    CloseAfterTimeout
}

[Native]
public enum MPUMposUiConfigurationPaymentMethod : long
{
    Card = 1 << 0,
    WalletAlipay = 1 << 1
}