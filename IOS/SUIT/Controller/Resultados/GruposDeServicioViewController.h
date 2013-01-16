//
//  GruposDeServicioViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 15/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface GruposDeServicioViewController : UITableViewController

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andServicio:(Servicio*)servicio;

@property(nonatomic,retain) Servicio* servicio;
@property(nonatomic,retain) NSArray* grupos;


@end
