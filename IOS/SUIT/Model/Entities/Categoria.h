//
//  Categoria.h
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Categoria : NSObject{
}

@property(nonatomic,readonly) NSNumber* categoriaID;
@property(nonatomic,readonly) NSString* nombre;
@property(nonatomic,readonly) BOOL TieneHijos;
@property(nonatomic,retain) NSArray* subCategorias;


-(Categoria*)initWhitDictionary:(NSDictionary*)dict;
-(BOOL)hasSubCategories;

-(NSString*)description;

@end
