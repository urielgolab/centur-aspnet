//
//  ProvedoresListViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "CategoriaSearchParametre.h"
#import "SRVBusqueda.h"
#import "ServiciosResult.h"
#import "BaseViewController.h"

@interface ProvedoresListViewController : BaseViewController<SearchDelegate,UITableViewDelegate,UITableViewDataSource>{
    CategoriaSearchParametre* searchParametre;
    ServiciosResult* result;
    
    IBOutlet UITableView* _tableView;
    
}

@property(nonatomic,retain) CategoriaSearchParametre* searchParametre;
@property(nonatomic,retain)UITableView* tableView;

@end
