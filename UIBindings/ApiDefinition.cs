using System;

using UIKit;
using Foundation;
using ObjCRuntime;
using CoreGraphics;
using MPOS

namespace MPOSUI
{
    
}

namespace MPOSUI
{
    // typedef void (^MPUTransactionCompleted)(UIViewController * _Nonnull, MPUTransactionResult, MPTransaction * _Nullable);
    delegate void MPUTransactionCompleted(UIViewController arg0, MPUTransactionResult arg1, [NullAllowed] MPTransaction arg2);

    // typedef void (^MPUPrintReceiptCompleted)(UIViewController * _Nonnull, MPUPrintReceiptResult);
    delegate void MPUPrintReceiptCompleted(UIViewController arg0, MPUPrintReceiptResult arg1);

    // typedef void (^MPUSummaryCompleted)(UIViewController * _Nonnull);
    delegate void MPUSummaryCompleted(UIViewController arg0);

    // typedef void (^MPUSettingsCompleted)(UIViewController * _Nonnull);
    delegate void MPUSettingsCompleted(UIViewController arg0);

    // typedef void (^MPULoginCompleted)(UIViewController * _Nonnull, MPULoginResult);
    delegate void MPULoginCompleted(UIViewController arg0, MPULoginResult arg1);

    // @interface MPUMposUi : NSObject
    [BaseType(typeof(NSObject))]
    interface MPUMposUi
    {
        // @property (nonatomic, strong) MPTransaction * _Nullable transaction;
        [NullAllowed, Export("transaction", ArgumentSemantic.Strong)]
        MPTransaction Transaction { get; set; }

        // @property (nonatomic, strong) int * _Nullable transactionProvider;
        [NullAllowed, Export("transactionProvider", ArgumentSemantic.Strong)]
        unsafe int* TransactionProvider { get; set; }

        // @property (nonatomic, strong) int * _Nullable transactionProcessDetails;
        [NullAllowed, Export("transactionProcessDetails", ArgumentSemantic.Strong)]
        unsafe int* TransactionProcessDetails { get; set; }

        // @property (nonatomic, strong) NSError * _Nullable error;
        [NullAllowed, Export("error", ArgumentSemantic.Strong)]
        NSError Error { get; set; }

        // @property (nonatomic, strong) MPUMposUiConfiguration * _Nonnull configuration;
        [Export("configuration", ArgumentSemantic.Strong)]
        MPUMposUiConfiguration Configuration { get; set; }

        // +(NSString * _Nonnull)version;
        [Static]
        [Export("version")]
        [Verify(MethodToProperty)]
        string Version { get; }

        // +(instancetype _Nullable)sharedInitializedInstance;
        [Static]
        [Export("sharedInitializedInstance")]
        [return: NullAllowed]
        MPUMposUi SharedInitializedInstance();

        // +(instancetype _Nonnull)initializeWithProviderMode:(id)providerMode merchantIdentifier:(NSString * _Nonnull)merchantIdentifier merchantSecret:(NSString * _Nonnull)merchantSecret;
        [Static]
        [Export("initializeWithProviderMode:merchantIdentifier:merchantSecret:")]
        MPUMposUi InitializeWithProviderMode(NSObject providerMode, string merchantIdentifier, string merchantSecret);

        // +(instancetype _Nonnull)initializeWithApplication:(MPUApplicationName)applicationName integratorIdentifier:(NSString * _Nonnull)integratorIdentifier __attribute__((deprecated("Use initializeWithProviderMode:application:integratorIdentifier instead")));
        [Static]
        [Export("initializeWithApplication:integratorIdentifier:")]
        MPUMposUi InitializeWithApplication(MPUApplicationName applicationName, string integratorIdentifier);

        // +(instancetype _Nonnull)initializeWithProviderMode:(id)providerMode application:(MPUApplicationName)applicationName integratorIdentifier:(NSString * _Nonnull)integratorIdentifier;
        [Static]
        [Export("initializeWithProviderMode:application:integratorIdentifier:")]
        MPUMposUi InitializeWithProviderMode(NSObject providerMode, MPUApplicationName applicationName, string integratorIdentifier);

        // -(UIViewController * _Nonnull)createTransactionViewControllerWithSessionIdentifier:(NSString * _Nonnull)sessionIdentifier completed:(MPUTransactionCompleted _Nonnull)completed;
        [Export("createTransactionViewControllerWithSessionIdentifier:completed:")]
        UIViewController CreateTransactionViewControllerWithSessionIdentifier(string sessionIdentifier, MPUTransactionCompleted completed);

