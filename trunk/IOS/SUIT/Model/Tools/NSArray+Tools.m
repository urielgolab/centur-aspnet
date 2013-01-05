//
//  NSArray+Tools.m
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "NSArray+Tools.h"


@implementation NSArray (Tools)


+(NSArray*)arrayWhitCategoriesForm:(NSArray*)arrayOfDictionary{
    
    NSMutableArray * aux = [NSMutableArray array];
    
    for (NSDictionary* dict in arrayOfDictionary) {
        Categoria* categoria = [[Categoria alloc]initWhitDictionary:dict];
        [aux addObject: categoria ];
    }
    
    return [NSArray arrayWithArray:aux];
}

+(NSArray*)arrayWhitZonasForm:(NSArray*)arrayOfDictionary{
    NSMutableArray * aux = [NSMutableArray array];
    
    for (NSDictionary* dict in arrayOfDictionary) {
        Zona* zona = [[Zona alloc]initWhitDictionary:dict];
        [aux addObject: zona ];
    }
    
    return [NSArray arrayWithArray:aux];
}

+(NSArray*)arrayWhitServiciosForm:(NSArray*)arrayOfDictionary{
    NSMutableArray * aux = [NSMutableArray array];
    
    for (NSDictionary* dict in arrayOfDictionary) {
        Servicio* proveedor = [[Servicio alloc]initWhitDictionary:dict];
        [aux addObject: proveedor ];
    }
    
    return [NSArray arrayWithArray:aux];
}

+(NSArray*)arrayWhitTurnosForm:(NSArray*)arrayOfDictionary{
    NSMutableArray * aux = [NSMutableArray array];
    
    for (NSDictionary* dict in arrayOfDictionary) {
        Turno* proveedor = [[Turno alloc]initWhitDictionary:dict];
        [aux addObject: proveedor ];
    }
    
    return [NSArray arrayWithArray:aux];

}

+(NSArray*)arrayWhitUsuariosForm:(NSArray*)arrayOfDictionary{
    NSMutableArray * aux = [NSMutableArray array];
    
    for (NSDictionary* dict in arrayOfDictionary) {
        Usuario* usuario = [[Usuario alloc]initWhitDictionary:dict];
        [aux addObject: usuario];
    }
    return [NSArray arrayWithArray:aux]; 
}

@end
