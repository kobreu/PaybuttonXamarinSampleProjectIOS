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
 * Detailing the current state of the transaction process.
 * @since 2.18.0
 */
typedef NS_ENUM(NSUInteger, MPAccessoryProcessDetailsState) {
    /** The process has been initialized and awaits execution */
    MPAccessoryProcessDetailsStateCreated,
    /** The process is establishing a connection to the accessory */
    MPAccessoryProcessDetailsStateConnectingToAccessory,
    /** The process is updating the accessory */
    MPAccessoryProcessDetailsStateUpdatingAccessory,
    /** The process is disconnecting from the accessory */
    MPAccessoryProcessDetailsStateDisconnectingFromAccessory,
    /** The process completed successfully */
    MPAccessoryProcessDetailsStateCompleted,
    /** The process was aborted */
    MPAccessoryProcessDetailsStateAborted,
    /** The process failed in one of the stages */
    MPAccessoryProcessDetailsStateFailed
};


/**
 * More detailed information on the current state of the process.
 * @since 2.18.0
 */
typedef NS_ENUM(NSUInteger, MPAccessoryProcessDetailsStateDetails) {

    /** The process has been initialized and awaits execution */
    MPAccessoryProcessDetailsStateDetailsCreated,
    /** The process is establishing a connection to the accessory */
    MPAccessoryProcessDetailsStateDetailsConnectingToAccessory,
    /** The process is retrying a connection to the accessory
        because if was not found on the first attempt */
    MPAccessoryProcessDetailsStateDetailConnectingToAccessoryRetrying,
    /** The process is checking if the accessory requires an update */
    MPAccessoryProcessDetailsStateDetailsCheckingForUpdate,
    /** The process is updating the accessory */
    MPAccessoryProcessDetailsStateDetailsUpdatingAccessory,
    /** The process is provisioning the accessory */
    MPAccessoryProcessDetailsStateDetailsProvisioningAccessory,
    /** The process is disconnecting from the accessory */
    MPAccessoryProcessDetailsStateDetailsDisconnectingFromAccessory,
    /** The process completed successfully */
    MPAccessoryProcessDetailsStateDetailsCompleted,
    /** The process was aborted */
    MPAccessoryProcessDetailsStateDetailsAborted,
    /** The process failed in one of the stages */
    MPAccessoryProcessDetailsStateDetailsFailed
};


@interface MPAccessoryProcessDetails : NSObject


/**
 * Provides a high level status of the current state of the process
 * @since 2.18.0
 */
@property (assign, readonly, nonatomic) MPAccessoryProcessDetailsState state;


/**
 * Provides more details information on the current state of the process
 * @since 2.18.0
 */
@property (assign, readonly, nonatomic) MPAccessoryProcessDetailsStateDetails stateDetails;


/**
 * Provides two localized lines of text (each with max 40 characters) that can be displayed on screen suitable for the current status
 * @since 2.18.0
 */
@property (strong, readonly, nonatomic, nonnull) NSArray *information;


/**
 * Holds the error thrown by the underlying components in case of a failure.
 * @since 2.18.0
 */
@property (strong, readonly, nonatomic, nullable) NSError *error;


@end
