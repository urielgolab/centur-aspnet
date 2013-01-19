//
//  Usuario.m
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "Usuario.h"

@implementation Usuario

-(Usuario*)initWhitDictionary:(NSDictionary*)dict{
    self = [super init];
    
    if (self) {
        
        NSLog(@"%@",dict);
        
        _usuarioID = NIL_IF_NSNULL([dict objectForKey:@"idUsuario"]);
        _nombreUsuario = NIL_IF_NSNULL([dict objectForKey:@"NombreUsuario"]);
        _nombre = NIL_IF_NSNULL([dict objectForKey:@"Nombre"]);
        _mail = NIL_IF_NSNULL([dict objectForKey:@"Email"]);
        _telefono = NIL_IF_NSNULL([dict objectForKey:@"Telefono"]);
        _apellido = NIL_IF_NSNULL([dict objectForKey:@"Apellido"]);
    }
    return self;
}

@end
