//
// PAYWORKS GMBH ("COMPANY") CONFIDENTIAL
// Copyright (c) 2015 Payworks GmbH, All Rights Reserved.
//
// NOTICE:  All information contained herein is, and remains the property of COMPANY. The intellectual and technical concepts contained
// herein are proprietary to COMPANY and may be covered by European or foreign Patents, patents in process, and are protected by trade secret or copyright law.
// Dissemination of this information or reproduction of this material is strictly forbidden unless prior written permission is obtained
// from COMPANY.  Access to the source code contained herein is hereby forbidden to anyone except current COMPANY employees, managers or contractors who have executed
// Confidentiality and Non-disclosure agreements explicitly covering such access.
//
// The copyright notice above does not evidence any actual or intended publication or disclosure of this source code, which includes
// information that is confidential and/or proprietary, and is a trade secret, of COMPANY.
// ANY REPRODUCTION, MODIFICATION, DISTRIBUTION, PUBLIC  PERFORMANCE,
// OR PUBLIC DISPLAY OF OR THROUGH USE  OF THIS  SOURCE CODE  WITHOUT  THE EXPRESS WRITTEN CONSENT OF COMPANY IS STRICTLY PROHIBITED, AND IN VIOLATION OF APPLICABLE
// LAWS AND INTERNATIONAL TREATIES.  THE RECEIPT OR POSSESSION OF  THIS SOURCE CODE AND/OR RELATED INFORMATION DOES NOT CONVEY OR IMPLY ANY RIGHTS
// TO REPRODUCE, DISCLOSE OR DISTRIBUTE ITS CONTENTS, OR TO MANUFACTURE, USE, OR SELL ANYTHING THAT IT  MAY DESCRIBE, IN WHOLE OR IN PART.


#import "MPTransaction.h"


/**
 * Describes the type of the transaction parameters
 * @since 2.8.0
 */
typedef NS_ENUM(NSUInteger, MPTransactionParametersType) {
    MPTransactionParametersTypeCharge,
    MPTransactionParametersTypeRefund,
    MPTransactionParametersTypeCapture,
    MPTransactionParametersTypeTipAdjust
};


/**
 * Protocol implemented by the optionals object, on which basic additional parameters for a transaction can be set
 * @see MPTransactionParameters for parameters description
 * @since 2.24.0
 */
@protocol MPTransactionParametersBasicOptionals <NSObject>

/**
 * The subject of the transaction.
 * @since 2.24.0
 */
@property (nonatomic, nullable) NSString *subject;

/**
 * An custom identifier, that can be used to reference transaction to your internal system.
 * Valid range is ([A-Z][a-z][0-9])*{0,256}.
 * @since 2.24.0
 */
@property (nonatomic, nullable) NSString *customIdentifier;

/**
 * An arbitrary string to be displayed on your customer's credit card statement.
 * @note Certain limitations may apply. Please check the documentation related to the aquirers you are working with.
 * @since 2.24.0
 */
@property (nonatomic, nullable) NSString *statementDescriptor;

/**
 * The fee that will be added to the transaction costs.
 * @since 2.24.0
 */
@property (nonatomic, nullable) NSDecimalNumber *applicationFee;

/**
 * A set of key/value pairs that you can attach to a charge object.
 * @note Size limits may apply! Please check the documentation related to aquirers you work with
 * @since 2.24.0
 */
@property (nonatomic, nullable) NSDictionary *metadata;

@end



@protocol MPTransactionParametersChargeOptionals <MPTransactionParametersBasicOptionals>

/**
 * Sets the tip amount which is included in the transaction. The tip is a part of the full transaction amount.
 * Please check the documentation related to the acquirers you are working with.
 * @since 2.24.0
 */
@property (nonatomic, nullable) NSDecimalNumber *includedTipAmount;

/**
 * Sets if the transaction should be auto captured. By default is YES.
 *
 * @since 2.24.0
 */
