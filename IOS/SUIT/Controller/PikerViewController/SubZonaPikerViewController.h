//
//  SubZonaPikerViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "PikerTableViewController.h"
#import "ZonaCell.h"

@interface SubZonaPikerViewController : PikerTableViewController<SubzonaTarget>{
    Zona* zona;
    NSObject<Zonable>* zonable;

}

@property(nonatomic,retain) NSObject<Zonable>* zonable;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andZona:(Zona*)aZona;

@end
