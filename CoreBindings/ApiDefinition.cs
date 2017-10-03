using System;
using CoreFoundation;
using Foundation;
using ObjCRuntime;
using UIKit;



namespace MPOS
{

    [Native]
    public enum MPTransactionAction : long
    {
        None = 0,
        /** A customer signature must be provided to complete the transaction */
        CustomerSignature = 1 << 0,
        /** The customer must be identified by means of ID check with an official document */
        CustomerIdentification = 1 << 1,
        /** Used to indicate that an application needs to be selected in order to continue with the transaction */
        ApplicationSelection = 1 << 2,
        /** Used to indicate that a credit or debit workflow needs to be selected */
        CreditDebitSelection = 1 << 3,
    }

    [Native]
    public enum MPTransactionType : long
    {
        /** Unknown or not available */
        Unknown = 0,
        /** Debit transaction, where the funds are directly removed from debited from the account */
        Charge,
        /** Refund transaction, where the funds are directly posted to the account */
        Refund,
        /** Preauthorize transaction, where the funds are reserved on the account. Note: just available for mapping purposes and cannot be initiated by the SDK.  */
        Preauthorize,
        /** Credit transaction, where the funds are credited to an account. Note: just available for mapping purposes and cannot be initiated by the SDK. */
        Credit
    }

    [Native]
    public enum MPTransactionStatus : long
    {
        Unknown = 0,
        /** Transaction is initialized and can be started */
        Initialized,
        /** Transaction result is still pending (e.g. not finished or waiting for async workflow) */
        Pending,
        /** Transaction was accepted offline and must be uploaded to be executed by the backend */
        Accepted,
        /** Transaction was approved */
        Approved,
        /** Transaction was declined */
        Declined,
        /** Transaction was aborted (by merchant or shopper) */
        Aborted,
        /** An error occured, see [MPTransaction.error] for more details */
        Error,
        /** The transaction ended in a state that is inconclusive and the SDK cannot derive the outcome (e.g. due to no internet connection). This is a special case of failure. */
        Inconclusive
    }

    [Native]
    public enum MPCurrency : ulong
    {
        /** An unknown currency. Is actually part of the ISO standard, but should be treated as an error. */
        Unknown,
        /** United Arab Emirates Dirham */
        AED,
        /** Argentine Peso */
        ARS,
        /** Australian Dollar */
        AUD,
        /** Azerbaijani Manat */
        AZN,
        /** Bulgarian Lev */
        BGN,
        /** Bahraini Dinar */
        BHD,
        /** Brazilian Real */
        BRL,
        /** Canadian Dollar */
        CAD,
        /** Swiss Franc */
        CHF,
        /** Chinese Yuan */
        CNY,
        /** Colombian Peso */
        COP,
        /** Czech Koruna */
        CZK,
        /** Danish Krone */
        DKK,
        /** Egyptian Pound */
        EGP,
        /** Euro */
        EUR,
        /** Pound Sterling */
        GBP,
        /** Ghanaian Cedi */
        GHS,
        /** Hong Kong Dollars */
        HKD,
        /** Croatian Kuna */
        HRK,
        /** Hungarian Forint */
        HUF,
        /** Israeli New Shekel */
        ILS,
        /** Indian Rupee */
        INR,
        /** Japanese Yen */
        JPY,
        /** South Korean Won */
        KRW,
        /** Kuwaiti Dinar */
        KWD,
        /** Moroccan Dirham */
        MAD,
        /** Mexican Peso */
        MXN,
        /** Malaysian Ringgit */
        MYR,
        /** Nigerian Naira */
        NGN,
        /** Norwegian Krone */
        NOK,
        /** New Zealand Dollar */
        NZD,
        /** Omani Rial */
        OMR,
        /** Philippine Peso */
        PHP,
        /** Pakistani Rupee */
        PKR,
        /** Polish Zloty */
        PLN,
        /** Qatari Rial */
        QAR,
        /** Romanian Leu */
        RON,
        /** Serbian Dinar */
        RSD,
        /** Russian Ruble */
        RUB,
        /** Saudi Riyal */
        SAR,
        /** Swedish Krona */
        SEK,
        /** Singapore Dollar */
        SGD,
        /** Thai Baht */
        THB,
        /** Tunisian Dinar */
        TND,
        /** Turkish Lira */
        TRY,
        /** New Taiwan Dollar */
        TWD,
        /** Ukrainian Hryvnia */
        UAH,
        /** US Dollar */
        USD,
        /** Vietnamese Dong */
        VND,
        /** South African Rand */
        ZAR
    }

