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



@property(nonatomic,retain) NSString* Categoria;
@property(nonatomic,retain) NSString* Descripcion;
@property(nonatomic,retain) NSString* Direccion;
@property(nonatomic,retain) NSString* Email;
@property(nonatomic,retain) NSString* EnvioRecordatorio;
@property(nonatomic,retain) NSNumber* ID;
@property(nonatomic,retain) NSNumber* IDProveedor;
@property(nonatomic,retain) NSNumber* Imagen;
@property(nonatomic,retain) NSNumber* MaxOffset;
@property(nonatomic) BOOL MercadoPago;
@property(nonatomic,retain) NSString* MinOffset;
@property(nonatomic) BOOL NecesitaConfirmacion;
@property(nonatomic,retain) NSString* Nombre;
@property(nonatomic,retain) NSString* NombreUsuarioProveedor;
@property(nonatomic,retain) NSString* Observaciones;
@property(nonatomic,retain) NSNumber* Precio;
@property(nonatomic) BOOL Privacidad;
@property(nonatomic) BOOL Sobreturno;
@property(nonatomic,retain) NSString* Telefono;
@property(nonatomic,retain) NSString* Zona;
@property(nonatomic) BOOL EsFavorito;


@property(nonatomic) CLLocationCoordinate2D coordinate;
@property(nonatomic) BOOL isCoordinated;

@property(nonatomic,readonly,copy)NSString* title;
@property(nonatomic,readonly,copy)NSString* subtitle;


-(Servicio*)initWhitDictionary:(NSDictionary*)dict;

@end
