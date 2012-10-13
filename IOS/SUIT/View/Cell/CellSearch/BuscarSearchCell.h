//
//  BuscarSearchCell.h
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "SearchParametre.h"

@interface BuscarSearchCell : UITableViewCell{
    UIView* desableView;
    SearchParametre* searchParametre;
}

@property(nonatomic,retain) SearchParametre* searchParametre;

@end
