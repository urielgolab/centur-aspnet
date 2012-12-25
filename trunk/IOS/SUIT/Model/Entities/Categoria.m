//
//  Categoria.m
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "Categoria.h"
#import "NSArray+Tools.h"

@implementation Categoria

@synthesize nombre,categoriaID,subCategorias;


-(Categoria*)initWhitDictionary:(NSDictionary*)dict{
    
    if (self = [super init]) {
        nombre = [dict objectForKey:@"NombreCategoria"];
        categoriaID = [dict objectForKey:@"IDCategoria"];
        //subCategorias = [NSArray arrayWhitCategoriesForm: [dict objectForKey:@"subCategorias"]];
    }
    return self;
    
}

-(BOOL)hasSubCategories{
    return [subCategorias count]>0;
}

#pragma mark - DEbug methods

-(NSString*)description{
    return [NSString stringWithFormat:@"%@ %@",nombre, [super description]];
}


@end
