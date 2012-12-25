//
//  SRVBase.h
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "CWLSynthesizeSingleton.h"
#import "NSArray+Tools.h"
#import "BTHttpClient.h"
#import "AFJSONRequestOperation.h"

#define SERVICE_BASE_URL @"http://centur.ugserver.com.ar/Uriel/CenturServiceREST.svc"

#define SERVICE_GETCATEGORIES_OK @"getcategoriesOK"
#define SERVICE_GETSUBCATEGORIES_OK @"getsubcategoriesOK"

#define SERVICE_GETZONAS_OK @"getzonaOK"
#define SERVICE_GETSUBZONAS_OK @"getsubzonaOK"


#define SERVICE_LOGIN_OK @"loginOk"
#define SERVICE_LOGIN_FAILED @"loginFailed"
 
@interface SRVBase : NSObject


@end
