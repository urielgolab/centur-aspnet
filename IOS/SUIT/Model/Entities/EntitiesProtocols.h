//
//  EntitiesProtocols.h
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Zona.h"
#import "Categoria.h"
#import "Hora.h"
#import "Fecha.h"


@protocol Categorizable <NSObject>

@property(nonatomic,readonly) NSArray* categorias;

@optional
-(void)removeCategoriasObject:(Categoria *)object;
-(void)addCategoriasObject:(Categoria *)object;

@end


@protocol Zonable <NSObject>

@property(nonatomic,readonly) NSArray* zonas;

@optional
-(void)removeZonasObject:(Zona *)object;
-(void)addZonasObject:(Zona *)object;

@end

@protocol Nombreable <NSObject>

@property(nonatomic,retain) NSString* nombre;

@end

@protocol Horable <NSObject>

@property(nonatomic,retain) Hora* horario;

@end

@protocol Fecheable <NSObject>

@property(nonatomic,retain) Fecha* fecha;

@end
