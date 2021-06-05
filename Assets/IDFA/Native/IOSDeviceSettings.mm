#include <AppTrackingTransparency/ATTrackingManager.h>
//#import <FBAudienceNetwork/FBAdSettings.h>
#import <FBSDKCoreKit/FBSDKSettings.h>

extern "C" void _SetAdvertiserTrackingEnabled(bool trackingEnabled)
{
    if (@available(iOS 14, *)) {
        NSLog(@"FBAdSettings setAdvertiserTrackingEnabled: %@", trackingEnabled ? @"YES" : @"NO");
//        [FBAdSettings setAdvertiserTrackingEnabled: trackingEnabled];
        [FBSDKSettings setAdvertiserTrackingEnabled: trackingEnabled];
    }
}

extern "C" void _RequestIDFA()
{
    if (@available(iOS 14, *)) {
        [ATTrackingManager requestTrackingAuthorizationWithCompletionHandler:^(ATTrackingManagerAuthorizationStatus status) {
            
            bool trackingEnabled = (status != ATTrackingManagerAuthorizationStatusDenied);
            NSLog(@"&&&& ATTrackingManagerAuthorizationStatus trackingEnabled: = %u", (unsigned)trackingEnabled);
            
            _SetAdvertiserTrackingEnabled(trackingEnabled);
        }];
    }
}
