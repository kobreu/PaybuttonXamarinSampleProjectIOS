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
#import "MPAccessoryProcess.h"

@class MPAccessory;
@class MPAccessoryParameters;

typedef void (^MPAccessoryModuleConnectionStateChanged)(MPAccessory * _Nonnull accessory);


@interface MPAccessoryModule : NSObject

/**
 * Return all connected accessories
 * @since 2.18.0
 */
- (nonnull NSArray *)connectedAccesories;


/**
 * Connects to an accessory with the given parameters.
 * @param parameters The accessory parameters to be used for the connection effort
 * @param statusChanged The status of the process changed and new information can be displayed to the user
 * @param completed The completed handler called when the connection effort is completed
 * @return MPAccessoryProcess The process object used.
 * @since 2.18.0
 */
- (nonnull MPAccessoryProcess *)connectToAccessoryWithAccessoryParameters:(nonnull MPAccessoryParameters *)parameters
                                                            statusChanged:(nonnull MPAccessoryProcessStatusChanged)statusChanged
                                                                completed:(nonnull MPAccessoryProcessCompleted)completed;


/**
 * Updates an accessory with update process.
 * @param statusChanged The status of the process changed and new information can be displayed to the user
 * @param completed The completed handler called when the updating effort is completed
 * @since 2.18.0
 */
- (nonnull MPAccessoryProcess *)updateAccessory:(nonnull MPAccessory*)accessory
                                  statusChanged:(nonnull MPAccessoryProcessStatusChanged)statusChanged
                                      completed:(nonnull MPAccessoryProcessCompleted)completed;


/**
 * Disconnects from an accessory with the given parameters.
 * @param parameters The accessory parameters to be used for the disconnecting effort
 * @param completed The completed handler called when the disconnecting effort is completed
 * @since 2.18.0
 */
- (nonnull MPAccessoryProcess *)disconnectFromAccessory:(nonnull MPAccessory*)accessory
                                          statusChanged:(nonnull MPAccessoryProcessStatusChanged)statusChanged
                                              completed:(nonnull MPAccessoryProcessCompleted)completed;



/**
 * Block to be executed when an accessory changes it's connection state
 * @since 2.18.0
 */
@property (nonatomic, copy, nullable) MPAccessoryModuleConnectionStateChanged connectionStateChangedBlock;

@end