        // -(UIViewController * _Nonnull)createChargeTransactionViewControllerWithAmount:(NSDecimalNumber * _Nonnull)amount currency:(id)currency subject:(NSString * _Nullable)subject customIdentifier:(NSString * _Nullable)customIdentifier completed:(MPUTransactionCompleted _Nonnull)completed __attribute__((deprecated("Use createTransactionViewControllerWithTransactionParameters:completed: instead")));
        [Export("createChargeTransactionViewControllerWithAmount:currency:subject:customIdentifier:completed:")]
        UIViewController CreateChargeTransactionViewControllerWithAmount(NSDecimalNumber amount, NSObject currency, [NullAllowed] string subject, [NullAllowed] string customIdentifier, MPUTransactionCompleted completed);

        // -(UIViewController * _Nonnull)createRefundTransactionViewControllerWithTransactionIdentifer:(NSString * _Nonnull)transactionIndentifier subject:(NSString * _Nullable)subject customIdentifier:(NSString * _Nullable)customIdentifier completed:(MPUTransactionCompleted _Nonnull)completed __attribute__((deprecated("Use createTransactionViewControllerWithTransactionParameters:completed: instead")));
        [Export("createRefundTransactionViewControllerWithTransactionIdentifer:subject:customIdentifier:completed:")]
        UIViewController CreateRefundTransactionViewControllerWithTransactionIdentifer(string transactionIndentifier, [NullAllowed] string subject, [NullAllowed] string customIdentifier, MPUTransactionCompleted completed);

        // -(UIViewController * _Nonnull)createTransactionViewControllerWithTransactionParameters:(id)transactionParameters completed:(MPUTransactionCompleted _Nonnull)completed;
        [Export("createTransactionViewControllerWithTransactionParameters:completed:")]
        UIViewController CreateTransactionViewControllerWithTransactionParameters(NSObject transactionParameters, MPUTransactionCompleted completed);

        // -(UIViewController * _Nonnull)createTransactionViewControllerWithTransactionParameters:(id)transactionParameters processParameters:(id)processParameters completed:(MPUTransactionCompleted _Nonnull)completed;
        [Export("createTransactionViewControllerWithTransactionParameters:processParameters:completed:")]
        UIViewController CreateTransactionViewControllerWithTransactionParameters(NSObject transactionParameters, NSObject processParameters, MPUTransactionCompleted completed);

        // -(UIViewController * _Nonnull)createSummaryViewControllerWithTransactionIdentifier:(NSString * _Nonnull)transacitonIdentifier completed:(MPUSummaryCompleted _Nonnull)completed;
        [Export("createSummaryViewControllerWithTransactionIdentifier:completed:")]
        UIViewController CreateSummaryViewControllerWithTransactionIdentifier(string transacitonIdentifier, MPUSummaryCompleted completed);

        // -(UIViewController * _Nonnull)createPrintTransactionViewControllerWithTransactionIdentifier:(NSString * _Nonnull)transactionIdentifier completed:(MPUPrintReceiptCompleted _Nonnull)completed;
        [Export("createPrintTransactionViewControllerWithTransactionIdentifier:completed:")]
        UIViewController CreatePrintTransactionViewControllerWithTransactionIdentifier(string transactionIdentifier, MPUPrintReceiptCompleted completed);

        // -(UIViewController * _Nonnull)createSettingsViewController:(MPUSettingsCompleted _Nonnull)completed;
        [Export("createSettingsViewController:")]
        UIViewController CreateSettingsViewController(MPUSettingsCompleted completed);

        // -(UIViewController * _Nonnull)createLoginViewController:(MPULoginCompleted _Nonnull)completed;
        [Export("createLoginViewController:")]
        UIViewController CreateLoginViewController(MPULoginCompleted completed);

        // -(void)logoutFromApplication;
        [Export("logoutFromApplication")]
        void LogoutFromApplication();

        // -(BOOL)isApplicationLoggedIn;
        [Export("isApplicationLoggedIn")]
        [Verify(MethodToProperty)]
        bool IsApplicationLoggedIn { get; }
    }

