//
//  SearchParametre.h
//  SUIT
//
//  Created by Manuel Kenar on 18-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>

@protocol Searchable <NSObject>

-(NSDictionary*)searchParams;

@end

@interface SearchParametre : NSObject

-(BOOL)canPerformSearch;

@end
