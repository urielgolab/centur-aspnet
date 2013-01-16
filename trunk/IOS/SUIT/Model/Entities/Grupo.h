//
//  Grupo.h
//  SUIT
//
//  Created by Manuel Kenar on 10/01/13.
//  Copyright (c) 2013 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Grupo : NSObject

@property(nonatomic,retain) NSString* Descripcion;
@property(nonatomic,retain) NSNumber* ID;
@property(nonatomic,retain) NSArray* MiembrosList;
@property(nonatomic,retain) NSString* Nombre;
@property(nonatomic,retain) NSArray* ServicioList;
@property(nonatomic,retain) NSString* Tipo;
@property(nonatomic) BOOL usuarioEstaEnGrupo;

-(Grupo*)initWhitDictionary:(NSDictionary*)dict;


@end
