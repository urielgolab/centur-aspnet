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
    [params setObject:@"JSON" forKey:@"format"];
    
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

@end
