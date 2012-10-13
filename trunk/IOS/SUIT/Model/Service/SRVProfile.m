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
    for (Usuario* usuario in usuarios) {
        if ([usuario.nombre isEqualToString:usuarioString]) {
            self.currentUser= usuario;
            [[NSNotificationCenter defaultCenter]postNotificationName:SERVICE_LOGIN_OK object:nil userInfo:nil];
            return;
        }
    }
    [[NSNotificationCenter defaultCenter]postNotificationName:SERVICE_LOGIN_FAILED object:nil userInfo:nil];
}

-(SRVProfile*)init{
    
    self = [super init];
    
    if (self) {
        NSString *pathStr = [[NSBundle mainBundle]bundlePath];
        NSString *finalPath = [pathStr stringByAppendingPathComponent:@"Usuarios.plist"];
        NSDictionary* dict = [NSDictionary dictionaryWithContentsOfFile:finalPath];
        usuarios = [NSArray arrayWhitUsuariosForm:[dict objectForKey:@"Usuarios"]];
    }
    
    return self;
}

@end
