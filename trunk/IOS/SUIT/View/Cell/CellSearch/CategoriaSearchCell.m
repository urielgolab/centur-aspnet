//
//  CategoriaSearchCell.m
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "CategoriaSearchCell.h"

@implementation CategoriaSearchCell

@synthesize categorias;

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

- (void)setCategorias:(NSArray*)aCategorias{
    categorias = aCategorias;
    self.textLabel.text=@"Categoria";
    self.textLabel.textAlignment = UITextAlignmentCenter;
    
    if ([categorias count] != 0 ) {
        self.textLabel.textAlignment = UITextAlignmentLeft;
        NSString *format =@"Categoria: \"%@\" ";
        self.textLabel.text = [NSString stringWithFormat:format,@"Multiple"];
        if ([categorias count] == 1) {
            Categoria *categoria = [categorias objectAtIndex:0];
            self.textLabel.text = [NSString stringWithFormat:format,categoria.nombre];
        }
    }

}

@end
