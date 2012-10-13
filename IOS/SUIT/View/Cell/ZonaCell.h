//
//  ZonaCell.h
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Zona.h"

@protocol SubzonaTarget <NSObject>

-(void)showSubzonaDetail:(Zona*)zona;

@end


@interface ZonaCell : UITableViewCell{  
    
    UIButton* accesoryButton;
    Zona* zona;
    id<SubzonaTarget> target;
}

@property(nonatomic,retain) id target;
@property(nonatomic,retain) Zona* zona;



@end
