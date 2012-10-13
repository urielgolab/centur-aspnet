//
//  SRVZona.m
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SRVZona.h"
#import "NSArray+Tools.h"

@implementation SRVZona


CWL_SYNTHESIZE_SINGLETON_FOR_CLASS(SRVZona);


-(void)searchAllZonas{
    if (zonas) {
        return;
    }
    
    NSString *pathStr = [[NSBundle mainBundle]bundlePath];
    NSString *finalPath = [pathStr stringByAppendingPathComponent:@"Zona.plist"];
    NSDictionary* dict = [NSDictionary dictionaryWithContentsOfFile:finalPath];
    
    zonas = [NSArray arrayWhitZonasForm:[dict objectForKey:@"Zonas"]];
    [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_GETZONAS_OK object:nil];
    
}

-(NSArray*)getAllZonas{
    return [NSArray arrayWithArray:zonas];
}


-(void)searchAllSubZonasFrom:(Zona *)zona{
    [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_GETSUBZONAS_OK object:zona];
    
}

-(NSArray*)getAllSubZonasFrom: (Zona*)zona{
    return zona.subZonas;
}

@end
