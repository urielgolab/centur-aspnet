//
//  Zona.m
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "Zona.h"
#import "NSArray+Tools.h"

@implementation Zona

@synthesize nombre,subZonas,zonaID;

-(Zona*)initWhitDictionary:(NSDictionary*)dict{
    
    if (self = [super init]) {
        nombre = [dict objectForKey:@"NombreZona"];
        zonaID = [dict objectForKey:@"IDZona"];
        _TieneHijos = [[dict objectForKey:@"TieneHijos"]boolValue];
        //subZonas = [NSArray arrayWhitZonasForm: [dict objectForKey:@"subZonas"]];
    }
    return self;
    
}

-(BOOL)hasSubZonas{
    return self.TieneHijos;
}

#pragma mark - DEbug methods

-(NSString*)description{
    return [NSString stringWithFormat:@"%@ %@",nombre, [super description]];
}

-(BOOL)isEqual:(id)object{
    BOOL baseEqual = [super isEqual:object];
    BOOL classEqual = NO;
    if ([object isKindOfClass:[self class]]) {
        classEqual = [self.zonaID isEqual: ((Zona*)object).zonaID];
    }
    return baseEqual || classEqual;
}

@end
