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
    NSObject<Fecheable>* fecheable;
    
    IBOutlet UIDatePicker* pikerDesde;
    IBOutlet UIDatePicker* pikerHasta;
    IBOutlet UIScrollView * scroll;
}

@property (nonatomic,retain) NSObject<Fecheable>* fecheable;
@end
