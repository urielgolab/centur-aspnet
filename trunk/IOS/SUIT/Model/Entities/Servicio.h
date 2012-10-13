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
    NSNumber* categoriaid;
    NSString* descripcion;
    NSString* direccion;
    NSString* foto;
    NSNumber* _id;
    NSString* nombre;
    NSString* observacion;
    NSNumber* proveedorid;

    CLLocationCoordinate2D coordinate;
    BOOL isCoordinated;
}


@property(nonatomic) NSNumber* categoriaid;
@property(nonatomic) NSString* descripcion;
@property(nonatomic) NSString* direccion;
@property(nonatomic) NSString* foto;
@property(nonatomic) NSNumber* _id;
@property(nonatomic) NSString* nombre;
@property(nonatomic) NSString* observacion;
@property(nonatomic) NSNumber* proveedorid;

@property(nonatomic) CLLocationCoordinate2D coordinate;
@property(nonatomic) BOOL isCoordinated;

@property(nonatomic,readonly,copy)NSString* title;
@property(nonatomic,readonly,copy)NSString* subtitle;


-(Servicio*)initWhitDictionary:(NSDictionary*)dict;

@end
