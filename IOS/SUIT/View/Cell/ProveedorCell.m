//
//  ProveedorCell.m
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "ProveedorCell.h"

@implementation ProveedorCell
@synthesize proveedor;

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        self.textLabel.textAlignment= UITextAlignmentCenter;
    }
    return self;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

-(void)setProveedor:(Servicio *)aProveedor{
    proveedor = aProveedor;
    
    self.textLabel.text = aProveedor.Nombre;
}

@end
