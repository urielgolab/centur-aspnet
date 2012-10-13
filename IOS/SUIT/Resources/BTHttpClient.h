//
//  BTHttpClient.h
//  BatangaV2
//
//  Created by Lucas Emanuel Saavedra on 08/05/12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface BTHttpClient : NSObject{
}
+(BTHttpClient*) GetInstance;

- (NSMutableURLRequest *) createRequestWithURL:(NSString*) url andParams:(NSDictionary*)params;

- (NSMutableURLRequest *) createRequestWithURL:(NSString*) url andParams:(NSDictionary*)params imageData:(NSData*)imageData ;
@end
