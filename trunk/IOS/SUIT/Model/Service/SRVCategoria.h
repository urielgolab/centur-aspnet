//
//  SRVCategoria.h
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SRVBase.h"
#import "Categoria.h"

@interface SRVCategoria : SRVBase{
    NSArray* categories;
}

CWL_DECLARE_SINGLETON_FOR_CLASS(SRVCategoria)

-(void)searchAllCategories;
-(NSArray*)getAllCategories;

-(void)searchAllSubCategoriesFrom: (Categoria*)categoria;
-(NSArray*)getAllSubCategoriesFrom: (Categoria*)categoria;

@end
