//
//  PikerTableViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "BasePikerViewController.h"

@interface PikerTableViewController : BasePikerViewController<UITableViewDelegate,UITableViewDataSource>{
    IBOutlet UITableView* _tableView;
}

@property(nonatomic,retain) UITableView *tableView;

@end
