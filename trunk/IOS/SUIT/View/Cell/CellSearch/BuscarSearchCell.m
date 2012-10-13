//
//  BuscarSearchCell.m
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "BuscarSearchCell.h"

@implementation BuscarSearchCell
@synthesize searchParametre;

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        self.textLabel.textAlignment = UITextAlignmentCenter;
        self.textLabel.text = @"Buscar";
    }
    return self;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

- (void)setSearchParametre:(SearchParametre *)asearchParametre{
    searchParametre = asearchParametre;
    self.userInteractionEnabled = [asearchParametre canPerformSearch];
    if (self.userInteractionEnabled) {
        self.textLabel.alpha = 1;
    }else {
        self.textLabel.alpha = 0.439216f; // (1 - alpha) * 255 = 143
    }
}

@end
