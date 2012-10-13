//
//  Zona.h
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Zona : NSObject{
    NSArray* subZonas;
    NSNumber* zonaID;
    NSString* nombre;
}

@property(nonatomic,readonly) NSArray* subZonas;
@property(nonatomic,readonly) NSNumber* zonaID;
@property(nonatomic,readonly) NSString* nombre;


-(Zona*)initWhitDictionary:(NSDictionary*)dict;
-(BOOL)hasSubZonas;

@end
