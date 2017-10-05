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

/**
 * Options to customize transaction process tipping step parameters
 * @since 2.22.0
 */
@protocol MPTransactionProcessTippingStepParametersOptionals <NSObject>

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
 * Options to customize tipping amount parameters
 * @since 2.22.0
 */
@protocol MPTransactionProcessTippingAmountStepParametersOptionals <MPTransactionProcessTippingStepParametersOptionals>
@end

/**
 * Options to customize tipping total parameters
 * @since 2.22.0
 */
@protocol MPTransactionProcessTippingTotalStepParametersOptionals <MPTransactionProcessTippingStepParametersOptionals>

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
typedef void (^MPTransactionProcessTippingAmountStepParametersOptionalsBlock)(id<MPTransactionProcessTippingAmountStepParametersOptionals> _Nonnull optionals);

/**
 * Type of block used to set optional parameters for tipping total flow
 * @since 2.22.0
 */
typedef void (^MPTransactionProcessTippingTotalStepParametersOptionalsBlock)(id<MPTransactionProcessTippingTotalStepParametersOptionals> _Nonnull optionals);


/**
 * Transaction process step parameters used to handle request for tip
 * @since 2.22.0
 */
@interface MPTransactionProcessTippingStepParameters : NSObject

/**
 * Constructor of transaction process tipping step parameters for amount flow
 * @param optionalsBlock Block that will be executed to further customize parameters
 * @since 2.22.0
 */
+ (nonnull instancetype)tippingAmountParametersWithOptionalsBlock:(nullable MPTransactionProcessTippingAmountStepParametersOptionalsBlock)optionalsBlock;


/**
 * Constructor of transaction process tipping step parameters for total flow
 * @param optionalsBlock Block that will be executed to further customize parameters
 * @since 2.22.0
 */
+ (nonnull instancetype)tippingTotaltParametersWithOptionalsBlock:(nullable MPTransactionProcessTippingTotalStepParametersOptionalsBlock)optionalsBlock;


@end
