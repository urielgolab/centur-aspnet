//
//  SRVProfile.m
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SRVProfile.h"
#import "NSArray+Tools.h"


@implementation SRVProfile

@synthesize currentUser;

CWL_SYNTHESIZE_SINGLETON_FOR_CLASS(SRVProfile);

-(void)loginUserName:(NSString*)usuarioString withPassword:(NSString*)password{
    
    
    NSString* url = [NSString stringWithFormat:@"%@", SERVICE_BASE_URL ];
    
    
    NSMutableDictionary *params = [NSMutableDictionary dictionary ];
    [params setObject:usuarioString forKey:@"nombreUsuario"];
    
    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    NSMutableURLRequest *req =  [client requestWithMethod:@"GET" path:@"DetalleUsuario" parameters:params];
    
    AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:req success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
        
        
        Usuario* usuario = [[Usuario alloc]initWhitDictionary:[JSON objectForKey:@"Body"]];
        if ([[JSON objectForKey:@"Estado"]boolValue] || ![usuario.password isEqualToString:password]) {
            [[NSNotificationCenter defaultCenter]postNotificationName:SERVICE_LOGIN_FAILED object:nil userInfo:nil];
            return;
        }
        
        self.currentUser = usuario;
        
        [[NSNotificationCenter defaultCenter]postNotificationName:SERVICE_LOGIN_OK object:nil userInfo:nil];
        NSLog(@"%@",JSON);
    }
    failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error) {
        NSLog(@"%@",error);
        [[NSNotificationCenter defaultCenter]postNotificationName:SERVICE_LOGIN_FAILED object:nil userInfo:nil];

    }];
    
    [operation start];
}


// RegistrarUsuario(ByVal NombreUsuario As String, ByVal password As String, ByVal telefono As String, ByVal rolUsuario As String, ByVal nombre As String, ByVal apellido As String, ByVal email As String)

-(void)registrarNombreUsuario:(NSString*)nombreUsuario
                     password:(NSString*)password
                     telefono:(NSString*)telefono
                       nombre:(NSString*)nombre
                     apellido:(NSString*)apellido
                        email:(NSString*)email {
    
    NSString* url = [NSString stringWithFormat:@"%@", SERVICE_BASE_URL ];
    
    
    NSMutableDictionary *params = [NSMutableDictionary dictionary ];
    [params setObject:nombreUsuario forKey:@"nombreUsuario"];
    [params setObject:password forKey:@"password"];
    [params setObject:telefono forKey:@"telefono"];
    [params setObject:@"C" forKey:@"rolUsuario"];
    [params setObject:nombre forKey:@"nombre"];
    [params setObject:apellido forKey:@"apellido"];
    [params setObject:email forKey:@"email"];
    [params setObject:@"A" forKey:@"accion"];
    
    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    NSMutableURLRequest *req =  [client requestWithMethod:@"GET" path:@"RegistrarUsuario" parameters:params];
    
    AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:req success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
        
        Usuario* usuario = [[Usuario alloc]initWhitDictionary:[JSON objectForKey:@"Body"]];
        if ([[JSON objectForKey:@"Estado"]boolValue] || ![usuario.password isEqualToString:password]) {
            [[NSNotificationCenter defaultCenter]postNotificationName:SERVICE_SIGN_FAILED object:nil userInfo:nil];
            return;
        }
        
        self.currentUser = usuario;
        [[NSNotificationCenter defaultCenter]postNotificationName:SERVICE_SIGN_OK object:nil userInfo:nil];
        NSLog(@"%@",JSON);
    }
        failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error) {
            NSLog(@"%@",error);
        [[NSNotificationCenter defaultCenter]postNotificationName:SERVICE_SIGN_FAILED object:nil userInfo:nil];
                                                                                            
                                                                                        }];
    
    [operation start];
}

-(void)saveUsuario{
    NSString* url = [NSString stringWithFormat:@"%@", SERVICE_BASE_URL ];
    
    
    NSMutableDictionary *params = [NSMutableDictionary dictionary ];
    
    [params setObject:self.currentUser.usuarioID forKey:@"idUsuario"];
    [params setObject:self.currentUser.nombreUsuario forKey:@"NombreUsuario"];
    [params setObject:self.currentUser.telefono forKey:@"Telefono"];
    [params setObject:self.currentUser.nombre forKey:@"Nombre"];
    [params setObject:self.currentUser.apellido forKey:@"Apellido"];
    [params setObject:self.currentUser.mail forKey:@"Email"];
    [params setObject:@"M" forKey:@"accion"];

    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    NSMutableURLRequest *req =  [client requestWithMethod:@"GET" path:@"RegistrarUsuario" parameters:params];
    
    AFJSONRequestOperation *operation = [AFJSONRequestOperation JSONRequestOperationWithRequest:req success:^(NSURLRequest *request, NSHTTPURLResponse *response, id JSON) {
        if ([[JSON objectForKey:@"Estado"]boolValue]) {
            [[NSNotificationCenter defaultCenter]postNotificationName:SERVice_EDITPROFILE_FAILED object:nil userInfo:nil];
            return;
        }
        
        [[NSNotificationCenter defaultCenter]postNotificationName:SERVice_EDITPROFILE_OK object:nil userInfo:nil];
        NSLog(@"%@",JSON);
    }
                                                                                        failure:^(NSURLRequest *request, NSHTTPURLResponse *response, NSError *error) {
                                                                                            NSLog(@"%@",error);
                                                                                            [[NSNotificationCenter defaultCenter]postNotificationName:SERVice_EDITPROFILE_FAILED object:nil userInfo:nil];
                                                                                            
                                                                                        }];
    
    [operation start];

}

@end
