//
//  Turno.h
//  SUIT
//
//  Created by Manuel Kenar on 05/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Turno : NSObject

@property(nonatomic) BOOL Disponible;
@property(nonatomic) NSString* Fecha;
@property(nonatomic) NSNumber* ServicioID;
@property(nonatomic) NSString* horaFin;
@property(nonatomic) NSString* horaInicio;
@property(nonatomic) NSNumber* idTurno;

-(Turno*)initWhitDictionary:(NSDictionary*)dict;


@end
