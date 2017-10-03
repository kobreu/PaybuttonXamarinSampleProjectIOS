using System;
using CoreFoundation;
using Foundation;
using ObjCRuntime;
using UIKit;



namespace MPOS
{

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
    public enum MPCurrency : ulong
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

}

namespace MPOS
{


    // @interface MPAccessory
    [BaseType(typeof(NSObject))]
    interface MPAccessory
    {
        // @property (readonly, assign, nonatomic) int type;
        [Export("type")]
        int Type { get; }

        // @property (readonly, nonatomic, strong) MPAccessoryDetails * _Nonnull details;
        // [Export("details", ArgumentSemantic.Strong)]
        // MPAccessoryDetails Details { get; }

        // @property (readonly, assign, nonatomic) int connectionType;
        [Export("connectionType")]
        int ConnectionType { get; }

        // @property (readonly, nonatomic, strong) MPAccessoryParameters * _Nonnull parameters;
        [Export("parameters", ArgumentSemantic.Strong)]
        MPAccessoryParameters Parameters { get; }

        // @property (readonly, assign, nonatomic) int connectionState;
        [Export("connectionState")]
        int ConnectionState { get; }

        // @property (readonly, assign, nonatomic) int batteryState;
        [Export("batteryState")]
        int BatteryState { get; }

        // @property (readonly, assign, nonatomic) int batteryLevel;
        [Export("batteryLevel")]
        int BatteryLevel { get; }

        // @property (readonly, assign, nonatomic) int state;
        [Export("state")]
        int State { get; }

        // @property (readonly, assign, nonatomic) int components;
        [Export("components")]
        int Components { get; }

        // -(MPAccessoryComponent * _Nullable)componentForType:(id)component;
        // [Export("componentForType:")]
        // [return: NullAllowed]
        // MPAccessoryComponent ComponentForType(NSObject component);
    }

