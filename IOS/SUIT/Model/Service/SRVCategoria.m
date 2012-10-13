//
//  SRVCategoria.m
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SRVCategoria.h"
#import "NSArray+Tools.h"

@implementation SRVCategoria

CWL_SYNTHESIZE_SINGLETON_FOR_CLASS(SRVCategoria);

-(void)searchAllCategories{
    if (categories) {
        return;
    }
    
    NSString *pathStr = [[NSBundle mainBundle]bundlePath];
    NSString *finalPath = [pathStr stringByAppendingPathComponent:@"Categoria.plist"];
    NSDictionary* dict = [NSDictionary dictionaryWithContentsOfFile:finalPath];
    
    categories = [NSArray arrayWhitCategoriesForm:[dict objectForKey:@"Categorias"]];
    [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_GETCATEGORIES_OK object:nil];

}

-(NSArray*)getAllCategories{
    return [NSArray arrayWithArray:categories];
}


-(void)searchAllSubCategoriesFrom: (Categoria*)categoria{
    [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_GETSUBCATEGORIES_OK object:categoria];

}

-(NSArray*)getAllSubCategoriesFrom: (Categoria*)categoria{
    return categoria.subCategorias;
}

@end
