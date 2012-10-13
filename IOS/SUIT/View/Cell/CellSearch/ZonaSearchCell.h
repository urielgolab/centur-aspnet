//
//  ZonaSearchCell.h
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "EntitiesProtocols.h"

@interface ZonaSearchCell : UITableViewCell{
    NSArray* zonas;
}

@property(nonatomic,retain) NSArray *zonas;

@end
