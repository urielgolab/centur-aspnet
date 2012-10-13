//
//  BusquedaCategoriaViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "CategoriaSearchParametre.h"
#import "BaseViewController.h"

@interface BusquedaCategoriaViewController : BaseViewController<CategoriaSearchParametreDelegate,UIAlertViewDelegate,UITableViewDelegate,UITableViewDataSource>{
    CategoriaSearchParametre* searchParametre;
    IBOutlet UITableView* _tableview;
}


@end