    // @interface MPUMposUiAppearance : NSObject
    [BaseType(typeof(NSObject))]
    interface MPUMposUiAppearance
    {
        // @property (nonatomic, strong) UIColor * _Nonnull navigationBarTint;
        [Export("navigationBarTint", ArgumentSemantic.Strong)]
        UIColor NavigationBarTint { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull navigationBarTextColor;
        [Export("navigationBarTextColor", ArgumentSemantic.Strong)]
        UIColor NavigationBarTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
        [Export("backgroundColor", ArgumentSemantic.Strong)]
        UIColor BackgroundColor { get; set; }

        // @property (assign, nonatomic) UIStatusBarStyle statusBarStyle;
        [Export("statusBarStyle", ArgumentSemantic.Assign)]
        UIStatusBarStyle StatusBarStyle { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull preauthorizedBackgroundColor;
        [Export("preauthorizedBackgroundColor", ArgumentSemantic.Strong)]
        UIColor PreauthorizedBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull preauthorizedTextColor;
        [Export("preauthorizedTextColor", ArgumentSemantic.Strong)]
        UIColor PreauthorizedTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull approvedBackgroundColor;
        [Export("approvedBackgroundColor", ArgumentSemantic.Strong)]
        UIColor ApprovedBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull approvedTextColor;
        [Export("approvedTextColor", ArgumentSemantic.Strong)]
        UIColor ApprovedTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull declinedBackgroundColor;
        [Export("declinedBackgroundColor", ArgumentSemantic.Strong)]
        UIColor DeclinedBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull declinedTextColor;
        [Export("declinedTextColor", ArgumentSemantic.Strong)]
        UIColor DeclinedTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull refundedBackgroundColor;
        [Export("refundedBackgroundColor", ArgumentSemantic.Strong)]
        UIColor RefundedBackgroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull refundedTextColor;
        [Export("refundedTextColor", ArgumentSemantic.Strong)]
        UIColor RefundedTextColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable actionButtonTextColor;
        [NullAllowed, Export("actionButtonTextColor", ArgumentSemantic.Strong)]
        UIColor ActionButtonTextColor { get; set; }
    }

    [Static]
    [Verify(ConstantsInterfaceAssociation)]
    partial interface Constants
    {
        // extern const NSTimeInterval MPUMposUiConfigurationResultDisplayCloseTimeout;
        [Field("MPUMposUiConfigurationResultDisplayCloseTimeout", "__Internal")]
        double MPUMposUiConfigurationResultDisplayCloseTimeout { get; }
    }

    // @interface MPUMposUiConfiguration : NSObject
    [BaseType(typeof(NSObject))]
    interface MPUMposUiConfiguration
    {
        // @property (assign, nonatomic) int terminalFamily __attribute__((deprecated("Use terminalParameters instead!")));
        [Export("terminalFamily")]
        int TerminalFamily { get; set; }

        // @property (nonatomic, strong) int * _Nonnull terminalParameters;
        [Export("terminalParameters", ArgumentSemantic.Strong)]
        unsafe int* TerminalParameters { get; set; }

        // @property (assign, nonatomic) int printerFamily __attribute__((deprecated("Use printerParameters instead!")));
        [Export("printerFamily")]
        int PrinterFamily { get; set; }

        // @property (nonatomic, strong) int * _Nonnull printerParameters;
        [Export("printerParameters", ArgumentSemantic.Strong)]
        unsafe int* PrinterParameters { get; set; }

        // @property (nonatomic, strong) MPUMposUiAppearance * _Nonnull appearance;
        [Export("appearance", ArgumentSemantic.Strong)]
        MPUMposUiAppearance Appearance { get; set; }

        // @property (assign, nonatomic) MPUMposUiConfigurationSignatureCapture signatureCapture;
        [Export("signatureCapture", ArgumentSemantic.Assign)]
        MPUMposUiConfigurationSignatureCapture SignatureCapture { get; set; }

        // @property (assign, nonatomic) MPUMposUiConfigurationSummaryFeature summaryFeatures;
        [Export("summaryFeatures", ArgumentSemantic.Assign)]
        MPUMposUiConfigurationSummaryFeature SummaryFeatures { get; set; }

        // @property (assign, nonatomic) MPUMposUiConfigurationResultDisplayBehavior resultDisplayBehavior;
        [Export("resultDisplayBehavior", ArgumentSemantic.Assign)]
        MPUMposUiConfigurationResultDisplayBehavior ResultDisplayBehavior { get; set; }

        // @property (assign, nonatomic) MPUMposUiConfigurationPaymentMethod paymentMethods;
        [Export("paymentMethods", ArgumentSemantic.Assign)]
        MPUMposUiConfigurationPaymentMethod PaymentMethods { get; set; }
    }

}
