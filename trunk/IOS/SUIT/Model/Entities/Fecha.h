//
//  Fecha.h
//  SUIT
//
//  Created by Manuel Kenar on 25-08-12.
//  Copyright (c) 2012 Casa. All rights reserved.
//

#import <Foundation/Foundation.h>

@interface Fecha : NSObject{
    NSDate* fechaDesde;
    NSDate* fechaHasta;
}

@property(nonatomic,retain) NSDate* fechaDesde;
@property(nonatomic,retain) NSDate* fechaHasta;

@end
