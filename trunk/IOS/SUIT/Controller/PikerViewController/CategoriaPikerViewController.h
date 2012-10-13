//
//  CategoriaPikerViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "PikerTableViewController.h"
#import "CategoriaCell.h"

@interface CategoriaPikerViewController : PikerTableViewController<SubcategorieTarget>{
    NSObject<Categorizable>* categorizable;
}

@property(nonatomic,retain) NSObject<Categorizable>* categorizable;


@end
