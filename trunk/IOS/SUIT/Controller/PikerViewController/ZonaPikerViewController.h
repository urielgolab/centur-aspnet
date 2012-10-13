//
//  ZonaPikerViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "PikerTableViewController.h"
#import "ZonaCell.h"

@interface ZonaPikerViewController : PikerTableViewController<SubzonaTarget>{
    NSObject<Zonable>* zonable;
}

@property(nonatomic,retain) NSObject<Zonable>* zonable;

@end
