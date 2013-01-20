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
@property(nonatomic) BOOL Confirmado;
@property(nonatomic,retain) NSString* Fecha;
@property(nonatomic,retain) NSString* FechaMMDD;
@property(nonatomic,retain) NSString* ClienteNombre;
@property(nonatomic,retain) NSString* ServicioNombre;
@property(nonatomic,retain) NSNumber* ServicioID;
@property(nonatomic,retain) NSString* horaFin;
@property(nonatomic,retain) NSString* horaInicio;
@property(nonatomic,retain) NSNumber* idTurno;


-(Turno*)initWhitDictionary:(NSDictionary*)dict;


@end
