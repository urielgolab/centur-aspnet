
//
//  Turno.m
//  SUIT
//
//  Created by Manuel Kenar on 05/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import "Turno.h"

@implementation Turno

-(Turno*)initWhitDictionary:(NSDictionary*)dict{
    self = [super init];
    
    if (self) {
        self.Disponible = [NIL_IF_NSNULL([dict objectForKey:@"Disponible"])boolValue];
        self.Confirmado = [NIL_IF_NSNULL([dict objectForKey:@"Confirmado"])boolValue];
        self.Fecha = NIL_IF_NSNULL([dict objectForKey:@"Fecha"]);
        self.ServicioID = NIL_IF_NSNULL([dict objectForKey:@"ServicioID"]);
        self.horaFin = NIL_IF_NSNULL([dict objectForKey:@"horaFin"]);
        self.horaInicio = NIL_IF_NSNULL([dict objectForKey:@"horaInicio"]);
        self.idTurno = NIL_IF_NSNULL([dict objectForKey:@"idTurno"]);
        self.ClienteNombre = NIL_IF_NSNULL([dict objectForKey:@"ClienteNombre"]);
        self.ServicioNombre = NIL_IF_NSNULL([dict objectForKey:@"ServicioNombre"]);
        self.FechaMMDD = NIL_IF_NSNULL([dict objectForKey:@"FechaMMDD"]);

    }
    return self;
}

@end