@property (nonatomic, assign) BOOL autoCapture;

/**
 * Sets if the transaction as adjustable tip. By default is NO.
 *
 * @since 2.24.0
 */
@property (nonatomic, assign) BOOL tipAdjustable;

@end


/**
 * Protocol implemented by the optionals object, on which additional parameters for a standalone refund transaction can be set
 * @see MPTransactionParameters for parameters description
 * @since 2.24.0
 */
@protocol MPTransactionParametersStandaloneRefundOptionals <MPTransactionParametersBasicOptionals>

@end


/**
 * Protocol implemented by the optionals object, on which additional parameters for a transaction can be set
 * @see MPTransactionParameters for parameters description
 * @since 2.5.0
 */
@protocol MPTransactionParametersOptionals <MPTransactionParametersChargeOptionals>

@end


/**
 * Protocol implemented by the refund optionals object, on which additional parameters for a transaction can be set
 * @see MPTransactionParameters for parameters description
 * @since 2.5.0
 */
@protocol MPTransactionParametersRefundOptionals <NSObject>

/**
 * The subject of the transaction.
 * @since 2.5.0
 */

@property (nonatomic, nullable) NSString *subject;
/**
 * An custom identifier, that can be used to reference transaction to your internal system.
 * Valid range is ([A-Z][a-z][0-9])*{0,256}.
 * @since 2.5.0
 */
@property (nonatomic, nullable) NSString *customIdentifier;

/**
 * Sets the amount and currency.
 * @param amount The amount.
 * @param currency The currency.
 * @since 2.5.0
 */
- (void)setAmount:(nonnull NSDecimalNumber*)amount currency:(MPCurrency)currency;

@end



/**
 * Protocol implemented by the capture optionals object, on which additional parameters for a partial capture can be set
 * @see MPTransactionParameters for parameters description
 * @since 2.8.0
 */
@protocol MPTransactionParametersCaptureOptionals <NSObject>

/**
 * Sets the amount and currency.
 * @param amount The amount to be captured.
 * @param currency The currency.
 * @since 2.8.0
 */
- (void)setAmount:(nonnull NSDecimalNumber*)amount currency:(MPCurrency)currency;

@end



/**
 * Protocol implemented by the tip adjust optionals object, on which additional parameters for a tip adjust can be set
 * @see MPTransactionParameters for parameters description
 * @since 2.22.0
 */
@protocol MPTransactionParametersTipAdjustOptionals <NSObject>

/**
 * Sets the amount and currency.
 * @param amount The amount to be captured.
 * @param currency The currency.
 * @since 2.22.0
 */
- (void)setAmount:(nonnull NSDecimalNumber*)amount currency:(MPCurrency)currency;

@end



/**
 * Optionals callback definition, providing access to an object to set optional parameters for a transaction.
 * @param optionals Object to set optional parameters on.
 * @since 2.5.0
 */
typedef void (^MPTransactionParametersOptionalsBlock)(id<MPTransactionParametersOptionals>_Nonnull optionals);

/**
 * Optionals callback definition, providing access to an object to set optional parameters for a standalone refund transaction.
 * @param optionals Object to set optional parameters on.
 * @since 2.24.0
 */
typedef void (^MPTransactionParametersStandaloneRefundOptionalsBlock)(id<MPTransactionParametersStandaloneRefundOptionals>_Nonnull optionals);

/**
 * Optionals callback definition, providing access to an object to set optional parameters for a refund.
 * @param optionals Object to set optional parameters on.
 * @since 2.5.0
 */
typedef void (^MPTransactionParametersRefundOptionalsBlock)(id<MPTransactionParametersRefundOptionals>_Nonnull optionals);

/**
 * Optionals callback definition, providing access to an object to set optional parameters for a tip adjust.
 * @param optionals Object to set optional parameters on.
 * @since 2.22.0
 */
typedef void (^MPTransactionParametersTipAdjustOptionalsBlock)(id<MPTransactionParametersTipAdjustOptionals>_Nonnull optionals);


