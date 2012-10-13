//
//  SubCategoriaPikerViewController.h
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Categoria.h"
#import "PikerTableViewController.h"

@interface SubCategoriaPikerViewController : PikerTableViewController{
    Categoria* categoria;
    NSObject<Categorizable>* categorizable;
}

@property(nonatomic,retain) NSObject<Categorizable>* categorizable;

- (id)initWithNibName:(NSString *)nibNameOrNil bundle:(NSBundle *)nibBundleOrNil andCategoria:(Categoria*)aCategoria;

@end
