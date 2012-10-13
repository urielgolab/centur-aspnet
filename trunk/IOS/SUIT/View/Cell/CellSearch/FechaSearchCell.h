//
//  FechaCell.h
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Fecha.h"

@interface FechaSearchCell : UITableViewCell{
    Fecha* fecha;
}

@property(nonatomic,retain) Fecha *fecha;

@end
