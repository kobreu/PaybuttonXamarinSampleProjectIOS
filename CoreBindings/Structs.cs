using System;
using System.Runtime.InteropServices;
using ObjCRuntime;


namespace MPOS {

   /* [Native]
    public enum MPProviderMode : ulong
    {
        Unknown = 0,
        Live,
        Test,
        Mock,
        Jungle,
        LiveFixed,
        TestFixed
    }*/
}

[Native]
public enum MPProviderMode : long
{   
    Unknown = 0,
    Live,
    Test,
    Mock,
    Jungle,
    LiveFixed,
    TestFixed
}

[Native]
public enum MPTransactionParametersType : long
{
    Charge,
    Refund,
    Capture,
    TipAdjust
}

[Native]
public enum MPCurrency : long
{
    /** An unknown currency. Is actually part of the ISO standard, but should be treated as an error. */
    Unknown,
    /** United Arab Emirates Dirham */
    EUR 
}

[Native]
    public enum MPAccessoryFamily : long
    {

        /** Use a mock */
        Mock = 0,

        /** Use the Miura MPI devices  */
        MiuraMPI,

        /** Use the Verifone e-Series (except e105) */
        VerifoneESeries,
        /** Use the Verifone e-Series (except e105) that runs VIPA*/
        VerifoneVIPA,
        /** Use the Verifone e105 */
        VerifoneE105,

        /** Use the Sewoo printer */
        Sewoo,

        /** Use the BBPOS WisePad or WisePOS */
        BBPOS,
        /** Use the BBPOS Chipper */
        BBPOSChipper
    }

