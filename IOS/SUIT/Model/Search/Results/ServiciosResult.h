//
//  ProvedoresResult.h
//  SUIT
//
//  Created by Manuel Kenar on 31-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>
#import "Servicio.h"

@protocol SearchResult <NSObject>

@end

@interface ServiciosResult : NSObject<SearchResult>{
    NSArray* servicios;
}

@property(nonatomic,retain) NSArray* servicios;

@end