    [Native]
    public enum MPTransactionState : long
    {
        /** Unkndown or not available */
        Unknown = 0,
        /** The transaction is waiting to be executed */
        Idle,
        /** The transaction is waiting for the card to be inserted */
        AwaitingCardPresentation,
        /** The card is currently being analyzed */
        AwaitingCardIdentification,
        /** The card requires an application selection by the cardholder */
        AwaitingApplicationSelection,
        /** The card requires credit/debit to be selected */
        AwaitingCreditDebitSelection,
        /** The transaction requires an amount confirmation by the cardholder */
        AwaitingAmountConfirmation,
        /** The transaction requires a PIN to be inserted */
        AwaitingPIN,
        /** The transaction is a being executed with the remote system */
        AwaitingExecution,
        /** The transaction is waiting for the card to be removed */
        AwaitingCardRemoval,
        /** The transaction requires a signature by the cardholder */
        AwaitingSignature,
        /** The transaction requires an identificatio by the cardholder */
        AwaitingIdentification,
        /** The transaction is being finalized with the remote host */
        AwaitingCompletion,
        /** The transaction is in a final state and no changes can be made to it anymore */
        Ended
    }

    [Native]
    public enum MPTransactionMode : long
    {
        /** Transaction was executed and finalized online*/
        Online = 0,
        /** Transaction was executed offline*/
        Offline
    }

    [Native]
    public enum MPAccessoryType : long
    {
        /** Unkndown or not available */
        Unknown = 0,
        /** Mock */
        Mock,

        /** Miura Shuttle */
        MiuraShuttle,
        /** Miura M010 */
        MiuraM010,
        /** Miura M007 */
        MiuraM007,

        /** Verifone E105 */
        VerifoneE105,
        /** Verifone E315 */
        VerifoneE315,
        /** Verifone E335 */
        VerifoneE335,
        /** Verifone E355 */
        VerifoneE355,
        /** Verifone VX820 */
        VerifoneVX820,
        /** Sewoo LKP21 */
        SewooLKP21,

        /** BBPOS WisePad */
        BBPOSWisePad,
        /** BBPOS Chipper */
        BBPOSChipper
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

    [Native]
    public enum MPAccessoryState : long
    {
        /** Unkndown or not available */
        Unknown = 0,
        /** The accessory is unavailable (either unavailable or disconnected) */
        Unavailable,
        /** The accessory is in idle mode */
        Idle,
        /** The accessory currently authenticating against other system */
        Authenticating,
        /** The accessory is currently being updated */
        Updating,
        /** The accessory is currently in use for various operations (e.g a transaction or other onboard fuctionality) */
        Busy,
        /** The accessory is reconnecting*/
        Reconnecting
    }

    [Native]
    public enum MPAccessoryConnectionType : long
    {
        /** Unkndown or not available */
        Unknown = 0,
        /** Connected via Bluetooth or Lightning/Dock connector (MfI program) */
        ExternalAccessory,
        /** Connected via a direct TCP connection */
        TCP,
        /** Connected via the headphone jack of the device */
        AudioJack
    }

