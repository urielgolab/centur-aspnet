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
//    
//    NSString *pathStr = [[NSBundle mainBundle]bundlePath];
//    NSString *finalPath = [pathStr stringByAppendingPathComponent:@"Zona.plist"];
//    NSDictionary* dict = [NSDictionary dictionaryWithContentsOfFile:finalPath];
//    
//    zonas = [NSArray arrayWhitZonasForm:[dict objectForKey:@"Zonas"]];
//    [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_GETZONAS_OK object:nil];
    
    
    
    NSMutableDictionary *params = [NSMutableDictionary dictionary ];
    //[params setObject:@"JSON" forKey:@"format"];
    [params setObject:@"r" forKey:@"accion"];
    //[params setObject:@1 forKey:@"idZona"];
                                   
    NSString* url = [NSString stringWithFormat:@"%@", SERVICE_BASE_URL ];
    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    NSMutableURLRequest *req =  [client requestWithMethod:@"GET" path:@"BuscarZonas" parameters:params];
    
    AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:req success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
        
        zonas = [NSArray arrayWhitZonasForm:[JSON objectForKey:@"Body"]];
        [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_GETZONAS_OK object:nil];
        NSLog(@"%@",JSON);
        
        
        
    }
    failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error) {
                                                                                            NSLog(@"%@",error);
                                                                                        }];
    
    [operation start];
    
}

-(NSArray*)getAllZonas{
    return [NSArray arrayWithArray:zonas];
}


-(void)searchAllSubZonasFrom:(Zona *)zona{
    NSMutableDictionary *params = [NSMutableDictionary dictionary ];
    //[params setObject:@"JSON" forKey:@"format"];
    [params setObject:@"h" forKey:@"accion"];
    [params setObject:zona.zonaID forKey:@"idZona"];
    
    NSString* url = [NSString stringWithFormat:@"%@", SERVICE_BASE_URL ];
    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    NSMutableURLRequest *req =  [client requestWithMethod:@"GET" path:@"BuscarZonas" parameters:params];
    
    AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:req success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
        
        zona.subZonas = [NSArray arrayWhitZonasForm:[JSON objectForKey:@"Body"]];
        [[NSNotificationCenter defaultCenter] postNotificationName:SERVICE_GETSUBZONAS_OK object:zona];
        NSLog(@"%@",JSON);
        
        
        
    }
                                                                                        failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error) {
                                                                                            NSLog(@"%@",error);
                                                                                        }];
    
    [operation start];    
}

-(NSArray*)getAllSubZonasFrom: (Zona*)zona{
    return zona.subZonas;
}

@end
