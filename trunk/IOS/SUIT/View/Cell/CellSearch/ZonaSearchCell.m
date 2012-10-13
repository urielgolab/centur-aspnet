//
//  ZonaSearchCell.m
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "ZonaSearchCell.h"

@implementation ZonaSearchCell

@synthesize zonas;

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

- (void)setZonas:(NSArray*)aZona{
    zonas = aZona;
    self.textLabel.text=@"Zona";
    self.textLabel.textAlignment = UITextAlignmentCenter;
    
    if ([zonas count] != 0 ) {
        self.textLabel.textAlignment = UITextAlignmentLeft;
        NSString *format =@"Zona: \"%@\" ";
        self.textLabel.text = [NSString stringWithFormat:format,@"Multiple"];
        if ([zonas count] == 1) {
            Zona *zona = [zonas objectAtIndex:0];
            self.textLabel.text = [NSString stringWithFormat:format,zona.nombre];
        }
    }
    
}

@end
