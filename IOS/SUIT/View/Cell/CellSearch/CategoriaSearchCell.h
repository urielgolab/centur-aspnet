//
//  CategoriaSearchCell.h
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "EntitiesProtocols.h"


@interface CategoriaSearchCell : UITableViewCell{
    NSArray * categorias;
}

@property(nonatomic,retain) NSArray * categorias;

@end