/**
 * Optionals callback definition, providing access to an object to set optional parameters for a capture.
 * @param optionals Object to set optional parameters on.
 * @since 2.5.0
 */
typedef void (^MPTransactionParametersCaptureOptionalsBlock)(id<MPTransactionParametersCaptureOptionals>_Nonnull optionals);


/**
 * Transaction parameters that describe the initial parameters of a transaction.
 * The parameters are used to register a transaction via the Extended category on MPProvider or to start a one
 * on MPTransactionProvider.
 * @since 2.5.0
 */
@interface MPTransactionParameters : NSObject <NSCopying>

/**
 * The type of the transaction.
 * @since 2.5.0
 */
@property (nonatomic, readonly, assign) MPTransactionType transactionType;

/**
 * The amount of the transaction.
 * @since 2.5.0
 */
@property (nonatomic, readonly, copy, nullable) NSDecimalNumber *amount;

/**
 * The currency of the transaction.
 * @since 2.5.0
 */
@property (nonatomic, readonly, assign) MPCurrency currency;

/**
 * Sets if the transaction should be auto captured. By default is YES.
 *
 * @since 2.8.0
 */
@property (nonatomic, readonly, assign) BOOL autoCapture;

/**
 * Sets if the transaction as adjustable tip. By default is NO.
 *
 * @since 2.22.0
 */
@property (nonatomic, readonly, assign) BOOL tipAdjustable;

/**
 * A reference to a previous transaction.
 * Required for referencing transactions (e.g. refund).
 * @since 2.5.0
 */
@property (nonatomic, readonly, copy, nullable) NSString *referencedTransactionIdentifier;

/**
 * A reference to the custom identifier of a previous transaction
 * @since 2.5.0
 */
@property (nonatomic, readonly, copy, nullable) NSString *referencedCustomIdentifier;

/**
 * The subject of the transaction.
 * @since 2.5.0
 */
@property (nonatomic, readonly, copy, nullable) NSString *subject;

/**
 * An (optional) custom identifier, that can be used to reference transaction to your internal system.
 * Valid range is ([A-Z][a-z][0-9])*{0,256}.
 * @throws NSException if customerIdentifier is not in the valid range when set on the optionals object. Nil and Empty value is OK.
 * @since 2.5.0
 */
@property (nonatomic, readonly, copy, nullable) NSString *customIdentifier;

/**
 * An arbitrary string to be displayed on your customer's credit card statement.
 * @note Certain limitations may apply. Please check the documentation related to the aquirers you are working with.
 * @since 2.5.0
 */
@property (nonatomic, readonly, copy, nullable) NSString *statementDescriptor;

/**
 * The fee that will be added to the transaction costs.
 * @since 2.5.0
 */
@property (nonatomic, readonly, copy, nullable) NSDecimalNumber *applicationFee;

/**
 * Sets the tip amount which is included in the transaction. The tip is a part of the full transaction amount.
 * Please check the documentation related to the acquirers you are working with.
 * @since 2.7.0
 */
@property (nonatomic, readonly, copy, nullable) NSDecimalNumber *includedTipAmount;

/**
 * A set of key/value pairs that you can attach to a charge object.
 * @note Size limits may apply! Please check the documentation related to aquirers you work with
 * @since 2.5.0
 */
@property (nonatomic, readonly, copy, nullable) NSDictionary *metadata;


/**
 * Type of the parameter
 * @since 2.8.0
 */
@property (nonatomic, readonly, assign) MPTransactionParametersType parametersType;


/**
 * Creates parameters for a new charge transaction.
 * @param amount The amount of the transaction
 * @param currency The currency of the transaction
 * @param optionalsBlock A block that has one argument - an object on which optional parameters can be set. Can be null.
 * @return A new transaction parameters object that can be used to start a transaction
 * @throws NSException if amount is nil or NaN
 * @since 2.5.0
 */
