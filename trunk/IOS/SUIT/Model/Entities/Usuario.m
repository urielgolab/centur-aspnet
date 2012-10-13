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
        usuarioID = [dict objectForKey:@"usuarioID"];
        nombre = [dict objectForKey:@"nombre"];
        mail = [dict objectForKey:@"mail"];
        mail = [dict objectForKey:@"direccion"];
    }
    return self;
}

@end
