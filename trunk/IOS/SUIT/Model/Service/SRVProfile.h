//
//  SRVProfile.h
//  SUIT
//
//  Created by Manuel Kenar on 01-09-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "SRVBase.h"
#import "Usuario.h"


@interface SRVProfile : SRVBase{
    NSArray* usuarios;
    Usuario* currentUser;
}

@property(nonatomic,retain)Usuario* currentUser;

CWL_DECLARE_SINGLETON_FOR_CLASS(SRVProfile);

-(void)loginUserName:(NSString*)usuario withPassword:(NSString*)password;

@end
