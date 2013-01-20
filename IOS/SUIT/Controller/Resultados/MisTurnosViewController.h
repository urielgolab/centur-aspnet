//
//  MisTurnosViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 10/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>

@interface MisTurnosViewController : UITableViewController

@property(atomic,retain) NSMutableArray* misTurnosConfirmados;
@property(atomic,retain) NSMutableArray* misTurnosNoConfirmados;

@end
