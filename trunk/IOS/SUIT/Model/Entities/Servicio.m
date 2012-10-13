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

@synthesize categoriaid,descripcion,direccion,foto,_id,nombre,observacion,proveedorid, coordinate, isCoordinated;

-(Servicio*)initWhitDictionary:(NSDictionary*)dict{
    if (self = [super init]) {
        
        categoriaid = [[dict objectForKey:@"categoria"]objectForKey:@"id"];
        descripcion = [dict objectForKey:@"descripcion"];
        nombre = [dict objectForKey:@"nombre"];
        direccion = [dict objectForKey:@"direccion"];
        foto = [dict objectForKey:@"foto"] ;
        observacion = [dict objectForKey:@"observacion"];
        proveedorid = [[dict objectForKey:@"proveedor"]objectForKey:@"id"];
        
        isCoordinated = [[dict objectForKey:@"coordinate"]boolValue];
        if (isCoordinated){
            CLLocationDegrees latitude = [[dict objectForKey:@"latitude"]doubleValue];
            CLLocationDegrees longitude = [[dict objectForKey:@"longitude"]doubleValue];
            coordinate = CLLocationCoordinate2DMake(latitude,longitude);
        }
        direccion =  [dict objectForKey:@"direccion"];
        descripcion = [dict objectForKey:@"descripcion"];

    }
    return self;   
}

#pragma mark - MKAnnotation


-(NSString*)title{
    return [self.nombre copy];
}

-(NSString*)subtitle{
    return [self.direccion copy];
}



@end
