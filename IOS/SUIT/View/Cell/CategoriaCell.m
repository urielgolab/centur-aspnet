//
//  CategoriaCell.m
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "CategoriaCell.h"

@implementation CategoriaCell

@synthesize categoria,target;

- (id)initWithStyle:(UITableViewCellStyle)style reuseIdentifier:(NSString *)reuseIdentifier
{
    self = [super initWithStyle:style reuseIdentifier:reuseIdentifier];
    if (self) {
        accesoryButton = [UIButton buttonWithType: UIButtonTypeContactAdd];

        self.accessoryView = accesoryButton;
        [accesoryButton addTarget:self 
                           action:@selector(showSubcategoriaDetail:) 
                 forControlEvents:UIControlEventTouchUpInside];
    }
    return self;
}

-(void)setSelected:(BOOL)selected animated:(BOOL)animated{
    [super setSelected:selected animated:animated];
}

-(void)setCategoria:(Categoria *)aCategoria{
    categoria = aCategoria;    
    self.textLabel.text = categoria.nombre;
    self.textLabel.textAlignment = UITextAlignmentCenter;
    accesoryButton.hidden = ![categoria hasSubCategories];
}

-(void)showSubcategoriaDetail:(UIButton*)sender{

    [target showSubcategoriaDetail:categoria];
}




@end
