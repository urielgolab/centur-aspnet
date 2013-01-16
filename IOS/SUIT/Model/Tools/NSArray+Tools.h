//
//  NSArray+Tools.h
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Categoria.h"
#import "Zona.h"
#import "Servicio.h"
#import "Usuario.h"
#import "Turno.h"
#import "Grupo.h"

@interface NSArray (Tools)

+(NSArray*)arrayWhitCategoriesForm:(NSArray*)arrayOfDictionary;
+(NSArray*)arrayWhitZonasForm:(NSArray*)arrayOfDictionary;
+(NSArray*)arrayWhitServiciosForm:(NSArray*)arrayOfDictionary;
+(NSArray*)arrayWhitUsuariosForm:(NSArray*)arrayOfDictionary;
+(NSArray*)arrayWhitTurnosForm:(NSArray*)arrayOfDictionary;
+(NSArray*)arrayWhitGruposForm:(NSArray*)arrayOfDictionary;
@end
