//
//  FechaCell.m
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "FechaSearchCell.h"

@implementation FechaSearchCell
@synthesize fecha;

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:UITableViewCellStyleSubtitle reuseIdentifier:reuseIdentifier];
    if (self) {
        self.textLabel.textAlignment = UITextAlignmentCenter;
    }
    return self;
}

- (void)setSelected:(BOOL)selected animated:(BOOL)animated
{
    [super setSelected:selected animated:animated];

    // Configure the view for the selected state
}

-(void)setFecha:(Fecha *)aFecha{
    fecha= aFecha;
    self.textLabel.text=@"Fecha";
    self.detailTextLabel.text = @"";
    self.textLabel.textAlignment = UITextAlignmentRight;
    
    if (fecha.fechaDesde !=  nil || fecha.fechaHasta != nil ) {
        self.textLabel.textAlignment = UITextAlignmentLeft;
        self.detailTextLabel.textAlignment = UITextAlignmentLeft;
        NSDateFormatter *dateFormatter = [[NSDateFormatter alloc] init];
        [dateFormatter setDateStyle:NSDateFormatterShortStyle];
        [dateFormatter setTimeStyle:kCFDateFormatterShortStyle];
        NSString *format =@"Fecha desde: %@";
        
        self.textLabel.text = [NSString stringWithFormat:
                               format, [dateFormatter stringFromDate:fecha.fechaDesde ]]; 
        
        format =@"Fecha Hasta: %@";
        self.detailTextLabel.text = [NSString stringWithFormat:
                               format, [dateFormatter stringFromDate:fecha.fechaHasta]]; 
        
        
        
    }
}

@end
