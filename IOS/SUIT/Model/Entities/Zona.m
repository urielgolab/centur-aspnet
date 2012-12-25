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
        //subZonas = [NSArray arrayWhitZonasForm: [dict objectForKey:@"subZonas"]];
    }
    return self;
    
}

-(BOOL)hasSubZonas{
    return [subZonas count]>0;
}

#pragma mark - DEbug methods

-(NSString*)description{
    return [NSString stringWithFormat:@"%@ %@",nombre, [super description]];
}


@end