    // @interface MPAccessoryParameters : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryParameters
    {
        // @property (readonly, assign, nonatomic) int accessoryFamily;
        [Export("accessoryFamily")]
        int AccessoryFamily { get; }

        // @property (readonly, assign, nonatomic) int connectionType;
        [Export("connectionType")]
        int ConnectionType { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * _Nullable filters;
        [NullAllowed, Export("filters", ArgumentSemantic.Strong)]
        NSDictionary Filters { get; }

        // @property (readonly, assign, nonatomic) int locale;
        [Export("locale")]
        int Locale { get; }

        // @property (readonly, assign, nonatomic) BOOL keepAlive;
        [Export("keepAlive")]
        bool KeepAlive { get; }

        // +(instancetype _Nonnull)mockAccessoryParameters;
        [Static]
        [Export("mockAccessoryParameters")]
        MPAccessoryParameters MockAccessoryParameters();

        // +(instancetype _Nonnull)externalAccessoryParametersWithFamily:(id)family protocol:(NSString * _Nonnull)protocol optionals:(MPExternalAccessoryOptionalsBlock _Nullable)optionalsBlock;
        [Static]
        [Export("externalAccessoryParametersWithFamily:protocol:optionals:")]
        MPAccessoryParameters ExternalAccessoryParametersWithFamily(MPAccessoryFamily family, string protocol, [NullAllowed] MPExternalAccessoryOptionalsBlock optionalsBlock);
    }

    // @interface MPTransaction
    [BaseType(typeof(NSObject))]
    interface MPTransaction
    {
        // @property (readonly, nonatomic, strong) int * _Nonnull amount;
       // [Export("amount", ArgumentSemantic.Strong)]
       // unsafe int* Amount { get; }

        // @property (readonly, assign, nonatomic) int currency;
        [Export("currency")]
        int Currency { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable subject;
       // [NullAllowed, Export("subject", ArgumentSemantic.Strong)]
      //  unsafe int* Subject { get; }

        // @property (readonly, nonatomic, strong) int * _Nonnull statementDescriptor;
      //  [Export("statementDescriptor", ArgumentSemantic.Strong)]
      //  unsafe int* StatementDescriptor { get; }

        // @property (readonly, assign, nonatomic) int type;
        [Export("type")]
        int Type { get; }

        // @property (readonly, assign, nonatomic) int mode;
        [Export("mode")]
        int Mode { get; }

        // @property (readonly, assign, nonatomic) int captured;
        [Export("captured")]
        int Captured { get; }

        // @property (readonly, nonatomic, strong) MPPaymentDetails * _Nonnull paymentDetails;
        //[Export("paymentDetails", ArgumentSemantic.Strong)]
        //MPPaymentDetails PaymentDetails { get; }

        // @property (readonly, nonatomic, strong) MPRefundDetails * _Nonnull refundDetails;
        //[Export("refundDetails", ArgumentSemantic.Strong)]
       // MPRefundDetails RefundDetails { get; }

        // @property (readonly, nonatomic, strong) MPClearingDetails * _Nonnull clearingDetails;
        //[Export("clearingDetails", ArgumentSemantic.Strong)]
        //MPClearingDetails ClearingDetails { get; }

        // @property (readonly, nonatomic, strong) MPCardDetails * _Nonnull cardDetails;
        //[Export("cardDetails", ArgumentSemantic.Strong)]
        //MPCardDetails CardDetails { get; }

        // @property (readonly, nonatomic, strong) MPShopperDetails * _Nonnull shopperDetails;
        //[Export("shopperDetails", ArgumentSemantic.Strong)]
        //MPShopperDetails ShopperDetails { get; }

        // @property (readonly, nonatomic, strong) MPTransactionDetails * _Nonnull details;
        //[Export("details", ArgumentSemantic.Strong)]
        //MPTransactionDetails Details { get; }

        // @property (readonly, assign, nonatomic) int status;
        [Export("status")]
        int Status { get; }

        // @property (readonly, nonatomic, strong) MPStatusDetails * _Nullable statusDetails;
        //[NullAllowed, Export("statusDetails", ArgumentSemantic.Strong)]
        //MPStatusDetails StatusDetails { get; }

        // @property (readonly, assign, nonatomic) int state;
        [Export("state")]
        int State { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable error;
       // [NullAllowed, Export("error", ArgumentSemantic.Strong)]
      //  unsafe int* Error { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable sessionIdentifier;
       // [NullAllowed, Export("sessionIdentifier", ArgumentSemantic.Strong)]
      //  unsafe int* SessionIdentifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable identifier;
      //  [NullAllowed, Export("identifier", ArgumentSemantic.Strong)]
      //  unsafe int* Identifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable groupIdentifier;
      //  [NullAllowed, Export("groupIdentifier", ArgumentSemantic.Strong)]
      //  unsafe int* GroupIdentifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable referencedTransactionIdentifier;
       // [NullAllowed, Export("referencedTransactionIdentifier", ArgumentSemantic.Strong)]
      //  unsafe int* ReferencedTransactionIdentifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable customIdentifier;
      //  [NullAllowed, Export("customIdentifier", ArgumentSemantic.Strong)]
      //  unsafe int* CustomIdentifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable created;
      //  [NullAllowed, Export("created", ArgumentSemantic.Strong)]
      //  unsafe int* Created { get; }

        // -(id)canBeAborted;
        [Export("canBeAborted")]
        bool CanBeAborted(); 

        // @property (readonly, nonatomic, strong) MPProcessingDetails * _Nonnull processingDetails;
        //[Export("processingDetails", ArgumentSemantic.Strong)]
        //MPProcessingDetails ProcessingDetails { get; }

        // @property (readonly, nonatomic, strong) MPReceipt * _Nullable customerReceipt;
        //[NullAllowed, Export("customerReceipt", ArgumentSemantic.Strong)]
        //MPReceipt CustomerReceipt { get; }

        // @property (readonly, nonatomic, strong) MPReceipt * _Nullable merchantReceipt;
        //[NullAllowed, Export("merchantReceipt", ArgumentSemantic.Strong)]
        //MPReceipt MerchantReceipt { get; }
    }





    // @interface MPTransactionProcess : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionProcess
    {
        // @property (readonly, nonatomic, strong) MPTransactionProvider * _Nullable provider;
        [NullAllowed, Export("provider", ArgumentSemantic.Strong)]
        MPTransactionProvider Provider { get; }

        // @property (readonly, nonatomic, strong) MPTransaction * _Nullable transaction;
        [NullAllowed, Export("transaction", ArgumentSemantic.Strong)]
        MPTransaction Transaction { get; }

        // @property (readonly, nonatomic, strong) MPAccessory * _Nullable accessory;
        [NullAllowed, Export("accessory", ArgumentSemantic.Strong)]
        MPAccessory Accessory { get; }

        // @property (readonly, nonatomic, strong) MPTransactionProcessDetails * _Nonnull details;
       // [Export("details", ArgumentSemantic.Strong)]
       // MPTransactionProcessDetails Details { get; }

        // -(void)continueWithCustomerSignature:(UIImage * _Nullable)signature verified:(BOOL)verified;
        [Export("continueWithCustomerSignature:verified:")]
        void ContinueWithCustomerSignature([NullAllowed] UIImage signature, bool verified);

        // -(void)continueWithCustomerSignatureOnReceipt;
        [Export("continueWithCustomerSignatureOnReceipt")]
        void ContinueWithCustomerSignatureOnReceipt();

        // -(void)continueWithCustomerIdentityVerified:(BOOL)verified;
        [Export("continueWithCustomerIdentityVerified:")]
        void ContinueWithCustomerIdentityVerified(bool verified);

        // -(void)continueWithSelectedApplication:(MPApplicationInformation * _Nonnull)application;
       // [Export("continueWithSelectedApplication:")]
      //  void ContinueWithSelectedApplication(MPApplicationInformation application);

        // -(void)continueCreditDebitSelectionWithCredit;
        [Export("continueCreditDebitSelectionWithCredit")]
        void ContinueCreditDebitSelectionWithCredit();

        // -(void)continueCreditDebitSelectionWithDebit;
        [Export("continueCreditDebitSelectionWithDebit")]
        void ContinueCreditDebitSelectionWithDebit();

        // -(BOOL)requestAbort;
        [Export("requestAbort")]
        bool RequestAbort();

        // -(BOOL)canBeAborted;
        [Export("canBeAborted")]
        bool CanBeAborted();
    }

    // @interface MPTransactionActionSupport : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionActionSupport
    {
    }

    // @protocol MPExternalAccessoryOptionals <MPAccessoryOptionals>
    [Protocol, Model]
    [BaseType(typeof(MPAccessoryOptionals))]
    interface MPExternalAccessoryOptionals
    {
        // @required @property (nonatomic) NSString * _Nullable namePrefix;
        [Abstract]
        [NullAllowed, Export("namePrefix")]
        string NamePrefix { get; set; }
    }

    // @protocol MPAccessoryOptionals <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPAccessoryOptionals
    {
        // @required @property (nonatomic) NSArray * _Nullable idleText;
        [Abstract]
        [NullAllowed, Export("idleText", ArgumentSemantic.Assign)]
        NSString[] IdleText { get; set; }

        // @required @property (nonatomic) int locale;
        [Abstract]
        [Export("locale")]
        int Locale { get; set; }

        // @required @property (nonatomic) BOOL keepAlive;
        [Abstract]
        [Export("keepAlive")]
        bool KeepAlive { get; set; }
    }

    // typedef void (^MPExternalAccessoryOptionalsBlock)(id<MPExternalAccessoryOptionals> _Nonnull);
    delegate void MPExternalAccessoryOptionalsBlock(MPExternalAccessoryOptionals arg0);

    // typedef void (^MPTransactionProcessRegistered)(MPTransactionProcess * _Nonnull, MPTransaction * _Nonnull);
    delegate void MPTransactionProcessRegistered(MPTransactionProcess arg0, MPTransaction arg1);

    // typedef void (^MPTransactionProcessStatusChanged)(MPTransactionProcess * _Nonnull, MPTransaction * _Nullable, MPTransactionProcessDetails * _Nonnull);
    delegate void MPTransactionProcessStatusChanged(MPTransactionProcess arg0, [NullAllowed] MPTransaction arg1, MPTransactionProcessDetails arg2);

    // typedef void (^MPTransactionProcessActionRequired)(MPTransactionProcess * _Nonnull, MPTransaction * _Nonnull, int, MPTransactionActionSupport * _Nullable);
    delegate void MPTransactionProcessActionRequired(MPTransactionProcess arg0, MPTransaction arg1, int arg2, [NullAllowed] MPTransactionActionSupport arg3);

    // typedef void (^MPTransactionProcessCompleted)(MPTransactionProcess * _Nonnull, MPTransaction * _Nullable, MPTransactionProcessDetails * _Nonnull);
    delegate void MPTransactionProcessCompleted(MPTransactionProcess arg0, [NullAllowed] MPTransaction arg1, MPTransactionProcessDetails arg2);



    // @interface MPTransactionProcessDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionProcessDetails
    {
        // @property (readonly, assign, nonatomic) MPTransactionProcessDetailsState state;
       // [Export("state", ArgumentSemantic.Assign)]
      //  MPTransactionProcessDetailsState State { get; }

        // @property (readonly, assign, nonatomic) MPTransactionProcessDetailsStateDetails stateDetails;
       // [Export("stateDetails", ArgumentSemantic.Assign)]
       // MPTransactionProcessDetailsStateDetails StateDetails { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull information;
        [Export("information", ArgumentSemantic.Strong)]
        NSString[] Information { get; }

        // @property (readonly, nonatomic, strong) NSError * _Nullable error;
      //  [NullAllowed, Export("error", ArgumentSemantic.Strong)]
      //  NSError Error { get; }
    }


    [BaseType(typeof(NSObject))]
    interface MPTransactionProvider
    {

        // -(MPTransactionProcess * _Nonnull)startTransactionWithParameters:(MPTransactionParameters * _Nonnull)transactionParameters accessoryParameters:(MPAccessoryParameters * _Nonnull)accessoryParameters registered:(MPTransactionProcessRegistered _Nonnull)registered statusChanged:(MPTransactionProcessStatusChanged _Nonnull)statusChanged actionRequired:(MPTransactionProcessActionRequired _Nonnull)actionRequired completed:(MPTransactionProcessCompleted _Nonnull)completed;
        [Export("startTransactionWithParameters:accessoryParameters:registered:statusChanged:actionRequired:completed:")]
        MPTransactionProcess StartTransactionWithParameters(MPTransactionParameters transactionParameters, MPAccessoryParameters accessoryParameters, MPTransactionProcessRegistered registered, MPTransactionProcessStatusChanged statusChanged, MPTransactionProcessActionRequired actionRequired, MPTransactionProcessCompleted completed);
    }

    // @interface MPMpos : NSObject
    [BaseType(typeof(NSObject))]
    interface MPMpos
    {


        // +(NSString * _Nonnull)version;
        [Static]
        [Export("version")]
        string Version { get; }

        // +(NSString * _Nonnull)build;
        [Static]
        [Export("build")]
        string Build { get; }

        // +(MPTransactionProvider * _Nonnull)transactionProviderForMode:(MPProviderMode)mode merchantIdentifier:(NSString * _Nonnull)merchantIdentifier merchantSecretKey:(NSString * _Nonnull)merchantSecretKey;
        [Static]
        [Export("transactionProviderForMode:merchantIdentifier:merchantSecretKey:")]
        MPTransactionProvider TransactionProviderForMode(MPProviderMode mode, string merchantIdentifier, string merchantSecretKey);
    }

    // @interface MPTransactionParameters : NSObject <NSCopying>
    [BaseType(typeof(NSObject))]
    interface MPTransactionParameters : INSCopying
    {
        // @property (readonly, assign, nonatomic) int transactionType;
        [Export("transactionType")]
        int TransactionType { get; }

        // @property (readonly, copy, nonatomic) NSDecimalNumber * _Nullable amount;
        [NullAllowed, Export("amount", ArgumentSemantic.Copy)]
        NSDecimalNumber Amount { get; }

        // @property (readonly, assign, nonatomic) int currency;
        [Export("currency")]
        int Currency { get; }

        // @property (readonly, assign, nonatomic) BOOL autoCapture;
        [Export("autoCapture")]
        bool AutoCapture { get; }

        // @property (readonly, assign, nonatomic) BOOL tipAdjustable;
        [Export("tipAdjustable")]
        bool TipAdjustable { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable referencedTransactionIdentifier;
        [NullAllowed, Export("referencedTransactionIdentifier")]
        string ReferencedTransactionIdentifier { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable referencedCustomIdentifier;
        [NullAllowed, Export("referencedCustomIdentifier")]
        string ReferencedCustomIdentifier { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable subject;
        [NullAllowed, Export("subject")]
        string Subject { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable customIdentifier;
        [NullAllowed, Export("customIdentifier")]
        string CustomIdentifier { get; }

        // @property (readonly, copy, nonatomic) NSString * _Nullable statementDescriptor;
        [NullAllowed, Export("statementDescriptor")]
        string StatementDescriptor { get; }

        // @property (readonly, copy, nonatomic) NSDecimalNumber * _Nullable applicationFee;
        [NullAllowed, Export("applicationFee", ArgumentSemantic.Copy)]
        NSDecimalNumber ApplicationFee { get; }

        // @property (readonly, copy, nonatomic) NSDecimalNumber * _Nullable includedTipAmount;
        [NullAllowed, Export("includedTipAmount", ArgumentSemantic.Copy)]
        NSDecimalNumber IncludedTipAmount { get; }

        // @property (readonly, copy, nonatomic) NSDictionary * _Nullable metadata;
        [NullAllowed, Export("metadata", ArgumentSemantic.Copy)]
        NSDictionary Metadata { get; }

        // @property (readonly, assign, nonatomic) MPTransactionParametersType parametersType;
        [Export("parametersType", ArgumentSemantic.Assign)]
        MPTransactionParametersType ParametersType { get; }

        // +(instancetype _Nonnull)chargeWithAmount:(NSDecimalNumber * _Nonnull)amount currency:(id)currency optionals:(MPTransactionParametersOptionalsBlock _Nullable)optionalsBlock;
        [Static]
        [Export("chargeWithAmount:currency:optionals:")]
        MPTransactionParameters ChargeWithAmount(NSDecimalNumber amount, MPCurrency currency, [NullAllowed] MPTransactionParametersOptionalsBlock optionalsBlock);

        // -(void)updateIncludedTipAmount:(NSDecimalNumber * _Nonnull)tipAmount;
        [Export("updateIncludedTipAmount:")]
        void UpdateIncludedTipAmount(NSDecimalNumber tipAmount);

        // -(void)updateAmountWithAmountIncludingTip:(NSDecimalNumber * _Nonnull)amountIncludingTip;
        [Export("updateAmountWithAmountIncludingTip:")]
        void UpdateAmountWithAmountIncludingTip(NSDecimalNumber amountIncludingTip);
    }

    // typedef void (^MPTransactionParametersOptionalsBlock)(id<MPTransactionParametersOptionals> _Nonnull);
    delegate void MPTransactionParametersOptionalsBlock(MPTransactionParametersOptionals arg0);

    // @protocol MPTransactionParametersOptionals <MPTransactionParametersChargeOptionals>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPTransactionParametersOptionals : MPTransactionParametersChargeOptionals
    {
    }

    // @protocol MPTransactionParametersChargeOptionals <MPTransactionParametersBasicOptionals>
    [Protocol, Model]
    interface MPTransactionParametersChargeOptionals : MPTransactionParametersBasicOptionals
    {
        // @required @property (nonatomic) NSDecimalNumber * _Nullable includedTipAmount;
        [Abstract]
        [NullAllowed, Export("includedTipAmount", ArgumentSemantic.Assign)]
        NSDecimalNumber IncludedTipAmount { get; set; }

        // @required @property (assign, nonatomic) BOOL autoCapture;
        [Abstract]
        [Export("autoCapture")]
        bool AutoCapture { get; set; }

        // @required @property (assign, nonatomic) BOOL tipAdjustable;
        [Abstract]
        [Export("tipAdjustable")]
        bool TipAdjustable { get; set; }
    }

    // @protocol MPTransactionParametersBasicOptionals <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPTransactionParametersBasicOptionals
    {
        // @required @property (nonatomic) NSString * _Nullable subject;
        [Abstract]
        [NullAllowed, Export("subject")]
        string Subject { get; set; }

        // @required @property (nonatomic) NSString * _Nullable customIdentifier;
        [Abstract]
        [NullAllowed, Export("customIdentifier")]
        string CustomIdentifier { get; set; }

        // @required @property (nonatomic) NSString * _Nullable statementDescriptor;
        [Abstract]
        [NullAllowed, Export("statementDescriptor")]
        string StatementDescriptor { get; set; }

        // @required @property (nonatomic) NSDecimalNumber * _Nullable applicationFee;
        [Abstract]
        [NullAllowed, Export("applicationFee", ArgumentSemantic.Assign)]
        NSDecimalNumber ApplicationFee { get; set; }

        // @required @property (nonatomic) NSDictionary * _Nullable metadata;
        [Abstract]
        [NullAllowed, Export("metadata", ArgumentSemantic.Assign)]
        NSDictionary Metadata { get; set; }
    }

}
