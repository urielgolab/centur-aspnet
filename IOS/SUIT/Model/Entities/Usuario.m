//
//  Usuario.m
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "Usuario.h"

@implementation Usuario

@synthesize usuarioID,nombre,mail,direccion;

-(Usuario*)initWhitDictionary:(NSDictionary*)dict{
    self = [super init];
    
    if (self) {
        usuarioID = [dict objectForKey:@"idUsuario"];
        nombre = [dict objectForKey:@"NombreUsuario"];
        mail = [dict objectForKey:@"mail"];
    }
    return self;
}

@end