+ (nonnull instancetype)chargeWithAmount:(nonnull NSDecimalNumber*)amount currency:(MPCurrency)currency optionals:(nullable MPTransactionParametersOptionalsBlock)optionalsBlock;


/**
 * Creates parameters for a new, standalone refund transaction.
 * @param amount The amount of the transaction
 * @param currency The currency of the transaction
 * @param optionalsBlock A block that has one argument - an object on which optional parameters can be set. Can be null.
 * @return A new transaction parameters object that can be used to start a transaction
 * @throws NSException if amount is nil or NaN
 * @since 2.24.0
 */
+ (nonnull instancetype)refundWithAmount:(nonnull NSDecimalNumber*)amount currency:(MPCurrency)currency optionals:(nullable MPTransactionParametersStandaloneRefundOptionalsBlock)optionalsBlock;


/**
 * Creates parameters for a refund transaction, linking to a previous transaction. This is for looking up the actual transaction which should get refunded.
 * @param transactionIdentifier The transaction to reference
 * @param optionalsBlock A block that has one argument - an object on which optional parameters can be set. Can be null.
 * @return A new transaction parameters object that can be used to start a refund transaction
 * @since 2.5.0
 */
+ (nonnull instancetype)refundForTransactionIdentifier:(nonnull NSString*)transactionIdentifier optionals:(nullable MPTransactionParametersRefundOptionalsBlock)optionalsBlock;


/**
 * Creates parameters for a refund transaction, linking to a transaction with the given custom identifier. This is for looking up the actual transaction which should get refunded.
 * @param customIdentifier The customIdentifier of the linked transaction
 * @param optionalsBlock A block that has one argument - an object on which optional parameters can be set. Can be null.
 * @return A new transaction parameters object that can be used to start a refund transaction
 * @since 2.5.0
 */
+ (nonnull instancetype)refundForCustomIdentifier:(nonnull NSString*)customIdentifier optionals:(nullable MPTransactionParametersRefundOptionalsBlock)optionalsBlock;

/**
 * Creates parameters for a tip adjust transaction, linking to a previous transaction which should get tip adjusted.
 * @param transactionIdentifier The transaction to reference
 * @param optionalsBlock A block that has one argument - an object on which optional parameters can be set. Can be null.
 * @return A new transaction parameters object that can be used to start a tip adjust transaction
 * @since 2.22.0
 */
+ (nonnull instancetype)tipAdjustForTransactionIdentifier:(nonnull NSString*)transactionIdentifier optionals:(nullable MPTransactionParametersTipAdjustOptionalsBlock)optionalsBlock;

/**
 * Creates parameters for a capture of a transaction which has not been yet captured.
 * @param transactionIdentifier The transaction to capture
 * @since 2.8.0
 */
+ (nonnull instancetype)captureTransactionWithIdentifier:(nonnull NSString*)transactionIdentifier optionals:(nullable MPTransactionParametersCaptureOptionalsBlock)optionalsBlock;



/**
 * Sets a new included tip amount and adjusts transaction amount accordingly BEFORE starting a transction.
 * If a tip was non-zero before update - the transaction amount will be adjusted by the difference in tip amounts, i.e. increased if new tip amount is higher and decreased otherwise.
 * @param tipAmount The new included tip amount
 * @throws NSException if in the result the new included tip or transaction amount is negative
 * @since 2.19.0
 */
- (void)updateIncludedTipAmount:(nonnull NSDecimalNumber*)tipAmount;

/**
 * Updates transaction with new amount including tip BEFORE starting.
 * If a tip was non-zero before update - the transaction amount will be adjusted.
 * @param amountIncludingTip The total transaction amount that includes tip amount
 * @throws NSException if in the result the new included tip or transaction amount is negative
 * @since 2.22.0
 */
- (void)updateAmountWithAmountIncludingTip:(nonnull NSDecimalNumber*)amountIncludingTip;

@end