    [Native]
    public enum MPAccessoryConnectionState : long
    {
        /** Unkndown or not available */
        Unknown = 0,
        /** The accessory is connected */
        Connected,
        /** The accessory is connected but unavailable (out of range, updating etc.) */
        ConnectedButUnavailable,
        /** The accessory is disconnected */
        Disconnected
    }

    [Native]
    public enum MPAccessoryBatteryState : long
    {
        /** Unkndown or not available */
        Unknown = 0,
        /** The device is unplugged and using the battery */
        Unplugged,
        /** The device is plugged in and charging the battery */
        Charging,
        /** The battery is plugged in and fully charged */
        Full,
        /** The battery level is critical */
        Critical
    }

    [Native]
    public enum MPLocale : long
    {
        _SystemDefault = 0,
        /** German */
        _de_DE,
        /** English */
        _en_US,
        /** French */
        _fr_FR,
        /** Italian */
        _it_IT,
        /** Belgian */
        _nl_BE,
        /** Portuguese */
        _pt_PT,
        /** Spanish */
        _es_ES,
        /** Finnish*/
        _fi_FI,
        /** Polish*/
        _pl_PL,
        /** Swedish */
        _sv_SE
    }

    [Native]
    public enum MPAccessoryComponentType : long
    {
        /** No componenets are available */
        None = 0,
        /** Barcode scanner component available */
        BarcodeScanner = 1 << 0,
        /** Printer component available */
        Printer = 1 << 1,
        /** Log access component available */
        Log = 1 << 2,
        /** Tipping component available*/
        Tipping = 1 << 3,
        /** Interaction component available */
        Interaction = 1 << 4
    }

    [Native]
    public enum MPReceiptLineKey : long
    {
        Unknown,
        ReceiptType,
        TransactionType,
        Subject,
        Identifier,
        AmountAndCurrency,
        IncludedTipAmountAndCurrency,
        Date,
        Time,
        StatusText,
        PaymentDetailsSchemeOrLabel,
        PaymentDetailsMaskedAccount,
        PaymentDetailsSource,
        PaymentDetailsEMVApplicationID,
        PaymentDetailsAccountSequenceNumber,
        PaymentDetailsCustomerVerification,
        ClearingDetailsTransactionIdentifier,
        ClearingDetailsOriginalTransactionIdentifier,
        ClearingDetailsAuthorizationCode,
        ClearingDetailsMerchantId,
        ClearingDetailsTerminalId,
        MerchantDetailsPublicName,
        MerchantDetailsAddress,
        MerchantDetailsZip,
        MerchantDetailsCity,
        MerchantDetailsCountry,
        MerchantDetailsContact,
        MerchantDetailsAdditionalInformation
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
    public enum MPTransactionAbortReason : long
    {
        MerchantAborted = 0,
        AccessoryError,
        AccessoryNotWhitelisted
    }

    [Native]
    public enum MPErrorSource : long
    {
        Unknown = 0,
        Parameter,
        Accessory,
        Transaction,
        Server,
        Sdk,
        Internal
    }

    [Native]
    public enum MPErrorType : long
    {
        Unknown = 0,
        ParameterMissing,
        ParameterInvalid,
        AccessoryNotFound,
        AccessoryNotConnected,
        AccessoryAlreadyConnected,
        AccessoryAlreadyDisconnected,
        AccessoryBusy,
        AccessoryNotWhitelisted,
        AccessoryDeactivated,
        AccessoryRequiresUpdate,
        AccessoryBatteryLow,
        AccessoryTampered,
        AccessoryError,
        AccessoryComponentNotFound,
        AccessoryComponentPrinterBusy,
        AccessoryComponentPrinterPaperLowOrOut,
        AccessoryComponentPrinterCoverOpen,
        TransactionSessionNotFound,
        TransactionReferenceNotFound,
        TransactionInvalid,
        TransactionBusy,
        TransactionNoLongerAbortable,
        TransactionDeclined,
        TransactionAborted,
        TransactionError,
        TransactionActionError,
        OfflineBatchMalformedPendingManualReview,
        ServerUnavailable,
        ServerAuthenticationFailed,
        ServerUnknownUsername,
        ServerPinningWithRemoteFailed,
        ServerTimeout,
        ServerError,
        ServerInvalidResponse,
        SDKResourcesNotFound,
        SDKResourcesModified,
        SDKConfigurationMissing,
        SDKFeatureNotEnabled,
        InternalInconsistency
    }

