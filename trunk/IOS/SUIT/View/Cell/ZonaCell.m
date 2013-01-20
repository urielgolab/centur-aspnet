//
//  ZonaCell.m
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "ZonaCell.h"

@implementation ZonaCell

@synthesize zona,target;

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        accesoryButton = [UIButton buttonWithType: UIButtonTypeDetailDisclosure];
        
        self.accessoryView = accesoryButton;
        [accesoryButton addTarget:self 
                           action:@selector(showSubzonaDetail:) 
                 forControlEvents:UIControlEventTouchUpInside];
    }
    return self;
}

-(void)setSelected:(BOOL)selected animated:(BOOL)animated{
    [super setSelected:selected animated:animated];
}

-(void)setZona:(Zona *)aZona{
    zona = aZona;    
    self.textLabel.text = zona.nombre;
    self.textLabel.textAlignment = UITextAlignmentCenter;
    accesoryButton.hidden = ![zona hasSubZonas];
}

-(void)showSubzonaDetail:(UIButton*)sender{
    
    [target showSubzonaDetail:zona];
}
@end
