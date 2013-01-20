//
//  Proveedor.m
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "Servicio.h"
#import "Categoria.h"

@implementation Servicio


-(Servicio*)initWhitDictionary:(NSDictionary*)dict{
    if (self = [super init]) {
        self.Categoria = NIL_IF_NSNULL([dict objectForKey:@"Categoria"]);
        self.Descripcion = NIL_IF_NSNULL([dict objectForKey:@"Descripcion"]);
        self.Direccion = NIL_IF_NSNULL([dict objectForKey:@"Direccion"]);
        self.Email = NIL_IF_NSNULL([dict objectForKey:@"Email"]);
        self.EnvioRecordatorio = NIL_IF_NSNULL([dict objectForKey:@"EnvioRecordatorio"]);
        self.ID = NIL_IF_NSNULL([dict objectForKey:@"ID"]);
        self.IDProveedor = NIL_IF_NSNULL([dict objectForKey:@"IDProveedor"]);
        self.Imagen = NIL_IF_NSNULL([dict objectForKey:@"Imagen"]);
        self.MaxOffset = NIL_IF_NSNULL([dict objectForKey:@"MaxOffset"]);
        self.MercadoPago = [NIL_IF_NSNULL([dict objectForKey:@"MercadoPago"])boolValue];
        self.MinOffset = NIL_IF_NSNULL([dict objectForKey:@"MinOffset"]);
        self.NecesitaConfirmacion = [NIL_IF_NSNULL([dict objectForKey:@"NecesitaConfirmacion"])boolValue];
        self.Nombre = NIL_IF_NSNULL([dict objectForKey:@"Nombre"]);
        self.NombreUsuarioProveedor = NIL_IF_NSNULL([dict objectForKey:@"NombreUsuarioProveedor"]);
        self.Observaciones = NIL_IF_NSNULL([dict objectForKey:@"Observaciones"]);
        self.Precio = NIL_IF_NSNULL([dict objectForKey:@"Precio"]);
        self.Privacidad = [NIL_IF_NSNULL([dict objectForKey:@"Privacidad"])boolValue];
        self.Sobreturno = [NIL_IF_NSNULL([dict objectForKey:@"Sobreturno"])boolValue];
        self.Telefono = NIL_IF_NSNULL([dict objectForKey:@"Telefono"]);
        self.Zona = NIL_IF_NSNULL([dict objectForKey:@"Zona"]);
        self.EsFavorito = [NIL_IF_NSNULL([dict objectForKey:@"EsFavorito"])boolValue];
        self.PuedePedirTurno = [NIL_IF_NSNULL([dict objectForKey:@"PuedePedirTurno"])boolValue];
    }
    return self;   
}

#pragma mark - MKAnnotation


-(NSString*)title{
    return [self.Nombre copy];
}

-(NSString*)subtitle{
    return [self.Direccion copy];
}



@end
