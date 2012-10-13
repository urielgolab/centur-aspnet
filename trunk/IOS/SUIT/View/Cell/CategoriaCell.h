//
//  CategoriaCell.h
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <UIKit/UIKit.h>
#import "Categoria.h"

@protocol SubcategorieTarget <NSObject>

-(void)showSubcategoriaDetail:(Categoria*)categoria;

@end

@interface CategoriaCell : UITableViewCell{
    UIButton* accesoryButton;
    
    Categoria* categoria;
    id<SubcategorieTarget> target;
    
    
}

@property(nonatomic,retain) id target;
@property(nonatomic,retain) Categoria* categoria;

@end