    [Native]
    public enum MPTransactionStatusDetailsCode : long
    {
        Unknown = 0,
        InitializedAtServer,
        InitializedAtProcessor,
        InitializedWithReplacement,
        PendingWaitingForExecution,
        PendingWaitingForProcessor,
        PendingAwaitingFinalization,
        Approved,
        DeclinedCardOrTerminalDeclined,
        DeclinedProcessor,
        DeclinedInvalidTerminalSoftware,
        DeclinedInvalidTerminalConfiguration,
        DeclinedInvalidTerminal,
        DeclinedSessionExpired,
        DeclinedPinWrong,
        DeclinedPinWrongTooOften,
        DeclinedCardExpired,
        DeclinedCardInvalidScheme,
        DeclinedCardInvalidPan,
        DeclinedCardStolen,
        DeclinedCardUseOriginal,
        DeclinedProcessorExceedsWithdrawalCountLimit,
        DeclinedProcessorUncapturedChargesNotSupported,
        DeclinedProcessorInconsistentState,
        DeclinedMalformedRequest,
        DeclinedManipulationSuspected,
        DeclinedCardBlocked,
        DeclinedInsufficientFunds,
        DeclinedTransactionFrequencyExceeded,
        DeclinedCardLost,
        DeclinedInvalidScheme,
        DeclinedInvalidAmount,
        DeclinedInvalidConfiguration,
        DeclinedDuplicateTransaction,
        DeclinedInvalidWorkflow,
        DeclinedProcessorCardExpired,
        DeclinedProcessorRefundNotPossible,
        DeclinedProcessorTemporarilyBlacklisted,
        DeclinedAmountExceedsLimit,
        AbortedShopperRemovedCard,
        AbortedShopperAborted,
        AbortedMerchantAborted,
        AbortedWaitingForCardTimeout,
        ErrorUnableToPersistOfflineTransaction,
        ErrorOfflineTransactionPendingManualReview,
        ErrorInvalidProcessorFormat,
        ErrorInvalidProcessorStatus,
        ErrorMissingProcessorSession,
        ErrorInvalidProcessorSession,
        ErrorInvalidProcessorNonce,
        ErrorProcessorConnectionError,
        ErrorProcessorFailedInconsistentStateUnresolved,
        ErrorProcessorFailedInconsistentStateResolved,
        ErrorProcessorPaymentDetailsExtractionFailed,
        ErrorProcessorInvalidPaymentDetails,
        ErrorProcessorInvalidConfiguration,
        ErrorProcessorMalformedRequest,
        ErrorProcessorTransactionAlreadyInProgress,
        ErrorProcessorConnectionNoResponse,
        ErrorTerminalError,
        ErrorTerminalTimeout,
        ErrorServerInvalidTransactionType,
        ErrorServerInvalidTransactionStatus,
        ErrorServerMalformedRequest,
        ErrorServerInvalidRefundAmount,
        ErrorServerInvalidTransaction,
        ErrorServerInvalidResponse,
        ErrorServerUnavailable,
        ErrorServerAuthenticationFailed,
        ErrorServerPinningWithRemoteFailed,
        ErrorServerTimeout,
        ErrorServerAccessoryDeactivated,
        ErrorServerAccessoryNotAssignedToMerchant,
        ErrorServerSessionTimeout,
        ErrorApprovedOffline
    }

