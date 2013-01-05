//
//  SRVBusqueda.h
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SRVBase.h"
#import "SearchParametre.h"
#import "ServiciosResult.h"


@protocol SearchDelegate <NSObject>

-(void)searchDidFinishedOK:(NSObject<SearchResult>*)result forSearch:(NSObject<Searchable>*)search; 
-(void)searchDidFinishedFailedForSearch:(NSObject<Searchable>*)search whitError:(NSError*)error; 

@end

@interface SRVBusqueda : SRVBase

CWL_DECLARE_SINGLETON_FOR_CLASS(SRVBusqueda);

-(void)startSearchForProvedores:(NSObject<Searchable>*)search delegate: (NSObject<SearchDelegate>*) delegate;

-(void)startSearchForProvedorDetail:(Servicio*)servicio;

-(void)buscarTurnosPara:(Servicio*)servicio paraDia:(NSDate*)dia;

@end
