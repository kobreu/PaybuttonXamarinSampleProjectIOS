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


#import "MPAccessoryComponent.h"
#import "MPTransaction.h"

@class MPAccessoryComponentTipping;

/**
 * Asking for tip was successful
 * @param tipAmount The amount of the tip.
 * @since 2.11.0
 * @deprecated 2.22.0
 */
typedef void (^MPAccessoryComponentTippingAskForTipSuccess)(MPAccessoryComponentTipping * _Nonnull component, NSDecimalNumber * _Nonnull tipAmount) DEPRECATED_ATTRIBUTE;

/**
 * Asking for tip failed
 * @param error Error that describes why the tip failed
 * @since 2.11.0
 * @deprecated 2.22.0
 */
typedef void (^MPAccessoryComponentTippingAskForTipFailure)(MPAccessoryComponentTipping * _Nonnull component, NSError * _Nonnull error) DEPRECATED_ATTRIBUTE;

/**
 * Asking for tip was aborted
 * @since 2.11.0
 * @deprecated 2.22.0
 */
typedef void (^MPAccessoryComponentTippingAskForTipAbort)(MPAccessoryComponentTipping * _Nonnull component) DEPRECATED_ATTRIBUTE;

/**
 * Asking for tip was successful
 * @param amount The amount returned by tipping accessory, total transaction amount if askForTotalAmount parameter is set or tip amount if not
 * @since 2.22.0
 */
typedef void (^MPAccessoryComponentTippingAskSuccess)(MPAccessoryComponentTipping * _Nonnull component, NSDecimalNumber * _Nonnull tippingAmount);

/**
 * Asking for tip failed
 * @param error Error that describes why the tip failed
 * @since 2.22.0
 */
typedef void (^MPAccessoryComponentTippingAskFailure)(MPAccessoryComponentTipping * _Nonnull component, NSError * _Nonnull error);

/**
 * Asking for tip was aborted
 * @since 2.22.0
 */
typedef void (^MPAccessoryComponentTippingAskAbort)(MPAccessoryComponentTipping * _Nonnull component);

@class MPAccessoryComponentTippingParameters;

/**
 * A an additional component of an accessory which provides a way to ask user for a tip
 * @since 2.7.0
 */
@interface MPAccessoryComponentTipping : MPAccessoryComponent

/**
 * The component asks the user if they want to enter a tip and (if the answer is positive) for the tip amount.
 * @param transactionAmount Transaction amount for which the tip is asked for
 * @param currency Currency of the transaction
 * @param suggestedTip Tip to suggest to customer
 * @param success Executed when the user entered a tip
 * @param abort Executed when user refused to tip
 * @param failure Executed when something have gone wrong
 * @since 2.11.0
 * @deprecated 2.22.0
 */
- (void)askForTipForAmount:(nonnull NSDecimalNumber *)transactionAmmount
                  currency:(MPCurrency)currency
              suggestedTip:(nullable NSDecimalNumber *)suggestedTip
                   success:(_Nonnull MPAccessoryComponentTippingAskForTipSuccess)success
                     abort:(_Nonnull MPAccessoryComponentTippingAskForTipAbort)abort
                   failure:(_Nonnull MPAccessoryComponentTippingAskForTipFailure)failure DEPRECATED_MSG_ATTRIBUTE("Use askForTipWithParameters:success:abort:failure: method");


/**
 * The component asks the user if they want to add a tip and (if the answer is positive) for the tip or total amount.
 * @param parameters Provides tipping related information
 * @param success Executed when the user entered a tip
 * @param abort Executed when user refused to tip
 * @param failure Executed when something have gone wrong
 * @since 2.22.0
 */
- (void)askForTipWithParameters:(nonnull MPAccessoryComponentTippingParameters *)parameters
                        success:(_Nonnull MPAccessoryComponentTippingAskSuccess)success
                          abort:(_Nonnull MPAccessoryComponentTippingAskAbort)abort
                        failure:(_Nonnull MPAccessoryComponentTippingAskFailure)failure;


@end
