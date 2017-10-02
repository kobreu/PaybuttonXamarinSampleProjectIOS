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
}

namespace MPOS
{


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
        [Export("details", ArgumentSemantic.Strong)]
        MPTransactionProcessDetails Details { get; }

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
        [Export("continueWithSelectedApplication:")]
        void ContinueWithSelectedApplication(MPApplicationInformation application);

        // -(void)continueCreditDebitSelectionWithCredit;
        [Export("continueCreditDebitSelectionWithCredit")]
        void ContinueCreditDebitSelectionWithCredit();

        // -(void)continueCreditDebitSelectionWithDebit;
        [Export("continueCreditDebitSelectionWithDebit")]
        void ContinueCreditDebitSelectionWithDebit();

        // -(BOOL)requestAbort;
        [Export("requestAbort")]
        [Verify(MethodToProperty)]
        bool RequestAbort { get; }

        // -(BOOL)canBeAborted;
        [Export("canBeAborted")]
        [Verify(MethodToProperty)]
        bool CanBeAborted { get; }
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
    delegate void MPTransactionParametersOptionalsBlock(IMPTransactionParametersOptionals arg0);

    // @protocol MPTransactionParametersOptionals <MPTransactionParametersChargeOptionals>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMPTransactionParametersOptionals : MPTransactionParametersChargeOptionals
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
