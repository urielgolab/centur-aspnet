//
//  Grupo.m
//  SUIT
//
//  Created by Manuel Kenar on 10/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "Grupo.h"

@implementation Grupo

-(Grupo*)initWhitDictionary:(NSDictionary*)dict{
    self = [super init];
    
    if (self) {
        self.usuarioEstaEnGrupo = [NIL_IF_NSNULL([dict objectForKey:@"usuarioEstaEnGrupo"])boolValue];
        self.Tipo = NIL_IF_NSNULL([dict objectForKey:@"Tipo"]);
        self.ServicioList = NIL_IF_NSNULL([dict objectForKey:@"ServicioList"]);
        self.Nombre = NIL_IF_NSNULL([dict objectForKey:@"Nombre"]);
        self.MiembrosList = NIL_IF_NSNULL([dict objectForKey:@"MiembrosList"]);
        self.ID = NIL_IF_NSNULL([dict objectForKey:@"ID"]);
        self.Descripcion = NIL_IF_NSNULL([dict objectForKey:@"Descripcion"]);

    }
    return self;
}

@end
