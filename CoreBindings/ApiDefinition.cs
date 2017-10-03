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
        MPCurrency Currency { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable subject;
        [NullAllowed, Export("subject")]
        string Subject { get; }

        // @property (readonly, nonatomic, strong) int * _Nonnull statementDescriptor;
        [Export("statementDescriptor")]
        string StatementDescriptor { get; }

        // @property (readonly, assign, nonatomic) int type;
        [Export("type")]
        MPTransactionType Type { get; }

        // @property (readonly, assign, nonatomic) int mode;
        [Export("mode")]
        MPTransactionMode Mode { get; }

        // @property (readonly, assign, nonatomic) int captured;
        [Export("captured")]
        bool Captured { get; }

        // @property (readonly, nonatomic, strong) MPPaymentDetails * _Nonnull paymentDetails;
        [Export("paymentDetails")]
        MPPaymentDetails PaymentDetails { get; }

        // @property (readonly, nonatomic, strong) MPRefundDetails * _Nonnull refundDetails;
        [Export("refundDetails")]
        MPRefundDetails RefundDetails { get; }

        // @property (readonly, nonatomic, strong) MPClearingDetails * _Nonnull clearingDetails;
        [Export("clearingDetails")]
        MPClearingDetails ClearingDetails { get; }

        // @property (readonly, nonatomic, strong) MPCardDetails * _Nonnull cardDetails;
        [Export("cardDetails")]
        MPCardDetails CardDetails { get; }

        // @property (readonly, nonatomic, strong) MPShopperDetails * _Nonnull shopperDetails;
        [Export("shopperDetails", ArgumentSemantic.Strong)]
        MPShopperDetails ShopperDetails { get; }

        // @property (readonly, nonatomic, strong) MPTransactionDetails * _Nonnull details;
        [Export("details", ArgumentSemantic.Strong)]
        MPTransactionDetails Details { get; }

        // @property (readonly, assign, nonatomic) int status;
        [Export("status")]
        MPTransactionStatus Status { get; }

        // @property (readonly, nonatomic, strong) MPStatusDetails * _Nullable statusDetails;
        [NullAllowed, Export("statusDetails", ArgumentSemantic.Strong)]
        MPStatusDetails StatusDetails { get; }

        // @property (readonly, assign, nonatomic) int state;
        [Export("state")]
        MPTransactionState State { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable error;
        [NullAllowed, Export("error")]
        NSError Error { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable sessionIdentifier;
        [NullAllowed, Export("sessionIdentifier")]
        string SessionIdentifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable identifier;
        [NullAllowed, Export("identifier")]
        string Identifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable groupIdentifier;
        [NullAllowed, Export("groupIdentifier")]
        string GroupIdentifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable referencedTransactionIdentifier;
        [NullAllowed, Export("referencedTransactionIdentifier")]
        string ReferencedTransactionIdentifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable customIdentifier;
        [NullAllowed, Export("customIdentifier")]
        string CustomIdentifier { get; }

        // @property (readonly, nonatomic, strong) int * _Nullable created;
        [NullAllowed, Export("created")]
        NSDate Created { get; }

        // -(id)canBeAborted;
        [Export("canBeAborted")]
        bool CanBeAborted();

        // @property (readonly, nonatomic, strong) MPProcessingDetails * _Nonnull processingDetails;
        [Export("processingDetails")]
        MPProcessingDetails ProcessingDetails { get; }

        // @property (readonly, nonatomic, strong) MPReceipt * _Nullable customerReceipt;
        [NullAllowed, Export("customerReceipt")]
        MPReceipt CustomerReceipt { get; }

        // @property (readonly, nonatomic, strong) MPReceipt * _Nullable merchantReceipt;
        [NullAllowed, Export("merchantReceipt")]
        MPReceipt MerchantReceipt { get; }
    }

    // @interface MPAccessory
    [BaseType(typeof(NSObject))]
    interface MPAccessory
    {
        // @property (readonly, assign, nonatomic) int type;
        [Export("type")]
        MPAccessoryType Type { get; }

        // @property (readonly, nonatomic, strong) MPAccessoryDetails * _Nonnull details;
        [Export("details")]
        MPAccessoryDetails Details { get; }

        // @property (readonly, assign, nonatomic) int connectionType;
        [Export("connectionType")]
        MPAccessoryConnectionType ConnectionType { get; }

        // @property (readonly, nonatomic, strong) MPAccessoryParameters * _Nonnull parameters;
        [Export("parameters", ArgumentSemantic.Strong)]
        MPAccessoryParameters Parameters { get; }

        // @property (readonly, assign, nonatomic) int connectionState;
        [Export("connectionState")]
        MPAccessoryConnectionState ConnectionState { get; }

        // @property (readonly, assign, nonatomic) int batteryState;
        [Export("batteryState")]
        MPAccessoryBatteryState BatteryState { get; }

        // @property (readonly, assign, nonatomic) int batteryLevel;
        [Export("batteryLevel")]
        int BatteryLevel { get; }

        // @property (readonly, assign, nonatomic) int state;
        [Export("state")]
        MPAccessoryState State { get; }

        // @property (readonly, assign, nonatomic) int components;
        [Export("components")]
        MPAccessoryComponentType Components { get; }

        // -(MPAccessoryComponent * _Nullable)componentForType:(id)component;
        [Export("componentForType:")]
        [return: NullAllowed]
        MPAccessoryComponent ComponentForType(MPAccessoryComponentType component);
    }

    // @interface MPReceiptLineItem : NSObject
    [BaseType(typeof(NSObject))]
    interface MPReceiptLineItem
    {
        // @property (readonly, assign, nonatomic) MPReceiptLineKey key;
        [Export("key", ArgumentSemantic.Assign)]
        MPReceiptLineKey Key { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull label;
        [Export("label", ArgumentSemantic.Strong)]
        string Label { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull value;
        [Export("value", ArgumentSemantic.Strong)]
        string Value { get; }
    }

    // @interface MPReceipt : NSObject
    [BaseType(typeof(NSObject))]
    interface MPReceipt
    {
        // @property (readonly, nonatomic, strong) MPReceiptLineItem * _Nonnull receiptType;
        [Export("receiptType", ArgumentSemantic.Strong)]
        MPReceiptLineItem ReceiptType { get; }

        // @property (readonly, nonatomic, strong) MPReceiptLineItem * _Nonnull transactionType;
        [Export("transactionType", ArgumentSemantic.Strong)]
        MPReceiptLineItem TransactionType { get; }

        // @property (readonly, nonatomic, strong) MPReceiptLineItem * _Nullable subject;
        [NullAllowed, Export("subject", ArgumentSemantic.Strong)]
        MPReceiptLineItem Subject { get; }

        // @property (readonly, nonatomic, strong) MPReceiptLineItem * _Nonnull identifier;
        [Export("identifier", ArgumentSemantic.Strong)]
        MPReceiptLineItem Identifier { get; }

        // @property (readonly, nonatomic, strong) MPReceiptLineItem * _Nonnull amountAndCurrency;
        [Export("amountAndCurrency", ArgumentSemantic.Strong)]
        MPReceiptLineItem AmountAndCurrency { get; }

        // @property (readonly, nonatomic, strong) MPReceiptLineItem * _Nonnull includedTipAmountAndCurrency;
        [Export("includedTipAmountAndCurrency", ArgumentSemantic.Strong)]
        MPReceiptLineItem IncludedTipAmountAndCurrency { get; }

        // @property (readonly, nonatomic, strong) MPReceiptLineItem * _Nonnull date;
        [Export("date", ArgumentSemantic.Strong)]
        MPReceiptLineItem Date { get; }

        // @property (readonly, nonatomic, strong) MPReceiptLineItem * _Nonnull time;
        [Export("time", ArgumentSemantic.Strong)]
        MPReceiptLineItem Time { get; }

        // @property (readonly, nonatomic, strong) MPReceiptLineItem * _Nonnull statusText;
        [Export("statusText", ArgumentSemantic.Strong)]
        MPReceiptLineItem StatusText { get; }

        // @property (readonly, assign, nonatomic) BOOL printSignatureLine;
        [Export("printSignatureLine")]
        bool PrintSignatureLine { get; }

        // @property (readonly, assign, nonatomic) BOOL printTipLine;
        [Export("printTipLine")]
        bool PrintTipLine { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull clearingDetails;
        [Export("clearingDetails", ArgumentSemantic.Strong)]
        MPReceiptLineItem[] ClearingDetails { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull paymentDetails;
        [Export("paymentDetails", ArgumentSemantic.Strong)]
        MPReceiptLineItem[] PaymentDetails { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull merchantDetails;
        [Export("merchantDetails", ArgumentSemantic.Strong)]
        MPReceiptLineItem[] MerchantDetails { get; }

        // -(MPReceiptLineItem * _Nullable)receiptLineItemForKey:(MPReceiptLineKey)key;
        [Export("receiptLineItemForKey:")]
        [return: NullAllowed]
        MPReceiptLineItem ReceiptLineItemForKey(MPReceiptLineKey key);

        // -(NSString * _Nonnull)prettyPrinted;
        [Export("prettyPrinted")]
        string PrettyPrinted();
    }

    // typedef void (^MPAccessoryConnectSuccess)(MPAccessory * _Nonnull);
    delegate void MPAccessoryConnectSuccess(MPAccessory arg0);

    // typedef void (^MPAccessoryConnectFailure)(NSError * _Nonnull);
    delegate void MPAccessoryConnectFailure(NSError arg0);

    // typedef void (^MPAccessoryCheckUpdateSuccess)(MPAccessory * _Nonnull, MPAccessoryUpdateRequirement * _Nonnull);
    delegate void MPAccessoryCheckUpdateSuccess(MPAccessory arg0, MPAccessoryUpdateRequirement arg1);

    // typedef void (^MPAccessoryCheckUpdateFailure)(MPAccessory * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryCheckUpdateFailure(MPAccessory arg0, NSError arg1);

    // typedef void (^MPAccessoryUpdateSuccess)(MPAccessory * _Nonnull);
    delegate void MPAccessoryUpdateSuccess(MPAccessory arg0);

    // typedef void (^MPAccessoryUpdateFailure)(MPAccessory * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryUpdateFailure(MPAccessory arg0, NSError arg1);

    // typedef void (^MPAccessoryProvisionSuccess)(MPAccessory * _Nonnull);
    delegate void MPAccessoryProvisionSuccess(MPAccessory arg0);

    // typedef void (^MPAccessoryProvisionFailure)(MPAccessory * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryProvisionFailure(MPAccessory arg0, NSError arg1);

    // typedef void (^MPAccessoryUpdateStateSuccess)(MPAccessory * _Nonnull);
    delegate void MPAccessoryUpdateStateSuccess(MPAccessory arg0);

    // typedef void (^MPAccessoryUpdateStateFailure)(MPAccessory * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryUpdateStateFailure(MPAccessory arg0, NSError arg1);

    // typedef void (^MPAccessoryDisconnectSuccess)(MPAccessory * _Nonnull);
    delegate void MPAccessoryDisconnectSuccess(MPAccessory arg0);

    // typedef void (^MPAccessoryDisconnectFailure)(MPAccessory * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryDisconnectFailure(MPAccessory arg0, NSError arg1);

    // typedef void (^MPTransactionLookupSuccess)(MPTransaction * _Nonnull);
    delegate void MPTransactionLookupSuccess(MPTransaction arg0);

    // typedef void (^MPTransactionLookupFailure)(NSString * _Nonnull, NSError * _Nonnull);
    delegate void MPTransactionLookupFailure(string arg0, NSError arg1);

    // typedef void (^MPTransactionApproval)(MPTransaction * _Nonnull);
    delegate void MPTransactionApproval(MPTransaction arg0);

    // typedef void (^MPTransactionAccept)(MPTransaction * _Nonnull);
    delegate void MPTransactionAccept(MPTransaction arg0);

    // typedef void (^MPTransactionDecline)(MPTransaction * _Nonnull);
    delegate void MPTransactionDecline(MPTransaction arg0);

    // typedef void (^MPTransactionAbort)(MPTransaction * _Nonnull);
    delegate void MPTransactionAbort(MPTransaction arg0);

    // typedef void (^MPTransactionFailure)(MPTransaction * _Nonnull, NSError * _Nonnull);
    delegate void MPTransactionFailure(MPTransaction arg0, NSError arg1);

    // typedef void (^MPTransactionCaptureSuccess)(MPTransaction * _Nonnull);
    delegate void MPTransactionCaptureSuccess(MPTransaction arg0);

    // typedef void (^MPTransactionCaptureFailure)(NSError * _Nonnull);
    delegate void MPTransactionCaptureFailure(NSError arg0);

    // typedef void (^MPTransactionActionRequired)(MPTransaction * _Nonnull, int, MPTransactionActionSupport * _Nullable);
    delegate void MPTransactionActionRequired(MPTransaction arg0, int arg1, [NullAllowed] MPTransactionActionSupport arg2);

    // typedef void (^MPTransactionAbortSuccess)(MPTransaction * _Nonnull);
    delegate void MPTransactionAbortSuccess(MPTransaction arg0);

    // typedef void (^MPTransactionAbortFailure)(MPTransaction * _Nonnull, NSError * _Nonnull);
    delegate void MPTransactionAbortFailure(MPTransaction arg0, NSError arg1);

    // typedef void (^MPRefundTransactionWithoutCardApproved)(MPTransaction * _Nonnull);
    delegate void MPRefundTransactionWithoutCardApproved(MPTransaction arg0);

    // typedef void (^MPRefundTransactionWithoutCardDeclined)(MPTransaction * _Nonnull);
    delegate void MPRefundTransactionWithoutCardDeclined(MPTransaction arg0);

    // typedef void (^MPRefundTransactionParamsWithoutCardFailure)(MPTransactionParameters * _Nonnull, NSError * _Nonnull);
    delegate void MPRefundTransactionParamsWithoutCardFailure(MPTransactionParameters arg0, NSError arg1);

    // typedef void (^MPRefundTransactionApproved)(MPTransaction * _Nonnull);
    delegate void MPRefundTransactionApproved(MPTransaction arg0);

    // typedef void (^MPRefundTransactionDeclined)(MPTransaction * _Nonnull);
    delegate void MPRefundTransactionDeclined(MPTransaction arg0);

    // typedef void (^MPRefundTransactionFailure)(MPTransactionParameters * _Nonnull, NSError * _Nonnull);
    delegate void MPRefundTransactionFailure(MPTransactionParameters arg0, NSError arg1);

    // typedef void (^MPTransactionTipAdjustSuccess)(MPTransaction * _Nonnull);
    delegate void MPTransactionTipAdjustSuccess(MPTransaction arg0);

    // typedef void (^MMPTransactionTipAdjustFailure)(MPTransactionParameters * _Nonnull, NSError * _Nonnull);
    delegate void MMPTransactionTipAdjustFailure(MPTransactionParameters arg0, NSError arg1);

    // typedef void (^MPCustomerReceiptSendingSuccess)(NSString * _Nonnull, NSString * _Nonnull);
    delegate void MPCustomerReceiptSendingSuccess(string arg0, string arg1);

    // typedef void (^MPCustomerReceiptSendingFailure)(NSString * _Nonnull, NSString * _Nonnull, NSError * _Nonnull);
    delegate void MPCustomerReceiptSendingFailure(string arg0, string arg1, NSError arg2);

    // typedef void (^MPTransactionQuerySuccess)(NSArray * _Nonnull);
    delegate void MPTransactionQuerySuccess(NSObject[] arg0);

    // typedef void (^MPTransactionQueryFailure)(NSError * _Nonnull);
    delegate void MPTransactionQueryFailure(NSError arg0);

    // @interface MPProvider : NSObject
    [BaseType(typeof(NSObject))]
    interface MPProvider
    {
        // @property (readonly, assign, nonatomic) int supportedActions;
        [Export("supportedActions")]
        MPTransactionAction SupportedActions { get; }

        // @property (readonly, assign, nonatomic) MPProviderMode providerMode;
        [Export("providerMode", ArgumentSemantic.Assign)]
        MPProviderMode ProviderMode { get; }

        // @property (readonly, nonatomic, strong) MPPaymentDetailsFactory * _Nonnull paymentDetailsFactory;
        [Export("paymentDetailsFactory", ArgumentSemantic.Strong)]
        MPPaymentDetailsFactory PaymentDetailsFactory { get; }

        // @property (readonly, nonatomic, strong) MPTransactionActionResponseFactory * _Nonnull transactionActionResponseFactory;
        [Export("transactionActionResponseFactory", ArgumentSemantic.Strong)]
        MPTransactionActionResponseFactory TransactionActionResponseFactory { get; }

        // @property (readonly, nonatomic, strong) NSSet * _Nonnull accessories;
        [Export("accessories", ArgumentSemantic.Strong)]
        NSSet Accessories { get; }

        // @property (nonatomic, strong) dispatch_queue_t _Nonnull callbackQueue;
        [Export("callbackQueue", ArgumentSemantic.Strong)]
        DispatchQueue CallbackQueue { get; set; }

        // -(void)connectToAccessoryWithParameters:(MPAccessoryParameters * _Nonnull)parameters success:(MPAccessoryConnectSuccess _Nonnull)success failure:(MPAccessoryConnectFailure _Nonnull)failure;
        [Export("connectToAccessoryWithParameters:success:failure:")]
        void ConnectToAccessoryWithParameters(MPAccessoryParameters parameters, MPAccessoryConnectSuccess success, MPAccessoryConnectFailure failure);

        // -(void)checkUpdateRequirementForAccessory:(MPAccessory * _Nonnull)accessory success:(MPAccessoryCheckUpdateSuccess _Nonnull)success failure:(MPAccessoryCheckUpdateFailure _Nonnull)failure;
        [Export("checkUpdateRequirementForAccessory:success:failure:")]
        void CheckUpdateRequirementForAccessory(MPAccessory accessory, MPAccessoryCheckUpdateSuccess success, MPAccessoryCheckUpdateFailure failure);

        // -(void)updateAccessory:(MPAccessory * _Nonnull)accessory success:(MPAccessoryUpdateSuccess _Nonnull)success failure:(MPAccessoryUpdateFailure _Nonnull)failure;
        [Export("updateAccessory:success:failure:")]
        void UpdateAccessory(MPAccessory accessory, MPAccessoryUpdateSuccess success, MPAccessoryUpdateFailure failure);

        // -(void)provisionAccessory:(MPAccessory * _Nonnull)accessory success:(MPAccessoryProvisionSuccess _Nonnull)success failure:(MPAccessoryProvisionFailure _Nonnull)failure;
        [Export("provisionAccessory:success:failure:")]
        void ProvisionAccessory(MPAccessory accessory, MPAccessoryProvisionSuccess success, MPAccessoryProvisionFailure failure);

        // -(void)updateAccessoryState:(MPAccessory * _Nonnull)accessory success:(MPAccessoryUpdateStateSuccess _Nonnull)success failure:(MPAccessoryUpdateStateFailure _Nonnull)failure;
        [Export("updateAccessoryState:success:failure:")]
        void UpdateAccessoryState(MPAccessory accessory, MPAccessoryUpdateStateSuccess success, MPAccessoryUpdateStateFailure failure);

        // -(void)disconnectFromAccessory:(MPAccessory * _Nonnull)accessory success:(MPAccessoryDisconnectSuccess _Nonnull)success failure:(MPAccessoryDisconnectFailure _Nonnull)failure;
        [Export("disconnectFromAccessory:success:failure:")]
        void DisconnectFromAccessory(MPAccessory accessory, MPAccessoryDisconnectSuccess success, MPAccessoryDisconnectFailure failure);

        // -(void)lookupTransactionWithSessionIdentifier:(NSString * _Nonnull)identifier success:(MPTransactionLookupSuccess _Nonnull)success failure:(MPTransactionLookupFailure _Nonnull)failure;
        [Export("lookupTransactionWithSessionIdentifier:success:failure:")]
        void LookupTransactionWithSessionIdentifier(string identifier, MPTransactionLookupSuccess success, MPTransactionLookupFailure failure);

        // -(void)lookupTransactionWithTransactionIdentifier:(NSString * _Nonnull)identifier success:(MPTransactionLookupSuccess _Nonnull)success failure:(MPTransactionLookupFailure _Nonnull)failure;
        [Export("lookupTransactionWithTransactionIdentifier:success:failure:")]
        void LookupTransactionWithTransactionIdentifier(string identifier, MPTransactionLookupSuccess success, MPTransactionLookupFailure failure);

        // -(void)startTransaction:(MPTransaction * _Nonnull)transaction usingAccessory:(MPAccessory * _Nonnull)accessory approval:(MPTransactionApproval _Nonnull)approval decline:(MPTransactionDecline _Nonnull)decline abort:(MPTransactionAbort _Nonnull)abort failure:(MPTransactionFailure _Nonnull)failure actionRequired:(MPTransactionActionRequired _Nonnull)actionRequired;
        [Export("startTransaction:usingAccessory:approval:decline:abort:failure:actionRequired:")]
        void StartTransaction(MPTransaction transaction, MPAccessory accessory, MPTransactionApproval approval, MPTransactionDecline decline, MPTransactionAbort abort, MPTransactionFailure failure, MPTransactionActionRequired actionRequired);

        // -(void)executeTransaction:(MPTransaction * _Nonnull)transaction accountParameters:(MPAccountParameters * _Nonnull)accountParameters approval:(MPTransactionApproval _Nonnull)approval decline:(MPTransactionDecline _Nonnull)decline abort:(MPTransactionAbort _Nonnull)abort failure:(MPTransactionFailure _Nonnull)failure;
        [Export("executeTransaction:accountParameters:approval:decline:abort:failure:")]
        void ExecuteTransaction(MPTransaction transaction, MPAccountParameters accountParameters, MPTransactionApproval approval, MPTransactionDecline decline, MPTransactionAbort abort, MPTransactionFailure failure);

        // -(void)continueTransaction:(MPTransaction * _Nonnull)transaction withAction:(id)action response:(MPTransactionActionResponse * _Nullable)response;
        [Export("continueTransaction:withAction:response:")]
        void ContinueTransaction(MPTransaction transaction, NSObject action, [NullAllowed] MPTransactionActionResponse response);

        // -(void)abortTransaction:(MPTransaction * _Nonnull)transaction success:(MPTransactionAbortSuccess _Nonnull)success failure:(MPTransactionAbortFailure _Nonnull)failure;
        [Export("abortTransaction:success:failure:")]
        void AbortTransaction(MPTransaction transaction, MPTransactionAbortSuccess success, MPTransactionAbortFailure failure);

        // -(void)abortTransaction:(MPTransaction * _Nonnull)transaction reason:(MPTransactionAbortReason)reason success:(MPTransactionAbortSuccess _Nonnull)success failure:(MPTransactionAbortFailure _Nonnull)failure;
        [Export("abortTransaction:reason:success:failure:")]
        void AbortTransaction(MPTransaction transaction, MPTransactionAbortReason reason, MPTransactionAbortSuccess success, MPTransactionAbortFailure failure);

        // -(void)captureTransactionWithParameters:(MPTransactionParameters * _Nonnull)parameters success:(MPTransactionCaptureSuccess _Nonnull)success failure:(MPTransactionCaptureFailure _Nonnull)failure;
        [Export("captureTransactionWithParameters:success:failure:")]
        void CaptureTransactionWithParameters(MPTransactionParameters parameters, MPTransactionCaptureSuccess success, MPTransactionCaptureFailure failure);

        // -(void)sendCustomerReceiptForTransactionIdentifier:(NSString * _Nonnull)transactionIdentifier emailAddress:(NSString * _Nonnull)emailAddress success:(MPCustomerReceiptSendingSuccess _Nonnull)success failure:(MPCustomerReceiptSendingFailure _Nonnull)failure;
        [Export("sendCustomerReceiptForTransactionIdentifier:emailAddress:success:failure:")]
        void SendCustomerReceiptForTransactionIdentifier(string transactionIdentifier, string emailAddress, MPCustomerReceiptSendingSuccess success, MPCustomerReceiptSendingFailure failure);

        // -(void)refundTransactionWithoutCardForParameters:(MPTransactionParameters * _Nonnull)transactionParameters approved:(MPRefundTransactionWithoutCardApproved _Nonnull)approved declined:(MPRefundTransactionWithoutCardDeclined _Nonnull)declined failure:(MPRefundTransactionParamsWithoutCardFailure _Nonnull)failure;
        [Export("refundTransactionWithoutCardForParameters:approved:declined:failure:")]
        void RefundTransactionWithoutCardForParameters(MPTransactionParameters transactionParameters, MPRefundTransactionWithoutCardApproved approved, MPRefundTransactionWithoutCardDeclined declined, MPRefundTransactionParamsWithoutCardFailure failure);

        // -(void)refundTransactionWithParameters:(MPTransactionParameters * _Nonnull)transactionParameters approved:(MPRefundTransactionApproved _Nonnull)approved declined:(MPRefundTransactionDeclined _Nonnull)declined failure:(MPRefundTransactionFailure _Nonnull)failure;
        [Export("refundTransactionWithParameters:approved:declined:failure:")]
        void RefundTransactionWithParameters(MPTransactionParameters transactionParameters, MPRefundTransactionApproved approved, MPRefundTransactionDeclined declined, MPRefundTransactionFailure failure);

        // -(void)tipAdjustTransactionWithParameters:(MPTransactionParameters * _Nonnull)transactionParameters success:(MPTransactionTipAdjustSuccess _Nonnull)success failure:(MMPTransactionTipAdjustFailure _Nonnull)failure;
        [Export("tipAdjustTransactionWithParameters:success:failure:")]
        void TipAdjustTransactionWithParameters(MPTransactionParameters transactionParameters, MPTransactionTipAdjustSuccess success, MMPTransactionTipAdjustFailure failure);

        // -(void)queryTransactionsUsingFilters:(MPTransactionFilterParameters * _Nonnull)filterParameters includeReceipts:(BOOL)includeReceipts range:(NSRange)range success:(MPTransactionQuerySuccess _Nonnull)success failure:(MPTransactionQueryFailure _Nonnull)failure;
        [Export("queryTransactionsUsingFilters:includeReceipts:range:success:failure:")]
        void QueryTransactionsUsingFilters(MPTransactionFilterParameters filterParameters, bool includeReceipts, NSRange range, MPTransactionQuerySuccess success, MPTransactionQueryFailure failure);

        // -(void)addProviderComponentDelegate:(id<MPProviderComponentDelegate> _Nonnull)delegate;
        [Export("addProviderComponentDelegate:")]
        void AddProviderComponentDelegate(MPProviderComponentDelegate @delegate);

        // -(void)removeProviderComponentDelegate:(id<MPProviderComponentDelegate> _Nonnull)delegate;
        [Export("removeProviderComponentDelegate:")]
        void RemoveProviderComponentDelegate(MPProviderComponentDelegate @delegate);

        // -(void)addAccessoryComponentCallback:(id<MPAccessoryComponentDelegate> _Nonnull)delegate;
        [Export("addAccessoryComponentCallback:")]
        void AddAccessoryComponentCallback(MPAccessoryComponentDelegate @delegate);

        // -(void)removeAccessoryComponentCallback:(id<MPAccessoryComponentDelegate> _Nonnull)delegate;
        [Export("removeAccessoryComponentCallback:")]
        void RemoveAccessoryComponentCallback(MPAccessoryComponentDelegate @delegate);
    }

    /*[Static]
    [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull MPConnectSDKVersion;
        [Field("MPConnectSDKVersion", "__Internal")]
        NSString MPConnectSDKVersion { get; }
    }*/

    // @interface MPMpos : NSObject
    [BaseType(typeof(NSObject))]
    interface MPMpos
    {

        // +(MPProviderOptionsFactory * _Nonnull)providerOptionsFactory;
        [Static]
        [Export("providerOptionsFactory")]
        MPProviderOptionsFactory ProviderOptionsFactory();

        // +(MPProvider * _Nonnull)providerWithOptions:(MPProviderOptions * _Nonnull)options;
        [Static]
        [Export("providerWithOptions:")]
        MPProvider ProviderWithOptions(MPProviderOptions options);

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

    /*[Static]
    [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull MPErrorDomainKey;
        [Field("MPErrorDomainKey", "__Internal")]
        NSString MPErrorDomainKey { get; }

        // extern NSString *const _Nonnull MPErrorSourceKey;
        [Field("MPErrorSourceKey", "__Internal")]
        NSString MPErrorSourceKey { get; }

        // extern NSString *const _Nonnull MPErrorTypeKey;
        [Field("MPErrorTypeKey", "__Internal")]
        NSString MPErrorTypeKey { get; }

        // extern NSString *const _Nonnull MPErrorInfoKey;
        [Field("MPErrorInfoKey", "__Internal")]
        NSString MPErrorInfoKey { get; }

        // extern NSString *const _Nonnull MPErrorDeveloperInfoKey;
        [Field("MPErrorDeveloperInfoKey", "__Internal")]
        NSString MPErrorDeveloperInfoKey { get; }

        // extern NSString *const _Nonnull MPErrorLocalizedDescriptionKey;
        [Field("MPErrorLocalizedDescriptionKey", "__Internal")]
        NSString MPErrorLocalizedDescriptionKey { get; }
    }*/

    // @interface MPAdditions (NSError)
    /*[Category]
    [BaseType(typeof(NSError))]
    interface NSError_MPAdditions
    {
        // @property (readonly, assign, nonatomic) MPErrorSource source;
        [Export("source", ArgumentSemantic.Assign)]
        MPErrorSource Source { get; }

        // @property (readonly, assign, nonatomic) MPErrorType type;
        [Export("type", ArgumentSemantic.Assign)]
        MPErrorType Type { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable info;
        [NullAllowed, Export("info", ArgumentSemantic.Strong)]
        string Info { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable developerInfo;
        [NullAllowed, Export("developerInfo", ArgumentSemantic.Strong)]
        string DeveloperInfo { get; }

        // -(BOOL)isMPError;
        [Export("isMPError")]
        bool IsMPError();
    }*/

    /*[Static]
    [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull MPErrorKey;
        [Field("MPErrorKey", "__Internal")]
        NSString MPErrorKey { get; }
    }*/

    // @interface MPAdditions (NSException)
    /*[Category]
    [BaseType(typeof(NSException))]
    interface NSException_MPAdditions
    {
        // @property (readonly, nonatomic, strong) NSError * _Nullable errorInfo;
        [NullAllowed, Export("errorInfo", ArgumentSemantic.Strong)]
        NSError ErrorInfo { get; }
    }*/

    // @interface MPLogFormatter : NSObject
    [BaseType(typeof(NSObject))]
    interface MPLogFormatter
    {
    }

    // @interface MPProviderOptionsFactory : NSObject
    [BaseType(typeof(NSObject))]
    interface MPProviderOptionsFactory
    {
        // -(MPProviderOptions * _Nonnull)providerOptionsWithMode:(MPProviderMode)mode merchantIdentifer:(NSString * _Nonnull)merchantIdentifier merchantSecretKey:(NSString * _Nonnull)merchantSecretKey supportedActions:(id)supportedActions;
        [Export("providerOptionsWithMode:merchantIdentifer:merchantSecretKey:supportedActions:")]
        MPProviderOptions ProviderOptionsWithMode(MPProviderMode mode, string merchantIdentifier, string merchantSecretKey, MPTransactionAction supportedActions);

        // -(MPProviderOptions * _Nonnull)mockOptionsWithSupportedActions:(id)supportedActions;
        [Export("mockOptionsWithSupportedActions:")]
        MPProviderOptions MockOptionsWithSupportedActions(NSObject supportedActions);
    }

    // @interface MPProviderOptions : NSObject
    [BaseType(typeof(NSObject))]
    interface MPProviderOptions
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull merchantIdentifier;
        [Export("merchantIdentifier", ArgumentSemantic.Strong)]
        string MerchantIdentifier { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull merchantSecretKey;
        [Export("merchantSecretKey", ArgumentSemantic.Strong)]
        string MerchantSecretKey { get; }

        // @property (readonly, assign, nonatomic) MPProviderMode mode;
        [Export("mode", ArgumentSemantic.Assign)]
        MPProviderMode Mode { get; }

        // @property (assign, nonatomic) int supportedActions;
        [Export("supportedActions")]
        MPTransactionAction SupportedActions { get; set; }
    }

    // @interface MPProcessingDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPProcessingDetails
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable sessionIdentifier;
        [NullAllowed, Export("sessionIdentifier", ArgumentSemantic.Strong)]
        string SessionIdentifier { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull identifier;
        [Export("identifier", ArgumentSemantic.Strong)]
        string Identifier { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull timestamp;
        [Export("timestamp", ArgumentSemantic.Strong)]
        string Timestamp { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * _Nonnull additionalInformation;
        [Export("additionalInformation", ArgumentSemantic.Strong)]
        NSDictionary AdditionalInformation { get; }
    }

    // @interface MPStatusDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPStatusDetails
    {
        // @property (readonly, assign, nonatomic) MPTransactionStatusDetailsCode code;
        [Export("code", ArgumentSemantic.Assign)]
        MPTransactionStatusDetailsCode Code { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable detailedDescription;
        [NullAllowed, Export("detailedDescription", ArgumentSemantic.Strong)]
        string DetailedDescription { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable developerDescription;
        [NullAllowed, Export("developerDescription", ArgumentSemantic.Strong)]
        string DeveloperDescription { get; }
    }

    // @interface MPPaymentDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPPaymentDetails
    {
        // @property (readonly, assign, nonatomic) MPPaymentDetailsSource source;
        [Export("source", ArgumentSemantic.Assign)]
        MPPaymentDetailsSource Source { get; }

        // @property (readonly, assign, nonatomic) MPPaymentDetailsScheme scheme;
        [Export("scheme", ArgumentSemantic.Assign)]
        MPPaymentDetailsScheme Scheme { get; }

        // @property (readonly, assign, nonatomic) MPPaymentDetailsCustomerVerification customerVerification;
        [Export("customerVerification", ArgumentSemantic.Assign)]
        MPPaymentDetailsCustomerVerification CustomerVerification { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable accountNumber;
        [NullAllowed, Export("accountNumber", ArgumentSemantic.Strong)]
        string AccountNumber { get; }
    }

    // @interface MPRefundDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPRefundDetails
    {
        // @property (readonly, assign, nonatomic) MPRefundDetailsStatus status;
        [Export("status", ArgumentSemantic.Assign)]
        MPRefundDetailsStatus Status { get; }

        // @property (readonly, assign, nonatomic) MPRefundDetailsProcess process;
        [Export("process", ArgumentSemantic.Assign)]
        MPRefundDetailsProcess Process { get; }

        // @property (readonly, nonatomic, strong) NSArray<MPRefundTransaction *> * _Nonnull refundTransactions;
        [Export("refundTransactions", ArgumentSemantic.Strong)]
        MPRefundTransaction[] RefundTransactions { get; }
    }

    // @interface MPTransactionDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionDetails
    {
        // @property (readonly, nonatomic, strong) NSDecimalNumber * _Nullable applicationFee;
        [NullAllowed, Export("applicationFee", ArgumentSemantic.Strong)]
        NSDecimalNumber ApplicationFee { get; }

        // @property (readonly, nonatomic, strong) NSDecimalNumber * _Nullable includedTipAmount;
        [NullAllowed, Export("includedTipAmount", ArgumentSemantic.Strong)]
        NSDecimalNumber IncludedTipAmount { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * _Nullable metadata;
        [NullAllowed, Export("metadata", ArgumentSemantic.Strong)]
        NSDictionary Metadata { get; }

        // @property (readonly, assign, nonatomic) MPTransactionTipAdjustStatus tipAdjustStatus;
        [Export("tipAdjustStatus", ArgumentSemantic.Assign)]
        MPTransactionTipAdjustStatus TipAdjustStatus { get; }
    }

    // @interface MPClearingDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPClearingDetails
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable institute;
        [NullAllowed, Export("institute", ArgumentSemantic.Strong)]
        string Institute { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable transactionIdentifier;
        [NullAllowed, Export("transactionIdentifier", ArgumentSemantic.Strong)]
        string TransactionIdentifier { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable originalTransactionIdentifier;
        [NullAllowed, Export("originalTransactionIdentifier", ArgumentSemantic.Strong)]
        string OriginalTransactionIdentifier { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable completed;
        [NullAllowed, Export("completed", ArgumentSemantic.Strong)]
        NSDate Completed { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable authorizationCode;
        [NullAllowed, Export("authorizationCode", ArgumentSemantic.Strong)]
        string AuthorizationCode { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable merchantId;
        [NullAllowed, Export("merchantId", ArgumentSemantic.Strong)]
        string MerchantId { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable terminalId;
        [NullAllowed, Export("terminalId", ArgumentSemantic.Strong)]
        string TerminalId { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable statusText;
        [NullAllowed, Export("statusText", ArgumentSemantic.Strong)]
        string StatusText { get; }
    }

    // @interface MPCardDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPCardDetails
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable cardHolderName;
        [NullAllowed, Export("cardHolderName", ArgumentSemantic.Strong)]
        string CardHolderName { get; }

        // @property (readonly, assign, nonatomic) NSUInteger expiryMonth;
        [Export("expiryMonth")]
        nuint ExpiryMonth { get; }

        // @property (readonly, assign, nonatomic) NSUInteger expiryYear;
        [Export("expiryYear")]
        nuint ExpiryYear { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable fingerprint;
        [NullAllowed, Export("fingerprint", ArgumentSemantic.Strong)]
        string Fingerprint { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable maskedCardNumber;
        [NullAllowed, Export("maskedCardNumber", ArgumentSemantic.Strong)]
        string MaskedCardNumber { get; }

        // @property (readonly, assign, nonatomic) MPPaymentDetailsScheme scheme;
        [Export("scheme", ArgumentSemantic.Assign)]
        MPPaymentDetailsScheme Scheme { get; }
    }

    // @interface MPRefundTransaction : NSObject
    [BaseType(typeof(NSObject))]
    interface MPRefundTransaction
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable identifier;
        [NullAllowed, Export("identifier", ArgumentSemantic.Strong)]
        string Identifier { get; }

        // @property (readonly, nonatomic, strong) NSDate * _Nullable created;
        [NullAllowed, Export("created", ArgumentSemantic.Strong)]
        NSDate Created { get; }

        // @property (readonly, nonatomic, strong) NSDecimalNumber * _Nonnull amount;
        [Export("amount", ArgumentSemantic.Strong)]
        NSDecimalNumber Amount { get; }

        // @property (readonly, assign, nonatomic) int currency;
        [Export("currency")]
        MPCurrency Currency { get; }

        // @property (readonly, assign, nonatomic) int type;
        [Export("type")]
        MPTransactionType Type { get; }

        // @property (readonly, assign, nonatomic) MPRefundTransactionCode code;
        [Export("code", ArgumentSemantic.Assign)]
        MPRefundTransactionCode Code { get; }

        // @property (readonly, assign, nonatomic) int status;
        [Export("status")]
        MPTransactionStatus Status { get; }

        // @property (readonly, nonatomic, strong) MPStatusDetails * _Nullable statusDetails;
        [NullAllowed, Export("statusDetails", ArgumentSemantic.Strong)]
        MPStatusDetails StatusDetails { get; }
    }

    // @interface MPShopperDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPShopperDetails
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable email;
        [NullAllowed, Export("email", ArgumentSemantic.Strong)]
        string Email { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable identifier;
        [NullAllowed, Export("identifier", ArgumentSemantic.Strong)]
        string Identifier { get; }
    }

    // @interface MPTransactionActionSupport : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionActionSupport
    {
    }

    // @interface MPTransactionActionResponse : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionActionResponse
    {
    }

    // @interface MPTransactionActionResponseFactory : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionActionResponseFactory
    {
        // -(MPTransactionActionResponse * _Nonnull)responseForCustomerSignatureWithResult:(BOOL)signatureVerified signature:(UIImage * _Nonnull)signature;
        [Export("responseForCustomerSignatureWithResult:signature:")]
        MPTransactionActionResponse ResponseForCustomerSignatureWithResult(bool signatureVerified, UIImage signature);

        // -(MPTransactionActionResponse * _Nonnull)responseForCustomerSignatureOnReceipt;
        [Export("responseForCustomerSignatureOnReceipt")]
        MPTransactionActionResponse ResponseForCustomerSignatureOnReceipt();

        // -(MPTransactionActionResponse * _Nonnull)responseForCustomerIdentificationWithResult:(BOOL)customerVerified;
        [Export("responseForCustomerIdentificationWithResult:")]
        MPTransactionActionResponse ResponseForCustomerIdentificationWithResult(bool customerVerified);

        // -(MPTransactionActionResponse * _Nonnull)responseForApplicationSelectionWithApplication:(MPApplicationInformation * _Nonnull)application;
        [Export("responseForApplicationSelectionWithApplication:")]
        MPTransactionActionResponse ResponseForApplicationSelectionWithApplication(MPApplicationInformation application);

        // -(MPTransactionActionResponse * _Nonnull)responseForCreditDebitSelectionWithCredit;
        [Export("responseForCreditDebitSelectionWithCredit")]
        MPTransactionActionResponse ResponseForCreditDebitSelectionWithCredit();

        // -(MPTransactionActionResponse * _Nonnull)responseForCreditDebitSelectionWithDebit;
        [Export("responseForCreditDebitSelectionWithDebit")]
        MPTransactionActionResponse ResponseForCreditDebitSelectionWithDebit();
    }

    // @interface MPAccessoryDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryDetails
    {
        // @property (readonly, nonatomic, strong) NSString * _Nullable serialNumber;
        [NullAllowed, Export("serialNumber", ArgumentSemantic.Strong)]
        string SerialNumber { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable osVersion;
        [NullAllowed, Export("osVersion", ArgumentSemantic.Strong)]
        string OsVersion { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable softwareVersion;
        [NullAllowed, Export("softwareVersion", ArgumentSemantic.Strong)]
        string SoftwareVersion { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nullable type;
        [NullAllowed, Export("type", ArgumentSemantic.Strong)]
        string Type { get; }
    }

    // typedef void (^MPPaymentAccessoryDisplayTextSuccess)(MPAccessory * _Nonnull, NSArray * _Nonnull);
    delegate void MPPaymentAccessoryDisplayTextSuccess(MPAccessory arg0, NSObject[] arg1);

    // typedef void (^MPPaymentAccessoryDisplayTextFailure)(MPAccessory * _Nonnull, NSArray * _Nonnull, NSError * _Nonnull);
    delegate void MPPaymentAccessoryDisplayTextFailure(MPAccessory arg0, NSObject[] arg1, NSError arg2);

    // typedef void (^MPPaymentAccessoryDisplayIdleScreenSuccess)(MPAccessory * _Nonnull);
    delegate void MPPaymentAccessoryDisplayIdleScreenSuccess(MPAccessory arg0);

    // typedef void (^MPPaymentAccessoryDisplayIdleScreenFailure)(MPAccessory * _Nonnull, NSError * _Nonnull);
    delegate void MPPaymentAccessoryDisplayIdleScreenFailure(MPAccessory arg0, NSError arg1);

    // @interface MPPaymentAccessory : MPAccessory
    [BaseType(typeof(MPAccessory))]
    interface MPPaymentAccessory
    {
        // @property (readonly, assign, nonatomic) int locale;
        [Export("locale")]
        MPLocale Locale { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull idleScreenText;
        [Export("idleScreenText", ArgumentSemantic.Strong)]
        string[] IdleScreenText { get; }

        // @property (readonly, assign, nonatomic) MPPaymentAccessoryFeature features;
        [Export("features", ArgumentSemantic.Assign)]
        MPPaymentAccessoryFeature Features { get; }

        // @property (readonly, assign, nonatomic) MPPaymentAccessoryRequirement requirements;
        [Export("requirements", ArgumentSemantic.Assign)]
        MPPaymentAccessoryRequirement Requirements { get; }

        // -(void)displayText:(NSArray * _Nonnull)text success:(MPPaymentAccessoryDisplayTextSuccess _Nonnull)success failure:(MPPaymentAccessoryDisplayTextFailure _Nonnull)failure __attribute__((deprecated("Use MPAccessoryComponentInteraction.")));
        [Export("displayText:success:failure:")]
        void DisplayText(string[] text, MPPaymentAccessoryDisplayTextSuccess success, MPPaymentAccessoryDisplayTextFailure failure);

        // -(void)displayIdleScreenWithSuccess:(MPPaymentAccessoryDisplayIdleScreenSuccess _Nonnull)success failure:(MPPaymentAccessoryDisplayIdleScreenFailure _Nonnull)failure __attribute__((deprecated("Use MPAccessoryComponentInteraction.")));
        [Export("displayIdleScreenWithSuccess:failure:")]
        void DisplayIdleScreenWithSuccess(MPPaymentAccessoryDisplayIdleScreenSuccess success, MPPaymentAccessoryDisplayIdleScreenFailure failure);
    }

    // @interface MPAccessoryUpdateRequirement : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryUpdateRequirement
    {
        // @property (readonly, assign, nonatomic) MPAccessoryUpdateRequirementStatus status;
        [Export("status", ArgumentSemantic.Assign)]
        MPAccessoryUpdateRequirementStatus Status { get; }

        // @property (readonly, assign, nonatomic) MPAccessoryUpdateRequirementComponent affectedComponents;
        [Export("affectedComponents", ArgumentSemantic.Assign)]
        MPAccessoryUpdateRequirementComponent AffectedComponents { get; }
    }

    // @interface MPAbstractTransactionActionSupportWrapper : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAbstractTransactionActionSupportWrapper
    {
        // +(instancetype _Nonnull)wrapAround:(MPTransactionActionSupport * _Nonnull)wrappedSupport;
        [Static]
        [Export("wrapAround:")]
        MPAbstractTransactionActionSupportWrapper WrapAround(MPTransactionActionSupport wrappedSupport);
    }

    // @interface MPTransactionActionApplicationSelectionSupportWrapper : MPAbstractTransactionActionSupportWrapper
    [BaseType(typeof(MPAbstractTransactionActionSupportWrapper))]
    interface MPTransactionActionApplicationSelectionSupportWrapper
    {
        // @property (readonly, nonatomic, strong) NSArray * _Nonnull text;
        [Export("text", ArgumentSemantic.Strong)]
        string[] Text { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull applications;
        [Export("applications", ArgumentSemantic.Strong)]
        MPApplicationInformation[] Applications { get; }
    }

    // @protocol MPProviderComponentDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPProviderComponentDelegate
    {
        // @optional -(void)accessory:(MPAccessory * _Nonnull)accessory didChangeState:(id)state;
        [Export("accessory:didChangeState:")]
        void Accessory(MPAccessory accessory, NSObject state);

        // @optional -(void)transaction:(MPTransaction * _Nonnull)transaction didChangeState:(id)state abortable:(BOOL)abortable;
        [Export("transaction:didChangeState:abortable:")]
        void Transaction(MPTransaction transaction, NSObject state, bool abortable);

        // @optional -(void)provider:(MPProvider * _Nonnull)provider didRequestDisplayUpdateForType:(MPProviderComponentDelegateDisplayUpdateType)type text:(NSArray * _Nonnull)text support:(MPDisplayUpdateSupport * _Nonnull)support;
        //[Export("provider:didRequestDisplayUpdateForType:text:support:")]
        //void Provider(MPProvider provider, MPProviderComponentDelegateDisplayUpdateType type, string[] text, MPDisplayUpdateSupport support);
    }

    // @protocol MPAccessoryComponentDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPAccessoryComponentDelegate
    {
        // @optional -(void)accessory:(MPAccessory * _Nonnull)accessory didChangeBatteryState:(id)state level:(NSInteger)level;
        [Export("accessory:didChangeBatteryState:level:")]
        void DidChangeBatteryState(MPAccessory accessory, NSObject state, nint level);

        // @optional -(void)accessory:(MPAccessory * _Nonnull)accessory didEmitCardEvent:(MPAccessoryCardEvent)event;
        //[Export("accessory:didEmitCardEvent:")]
        //void DidEmitCardEvent(MPAccessory accessory, MPAccessoryCardEvent @event);

        // @optional -(void)accessory:(MPAccessory * _Nonnull)accessory didEmitKeyEvent:(MPAccessoryKeyEvent)event;
        //[Export("accessory:didEmitKeyEvent:")]
        //void DidEmitKeyEvent(MPAccessory accessory, MPAccessoryKeyEvent @event);
    }

    // @interface MPAbstractDisplayUpdateSupportWrapper : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAbstractDisplayUpdateSupportWrapper
    {
        // +(instancetype _Nonnull)wrapAround:(MPDisplayUpdateSupport * _Nonnull)support;
        [Static]
        [Export("wrapAround:")]
        MPAbstractDisplayUpdateSupportWrapper WrapAround(MPDisplayUpdateSupport support);
    }

    // @interface MPPINInformation : NSObject
    [BaseType(typeof(NSObject))]
    interface MPPINInformation
    {
        // @property (readonly, assign, nonatomic) MPPINInformationStatus status;
        [Export("status", ArgumentSemantic.Assign)]
        MPPINInformationStatus Status { get; }

        // @property (readonly, assign, nonatomic) NSInteger digits;
        [Export("digits")]
        nint Digits { get; }
    }

    // @interface MPPINDisplayUpdateSupportWrapper : MPAbstractDisplayUpdateSupportWrapper
    [BaseType(typeof(MPAbstractDisplayUpdateSupportWrapper))]
    interface MPPINDisplayUpdateSupportWrapper
    {
        // @property (readonly, nonatomic, strong) MPPINInformation * _Nonnull information;
        [Export("information", ArgumentSemantic.Strong)]
        MPPINInformation Information { get; }
    }

    // @interface MPAccessoryComponent : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryComponent
    {
        // -(BOOL)isBusy;
        [Export("isBusy")]
        bool IsBusy();

        // -(void)abort;
        [Export("abort")]
        void Abort();
    }

    // typedef void (^MPAccessoryComponentPrinterPrintSuccess)(MPAccessoryComponentPrinter * _Nonnull, MPReceipt * _Nonnull);
    delegate void MPAccessoryComponentPrinterPrintSuccess(MPAccessoryComponentPrinter arg0, MPReceipt arg1);

    // typedef void (^MPAccessoryComponentPrinterPrintFailure)(MPAccessoryComponentPrinter * _Nonnull, MPReceipt * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentPrinterPrintFailure(MPAccessoryComponentPrinter arg0, MPReceipt arg1, NSError arg2);

    // @interface MPAccessoryComponentPrinter : MPAccessoryComponent
    [BaseType(typeof(MPAccessoryComponent))]
    interface MPAccessoryComponentPrinter
    {
        // @property (readonly, assign, nonatomic) MPAccessoryComponentPrinterState state;
        [Export("state", ArgumentSemantic.Assign)]
        MPAccessoryComponentPrinterState State { get; }

        // -(void)printReceipt:(MPReceipt * _Nonnull)receipt success:(MPAccessoryComponentPrinterPrintSuccess _Nonnull)success failure:(MPAccessoryComponentPrinterPrintFailure _Nonnull)failure;
        [Export("printReceipt:success:failure:")]
        void PrintReceipt(MPReceipt receipt, MPAccessoryComponentPrinterPrintSuccess success, MPAccessoryComponentPrinterPrintFailure failure);
    }

    // typedef void (^MPAccessoryComponentLogDownloadLogSuccess)(MPAccessoryComponentLog * _Nonnull, NSData * _Nonnull);
    delegate void MPAccessoryComponentLogDownloadLogSuccess(MPAccessoryComponentLog arg0, NSData arg1);

    // typedef void (^MPAccessoryComponentLogDownloadLogFailure)(MPAccessoryComponentLog * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentLogDownloadLogFailure(MPAccessoryComponentLog arg0, NSError arg1);

    // typedef void (^MPAccessoryComponentLogDeleteLogSuccess)(MPAccessoryComponentLog * _Nonnull);
    delegate void MPAccessoryComponentLogDeleteLogSuccess(MPAccessoryComponentLog arg0);

    // typedef void (^MPAccessoryComponentLogDeleteLogFailure)(MPAccessoryComponentLog * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentLogDeleteLogFailure(MPAccessoryComponentLog arg0, NSError arg1);

    // @interface MPAccessoryComponentLog : MPAccessoryComponent
    [BaseType(typeof(MPAccessoryComponent))]
    interface MPAccessoryComponentLog
    {
        // -(void)downloadLogWithSuccess:(MPAccessoryComponentLogDownloadLogSuccess _Nonnull)success failure:(MPAccessoryComponentLogDownloadLogFailure _Nonnull)failure;
        [Export("downloadLogWithSuccess:failure:")]
        void DownloadLogWithSuccess(MPAccessoryComponentLogDownloadLogSuccess success, MPAccessoryComponentLogDownloadLogFailure failure);

        // -(void)deleteLogWithSuccess:(MPAccessoryComponentLogDeleteLogSuccess _Nonnull)success failure:(MPAccessoryComponentLogDeleteLogFailure _Nonnull)failure;
        [Export("deleteLogWithSuccess:failure:")]
        void DeleteLogWithSuccess(MPAccessoryComponentLogDeleteLogSuccess success, MPAccessoryComponentLogDeleteLogFailure failure);
    }

    // @interface MPAccessoryComponentBarcodeScannerConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryComponentBarcodeScannerConfiguration
    {
        // @property (assign, nonatomic) MPAccessoryComponentBarcodeScannerConfigurationTriggerMode triggerMode;
        [Export("triggerMode", ArgumentSemantic.Assign)]
        MPAccessoryComponentBarcodeScannerConfigurationTriggerMode TriggerMode { get; set; }

        // @property (assign, nonatomic) MPAccessoryComponentBarcodeScannerConfigurationScanMode scanMode;
        [Export("scanMode", ArgumentSemantic.Assign)]
        MPAccessoryComponentBarcodeScannerConfigurationScanMode ScanMode { get; set; }

        // @property (assign, nonatomic) MPAccessoryComponentBarcodeScannerConfigurationContinuousMode continuousMode;
        [Export("continuousMode", ArgumentSemantic.Assign)]
        MPAccessoryComponentBarcodeScannerConfigurationContinuousMode ContinuousMode { get; set; }
    }

    // @interface MPAccessoryComponentBarcodeScannerData : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryComponentBarcodeScannerData
    {
        // @property (assign, nonatomic) MPAccessoryComponentBarcodeScannerConfigurationBarcodeType type;
        [Export("type", ArgumentSemantic.Assign)]
        MPAccessoryComponentBarcodeScannerConfigurationBarcodeType Type { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable barcode;
        [NullAllowed, Export("barcode", ArgumentSemantic.Strong)]
        string Barcode { get; set; }

        // @property (nonatomic, strong) NSData * _Nonnull rawResponse;
        [Export("rawResponse", ArgumentSemantic.Strong)]
        NSData RawResponse { get; set; }

        // @property (nonatomic, strong) NSData * _Nonnull rawBarcode;
        [Export("rawBarcode", ArgumentSemantic.Strong)]
        NSData RawBarcode { get; set; }
    }

    // typedef void (^MPAccessoryComponentBarcodeScannerStartScanSuccess)(MPAccessoryComponentBarcodeScanner * _Nonnull);
    delegate void MPAccessoryComponentBarcodeScannerStartScanSuccess(MPAccessoryComponentBarcodeScanner arg0);

    // typedef void (^MPAccessoryComponentBarcodeScannerStartScanScan)(MPAccessoryComponentBarcodeScanner * _Nonnull, MPAccessoryComponentBarcodeScannerData * _Nonnull);
    delegate void MPAccessoryComponentBarcodeScannerStartScanScan(MPAccessoryComponentBarcodeScanner arg0, MPAccessoryComponentBarcodeScannerData arg1);

    // typedef void (^MPAccessoryComponentBarcodeScannerStartScanButton)(MPAccessoryComponentBarcodeScanner * _Nonnull, NSUInteger);
    delegate void MPAccessoryComponentBarcodeScannerStartScanButton(MPAccessoryComponentBarcodeScanner arg0, nuint arg1);

    // typedef void (^MPAccessoryComponentBarcodeScannerStartScanAbort)(MPAccessoryComponentBarcodeScanner * _Nonnull);
    delegate void MPAccessoryComponentBarcodeScannerStartScanAbort(MPAccessoryComponentBarcodeScanner arg0);

    // typedef void (^MPAccessoryComponentBarcodeScannerStartScanFailure)(MPAccessoryComponentBarcodeScanner * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentBarcodeScannerStartScanFailure(MPAccessoryComponentBarcodeScanner arg0, NSError arg1);

    // typedef void (^MPAccessoryComponentBarcodeScannerStopScanSuccess)(MPAccessoryComponentBarcodeScanner * _Nonnull);
    delegate void MPAccessoryComponentBarcodeScannerStopScanSuccess(MPAccessoryComponentBarcodeScanner arg0);

    // typedef void (^MPAccessoryComponentBarcodeScannerStopScanFailure)(MPAccessoryComponentBarcodeScanner * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentBarcodeScannerStopScanFailure(MPAccessoryComponentBarcodeScanner arg0, NSError arg1);

    // @interface MPAccessoryComponentBarcodeScanner : MPAccessoryComponent
    [BaseType(typeof(MPAccessoryComponent))]
    interface MPAccessoryComponentBarcodeScanner
    {
        // -(void)startScanWithConfiguration:(MPAccessoryComponentBarcodeScannerConfiguration * _Nullable)configuration success:(MPAccessoryComponentBarcodeScannerStartScanSuccess _Nonnull)success scan:(MPAccessoryComponentBarcodeScannerStartScanScan _Nonnull)scan button:(MPAccessoryComponentBarcodeScannerStartScanButton _Nonnull)button failure:(MPAccessoryComponentBarcodeScannerStartScanFailure _Nonnull)failure __attribute__((deprecated("Use the startScanWithConfiguration:success:scan:button:abort:failure: method")));
        [Export("startScanWithConfiguration:success:scan:button:failure:")]
        void StartScanWithConfiguration([NullAllowed] MPAccessoryComponentBarcodeScannerConfiguration configuration, MPAccessoryComponentBarcodeScannerStartScanSuccess success, MPAccessoryComponentBarcodeScannerStartScanScan scan, MPAccessoryComponentBarcodeScannerStartScanButton button, MPAccessoryComponentBarcodeScannerStartScanFailure failure);

        // -(void)startScanWithSuccess:(MPAccessoryComponentBarcodeScannerStartScanSuccess _Nonnull)success scan:(MPAccessoryComponentBarcodeScannerStartScanScan _Nonnull)scan button:(MPAccessoryComponentBarcodeScannerStartScanButton _Nonnull)button failure:(MPAccessoryComponentBarcodeScannerStartScanFailure _Nonnull)failure __attribute__((deprecated("Use the startScanWithSuccess:scan:button:abort:failure: method")));
        [Export("startScanWithSuccess:scan:button:failure:")]
        void StartScanWithSuccess(MPAccessoryComponentBarcodeScannerStartScanSuccess success, MPAccessoryComponentBarcodeScannerStartScanScan scan, MPAccessoryComponentBarcodeScannerStartScanButton button, MPAccessoryComponentBarcodeScannerStartScanFailure failure);

        // -(void)startScanWithConfiguration:(MPAccessoryComponentBarcodeScannerConfiguration * _Nullable)configuration success:(MPAccessoryComponentBarcodeScannerStartScanSuccess _Nonnull)success scan:(MPAccessoryComponentBarcodeScannerStartScanScan _Nonnull)scan button:(MPAccessoryComponentBarcodeScannerStartScanButton _Nonnull)button abort:(MPAccessoryComponentBarcodeScannerStartScanAbort _Nonnull)abort failure:(MPAccessoryComponentBarcodeScannerStartScanFailure _Nonnull)failure;
        [Export("startScanWithConfiguration:success:scan:button:abort:failure:")]
        void StartScanWithConfiguration([NullAllowed] MPAccessoryComponentBarcodeScannerConfiguration configuration, MPAccessoryComponentBarcodeScannerStartScanSuccess success, MPAccessoryComponentBarcodeScannerStartScanScan scan, MPAccessoryComponentBarcodeScannerStartScanButton button, MPAccessoryComponentBarcodeScannerStartScanAbort abort, MPAccessoryComponentBarcodeScannerStartScanFailure failure);

        // -(void)startScanWithSuccess:(MPAccessoryComponentBarcodeScannerStartScanSuccess _Nonnull)success scan:(MPAccessoryComponentBarcodeScannerStartScanScan _Nonnull)scan button:(MPAccessoryComponentBarcodeScannerStartScanButton _Nonnull)button abort:(MPAccessoryComponentBarcodeScannerStartScanAbort _Nonnull)abort failure:(MPAccessoryComponentBarcodeScannerStartScanFailure _Nonnull)failure;
        [Export("startScanWithSuccess:scan:button:abort:failure:")]
        void StartScanWithSuccess(MPAccessoryComponentBarcodeScannerStartScanSuccess success, MPAccessoryComponentBarcodeScannerStartScanScan scan, MPAccessoryComponentBarcodeScannerStartScanButton button, MPAccessoryComponentBarcodeScannerStartScanAbort abort, MPAccessoryComponentBarcodeScannerStartScanFailure failure);

        // -(void)stopScanWithSuccess:(MPAccessoryComponentBarcodeScannerStopScanSuccess _Nonnull)success failure:(MPAccessoryComponentBarcodeScannerStopScanFailure _Nonnull)failure __attribute__((deprecated("Use the abort method")));
        [Export("stopScanWithSuccess:failure:")]
        void StopScanWithSuccess(MPAccessoryComponentBarcodeScannerStopScanSuccess success, MPAccessoryComponentBarcodeScannerStopScanFailure failure);
    }

    // typedef void (^MPAccessoryComponentTippingAskForTipSuccess)(MPAccessoryComponentTipping * _Nonnull, NSDecimalNumber * _Nonnull);
   /* delegate void MPAccessoryComponentTippingAskForTipSuccess(MPAccessoryComponentTipping arg0, NSDecimalNumber arg1);

    // typedef void (^MPAccessoryComponentTippingAskForTipFailure)(MPAccessoryComponentTipping * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentTippingAskForTipFailure(MPAccessoryComponentTipping arg0, NSError arg1);

    // typedef void (^MPAccessoryComponentTippingAskForTipAbort)(MPAccessoryComponentTipping * _Nonnull);
    delegate void MPAccessoryComponentTippingAskForTipAbort(MPAccessoryComponentTipping arg0);

    // typedef void (^MPAccessoryComponentTippingAskSuccess)(MPAccessoryComponentTipping * _Nonnull, NSDecimalNumber * _Nonnull);
    delegate void MPAccessoryComponentTippingAskSuccess(MPAccessoryComponentTipping arg0, NSDecimalNumber arg1);

    // typedef void (^MPAccessoryComponentTippingAskFailure)(MPAccessoryComponentTipping * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentTippingAskFailure(MPAccessoryComponentTipping arg0, NSError arg1);

    // typedef void (^MPAccessoryComponentTippingAskAbort)(MPAccessoryComponentTipping * _Nonnull);
    delegate void MPAccessoryComponentTippingAskAbort(MPAccessoryComponentTipping arg0);*/

    // @interface MPAccessoryComponentTipping : MPAccessoryComponent
   /* [BaseType(typeof(MPAccessoryComponent))]
    interface MPAccessoryComponentTipping
    {
        // -(void)askForTipForAmount:(NSDecimalNumber * _Nonnull)transactionAmmount currency:(id)currency suggestedTip:(NSDecimalNumber * _Nullable)suggestedTip success:(MPAccessoryComponentTippingAskForTipSuccess _Nonnull)success abort:(MPAccessoryComponentTippingAskForTipAbort _Nonnull)abort failure:(MPAccessoryComponentTippingAskForTipFailure _Nonnull)failure __attribute__((deprecated("Use askForTipWithParameters:success:abort:failure: method")));
        [Export("askForTipForAmount:currency:suggestedTip:success:abort:failure:")]
        void AskForTipForAmount(NSDecimalNumber transactionAmmount, NSObject currency, [NullAllowed] NSDecimalNumber suggestedTip, MPAccessoryComponentTippingAskForTipSuccess success, MPAccessoryComponentTippingAskForTipAbort abort, MPAccessoryComponentTippingAskForTipFailure failure);

        // -(void)askForTipWithParameters:(MPAccessoryComponentTippingParameters * _Nonnull)parameters success:(MPAccessoryComponentTippingAskSuccess _Nonnull)success abort:(MPAccessoryComponentTippingAskAbort _Nonnull)abort failure:(MPAccessoryComponentTippingAskFailure _Nonnull)failure;
        [Export("askForTipWithParameters:success:abort:failure:")]
        void AskForTipWithParameters(MPAccessoryComponentTippingParameters parameters, MPAccessoryComponentTippingAskSuccess success, MPAccessoryComponentTippingAskAbort abort, MPAccessoryComponentTippingAskFailure failure);
    }*/

    // @protocol MPAccessoryComponentInteractionAskForNumberOptionals <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPAccessoryComponentInteractionAskForNumberOptionals
    {
        // @required -(void)setFormatWithIntegerDigits:(NSUInteger)integerDigits fractionDigits:(NSUInteger)fractionDigits;
        [Abstract]
        [Export("setFormatWithIntegerDigits:fractionDigits:")]
        void SetFormatWithIntegerDigits(nuint integerDigits, nuint fractionDigits);

        // @required -(void)setAutoConfirm:(BOOL)autoConfirm;
        [Abstract]
        [Export("setAutoConfirm:")]
        void SetAutoConfirm(bool autoConfirm);

        // @required -(void)setDefaultNumber:(NSDecimalNumber * _Nonnull)defaultNumber;
        [Abstract]
        [Export("setDefaultNumber:")]
        void SetDefaultNumber(NSDecimalNumber defaultNumber);

        // @required -(void)setDisplayAmount:(NSDecimalNumber * _Nonnull)amount currency:(id)currency;
        [Abstract]
        [Export("setDisplayAmount:currency:")]
        void SetDisplayAmount(NSDecimalNumber amount, NSObject currency);

        // @required -(void)setShowIdleScreen:(BOOL)showIdleScreen;
        [Abstract]
        [Export("setShowIdleScreen:")]
        void SetShowIdleScreen(bool showIdleScreen);
    }

    // typedef void (^MPAccessoryComponentInteractionAskForNumberOptionals)(id<MPAccessoryComponentInteractionAskForNumberOptionals> _Nonnull);
    //delegate void MPAccessoryComponentInteractionAskForNumberOptionals (MPAccessoryComponentInteractionAskForNumberOptionals arg0);

    // @interface MPAccessoryComponentInteractionAskForNumberParameters : NSObject
    [BaseType (typeof(NSObject))]
    interface MPAccessoryComponentInteractionAskForNumberParameters
    {
        // +(instancetype _Nonnull)parametersWithPrompt:(MPAccessoryComponentInteractionPrompt)prompt optionals:(MPAccessoryComponentInteractionAskForNumberOptionals _Nullable)optionalsBlock;
        [Static]
        [Export ("parametersWithPrompt:optionals:")]
        MPAccessoryComponentInteractionAskForNumberParameters ParametersWithPrompt (MPAccessoryComponentInteractionPrompt prompt, [NullAllowed] MPAccessoryComponentInteractionAskForNumberOptionals optionalsBlock);

        // +(instancetype _Nonnull)parametersWithPromptIndexes:(NSArray * _Nonnull)promptIndexes optionals:(MPAccessoryComponentInteractionAskForNumberOptionals _Nullable)optionalsBlock;
        [Static]
        [Export ("parametersWithPromptIndexes:optionals:")]
        MPAccessoryComponentInteractionAskForNumberParameters ParametersWithPromptIndexes (string[] promptIndexes, [NullAllowed] MPAccessoryComponentInteractionAskForNumberOptionals optionalsBlock);
    }

    // @protocol MPAccessoryComponentInteractionAskForConfirmationParametersOptionals <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MPAccessoryComponentInteractionAskForConfirmationParametersOptionals
    {
        // @required -(void)setCenterText:(BOOL)centered;
        [Abstract]
        [Export ("setCenterText:")]
        void SetCenterText (bool centered);

        // @required -(void)setShowIdleScreen:(BOOL)showIdleScreen;
        [Abstract]
        [Export ("setShowIdleScreen:")]
        void SetShowIdleScreen (bool showIdleScreen);

        // @required -(void)setConfirmationKeys:(MPAccessoryComponentInteractionConfirmationKey)keys;
        //[Abstract]
        //[Export ("setConfirmationKeys:")]
        //void SetConfirmationKeys (MPAccessoryComponentInteractionConfirmationKey keys);
    }

    // typedef void (^MPAccessoryComponentInteractionAskForConfirmationParametersOptionals)(id<MPAccessoryComponentInteractionAskForConfirmationParametersOptionals> _Nonnull);
    //delegate void MPAccessoryComponentInteractionAskForConfirmationParametersOptionals (MPAccessoryComponentInteractionAskForConfirmationParametersOptionals arg0);

    // @interface MPAccessoryComponentInteractionAskForConfirmationParameters : NSObject
    [BaseType (typeof(NSObject))]
    interface MPAccessoryComponentInteractionAskForConfirmationParameters
    {
        // +(instancetype _Nonnull)parametersWithText:(NSArray * _Nonnull)text optionals:(MPAccessoryComponentInteractionAskForConfirmationParametersOptionals _Nullable)optionalsBlock;
        [Static]
        [Export ("parametersWithText:optionals:")]
        MPAccessoryComponentInteractionAskForConfirmationParameters ParametersWithText (string[] text, [NullAllowed] MPAccessoryComponentInteractionAskForConfirmationParametersOptionals optionalsBlock);
    }

    // typedef void (^MPAccessoryComponentInteractionConfirmationSuccess)(MPAccessoryComponentInteraction * _Nonnull, MPAccessoryComponentInteractionConfirmationKey);
    // delegate void MPAccessoryComponentInteractionConfirmationSuccess (MPAccessoryComponentInteraction arg0, MPAccessoryComponentInteractionConfirmationKey arg1);

    // typedef void (^MPAccessoryComponentInteractionConfirmationFailure)(MPAccessoryComponentInteraction * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentInteractionConfirmationFailure (MPAccessoryComponentInteraction arg0, NSError arg1);

     // typedef void (^MPAccessoryComponentInteractionConfirmationAbort)(MPAccessoryComponentInteraction * _Nonnull);
    delegate void MPAccessoryComponentInteractionConfirmationAbort (MPAccessoryComponentInteraction arg0);

    // typedef void (^MPAccessoryComponentInteractionAskForNumberSuccess)(MPAccessoryComponentInteraction * _Nonnull, NSString * _Nonnull);
    delegate void MPAccessoryComponentInteractionAskForNumberSuccess (MPAccessoryComponentInteraction arg0, string arg1);

    // typedef void (^MPAccessoryComponentInteractionAskForNumberFailure)(MPAccessoryComponentInteraction * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentInteractionAskForNumberFailure (MPAccessoryComponentInteraction arg0, NSError arg1);

    // typedef void (^MPAccessoryComponentInteractionAskForNumberAbort)(MPAccessoryComponentInteraction * _Nonnull);
    delegate void MPAccessoryComponentInteractionAskForNumberAbort (MPAccessoryComponentInteraction arg0);

    // typedef void (^MPAccessoryComponentInteractionDisplayTextSuccess)(MPAccessoryComponentInteraction * _Nonnull);
    delegate void MPAccessoryComponentInteractionDisplayTextSuccess (MPAccessoryComponentInteraction arg0);

    // typedef void (^MPAccessoryComponentInteractionDisplayTextFailure)(MPAccessoryComponentInteraction * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentInteractionDisplayTextFailure (MPAccessoryComponentInteraction arg0, NSError arg1);

    // typedef void (^MPAccessoryComponentInteractionDisplayIdleScreenSuccess)(MPAccessoryComponentInteraction * _Nonnull);
    delegate void MPAccessoryComponentInteractionDisplayIdleScreenSuccess (MPAccessoryComponentInteraction arg0);

    // typedef void (^MPAccessoryComponentInteractionDisplayIdleScreenFailure)(MPAccessoryComponentInteraction * _Nonnull, NSError * _Nonnull);
    delegate void MPAccessoryComponentInteractionDisplayIdleScreenFailure (MPAccessoryComponentInteraction arg0, NSError arg1);

    // @interface MPAccessoryComponentInteraction : MPAccessoryComponent
    [BaseType (typeof(MPAccessoryComponent))]
    interface MPAccessoryComponentInteraction
    {
        // -(void)askForConfirmationWithParameters:(MPAccessoryComponentInteractionAskForConfirmationParameters * _Nonnull)params success:(MPAccessoryComponentInteractionConfirmationSuccess _Nonnull)success abort:(MPAccessoryComponentInteractionConfirmationAbort _Nonnull)abort failure:(MPAccessoryComponentInteractionConfirmationFailure _Nonnull)failure;
        //[Export ("askForConfirmationWithParameters:success:abort:failure:")]
        //void AskForConfirmationWithParameters (MPAccessoryComponentInteractionAskForConfirmationParameters @params, MPAccessoryComponentInteractionConfirmationSuccess success, MPAccessoryComponentInteractionConfirmationAbort abort, MPAccessoryComponentInteractionConfirmationFailure failure);

        // -(void)askForNumberWithParameters:(MPAccessoryComponentInteractionAskForNumberParameters * _Nonnull)params success:(MPAccessoryComponentInteractionAskForNumberSuccess _Nonnull)success abort:(MPAccessoryComponentInteractionAskForNumberAbort _Nonnull)abort failure:(MPAccessoryComponentInteractionAskForNumberFailure _Nonnull)failure;
        [Export ("askForNumberWithParameters:success:abort:failure:")]
        void AskForNumberWithParameters (MPAccessoryComponentInteractionAskForNumberParameters @params, MPAccessoryComponentInteractionAskForNumberSuccess success, MPAccessoryComponentInteractionAskForNumberAbort abort, MPAccessoryComponentInteractionAskForNumberFailure failure);

        // -(void)displayText:(NSArray * _Nonnull)text success:(MPAccessoryComponentInteractionDisplayTextSuccess _Nonnull)success failure:(MPAccessoryComponentInteractionDisplayTextFailure _Nonnull)failure;
        [Export ("displayText:success:failure:")]
        void DisplayText (string[] text, MPAccessoryComponentInteractionDisplayTextSuccess success, MPAccessoryComponentInteractionDisplayTextFailure failure);

        // -(void)displayIdleScreenSuccess:(MPAccessoryComponentInteractionDisplayIdleScreenSuccess _Nonnull)success failure:(MPAccessoryComponentInteractionDisplayIdleScreenFailure _Nonnull)failure;
        [Export ("displayIdleScreenSuccess:failure:")]
        void DisplayIdleScreenSuccess (MPAccessoryComponentInteractionDisplayIdleScreenSuccess success, MPAccessoryComponentInteractionDisplayIdleScreenFailure failure);
    }

    // @interface MPApplicationInformation : NSObject
    [BaseType(typeof(NSObject))]
    interface MPApplicationInformation
    {
        // @property (readonly, nonatomic, strong) NSString * _Nonnull applicationIdentifier;
        [Export("applicationIdentifier", ArgumentSemantic.Strong)]
        string ApplicationIdentifier { get; }

        // @property (readonly, nonatomic, strong) NSString * _Nonnull applicationName;
        [Export("applicationName", ArgumentSemantic.Strong)]
        string ApplicationName { get; }
    }

    // @interface MPPaymentDetailsFactory : NSObject
    [BaseType(typeof(NSObject))]
    interface MPPaymentDetailsFactory
    {
        // -(MPPaymentDetails * _Nonnull)paymentDetails;
        [Export("paymentDetails")]
        MPPaymentDetails PaymentDetails();
    }

    // typedef void (^MPPrintingProcessStatusChanged)(MPPrintingProcess * _Nonnull, MPTransaction * _Nullable, MPPrintingProcessDetails * _Nonnull);
    delegate void MPPrintingProcessStatusChanged (MPPrintingProcess arg0, [NullAllowed] MPTransaction arg1, MPPrintingProcessDetails arg2);

    // typedef void (^MPPrintingProcessCompleted)(MPPrintingProcess * _Nonnull, MPTransaction * _Nullable, MPPrintingProcessDetails * _Nonnull);
    delegate void MPPrintingProcessCompleted (MPPrintingProcess arg0, [NullAllowed] MPTransaction arg1, MPPrintingProcessDetails arg2);

    // @interface MPPrintingProcess : NSObject
    [BaseType(typeof(NSObject))]
    interface MPPrintingProcess
    {
        // @property (readonly, nonatomic, strong) MPTransactionProvider * _Nullable provider;
        [NullAllowed, Export("provider", ArgumentSemantic.Strong)]
        MPTransactionProvider Provider { get; }

        // @property (readonly, nonatomic, strong) MPAccessory * _Nullable accessory;
        [NullAllowed, Export("accessory", ArgumentSemantic.Strong)]
        MPAccessory Accessory { get; }

        // @property (readonly, nonatomic, strong) MPPrintingProcessDetails * _Nonnull details;
        [Export("details", ArgumentSemantic.Strong)]
        MPPrintingProcessDetails Details();

        // -(BOOL)requestAbort;
        [Export("requestAbort")]
        bool RequestAbort();

        // -(BOOL)canBeAborted;
        [Export("canBeAborted")]
        bool CanBeAborted();
    }

    // @interface MPPrintingProcessDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPPrintingProcessDetails
    {
        // @property (readonly, assign, nonatomic) MPPrintingProcessDetailsState state;
        [Export("state", ArgumentSemantic.Assign)]
        MPPrintingProcessDetailsState State { get; }

        // @property (readonly, assign, nonatomic) MPPrintingProcessDetailsStateDetails stateDetails;
        [Export("stateDetails", ArgumentSemantic.Assign)]
        MPPrintingProcessDetailsStateDetails StateDetails { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull information;
        [Export("information", ArgumentSemantic.Strong)]
        string[] Information { get; }

        // @property (readonly, nonatomic, strong) NSError * _Nullable error;
        [NullAllowed, Export("error", ArgumentSemantic.Strong)]
        NSError Error { get; }
    }

    // typedef void (^MPTransactionProcessRegistered)(MPTransactionProcess * _Nonnull, MPTransaction * _Nonnull);
    delegate void MPTransactionProcessRegistered (MPTransactionProcess arg0, MPTransaction arg1);

    // typedef void (^MPTransactionProcessStatusChanged)(MPTransactionProcess * _Nonnull, MPTransaction * _Nullable, MPTransactionProcessDetails * _Nonnull);
    delegate void MPTransactionProcessStatusChanged (MPTransactionProcess arg0, [NullAllowed] MPTransaction arg1, MPTransactionProcessDetails arg2);

    // typedef void (^MPTransactionProcessActionRequired)(MPTransactionProcess * _Nonnull, MPTransaction * _Nonnull, int, MPTransactionActionSupport * _Nullable);
    delegate void MPTransactionProcessActionRequired (MPTransactionProcess arg0, MPTransaction arg1, int arg2, [NullAllowed] MPTransactionActionSupport arg3);

    // typedef void (^MPTransactionProcessCompleted)(MPTransactionProcess * _Nonnull, MPTransaction * _Nullable, MPTransactionProcessDetails * _Nonnull);
    delegate void MPTransactionProcessCompleted (MPTransactionProcess arg0, [NullAllowed] MPTransaction arg1, MPTransactionProcessDetails arg2);

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
        MPTransactionProcessDetails Details();

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
        bool RequestAbort();

        // -(BOOL)canBeAborted;
        [Export("canBeAborted")]
        bool CanBeAborted();
    }

    // @interface MPTransactionProvider : NSObject
    [BaseType (typeof(NSObject))]
    interface MPTransactionProvider
    {
        // @property (readonly, nonatomic, strong) MPLocalizationToolbox * _Nonnull localizationToolbox;
        [Export ("localizationToolbox", ArgumentSemantic.Strong)]
        MPLocalizationToolbox LocalizationToolbox { get; }

        // @property (readonly, nonatomic, strong) MPTransactionModule * _Nonnull transactionModule;
        [Export ("transactionModule", ArgumentSemantic.Strong)]
        MPTransactionModule TransactionModule { get; }

        // @property (readonly, nonatomic, strong) MPAccessoryModule * _Nonnull accessoryModule;
        [Export ("accessoryModule", ArgumentSemantic.Strong)]
        MPAccessoryModule AccessoryModule { get; }

        // -(MPTransactionProcess * _Nonnull)startTransactionWithSessionIdentifier:(NSString * _Nonnull)sessionIdentifier accessoryParameters:(MPAccessoryParameters * _Nonnull)accessoryParameters statusChanged:(MPTransactionProcessStatusChanged _Nonnull)statusChanged actionRequired:(MPTransactionProcessActionRequired _Nonnull)actionRequired completed:(MPTransactionProcessCompleted _Nonnull)completed;
        [Export ("startTransactionWithSessionIdentifier:accessoryParameters:statusChanged:actionRequired:completed:")]
        MPTransactionProcess StartTransactionWithSessionIdentifier (string sessionIdentifier, MPAccessoryParameters accessoryParameters, MPTransactionProcessStatusChanged statusChanged, MPTransactionProcessActionRequired actionRequired, MPTransactionProcessCompleted completed);

        // -(MPTransactionProcess * _Nonnull)startTransactionWithSessionIdentifier:(NSString * _Nonnull)sessionIdentifier accessoryParameters:(MPAccessoryParameters * _Nonnull)accessoryParameters processParameters:(MPTransactionProcessParameters * _Nonnull)processParameters statusChanged:(MPTransactionProcessStatusChanged _Nonnull)statusChanged actionRequired:(MPTransactionProcessActionRequired _Nonnull)actionRequired completed:(MPTransactionProcessCompleted _Nonnull)completed;
        [Export ("startTransactionWithSessionIdentifier:accessoryParameters:processParameters:statusChanged:actionRequired:completed:")]
        MPTransactionProcess StartTransactionWithSessionIdentifier (string sessionIdentifier, MPAccessoryParameters accessoryParameters, MPTransactionProcessParameters processParameters, MPTransactionProcessStatusChanged statusChanged, MPTransactionProcessActionRequired actionRequired, MPTransactionProcessCompleted completed);

        // -(MPTransactionProcess * _Nonnull)startTransactionWithParameters:(MPTransactionParameters * _Nonnull)transactionParameters accessoryParameters:(MPAccessoryParameters * _Nonnull)accessoryParameters registered:(MPTransactionProcessRegistered _Nonnull)registered statusChanged:(MPTransactionProcessStatusChanged _Nonnull)statusChanged actionRequired:(MPTransactionProcessActionRequired _Nonnull)actionRequired completed:(MPTransactionProcessCompleted _Nonnull)completed;
        [Export ("startTransactionWithParameters:accessoryParameters:registered:statusChanged:actionRequired:completed:")]
        MPTransactionProcess StartTransactionWithParameters (MPTransactionParameters transactionParameters, MPAccessoryParameters accessoryParameters, MPTransactionProcessRegistered registered, MPTransactionProcessStatusChanged statusChanged, MPTransactionProcessActionRequired actionRequired, MPTransactionProcessCompleted completed);

        // -(MPTransactionProcess * _Nonnull)startTransactionWithParameters:(MPTransactionParameters * _Nonnull)transactionParameters accessoryParameters:(MPAccessoryParameters * _Nonnull)accessoryParameters processParameters:(MPTransactionProcessParameters * _Nullable)processParameters registered:(MPTransactionProcessRegistered _Nonnull)registered statusChanged:(MPTransactionProcessStatusChanged _Nonnull)statusChanged actionRequired:(MPTransactionProcessActionRequired _Nonnull)actionRequired completed:(MPTransactionProcessCompleted _Nonnull)completed;
        [Export ("startTransactionWithParameters:accessoryParameters:processParameters:registered:statusChanged:actionRequired:completed:")]
        MPTransactionProcess StartTransactionWithParameters (MPTransactionParameters transactionParameters, MPAccessoryParameters accessoryParameters, [NullAllowed] MPTransactionProcessParameters processParameters, MPTransactionProcessRegistered registered, MPTransactionProcessStatusChanged statusChanged, MPTransactionProcessActionRequired actionRequired, MPTransactionProcessCompleted completed);

        // -(MPTransactionProcess * _Nonnull)startTransactionWithParameters:(MPTransactionParameters * _Nonnull)transactionParameters accountParameters:(MPAccountParameters * _Nonnull)accountParameters registered:(MPTransactionProcessRegistered _Nonnull)registered statusChanged:(MPTransactionProcessStatusChanged _Nonnull)statusChanged completed:(MPTransactionProcessCompleted _Nonnull)completed;
        [Export ("startTransactionWithParameters:accountParameters:registered:statusChanged:completed:")]
        MPTransactionProcess StartTransactionWithParameters (MPTransactionParameters transactionParameters, MPAccountParameters accountParameters, MPTransactionProcessRegistered registered, MPTransactionProcessStatusChanged statusChanged, MPTransactionProcessCompleted completed);

        // -(MPTransactionProcess * _Nonnull)amendTransactionWithParameters:(MPTransactionParameters * _Nonnull)transactionParameters statusChanged:(MPTransactionProcessStatusChanged _Nonnull)statusChanged completed:(MPTransactionProcessCompleted _Nonnull)completed;
        [Export ("amendTransactionWithParameters:statusChanged:completed:")]
        MPTransactionProcess AmendTransactionWithParameters (MPTransactionParameters transactionParameters, MPTransactionProcessStatusChanged statusChanged, MPTransactionProcessCompleted completed);

        // -(MPPrintingProcess * _Nonnull)printCustomerReceiptForTransactionIdentifier:(NSString * _Nonnull)transactionIdentifier accessoryParameters:(MPAccessoryParameters * _Nonnull)accessoryParameters statusChanged:(MPPrintingProcessStatusChanged _Nonnull)statusChanged completed:(MPPrintingProcessCompleted _Nonnull)completed;
        [Export ("printCustomerReceiptForTransactionIdentifier:accessoryParameters:statusChanged:completed:")]
        MPPrintingProcess PrintCustomerReceiptForTransactionIdentifier (string transactionIdentifier, MPAccessoryParameters accessoryParameters, MPPrintingProcessStatusChanged statusChanged, MPPrintingProcessCompleted completed);
    }

    // @interface MPTransactionProcessDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionProcessDetails
    {
        // @property (readonly, assign, nonatomic) MPTransactionProcessDetailsState state;
        [Export("state", ArgumentSemantic.Assign)]
        MPTransactionProcessDetailsState State { get; }

        // @property (readonly, assign, nonatomic) MPTransactionProcessDetailsStateDetails stateDetails;
        [Export("stateDetails", ArgumentSemantic.Assign)]
        MPTransactionProcessDetailsStateDetails StateDetails { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull information;
        [Export("information", ArgumentSemantic.Strong)]
        string[] Information { get; }

        // @property (readonly, nonatomic, strong) NSError * _Nullable error;
        [NullAllowed, Export("error", ArgumentSemantic.Strong)]
        NSError Error { get; }
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

    // @protocol MPTransactionParametersChargeOptionals <MPTransactionParametersBasicOptionals>
    [Protocol]
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

    // @protocol MPTransactionParametersStandaloneRefundOptionals <MPTransactionParametersBasicOptionals>
    [Protocol]
    interface MPTransactionParametersStandaloneRefundOptionals : MPTransactionParametersBasicOptionals
    {
    }

    // @protocol MPTransactionParametersOptionals <MPTransactionParametersChargeOptionals>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPTransactionParametersOptionals : MPTransactionParametersChargeOptionals
    {
    }

    // @protocol MPTransactionParametersRefundOptionals <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPTransactionParametersRefundOptionals
    {
        // @required @property (nonatomic) NSString * _Nullable subject;
        [Abstract]
        [NullAllowed, Export("subject")]
        string Subject { get; set; }

        // @required @property (nonatomic) NSString * _Nullable customIdentifier;
        [Abstract]
        [NullAllowed, Export("customIdentifier")]
        string CustomIdentifier { get; set; }

        // @required -(void)setAmount:(NSDecimalNumber * _Nonnull)amount currency:(id)currency;
        [Abstract]
        [Export("setAmount:currency:")]
        void Currency(NSDecimalNumber amount, NSObject currency);
    }

    // @protocol MPTransactionParametersCaptureOptionals <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPTransactionParametersCaptureOptionals
    {
        // @required -(void)setAmount:(NSDecimalNumber * _Nonnull)amount currency:(id)currency;
        [Abstract]
        [Export("setAmount:currency:")]
        void Currency(NSDecimalNumber amount, NSObject currency);
    }

    // @protocol MPTransactionParametersTipAdjustOptionals <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPTransactionParametersTipAdjustOptionals
    {
        // @required -(void)setAmount:(NSDecimalNumber * _Nonnull)amount currency:(id)currency;
        [Abstract]
        [Export("setAmount:currency:")]
        void Currency(NSDecimalNumber amount, NSObject currency);
    }

    // typedef void (^MPTransactionParametersOptionalsBlock)(id<MPTransactionParametersOptionals> _Nonnull);
    delegate void MPTransactionParametersOptionalsBlock(MPTransactionParametersOptionals arg0);

    // typedef void (^MPTransactionParametersStandaloneRefundOptionalsBlock)(id<MPTransactionParametersStandaloneRefundOptionals> _Nonnull);
    delegate void MPTransactionParametersStandaloneRefundOptionalsBlock(MPTransactionParametersStandaloneRefundOptionals arg0);

    // typedef void (^MPTransactionParametersRefundOptionalsBlock)(id<MPTransactionParametersRefundOptionals> _Nonnull);
    delegate void MPTransactionParametersRefundOptionalsBlock(MPTransactionParametersRefundOptionals arg0);

    // typedef void (^MPTransactionParametersTipAdjustOptionalsBlock)(id<MPTransactionParametersTipAdjustOptionals> _Nonnull);
    delegate void MPTransactionParametersTipAdjustOptionalsBlock(MPTransactionParametersTipAdjustOptionals arg0);

    // typedef void (^MPTransactionParametersCaptureOptionalsBlock)(id<MPTransactionParametersCaptureOptionals> _Nonnull);
    delegate void MPTransactionParametersCaptureOptionalsBlock(MPTransactionParametersCaptureOptionals arg0);

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

    // typedef void (^MPAccessoryOptionalsBlock)(id<MPAccessoryOptionals> _Nonnull);
    delegate void MPAccessoryOptionalsBlock(MPAccessoryOptionals arg0);

    // typedef void (^MPExternalAccessoryOptionalsBlock)(id<MPExternalAccessoryOptionals> _Nonnull);
    delegate void MPExternalAccessoryOptionalsBlock(MPExternalAccessoryOptionals arg0);

    /*[Static]
    [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern NSString *const _Nonnull MPAccessoryOptionalsProtocolKey;
        [Field("MPAccessoryOptionalsProtocolKey", "__Internal")]
        NSString MPAccessoryOptionalsProtocolKey { get; }

        // extern NSString *const _Nonnull MPAccessoryOptionalsNamePrefixKey;
        [Field("MPAccessoryOptionalsNamePrefixKey", "__Internal")]
        NSString MPAccessoryOptionalsNamePrefixKey { get; }

        // extern NSString *const _Nonnull MPAccessoryOptionalsRemoteKey;
        [Field("MPAccessoryOptionalsRemoteKey", "__Internal")]
        NSString MPAccessoryOptionalsRemoteKey { get; }

        // extern NSString *const _Nonnull MPAccessoryOptionalsPortKey;
        [Field("MPAccessoryOptionalsPortKey", "__Internal")]
        NSString MPAccessoryOptionalsPortKey { get; }
    }*/

    // @interface MPAccessoryParameters : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryParameters
    {
        // @property (readonly, assign, nonatomic) int accessoryFamily;
        [Export("accessoryFamily")]
        MPAccessoryFamily AccessoryFamily { get; }

        // @property (readonly, assign, nonatomic) int connectionType;
        [Export("connectionType")]
        MPAccessoryConnectionType ConnectionType { get; }

        // @property (readonly, nonatomic, strong) NSDictionary * _Nullable filters;
        [NullAllowed, Export("filters", ArgumentSemantic.Strong)]
        NSDictionary Filters { get; }

        // @property (readonly, assign, nonatomic) int locale;
        [Export("locale")]
        int Locale { get; }

        // @property (readonly, assign, nonatomic) BOOL keepAlive;
        [Export("keepAlive")]
        bool KeepAlive { get; }

        // +(instancetype _Nonnull)externalAccessoryParametersWithFamily:(id)family protocol:(NSString * _Nonnull)protocol optionals:(MPExternalAccessoryOptionalsBlock _Nullable)optionalsBlock;
        [Static]
        [Export("externalAccessoryParametersWithFamily:protocol:optionals:")]
        MPAccessoryParameters ExternalAccessoryParametersWithFamily(MPAccessoryFamily family, string protocol, [NullAllowed] MPExternalAccessoryOptionalsBlock optionalsBlock);

        // +(instancetype _Nonnull)audioJackAccessoryParametersWithFamily:(id)family optionals:(MPAccessoryOptionalsBlock _Nullable)optionalsBlock;
        [Static]
        [Export("audioJackAccessoryParametersWithFamily:optionals:")]
        MPAccessoryParameters AudioJackAccessoryParametersWithFamily(MPAccessoryFamily family, [NullAllowed] MPAccessoryOptionalsBlock optionalsBlock);

        // +(instancetype _Nonnull)tcpAccessoryParametersWithFamily:(id)family remote:(NSString * _Nonnull)remote port:(NSUInteger)port optionals:(MPAccessoryOptionalsBlock _Nullable)optionalsBlock;
        [Static]
        [Export("tcpAccessoryParametersWithFamily:remote:port:optionals:")]
        MPAccessoryParameters TcpAccessoryParametersWithFamily(MPAccessoryFamily family, string remote, nuint port, [NullAllowed] MPAccessoryOptionalsBlock optionalsBlock);

        // +(instancetype _Nonnull)mockAccessoryParameters;
        [Static]
        [Export("mockAccessoryParameters")]
        MPAccessoryParameters MockAccessoryParameters();
    }

    // @interface MPAccountParameters : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccountParameters
    {
        // +(instancetype _Nullable)alipayParametersWithShopperIdentifier:(NSString * _Nonnull)shopperIdentifier source:(MPPaymentDetailsSource)source;
        [Static]
        [Export("alipayParametersWithShopperIdentifier:source:")]
        [return: NullAllowed]
        MPAccountParameters AlipayParametersWithShopperIdentifier(string shopperIdentifier, MPPaymentDetailsSource source);
    }

    // @protocol MPTransactionProcessParametersSteps <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MPTransactionProcessParametersSteps
    {
        // @required -(void)addAskForTipStepWithSuggestedAmount:(NSDecimalNumber * _Nullable)suggestedAmount __attribute__((deprecated("Use setTippingStepParameters method")));
        //[Abstract]
       // [Export("addAskForTipStepWithSuggestedAmount:")]
        //void AddAskForTipStepWithSuggestedAmount([NullAllowed] NSDecimalNumber suggestedAmount);

        // @required -(void)setTippingStepParameters:(MPTransactionProcessTippingStepParameters * _Nullable)tippingStepParameters;
       // [Abstract]
       // [Export("setTippingStepParameters:")]
       // void SetTippingStepParameters([NullAllowed] MPTransactionProcessTippingStepParameters tippingStepParameters);
    }

    // typedef void (^MPTransactionProcessParametersStepsBlock)(id<MPTransactionProcessParametersSteps> _Nonnull);
    delegate void MPTransactionProcessParametersStepsBlock(MPTransactionProcessParametersSteps arg0);

    // @interface MPTransactionProcessParameters : NSObject
    [BaseType (typeof(NSObject))]
    interface MPTransactionProcessParameters
    {
        // +(instancetype _Nullable)parametersWithSteps:(MPTransactionProcessParametersStepsBlock _Nonnull)stepsBlock;
        [Static]
        [Export ("parametersWithSteps:")]
        [return: NullAllowed]
        MPTransactionProcessParameters ParametersWithSteps (MPTransactionProcessParametersStepsBlock stepsBlock);
    }

    // @protocol MPAccessoryComponentTippingParametersOptionals <NSObject>
    /*[BaseType(typeof(NSObject))]
    interface MPAccessoryComponentTippingParametersOptionals
    {
        // @required -(void)setShowConfirmationScreen:(BOOL)showConfirmationScreen;
        //[Abstract]
        [Export("setShowConfirmationScreen:")]
        void SetShowConfirmationScreen(bool showConfirmationScreen);

        // @required -(void)setSuggestedAmount:(NSDecimalNumber * _Nullable)suggestedAmount;
        //[Abstract]
        [Export("setSuggestedAmount:")]
        void SetSuggestedAmount([NullAllowed] NSDecimalNumber suggestedAmount);

        // @required -(void)setFormatWithIntegerDigits:(NSUInteger)integerDigits fractionDigits:(NSUInteger)fractionDigits;
        //[Abstract]
        [Export("setFormatWithIntegerDigits:fractionDigits:")]
        void SetFormatWithIntegerDigits(nuint integerDigits, nuint fractionDigits);
    }*/

    // @protocol MPAccessoryComponentTippingTipAmountParametersOptionals <MPAccessoryComponentTippingParametersOptionals>
   /* [BaseType(typeof(MPAccessoryComponentTippingParametersOptionals))]
    interface MPAccessoryComponentTippingTipAmountParametersOptionals
    {
    }

// @protocol MPAccessoryComponentTippingTotalAmountParametersOptionals <MPAccessoryComponentTippingParametersOptionals>
    [BaseType(typeof(MPAccessoryComponentTippingParametersOptionals))]
    interface MPAccessoryComponentTippingTotalAmountParametersOptionals
    {
        // @required -(void)setZeroAmountDefaultsToTransactionAmount:(BOOL)zeroAmountDefaultsToTransactionAmount;
        [Abstract]
        [Export("setZeroAmountDefaultsToTransactionAmount:")]
        void SetZeroAmountDefaultsToTransactionAmount(bool zeroAmountDefaultsToTransactionAmount);
    }

    */

    /*

    // typedef void (^MPAccessoryComponentTippingTipAmountParametersOptionalsBlock)(id<MPAccessoryComponentTippingTipAmountParametersOptionals> _Nonnull);
    delegate void MPAccessoryComponentTippingTipAmountParametersOptionalsBlock(MPAccessoryComponentTippingTipAmountParametersOptionals arg0);

    // typedef void (^MPAccessoryComponentTippingTotalAmountParametersOptionalsBlock)(id<MPAccessoryComponentTippingTotalAmountParametersOptionals> _Nonnull);
    delegate void MPAccessoryComponentTippingTotalAmountParametersOptionalsBlock(MPAccessoryComponentTippingTotalAmountParametersOptionals arg0);

    // @interface MPAccessoryComponentTippingParameters : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryComponentTippingParameters
    {
        // +(instancetype _Nonnull)tippingAmountParametersWithTransactionAmount:(NSDecimalNumber * _Nonnull)transactionAmount currency:(id)currency optionalsBlock:(MPAccessoryComponentTippingTipAmountParametersOptionalsBlock _Nullable)optionalsBlock;
        [Static]
        [Export("tippingAmountParametersWithTransactionAmount:currency:optionalsBlock:")]
        MPAccessoryComponentTippingParameters TippingAmountParametersWithTransactionAmount(NSDecimalNumber transactionAmount, NSObject currency, [NullAllowed] MPAccessoryComponentTippingTipAmountParametersOptionalsBlock optionalsBlock);

        // +(instancetype _Nonnull)totalAmountParametersWithTransactionAmount:(NSDecimalNumber * _Nonnull)transactionAmount currency:(id)currency optionalsBlock:(MPAccessoryComponentTippingTotalAmountParametersOptionalsBlock _Nullable)optionalsBlock;
        [Static]
        [Export("totalAmountParametersWithTransactionAmount:currency:optionalsBlock:")]
        MPAccessoryComponentTippingParameters TotalAmountParametersWithTransactionAmount(NSDecimalNumber transactionAmount, NSObject currency, [NullAllowed] MPAccessoryComponentTippingTotalAmountParametersOptionalsBlock optionalsBlock);
    }*/


    /*


    



    // typedef void (^MPTransactionProcessTippingAmountStepParametersOptionalsBlock)(id<MPTransactionProcessTippingAmountStepParametersOptionals> _Nonnull);
    //delegate void MPTransactionProcessTippingAmountStepParametersOptionalsBlock(MPTransactionProcessTippingAmountStepParametersOptionals arg0);

    // typedef void (^MPTransactionProcessTippingTotalStepParametersOptionalsBlock)(id<MPTransactionProcessTippingTotalStepParametersOptionals> _Nonnull);
    //delegate void MPTransactionProcessTippingTotalStepParametersOptionalsBlock(MPTransactionProcessTippingTotalStepParametersOptionals arg0);


    // @interface MPTransactionProcessTippingStepParameters : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionProcessTippingStepParameters
    {
        // +(instancetype _Nonnull)tippingAmountParametersWithOptionalsBlock:(MPTransactionProcessTippingAmountStepParametersOptionalsBlock _Nullable)optionalsBlock;
        //[Static]
        //[Export("tippingAmountParametersWithOptionalsBlock:")]
        //MPTransactionProcessTippingStepParameters TippingAmountParametersWithOptionalsBlock([NullAllowed] MPTransactionProcessTippingAmountStepParametersOptionalsBlock optionalsBlock);

        // +(instancetype _Nonnull)tippingTotaltParametersWithOptionalsBlock:(MPTransactionProcessTippingTotalStepParametersOptionalsBlock _Nullable)optionalsBlock;
        //[Static]
        //[Export("tippingTotaltParametersWithOptionalsBlock:")]
        //MPTransactionProcessTippingStepParameters TippingTotaltParametersWithOptionalsBlock([NullAllowed] MPTransactionProcessTippingTotalStepParametersOptionalsBlock optionalsBlock);
    }*/

    // @interface MPLocalizationToolbox : NSObject
    [BaseType(typeof(NSObject))]
    interface MPLocalizationToolbox
    {
        // -(NSString * _Nullable)textFormattedForAmount:(NSDecimalNumber * _Nullable)amount currency:(id)currency;
        [Export("textFormattedForAmount:currency:")]
        [return: NullAllowed]
        string TextFormattedForAmount([NullAllowed] NSDecimalNumber amount, NSObject currency);

        // -(NSString * _Nullable)textFormattedForDate:(NSDate * _Nullable)date;
        [Export("textFormattedForDate:")]
        [return: NullAllowed]
        string TextFormattedForDate([NullAllowed] NSDate date);

        // -(NSString * _Nullable)textFormattedForTime:(NSDate * _Nullable)time;
        [Export("textFormattedForTime:")]
        [return: NullAllowed]
        string TextFormattedForTime([NullAllowed] NSDate time);

        // -(NSString * _Nullable)textFormattedForTimeAndDate:(NSDate * _Nullable)datetime;
        [Export("textFormattedForTimeAndDate:")]
        [return: NullAllowed]
        string TextFormattedForTimeAndDate([NullAllowed] NSDate datetime);

        // -(NSString * _Nullable)informationForTransactionStatusDetailsCode:(MPTransactionStatusDetailsCode)code;
        [Export("informationForTransactionStatusDetailsCode:")]
        [return: NullAllowed]
        string InformationForTransactionStatusDetailsCode(MPTransactionStatusDetailsCode code);
    }

    // @interface MPAccessoryProcessDetails : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryProcessDetails
    {
        // @property (readonly, assign, nonatomic) MPAccessoryProcessDetailsState state;
        [Export("state", ArgumentSemantic.Assign)]
        MPAccessoryProcessDetailsState State { get; }

        // @property (readonly, assign, nonatomic) MPAccessoryProcessDetailsStateDetails stateDetails;
        [Export("stateDetails", ArgumentSemantic.Assign)]
        MPAccessoryProcessDetailsStateDetails StateDetails { get; }

        // @property (readonly, nonatomic, strong) NSArray * _Nonnull information;
        [Export("information", ArgumentSemantic.Strong)]
        string[] Information { get; }

        // @property (readonly, nonatomic, strong) NSError * _Nullable error;
        [NullAllowed, Export("error", ArgumentSemantic.Strong)]
        NSError Error { get; }
    }

    // @interface MPAccessoryProcess : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryProcess
    {
        // @property (readonly, nonatomic, strong) MPAccessory * _Nullable accessory;
        [NullAllowed, Export("accessory", ArgumentSemantic.Strong)]
        MPAccessory Accessory { get; }

        // @property (readonly, nonatomic, strong) MPAccessoryProcessDetails * _Nonnull details;
        [Export("details", ArgumentSemantic.Strong)]
        MPAccessoryProcessDetails Details { get; }

        // -(BOOL)requestAbort;
        [Export("requestAbort")]
        bool RequestAbort();

        // -(BOOL)canBeAborted;
        [Export("canBeAborted")]
        bool CanBeAborted();
    }

    // typedef void (^MPAccessoryProcessStatusChanged)(MPAccessoryProcess * _Nonnull, MPAccessory * _Nullable, MPAccessoryProcessDetails * _Nonnull);
    delegate void MPAccessoryProcessStatusChanged(MPAccessoryProcess arg0, [NullAllowed] MPAccessory arg1, MPAccessoryProcessDetails arg2);

    // typedef void (^MPAccessoryProcessCompleted)(MPAccessoryProcess * _Nonnull, MPAccessory * _Nonnull, MPAccessoryProcessDetails * _Nonnull);
    delegate void MPAccessoryProcessCompleted(MPAccessoryProcess arg0, MPAccessory arg1, MPAccessoryProcessDetails arg2);

    // typedef void (^MPAccessoryModuleConnectionStateChanged)(MPAccessory * _Nonnull);
    delegate void MPAccessoryModuleConnectionStateChanged(MPAccessory arg0);


    // @interface MPAccessoryModule : NSObject
    [BaseType(typeof(NSObject))]
    interface MPAccessoryModule
    {
        // -(NSArray * _Nonnull)connectedAccesories;
        [Export("connectedAccesories")]
        MPAccessory[] ConnectedAccesories();

        // -(MPAccessoryProcess * _Nonnull)connectToAccessoryWithAccessoryParameters:(MPAccessoryParameters * _Nonnull)parameters statusChanged:(MPAccessoryProcessStatusChanged _Nonnull)statusChanged completed:(MPAccessoryProcessCompleted _Nonnull)completed;
        [Export("connectToAccessoryWithAccessoryParameters:statusChanged:completed:")]
        MPAccessoryProcess ConnectToAccessoryWithAccessoryParameters(MPAccessoryParameters parameters, MPAccessoryProcessStatusChanged statusChanged, MPAccessoryProcessCompleted completed);

        // -(MPAccessoryProcess * _Nonnull)updateAccessory:(MPAccessory * _Nonnull)accessory statusChanged:(MPAccessoryProcessStatusChanged _Nonnull)statusChanged completed:(MPAccessoryProcessCompleted _Nonnull)completed;
        [Export("updateAccessory:statusChanged:completed:")]
        MPAccessoryProcess UpdateAccessory(MPAccessory accessory, MPAccessoryProcessStatusChanged statusChanged, MPAccessoryProcessCompleted completed);

        // -(MPAccessoryProcess * _Nonnull)disconnectFromAccessory:(MPAccessory * _Nonnull)accessory statusChanged:(MPAccessoryProcessStatusChanged _Nonnull)statusChanged completed:(MPAccessoryProcessCompleted _Nonnull)completed;
        [Export("disconnectFromAccessory:statusChanged:completed:")]
        MPAccessoryProcess DisconnectFromAccessory(MPAccessory accessory, MPAccessoryProcessStatusChanged statusChanged, MPAccessoryProcessCompleted completed);

        // @property (copy, nonatomic) MPAccessoryModuleConnectionStateChanged _Nullable connectionStateChangedBlock;
        [NullAllowed, Export("connectionStateChangedBlock", ArgumentSemantic.Copy)]
        MPAccessoryModuleConnectionStateChanged ConnectionStateChangedBlock { get; set; }
    }

    // @interface MPTransactionFilterParameters : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionFilterParameters
    {
        // +(instancetype)emptyFilter;
        [Static]
        [Export("emptyFilter")]
        MPTransactionFilterParameters EmptyFilter();

        // +(instancetype)filterWithCustomIdentifier:(NSString *)customIdentifier;
        [Static]
        [Export("filterWithCustomIdentifier:")]
        MPTransactionFilterParameters FilterWithCustomIdentifier(string customIdentifier);
    }

    [BaseType(typeof(NSObject))]
    interface MPDisplayUpdateSupport
    {
        
    }

    // typedef void (^MPTransactionModuleLookupByTransactionIdentifierCompleted)(MPTransaction * _Nullable, NSError * _Nullable);
    delegate void MPTransactionModuleLookupByTransactionIdentifierCompleted([NullAllowed] MPTransaction arg0, [NullAllowed] NSError arg1);

    // typedef void (^MPTransactionModulQueryCompleted)(NSArray * _Nullable, NSError * _Nullable);
    delegate void MPTransactionModulQueryCompleted([NullAllowed] NSObject[] arg0, [NullAllowed] NSError arg1);

    // typedef void (^MPTransactionModuleSendingCustomerReceiptCompleted)(NSString * _Nonnull, NSString * _Nonnull, NSError * _Nullable);
    delegate void MPTransactionModuleSendingCustomerReceiptCompleted(string arg0, string arg1, [NullAllowed] NSError arg2);


    // @interface MPTransactionModule : NSObject
    [BaseType(typeof(NSObject))]
    interface MPTransactionModule
    {
        // -(void)lookupTransactionWithTransactionIdentifier:(NSString * _Nonnull)transactionIdentifier completed:(MPTransactionModuleLookupByTransactionIdentifierCompleted _Nonnull)completed;
        [Export("lookupTransactionWithTransactionIdentifier:completed:")]
        void LookupTransactionWithTransactionIdentifier(string transactionIdentifier, MPTransactionModuleLookupByTransactionIdentifierCompleted completed);

        // -(void)queryTransactionsUsingFilters:(MPTransactionFilterParameters * _Nullable)filterParameters completed:(MPTransactionModulQueryCompleted _Nonnull)completed;
        [Export("queryTransactionsUsingFilters:completed:")]
        void QueryTransactionsUsingFilters([NullAllowed] MPTransactionFilterParameters filterParameters, MPTransactionModulQueryCompleted completed);

        // -(void)queryTransactionsUsingFilters:(MPTransactionFilterParameters * _Nullable)filterParameters includeReceipts:(BOOL)includeReceipts range:(NSRange)range completed:(MPTransactionModulQueryCompleted _Nonnull)completed;
        [Export("queryTransactionsUsingFilters:includeReceipts:range:completed:")]
        void QueryTransactionsUsingFilters([NullAllowed] MPTransactionFilterParameters filterParameters, bool includeReceipts, NSRange range, MPTransactionModulQueryCompleted completed);

        // -(void)sendCustomerReceiptForTransactionIdentifier:(NSString * _Nonnull)transactionIdentifier emailAddress:(NSString * _Nonnull)emailAddress completed:(MPTransactionModuleSendingCustomerReceiptCompleted _Nonnull)completed;
        [Export("sendCustomerReceiptForTransactionIdentifier:emailAddress:completed:")]
        void SendCustomerReceiptForTransactionIdentifier(string transactionIdentifier, string emailAddress, MPTransactionModuleSendingCustomerReceiptCompleted completed);
    }

}
