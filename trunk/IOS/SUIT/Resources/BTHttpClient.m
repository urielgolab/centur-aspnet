//
//  BTHttpClient.m
//  BatangaV2
//
//  Created by Lucas Emanuel Saavedra on 08/05/12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import "BTHttpClient.h"
#import "AFHTTPClient.h"

@implementation BTHttpClient
static BTHttpClient* mInstance = nil;

+(BTHttpClient*) GetInstance
{
    @synchronized([BTHttpClient class])
    {
        if (mInstance==nil) {
            mInstance = [[self alloc]init];
        }
        return mInstance;
    }
}


- (NSMutableURLRequest *) createRequestWithURL:(NSString*) url andParams:(NSDictionary*)params{
    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    [client setDefaultHeader:@"User-Agent" value:@"iPad"];
    return [client multipartFormRequestWithMethod:@"POST" path:@"" parameters:params constructingBodyWithBlock:nil];
}

- (NSMutableURLRequest *) createRequestWithURL:(NSString*) url andParams:(NSDictionary*)params imageData:(NSData*)imageData {
    AFHTTPClient *client = [[AFHTTPClient alloc] initWithBaseURL:[NSURL URLWithString:url]];
    [client setDefaultHeader:@"User-Agent" value:@"iPad"];
    return [client multipartFormRequestWithMethod:@"POST" path:@"" parameters:params constructingBodyWithBlock:^(id <AFMultipartFormData>formData) {
        [formData appendPartWithFileData:imageData mimeType:@"image/jpeg" name:@"attachment"];
    }
            ];
}



@end
