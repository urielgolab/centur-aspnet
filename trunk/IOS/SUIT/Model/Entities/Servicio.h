//
//  Proveedor.h
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>
#import <MapKit/MapKit.h>
#import "Categoria.h"

@interface Servicio : NSObject<MKAnnotation>{
   
}



@property(nonatomic) NSString* Categoria;
@property(nonatomic) NSString* Descripcion;
@property(nonatomic) NSString* Direccion;
@property(nonatomic) NSString* Email;
@property(nonatomic) NSString* EnvioRecordatorio;
@property(nonatomic) NSNumber* ID;
@property(nonatomic) NSNumber* IDProveedor;
@property(nonatomic) NSNumber* Imagen;
@property(nonatomic) NSNumber* MaxOffset;
@property(nonatomic) BOOL MercadoPago;
@property(nonatomic) NSString* MinOffset;
@property(nonatomic) BOOL NecesitaConfirmacion;
@property(nonatomic) NSString* Nombre;
@property(nonatomic) NSString* NombreUsuarioProveedor;
@property(nonatomic) NSString* Observaciones;
@property(nonatomic) NSNumber* Precio;
@property(nonatomic) BOOL Privacidad;
@property(nonatomic) BOOL Sobreturno;
@property(nonatomic) NSString* Telefono;
@property(nonatomic) NSString* Zona;


@property(nonatomic) CLLocationCoordinate2D coordinate;
@property(nonatomic) BOOL isCoordinated;

@property(nonatomic,readonly,copy)NSString* title;
@property(nonatomic,readonly,copy)NSString* subtitle;


-(Servicio*)initWhitDictionary:(NSDictionary*)dict;

@end
