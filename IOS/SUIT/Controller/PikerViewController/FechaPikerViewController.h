//
//  FechaPikerViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "EntitiesProtocols.h"

@interface FechaPikerViewController : UIViewController{
    IBOutlet UIScrollView * scroll;
    __weak IBOutlet UIDatePicker *datePiker;
    
    NSDate* minunDate;
    NSDate* maxDate;
}

@property(nonatomic,retain) NSDate* minunDate;
@property(nonatomic,retain) NSDate* maxDate;
@property(nonatomic,copy) void (^searchBlock)(NSDate* date);

@end
