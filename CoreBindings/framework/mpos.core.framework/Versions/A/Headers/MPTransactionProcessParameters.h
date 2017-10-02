//
// PAYWORKS GMBH ("COMPANY") CONFIDENTIAL
// Copyright (c) 2016 Payworks GmbH, All Rights Reserved.
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


@class MPTransactionProcessTippingStepParameters;


@protocol MPTransactionProcessParametersSteps <NSObject>

/**
 * Creates an 'ask for tip' step.
 * @param suggestedAmount The amount to be displayed as a suggestion for a tip. If nil - then no suggestion will be displayed.
 * @since 2.7.0
 * @deprecated 2.22.0
 */
- (void)addAskForTipStepWithSuggestedAmount:(nullable NSDecimalNumber *)suggestedAmount DEPRECATED_MSG_ATTRIBUTE("Use setTippingStepParameters method");

/**
 * Sets transaction process tipping step parameters
 * @since 2.22.0
 */
- (void)setTippingStepParameters:(nullable MPTransactionProcessTippingStepParameters *)tippingStepParameters;


@end


typedef void (^MPTransactionProcessParametersStepsBlock)(_Nonnull id<MPTransactionProcessParametersSteps> steps);

/**
 * Specify the parameters for the transaction process.
 * For example you can enable asking the customer for the tip amount during the transaction.
 * These can be provided when starting a transaction.
 * @since 2.7.0
 */
@interface MPTransactionProcessParameters : NSObject

/**
 * Constructor for a new parameters object
 * @param stepsBlock Block that will be executed to further customize parameters
 * @since 2.22.0
 */
+ (nullable instancetype)parametersWithSteps:(nonnull MPTransactionProcessParametersStepsBlock)stepsBlock;

@end
