//
//  MasterViewController.h
//  SUIT
//
//  Created by Manuel  Kenar on 02-06-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "BaseViewController.h"

@class DetailViewController;
@class BaseViewController;

@interface MainViewController : BaseViewController<UITableViewDelegate,UITableViewDataSource>{
   IBOutlet UITableView* _tableView;
}

@property (strong, nonatomic) DetailViewController *detailViewController;

@end
