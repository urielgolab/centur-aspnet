//
//  CategoriaSearchParametre.m
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "CategoriaSearchParametre.h"

@implementation CategoriaSearchParametre

@synthesize zonas, categorias,fecha,nombre,horario,delegate;

-(CategoriaSearchParametre*) init {
    if (self = [super init]) {
        categorias = [NSMutableArray array];
        zonas = [NSMutableArray array];
        fecha = [[Fecha alloc]init];
    }
    return self;
}

-(BOOL)canPerformSearch{
    return [categorias count] > 0;
}

-(void)categoriasValueChange{
    [self.delegate categoriaSearchParametre:self];
}

-(void)addCategoriasObject:(Categoria *)object{
    [categorias addObject:object];
    [self categoriasValueChange];
}
-(void)removeCategoriasObject:(Categoria *)object{
    [categorias removeObject:object];
    [self categoriasValueChange];
}

-(void)addZonasObject:(Zona *)object{
    [zonas addObject:object];
    [self categoriasValueChange];
}

-(void)removeZonasObject:(Zona *)object{
    [zonas removeObject:object];
    [self categoriasValueChange];
}

-(NSArray*)categorias{
    return [NSArray arrayWithArray: categorias] ;
}


-(NSArray*)zonas{
    return [NSArray arrayWithArray: zonas] ;
}

-(void)setNombre:(NSString *)anombre{
    nombre= anombre;
    [self categoriasValueChange];
}

-(void)setFecha:(Fecha *)afecha{
    fecha= afecha;
    [self categoriasValueChange];
}

-(void)setHorario:(Hora *)aHorario{
    horario = aHorario;
    [self categoriasValueChange];
}

-(NSDictionary*)searchParams{
    NSMutableDictionary* params = [NSMutableDictionary dictionary];
    
    if (nombre) {
        [params setObject:nombre forKey:@"nombre"];
    }
//    if ([categorias count]) {
//        
//        [params setObject: categorias  forKey:@"categoriaID"];
//    }
    
    return [NSDictionary dictionaryWithDictionary:params];
}

@end