    [Native]
    public enum MPPaymentDetailsSource : long
    {
        Unknown = 0,
        Manual,
        Icc,
        MagneticStripe,
        MagneticStripeFallback,
        NFCUsingEMV,
        NFCUsingMSD,
        Barcode,
        QRCode
    }

    [Native]
    public enum MPPaymentDetailsScheme : long
    {
        Unknown = 0,
        MasterCard,
        Visa,
        VISAElectron,
        Maestro,
        AmericanExpress,
        Jcb,
        DinersClub,
        Discover,
        UnionPay,
        DiscoverCommonDebit,
        MastercardCommonDebit,
        VisaCommonDebit,
        VisaInterlink,
        GhLink,
        Alipay
    }

    [Native]
    public enum MPPaymentDetailsCustomerVerification : long
    {
        Unknown = 0,
        None,
        Signature,
        Pin,
        PINAndSignature,
        CustomerDevice
    }

    [Native]
    public enum MPRefundDetailsStatus : long
    {
        Unknown = 0,
        NonRefundable,
        RefundablePartialAndFull,
        RefundableFullOnly,
        Refunded
    }

    [Native]
    public enum MPRefundDetailsProcess : long
    {
        Unknown = 0,
        AnyCard = 1 << 0,
        WithoutCard = 1 << 1,
        SameCard = 1 << 2
    }

    [Native]
    public enum MPTransactionTipAdjustStatus : long
    {
        Unknown,
        Adjustable,
        NotAdjustable,
        Adjusted
    }

    [Native]
    public enum MPRefundTransactionCode : long
    {
        Unknown = 0,
        RefundBeforeClearing,
        RefundAfterClearing,
        PartialCapture
    }

    [Native]
    public enum MPPaymentAccessoryFeature : long
    {
        None = 0,
        MagneticStripe = 1 << 0,
        Icc = 1 << 1,
        Nfc = 1 << 2,
        EMVKernel = 1 << 3,
        SREDEncryption = 1 << 4,
        PINEncryption = 1 << 5,
        Keypad = 1 << 6,
        Display = 1 << 7,
        OnlineTransactions = 1 << 8,
        OfflineTransactions = 1 << 9,
        OfflinePIN = 1 << 10,
        AbortWithKey = 1 << 11,
        Refund = 1 << 12,
        StyledScreen = 1 << 13
    }

    [Native]
    public enum MPPaymentAccessoryRequirement : long
    {
        None = 0,
        AmountConfirmation = 1 << 0,
        AuthenticationBeforeUpdate = 1 << 1,
        ManualNFCActivation = 1 << 2,
        ContactlessOnlyWorkaround = 1 << 3
    }

    [Native]
    public enum MPAccessoryUpdateRequirementStatus : long
    {
        NoUpdateAvailable = 0,
        UpdateAvailableAndRequired,
        UpdateAvailableButInGracePeriod
    }


[Native]
    public enum MPAccessoryUpdateRequirementComponent : long
    {
        None = 0,
        Software = 1 << 0,
        Configuration = 1 << 1,
        Security = 1 << 2,
        Firmware = 1 << 3
    }

    [Native]
    public enum MPProviderComponentDelegateDisplayUpdateType : long
    {
        Text = 0,
        Pin
    }

    [Native]
    public enum MPAccessoryCardEvent : long
    {
        Unknown = 0,
        Inserted,
        Removed,
        Swiped
    }

    [Native]
    public enum MPAccessoryKeyEvent : long
    {
        Unknown = 0,
        Numeric,
        Cancel,
        Ok,
        Back
    }

    [Native]
    public enum MPPINInformationStatus : long
    {
        Started,
        Update,
        Completed,
        Incorrect,
        LastTry
    }

    [Native]
    public enum MPAccessoryComponentPrinterState : long
    {
        Unknown = 0,
        Normal,
        Busy,
        PaperLowOrEmpty,
        CoverOpen
    }

