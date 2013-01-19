//
//  Usuario.h
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Usuario : NSObject{    
}

@property(nonatomic,retain) NSNumber* usuarioID;
@property(nonatomic,retain) NSString* nombre;
@property(nonatomic,retain) NSString* mail;
@property(nonatomic,retain) NSString* direccion;
@property(nonatomic,retain) NSString* apellido;
@property(nonatomic,retain) NSString* telefono;
@property(nonatomic,retain) NSString* nombreUsuario;

-(Usuario*)initWhitDictionary:(NSDictionary*)dict;

@end
