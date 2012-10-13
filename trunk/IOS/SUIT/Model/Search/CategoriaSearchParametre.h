//
//  CategoriaSearchParametre.h
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "SearchParametre.h"
#import "Zona.h"
#import "Categoria.h"
#import "EntitiesProtocols.h"

@class CategoriaSearchParametre;

@protocol CategoriaSearchParametreDelegate <NSObject>

-(void)categoriaSearchParametre:(CategoriaSearchParametre*)categoriaSearchParametre;

@end

@interface CategoriaSearchParametre : SearchParametre<Categorizable, Zonable,Nombreable,Horable,Fecheable, Searchable >{
    
    id delegate;
    NSMutableArray* categorias;
    NSMutableArray* zonas;
    NSString* nombre; 
    Hora* horario;
    Fecha* fecha;
    
}
@property(nonatomic,retain) id<CategoriaSearchParametreDelegate> delegate;

@property(nonatomic,readonly) NSArray* categorias;
@property(nonatomic,readonly) NSArray* zonas;
@property(nonatomic,retain) NSString* nombre; 
@property(nonatomic,retain) Hora* horario;
@property(nonatomic,retain) Fecha* fecha;


-(void)removeCategoriasObject:(Categoria *)object;
-(void)addCategoriasObject:(Categoria *)object;

-(void)removeZonasObject:(Zona *)object;
-(void)addZonasObject:(Zona *)object;


@end
