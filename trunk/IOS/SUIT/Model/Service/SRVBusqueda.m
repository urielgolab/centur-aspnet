//
//  SRVBusqueda.m
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SRVBusqueda.h"
#import "NSArray+Tools.h"
#import "BTHttpClient.h"
#import "AFJSONRequestOperation.h"

@implementation SRVBusqueda

CWL_SYNTHESIZE_SINGLETON_FOR_CLASS(SRVBusqueda);


-(void)startSearchForProvedores:(NSObject<Searchable>*)search 
                       delegate: (NSObject<SearchDelegate>*) delegate {
    
    
    
    NSString* url = [NSString stringWithFormat:@"%@", SERVICE_BASE_URL ];
    
    
    NSMutableDictionary *params = [NSMutableDictionary dictionaryWithDictionary:[search searchParams]];
    //[params setObject:@"JSON" forKey:@"format"];
    
    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    NSMutableURLRequest *req =  [client requestWithMethod:@"GET" path:@"BuscarServicio" parameters:params];
    
    AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:req success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
        
        NSLog(@"%@",JSON);
        ServiciosResult *result = [[ServiciosResult alloc]init];
        result.servicios = [NSArray arrayWhitServiciosForm: [JSON objectForKey:@"Body" ]];
        [delegate searchDidFinishedOK:result forSearch:search];

        
    }
    failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error) {
        NSLog(@"%@",error);
    }];
    
    [operation start];
}

-(void)startSearchForProvedorDetail:(Servicio*)servicio{
    NSString* url = [NSString stringWithFormat:@"%@", SERVICE_BASE_URL ];
    
    
    NSMutableDictionary *params = [NSMutableDictionary dictionary ];
    [params setObject:servicio.ID forKey:@"servicioID"];
    
    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    NSMutableURLRequest *req =  [client requestWithMethod:@"GET" path:@"DetalleServicio" parameters:params];
    
    AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:req success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
        
        NSLog(@"%@",JSON);
        [servicio initWhitDictionary:[JSON objectForKey:@"Body"]];
        [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_GETSERVICIODETAIL_OK object:servicio];
    }
        failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error) {
                NSLog(@"%@",error);
            [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_GETSERVICIODETAIL_FAILED object:nil];

    }];
    
    [operation start];
}

-(void)buscarTurnosPara:(Servicio*)servicio paraDia:(NSDate*)dia{
    NSString* url = [NSString stringWithFormat:@"%@", SERVICE_BASE_URL ];
    
    
    NSMutableDictionary *params = [NSMutableDictionary dictionary ];
    NSDateFormatter* df = [[NSDateFormatter alloc]init];
    [df setDateFormat:@"YYYY-MM-dd"];
    
    [params setObject:servicio.ID forKey:@"servicioID"];
    [params setObject: [df stringFromDate:dia ] forKey:@"TurnoFecha"];
    
    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    NSMutableURLRequest *req =  [client requestWithMethod:@"GET" path:@"VerTurnosServicioxDia" parameters:params];
    
    AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:req success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
        
        NSLog(@"%@",JSON);
        NSArray* result  = [NSArray arrayWhitTurnosForm: JSON];//[JSON objectForKey:@"Body" ]];

        [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_TURNOSSERVICIO_OK object:result];
    }
        failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error) {
        NSLog(@"%@",error);
        [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_TURNOSSERVICIO_FAILED object:nil];
                                                                                            
                                                                                        }];
    
    [operation start];

}

@end