    public enum MPAccessoryComponentBarcodeScannerConfigurationTriggerMode
    {
        Edge = 0,
        Level,
        Soft,
        Passive
    }

    public enum MPAccessoryComponentBarcodeScannerConfigurationScanMode
    {
        MPAccessoryComponentBarcodeScannerConfigurationScanMode1D = 0,
        MPAccessoryComponentBarcodeScannerConfigurationScanMode1D2D
    }

    public enum MPAccessoryComponentBarcodeScannerConfigurationContinuousMode
    {
        Disabled = 0,
        Enabled
    }

    [Native]
    public enum MPAccessoryComponentBarcodeScannerConfigurationBarcodeType : long
    {
        Unknown = 0,
        UpcEan,
        Code39,
        Code128,
        Pdf417,
        Qr,
        Invalid
    }

    [Native]
    public enum MPAccessoryComponentInteractionPrompt : long
    {
        EnterTip = 0,
        EnterMobileNumber,
        EnterTableNumber,
        EnterAmount,
        EnterTotalAmount,
        Amount,
        Empty
    }

    [Native]
    public enum MPAccessoryComponentInteractionConfirmationKey : long
    {
        Ok = 1 << 0,
        Cancel = 1 << 1,
        Back = 1 << 2,
        Numeric = 1 << 3
    }

    [Native]
    public enum MPPrintingProcessDetailsState : long
    {
        Created,
        FetchingTransaction,
        ConnectingToAccessory,
        SendingToPrinter,
        SentToPrinter,
        Aborted,
        Failed
    }

    [Native]
    public enum MPPrintingProcessDetailsStateDetails : long
    {
        Created,
        FetchingTransaction,
        ConnectingToAccessory,
        ConnectingToAccessoryWaitingForPrinter,
        SendingToPrinterCheckingState,
        SendingToPrinter,
        SentToPrinter,
        Aborted,
        FailedPaperEmpty,
        FailedCoverOpen,
        Failed
    }

    [Native]
    public enum MPTransactionProcessDetailsState : long
    {
        Created,
        ConnectingToAccessory,
        Preparing,
        InitializingTransaction,
        WaitingForCardPresentation,
        WaitingForCardRemoval,
        Processing,
        Accepted,
        Approved,
        Declined,
        Aborted,
        Failed,
        NotRefundable,
        Inconclusive
    }

    [Native]
    public enum MPTransactionProcessDetailsStateDetails : long
    {
        Created,
        ConnectingToAccessory,
        ConnectingToAccessoryCheckingForUpdate,
        ConnectingToAccessoryUpdating,
        ConnectingToAccessoryWaitingForReader,
        PreparingAskingForTip,
        InitializingTransactionRegistering,
        InitializingTransactionQuerying,
        WaitingForCardPresentation,
        WaitingForCardRemoval,
        Processing,
        ProcessingActionRequired,
        ProcessingWaitingForPIN,
        ProcessingCompleted,
        Accepted,
        Approved,
        Declined,
        Aborted,
        Failed,
        NotRefundable,
        Inconclusive
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
    public enum MPAccessoryProcessDetailsState : long
    {
        Created,
        ConnectingToAccessory,
        UpdatingAccessory,
        DisconnectingFromAccessory,
        Completed,
        Aborted,
        Failed
    }

    [Native]
    public enum MPAccessoryProcessDetailsStateDetails : long
    {
        Created,
        ConnectingToAccessory,
        ConnectingToAccessoryRetrying,
        CheckingForUpdate,
        UpdatingAccessory,
        ProvisioningAccessory,
        DisconnectingFromAccessory,
        Completed,
        Aborted,
        Failed
    }

}

namespace MPOS
{

    // @interface MPTransaction
    [BaseType(typeof(NSObject))]
    interface MPTransaction
    {
        // @property (readonly, nonatomic, strong) int * _Nonnull amount;
        [Export("amount")]
        NSDecimalNumber Amount { get; }

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
