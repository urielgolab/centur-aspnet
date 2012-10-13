//
//  UIButton+urlImages.h
//  Batangav2
//
//  Created by ManuelRKenar on 24/08/12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import <Availability.h>

@interface UIButton (urlImages)

-(void)setImageUrl:(NSString *)urlString forState:(UIControlState)state;

@end
