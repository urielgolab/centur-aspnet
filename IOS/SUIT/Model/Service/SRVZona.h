//
//  SRVZona.h
//  SUIT
//
//  Created by Manuel Kenar on 26-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SRVBase.h"
#import "Zona.h"

@interface SRVZona : SRVBase{
    NSArray* zonas;
}

CWL_DECLARE_SINGLETON_FOR_CLASS(SRVZona)


-(void)searchAllZonas;
-(NSArray*)getAllZonas;

-(void)searchAllSubZonasFrom: (Zona*)categoria;
-(NSArray*)getAllSubZonasFrom: (Zona*)categoria;


@end
