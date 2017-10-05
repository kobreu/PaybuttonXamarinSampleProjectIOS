//
// PAYWORKS GMBH ("COMPANY") CONFIDENTIAL
// Copyright (c) 2017 Payworks GmbH, All Rights Reserved.
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

#import <Foundation/Foundation.h>
#import "MPTransaction.h"


/**
 * Options to customize tipping accessory parameters
 * @since 2.22.0
 */
@protocol MPAccessoryComponentTippingParametersOptionals <NSObject>

/**
 * Sets parameter that determines if to present confirmation screen
 * @since 2.22.0
 */
- (void)setShowConfirmationScreen:(BOOL)showConfirmationScreen;

/**
 * Sets suggested amount (tipping amount or total transaction amount)
 * @since 2.22.0
 */
- (void)setSuggestedAmount:(nullable NSDecimalNumber *)suggestedAmount;

/**
 * Sets tipping amount prompt format
 * @param integerDigits Max integer digits prompt part
 * @param fractionDigits Fraction digits prompt part
 * @since 2.22.0
 */
- (void)setFormatWithIntegerDigits:(NSUInteger)integerDigits fractionDigits:(NSUInteger)fractionDigits;

@end

/**
 * Options to customize tipping amount accessory parameters
 * @since 2.22.0
 */
@protocol MPAccessoryComponentTippingTipAmountParametersOptionals <MPAccessoryComponentTippingParametersOptionals>
@end

/**
 * Options to customize tipping total accessory parameters
 * @since 2.22.0
 */
@protocol MPAccessoryComponentTippingTotalAmountParametersOptionals <MPAccessoryComponentTippingParametersOptionals>

/**
 * Sets the parameter that determines if default transaction amount is equal to zero
 * @since 2.22.0
 */
- (void)setZeroAmountDefaultsToTransactionAmount:(BOOL)zeroAmountDefaultsToTransactionAmount;

@end

/**
 * Type of block used to set optional parameters for tipping amount flow
 * @since 2.22.0
 */
typedef void (^MPAccessoryComponentTippingTipAmountParametersOptionalsBlock)(id<MPAccessoryComponentTippingTipAmountParametersOptionals> _Nonnull optionals);

/**
 * Type of block used to set optional parameters for tipping total flow
 * @since 2.22.0
 */
typedef void (^MPAccessoryComponentTippingTotalAmountParametersOptionalsBlock)(id<MPAccessoryComponentTippingTotalAmountParametersOptionals> _Nonnull optionals);


/**
 * Accessory parameters used to handle request for tip
 * @since 2.22.0
 */
@interface MPAccessoryComponentTippingParameters : NSObject

/**
 * Constructor of new accessory parameters object for tipping amount flow
 * @param transactionAmount Transaction amount before tipping
 * @param currency Transaction currency
 * @param optionalsBlock Block that will be executed to further customize parameters
 * @since 2.22.0
 */
+ (nonnull instancetype)tippingAmountParametersWithTransactionAmount:(nonnull NSDecimalNumber *)transactionAmount
                                                            currency:(MPCurrency)currency
                                                      optionalsBlock:(nullable MPAccessoryComponentTippingTipAmountParametersOptionalsBlock)optionalsBlock;

/**
 * Constructor of new accessory parameters object for tipping total flow
 * @param transactionAmount Transaction amount before tipping
 * @param currency Transaction currency
 * @param optionalsBlock Block that will be executed to further customize parameters
 * @since 2.22.0
 */
+ (nonnull instancetype)totalAmountParametersWithTransactionAmount:(nonnull NSDecimalNumber *)transactionAmount
                                                          currency:(MPCurrency)currency
                                                    optionalsBlock:(nullable MPAccessoryComponentTippingTotalAmountParametersOptionalsBlock)optionalsBlock;

@end
