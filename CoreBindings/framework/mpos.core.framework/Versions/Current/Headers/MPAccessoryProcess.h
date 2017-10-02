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
#import "MPAccessoryProcessDetails.h"

@class MPAccessory;


@interface MPAccessoryProcess : NSObject


/**
 * Indicates a status change of the overall process and provides information about what is happening with process.
 * @param accessoryProcess The instance that called the block
 * @param accessory The accessory that is currently being processed
 * @param details The latest details object for providing access to the overall processing status
 * @since 2.18.0
 */
typedef void (^MPAccessoryProcessStatusChanged)(MPAccessoryProcess * _Nonnull accesoryProcess, MPAccessory * _Nullable accessory, MPAccessoryProcessDetails * _Nonnull details);


/**
 * Indicates that the process has been completed. The accesoryProcess.details provide additional information on the result of the process.
 * @param accesoryProcess The instance that called the block
 * @param accessory The accessory that has been used by the process
 * @param details The latest details object for providing access to the overall processing status (same as accesoryProcess.details)
 * @since 2.18.0
 */
typedef void (^MPAccessoryProcessCompleted)(MPAccessoryProcess * _Nonnull accesoryProcess, MPAccessory * _Nonnull accessory, MPAccessoryProcessDetails * _Nonnull details);


/**
 * The accessory object used by the process.
 * @since 2.18.0
 */
@property (strong, readonly, nonatomic, nullable) MPAccessory *accessory;


/**
 * The accessory process details providing access to the current status.
 * @since 2.18.0
 */
@property (strong, readonly, nonatomic, nonnull) MPAccessoryProcessDetails *details;


/**
 * Requests an abort at the next possible moment. Repeated calls are ignored.
 * Once the abort was successful, the process completes and has state == MPAccessoryProcessDetailsStateAborted.
 * @returns Returns NO if the process can not be aborted, and YES if the abort has been queued but is not guaranteed to happen
 * @since 2.18.0
 */
- (BOOL)requestAbort;


/**
 * Indicates whether the process can be aborted.
 * @return YES if it can be aborted, NO otherwise
 * @since 2.18.0
 */
- (BOOL)canBeAborted;

@end
