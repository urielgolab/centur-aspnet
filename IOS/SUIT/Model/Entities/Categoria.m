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



-(Categoria*)initWhitDictionary:(NSDictionary*)dict{
    
    if (self = [super init]) {
        _nombre = [dict objectForKey:@"NombreCategoria"];
        _categoriaID = [dict objectForKey:@"IDCategoria"];
        _TieneHijos = [[dict objectForKey:@"TieneHijos"]boolValue];
    }
    return self;
    
}

-(BOOL)hasSubCategories{
    return _TieneHijos;
}

#pragma mark - DEbug methods

-(NSString*)description{
    return [NSString stringWithFormat:@"%@ %@",self.nombre, [super description]];
}


@end
