//
//  NombreSearchCell.m
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "NombreSearchCell.h"

@implementation NombreSearchCell

@synthesize nombre;

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        // Initialization code
    }
    return self;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

-(void)setNombre:(NSString *)anombre{
    nombre = anombre;
    self.textLabel.text=@"Nombre";
    self.textLabel.textAlignment = UITextAlignmentCenter;
    
    if (nombre && ![nombre isEqualToString:@""]) {
        self.textLabel.textAlignment = UITextAlignmentLeft;
        self.textLabel.text = [NSString stringWithFormat:@"Nombre: \"%@\" ",nombre];
    }
}

@end
